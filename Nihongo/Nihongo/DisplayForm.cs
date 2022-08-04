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
        List<Infor> Values_LoadDefault { get; set; }

        List<(Infor, int)> Values_Display { get; set; }

        List<(Infor,int)> ValueRandoms { get; set; }

        int CurrentIndex = 0;

        private System.Windows.Forms.Timer aTimer { get; set; }

        public DisplayForm()
        {
            InitializeComponent();
        }

        void resetTimer()
        {
            if (aTimer != null)
            {
                aTimer.Stop();
                aTimer = null;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            loadCombobox();
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

            var fontSize = new[] {20F, 24F, 28F, 32F, 36F, 48F , 72F, 100F };
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
            var res = new List<(Infor,int)>();
            while (true)
            {
                var random_txt = GetRandom(Values_LoadDefault);
                if (res.Contains(random_txt))
                    continue;
                res.Add(random_txt);
                if (res.Count == Values_LoadDefault.Count)
                    break;
            }
            ValueRandoms = res;
            Values_Display = GetListInforsToDisplay();
            return Values_Display.Any();
        }

        void check()
        {
            var bCheck = File.Exists(textBox_path.Text);
            button1.Enabled = bCheck;
            button_auto.Enabled = bCheck;
            button_next.Enabled = bCheck;
            button2.Enabled = bCheck;
            button_reset.Enabled = bCheck;
        }

        static Random random = new Random();

        (Infor,int) GetRandom(List<Infor> infors)
        {
            var count = infors.Count;
            var index = random.Next(count);
            return (infors[index], index);
        }

        string getDisplayValue(Infor infor)
        {
            return radioButton_kanji.Checked ? infor.Kanji :
                   radioButton_hiragana.Checked
                   ? (string.IsNullOrEmpty(infor.Hiragana) ? infor.Kanji :  infor.Hiragana) 
                   : infor.VietNamese;
        }

        bool IsChange = false;

        Infor infor() => Values_Display[CurrentIndex].Item1;

        private void button1_Click(object sender, EventArgs e)
        {
            resetTimer();
            setNum();

            if (!IsChange)
            {
                button1.Text = radioButton_kanji.Checked 
                       ? (string.IsNullOrEmpty(infor().Hiragana) ? infor().Kanji : infor().Hiragana)
                       : infor().Kanji;
                IsChange = true;
            } else {
                button1.Text = getDisplayValue(infor());
                IsChange = false;
            }
        }

        List<(Infor,int)> ValuesLearn(bool haveLearned)
        {
            var res = new List<(Infor, int)>();
            for (int i = 0; i < ValueRandoms.Count; i++)
            {
                var infor = ValueRandoms[i];
                if (haveLearned == infor.Item1.HaveLearned)
                    res.Add(infor);
            }
            return res;
        }
        
        private void button_path_Click(object sender, EventArgs e)
        {
            resetTimer();
            var path = PathCommon.getPath();
            Values_LoadDefault = FileCommon.ReadFile(path);
            if (Values_LoadDefault is null || !Values_LoadDefault.Any())
                return;
            CurrentIndex = 0;
            textBox_path.Text = path;
            if (!GetValueRandom()) 
                return;
            
            button1.Text = getDisplayValue(Values_Display.First().Item1);
            checkBox_have_learned.Checked = Values_Display.First().Item1.HaveLearned;
            check();
            setNum();
        }


        private void button_auto_Click(object sender, EventArgs e)
        {
            var time = comboBox_second.Text.ToDouble();
            if (time > 0)
            {
                aTimer = new System.Windows.Forms.Timer();
                aTimer.Tick += new EventHandler(aTimer_Tick);
                aTimer.Interval = (int)(time * 1000);
                aTimer.Start();
                label_num.Text = "";
            }
        }

        void setNum()
        {
            label_num.Text = $"{CurrentIndex + 1} / {Values_Display.Count}";
        }

        List<Infor> Infors => Values_Display.Select(x => x.Item1).ToList();
        private void aTimer_Tick(object sender, EventArgs e)
        {
            if (aTimer != null && Values_Display != null)
                button1.Text = getDisplayValue(GetRandom(Infors).Item1);
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
            if (txt == "All")
            {
                return ValueRandoms;
            }
            else if (txt == "Had")
            {
                return ValuesLearn(true);
            }
            else
            {
                return ValuesLearn(false);
            }
        }

        void SetValueDisplay()
        {
            button1.Text = getDisplayValue(infor());
            checkBox_have_learned.Checked = infor().HaveLearned;
            setNum();
        }

        void UpdateInfors()
        {
            for (int i = 0; i <Values_Display.Count; i++)
            {
                var (infor, index) = Values_Display[i];
                Values_LoadDefault[index] = infor;
            }
        }

        void WriteFile()
        {
            var strs = Values_LoadDefault.Select(x => x.GetStringOneLine());
            FileCommon.WriteFile(textBox_path.Text, strs);
        }


        //event---------------------------------------
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
            resetTimer();
            CurrentIndex = 0;
            if (!GetValueRandom())
                return;
            SetValueDisplay();
        }

        private void radioButton_hiragana_CheckedChanged(object sender, EventArgs e)
        {
            if (Values_Display is null)
                return;
            button1.Text = getDisplayValue(infor());
        }

        private void radioButton_kanji_CheckedChanged(object sender, EventArgs e)
        {
            if (Values_Display is null)
                return;
            button1.Text = getDisplayValue(infor());
        }

        private void comboBox_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFontSize();
        }

        private void checkBox_have_learned_CheckedChanged(object sender, EventArgs e)
        {
            Values_Display[CurrentIndex].Item1.SetHaveLearned(checkBox_have_learned.Checked);
        }

        private void DisplayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Values_Display is null)
                return;
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            UpdateInfors();
            WriteFile();
        }
    }
}
