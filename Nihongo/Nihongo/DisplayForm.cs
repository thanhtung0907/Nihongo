using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
namespace Nihongo
{
    public partial class DisplayForm : Form
    {
        private List<(Infor, int)> Values_LoadDefault { get; set; }

        private List<(Infor, int)> Values_Display { get; set; }

        int CurrentIndex { get; set; }

        private Timer aTimer { get; set; }
        Infor CurrentInfor { get; set; }

        public DisplayForm()
        {
            InitializeComponent();
        }

        void resetTimer()
        {
            if (aTimer != null)
            {
                CurrentIndex = 0;
                aTimer.Stop();
                aTimer.Dispose();
                aTimer = null;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            loadCombobox();
            CurrentIndex = 0;
            radioButton_kanji.Checked = true;
            check();
            setFontSize();
        }

        void loadCombobox()
        {
            var seconds = new[] { 1, 2, 3, 4, 5 };
            foreach (var s in seconds) {
                comboBox_second.Items.Add(s);
            }
            comboBox_second.SelectedIndex = 1;

            var fontSize = new[] {32F, 36F, 48F , 72F, 100F };
            foreach (var s in fontSize) {
                comboBox_fontsize.Items.Add(s);
            }
            comboBox_fontsize.SelectedIndex = comboBox_fontsize.FindString("36");

            var learn = new[] { "All", "Had" , "Not Yet" };
            foreach (var s in learn)
            {
                comboBox_learn.Items.Add(s);
            }
            comboBox_learn.SelectedIndex = 0;
        }

        void setFontSize()
        {
            var fontSize = Single.Parse(comboBox_fontsize.Text);
            button1.Font = new Font("MS UI Gothic", fontSize, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)));
        }

        bool GetValueRandom()
        {
            var infor  = GetListInforsToDisplay();
            if (!infor.Any())
            {
                MessageBox.Show("no data");
                comboBox_learn.SelectedIndex = 0;
                return false;
            } 
            var res = new List<(Infor, int)>();
            while (true)
            {
                var random_txt = GetRandom(infor);
                if (res.Contains(random_txt))
                    continue;
                res.Add(random_txt);
                if (res.Count == infor.Count)
                    break;
            }
            Values_Display = res.ToList();
            Values_Display.ForEach(x => x.Item1.SetPostion(GetPosition()));
            return true;
        }

        void check()
        {
            var bCheck = File.Exists(textBox_path.Text);
            button1.Enabled = bCheck;
            button_auto.Enabled = bCheck;
            button_next.Enabled = bCheck;
            button2.Enabled = bCheck;
            button_reset.Enabled = bCheck;
            checkBox_have_learned.Enabled = bCheck;
            button_update.Enabled = bCheck;
            button_mean1.Enabled = bCheck;
            button_mean2.Enabled = bCheck;
        }

        static Random random = new Random();

        (Infor,int) GetRandom(List<(Infor,int)> infors)
        {
            var count = infors.Count;
            var index = random.Next(count);
            return (infors[index].Item1, infors[index].Item2);
        }

        Position GetPosition()
        {
            return radioButton_hiragana.Checked ? Position.Hiragana :
                   radioButton_kanji.Checked ? Position.Kanji : Position.Mean;

        }

        void ChangePositon(Infor infor)
        {
            if(infor.Position.IsKanji())
            {
                infor.SetPostion(radioButton_mean.Checked? Position.Mean : Position.Hiragana);
            }
            else if (infor.Position.IsHiragana())
            {
                infor.SetPostion(radioButton_mean.Checked ? Position.Mean : Position.Kanji);
            } 
            else 
            {
                infor.SetPostion(Position.Kanji);
            }
        }

        List<Infor> GetInfors(string path)
        {
            if (!File.Exists(path))
                return null;
            Infor CreateInfor(string[] strs)
            {
                var learned = strs.Count() > 3 && strs[3].Trim().Equals("X");
                return new Infor(strs[0], strs[1], strs[2], learned, GetPosition());
            }

            return File.ReadAllLines(path, Encoding.UTF8)
                .Select(s => s.Split(',')).Where(x => x.Count() > 2)
                .Select(x => CreateInfor(x))
                .Where(x => !string.IsNullOrEmpty(x.Kanji))
                .ToList();
        }


        void setDisplayValue(Infor infor)
        {
            switch (infor.Position)
            {
                case Position.Kanji: 
                    button1.Text = infor.Kanji; return;
                case Position.Hiragana:
                    button1.Text = !string.IsNullOrEmpty(infor.Hiragana) ? infor.Hiragana : infor.Kanji; return;
                case Position.Mean:
                    button1.Text = infor.VietNamese; return;
            }
        }

        List<(Infor,int)> ValuesLearn(bool haveLearned)
        {
            var res = new List<(Infor, int)>();
            for (int i = 0; i < Values_LoadDefault.Count; i++)
            {
                var infor = Values_LoadDefault[i];
                if (haveLearned == infor.Item1.HaveLearned)
                    res.Add((infor.Item1.Clone(), infor.Item2));
            }
            return res;
        }
        
        bool UpdateValue()
        {
            if (!GetValueRandom())
                return false;
            CurrentIndex = 0;
            SetValueDisplay();
            checkBox_have_learned.Checked = Values_Display.First().Item1.HaveLearned;
            check();
            setNum();
            return true;
        }

        void setNum()
        {
            if(aTimer is null)
                label_num.Text = $"{CurrentIndex + 1} / {Values_Display.Count}";
            else
                label_num.Text = $"{Values_Display.Count}";
        }

        private void aTimer_Tick(object sender, EventArgs e)
        {
            if (aTimer != null && Values_Display != null)
            {
                var infor = GetRandom(Values_Display).Item1;
                CurrentInfor = infor;
                setDisplayValue(infor);
                checkBox_have_learned.Checked = infor.HaveLearned;
                setNum();
            }
        }

        void changeTime()
        {
            var time = comboBox_second.Text.ToDouble();
            if (aTimer != null && time > 0)
                aTimer.Interval = (int)(time * 1000);
        }

        List<(Infor, int)> GetListInforsToDisplay()
        {
            var txt = comboBox_learn.Text;
            if (txt == "All"){
                return Values_LoadDefault.ToList();
            } else if (txt == "Had") {
                return ValuesLearn(true);
            } else {
                return ValuesLearn(false);
            }
        }

        void SetValueDisplay()
        {
            CurrentInfor = Values_Display[CurrentIndex].Item1.Clone();
            var positon = GetPosition();
            CurrentInfor.SetPostion(positon);
            setDisplayValue(CurrentInfor);
            checkBox_have_learned.Checked = CurrentInfor.HaveLearned;
            setNum();
        }

        void UpdateInfors()
        {
            for (int i = 0; i <Values_Display.Count; i++)
            {
                var (infor, index) = Values_Display[i];
                Values_LoadDefault[index] = (infor,index);
            }
        }

        void WriteFile()
        {
            var strs = Values_LoadDefault.Select(x => x.Item1.GetStringOneLine());
            FileCommon.WriteFile(textBox_path.Text, strs);
        }

        //event---------------------------------------

        private void button_auto_Click(object sender, EventArgs e)
        {
            if(aTimer != null){
                return;
            }

            var time = comboBox_second.Text.ToDouble();
            if (time > 0)
            {
                aTimer = new Timer();
                aTimer.Interval = (int)(time * 1000);
                aTimer.Tick += new EventHandler(aTimer_Tick);
                aTimer.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setNum();
            ChangePositon(CurrentInfor);
            setDisplayValue(CurrentInfor);
        }

        private void button_path_Click(object sender, EventArgs e)
        {
            var path = PathCommon.getPath();
            var infors = GetInfors(path);
            if (infors is null) {
                return;
            }
            Values_LoadDefault = new List<(Infor, int)>();
            for (int i = 0; i < infors.Count; i++) {
                Values_LoadDefault.Add((infors[i], i));
            }
            if (!Values_LoadDefault.Any())
                return;
            resetTimer();
            textBox_path.Text = path;
            if (!UpdateValue())
                return;
        }
        private void comboBox_second_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTime();
        }

        private void comboBox_second_KeyDown(object sender, KeyEventArgs e)
        {
            changeTime();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            resetTimer();
            if (CurrentIndex < Values_Display.Count-1)
                CurrentIndex++;
            SetValueDisplay();
        }

        private void button_before_Click(object sender, EventArgs e)
        {
            resetTimer();
            if (CurrentIndex > 0)
                CurrentIndex--;
            SetValueDisplay();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            CurrentIndex = 0;
            resetTimer();
            if (!GetValueRandom())
                return;
            SetValueDisplay();
        }

        void changeRadioButton()
        {
            if (Values_Display is null)
                return;
            var positon = GetPosition();
            CurrentInfor.SetPostion(positon);
            Values_Display.ForEach(x => x.Item1.SetPostion(positon));
            setDisplayValue(CurrentInfor);
        }

        private void radioButton_hiragana_CheckedChanged(object sender, EventArgs e)
        {
            changeRadioButton();
        }

        private void radioButton_kanji_CheckedChanged(object sender, EventArgs e)
        {
            changeRadioButton();
        }

        private void comboBox_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFontSize();
        }

        private void checkBox_have_learned_CheckedChanged(object sender, EventArgs e)
        {
            Values_Display[CurrentIndex].Item1.SetHaveLearned(checkBox_have_learned.Checked);
        }

        private void comboBox_learn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Values_Display is null)
                return;
            UpdateValue();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if(aTimer is null)
            {
                UpdateInfors();
                WriteFile();
            }
        }

        void SetDisplayClickMean()
        {
            if(!CurrentInfor.Position.IsMean()){
                CurrentInfor.SetPostion(Position.Mean);
            }
            else{
                if(radioButton_kanji.Checked)
                    CurrentInfor.SetPostion(Position.Kanji);
                else if (radioButton_hiragana.Checked)
                    CurrentInfor.SetPostion(Position.Hiragana);
            }
            setDisplayValue(CurrentInfor);
        }
        private void button_mean2_Click(object sender, EventArgs e)
        {
            SetDisplayClickMean();
        }

        private void button_mean1_Click(object sender, EventArgs e)
        {
            SetDisplayClickMean();
        }
    }
}
