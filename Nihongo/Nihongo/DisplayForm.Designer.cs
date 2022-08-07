
namespace Nihongo
{
    partial class DisplayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button_path = new System.Windows.Forms.Button();
            this.button_auto = new System.Windows.Forms.Button();
            this.comboBox_second = new System.Windows.Forms.ComboBox();
            this.button_next = new System.Windows.Forms.Button();
            this.radioButton_kanji = new System.Windows.Forms.RadioButton();
            this.radioButton_mean = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.radioButton_hiragana = new System.Windows.Forms.RadioButton();
            this.label_num = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_fontsize = new System.Windows.Forms.ComboBox();
            this.checkBox_have_learned = new System.Windows.Forms.CheckBox();
            this.comboBox_learn = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_update = new System.Windows.Forms.Button();
            this.button_mean2 = new System.Windows.Forms.Button();
            this.button_mean1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(92, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(426, 173);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_path
            // 
            this.button_path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_path.Location = new System.Drawing.Point(537, 12);
            this.button_path.Name = "button_path";
            this.button_path.Size = new System.Drawing.Size(61, 23);
            this.button_path.TabIndex = 3;
            this.button_path.Text = "...";
            this.button_path.UseVisualStyleBackColor = true;
            this.button_path.Click += new System.EventHandler(this.button_path_Click);
            // 
            // button_auto
            // 
            this.button_auto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_auto.Location = new System.Drawing.Point(12, 265);
            this.button_auto.Name = "button_auto";
            this.button_auto.Size = new System.Drawing.Size(74, 23);
            this.button_auto.TabIndex = 14;
            this.button_auto.Text = "自動";
            this.button_auto.UseVisualStyleBackColor = true;
            this.button_auto.Click += new System.EventHandler(this.button_auto_Click);
            // 
            // comboBox_second
            // 
            this.comboBox_second.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_second.FormattingEnabled = true;
            this.comboBox_second.Location = new System.Drawing.Point(98, 266);
            this.comboBox_second.Name = "comboBox_second";
            this.comboBox_second.Size = new System.Drawing.Size(46, 20);
            this.comboBox_second.TabIndex = 15;
            this.comboBox_second.SelectedIndexChanged += new System.EventHandler(this.comboBox_second_SelectedIndexChanged);
            this.comboBox_second.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_second_KeyDown);
            // 
            // button_next
            // 
            this.button_next.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_next.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_next.Location = new System.Drawing.Point(524, 78);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(74, 132);
            this.button_next.TabIndex = 12;
            this.button_next.Text = ">>";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // radioButton_kanji
            // 
            this.radioButton_kanji.AutoSize = true;
            this.radioButton_kanji.Location = new System.Drawing.Point(233, 52);
            this.radioButton_kanji.Name = "radioButton_kanji";
            this.radioButton_kanji.Size = new System.Drawing.Size(48, 16);
            this.radioButton_kanji.TabIndex = 6;
            this.radioButton_kanji.TabStop = true;
            this.radioButton_kanji.Text = "Kanji";
            this.radioButton_kanji.UseVisualStyleBackColor = true;
            this.radioButton_kanji.CheckedChanged += new System.EventHandler(this.radioButton_hiragana_CheckedChanged);
            // 
            // radioButton_mean
            // 
            this.radioButton_mean.AutoSize = true;
            this.radioButton_mean.Location = new System.Drawing.Point(288, 52);
            this.radioButton_mean.Name = "radioButton_mean";
            this.radioButton_mean.Size = new System.Drawing.Size(50, 16);
            this.radioButton_mean.TabIndex = 7;
            this.radioButton_mean.TabStop = true;
            this.radioButton_mean.Text = "Mean";
            this.radioButton_mean.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(12, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 132);
            this.button2.TabIndex = 10;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_before_Click);
            // 
            // button_reset
            // 
            this.button_reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_reset.Location = new System.Drawing.Point(160, 265);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(66, 23);
            this.button_reset.TabIndex = 16;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path:";
            // 
            // textBox_path
            // 
            this.textBox_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_path.Enabled = false;
            this.textBox_path.Location = new System.Drawing.Point(48, 14);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(470, 19);
            this.textBox_path.TabIndex = 2;
            // 
            // radioButton_hiragana
            // 
            this.radioButton_hiragana.AutoSize = true;
            this.radioButton_hiragana.Location = new System.Drawing.Point(159, 52);
            this.radioButton_hiragana.Name = "radioButton_hiragana";
            this.radioButton_hiragana.Size = new System.Drawing.Size(68, 16);
            this.radioButton_hiragana.TabIndex = 5;
            this.radioButton_hiragana.TabStop = true;
            this.radioButton_hiragana.Text = "Hiragana";
            this.radioButton_hiragana.UseVisualStyleBackColor = true;
            this.radioButton_hiragana.CheckedChanged += new System.EventHandler(this.radioButton_kanji_CheckedChanged);
            // 
            // label_num
            // 
            this.label_num.AutoSize = true;
            this.label_num.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_num.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_num.Location = new System.Drawing.Point(98, 84);
            this.label_num.Name = "label_num";
            this.label_num.Size = new System.Drawing.Size(42, 16);
            this.label_num.TabIndex = 15;
            this.label_num.Text = "0 / 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "Font Size";
            // 
            // comboBox_fontsize
            // 
            this.comboBox_fontsize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_fontsize.FormattingEnabled = true;
            this.comboBox_fontsize.Location = new System.Drawing.Point(92, 50);
            this.comboBox_fontsize.Name = "comboBox_fontsize";
            this.comboBox_fontsize.Size = new System.Drawing.Size(48, 20);
            this.comboBox_fontsize.TabIndex = 4;
            this.comboBox_fontsize.SelectedIndexChanged += new System.EventHandler(this.comboBox_fontsize_SelectedIndexChanged);
            // 
            // checkBox_have_learned
            // 
            this.checkBox_have_learned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_have_learned.AutoSize = true;
            this.checkBox_have_learned.Location = new System.Drawing.Point(504, 51);
            this.checkBox_have_learned.Name = "checkBox_have_learned";
            this.checkBox_have_learned.Size = new System.Drawing.Size(94, 16);
            this.checkBox_have_learned.TabIndex = 8;
            this.checkBox_have_learned.Text = "Have Learned";
            this.checkBox_have_learned.UseVisualStyleBackColor = true;
            this.checkBox_have_learned.CheckedChanged += new System.EventHandler(this.checkBox_have_learned_CheckedChanged);
            // 
            // comboBox_learn
            // 
            this.comboBox_learn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_learn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_learn.FormattingEnabled = true;
            this.comboBox_learn.Location = new System.Drawing.Point(288, 266);
            this.comboBox_learn.Name = "comboBox_learn";
            this.comboBox_learn.Size = new System.Drawing.Size(97, 20);
            this.comboBox_learn.TabIndex = 17;
            this.comboBox_learn.SelectedIndexChanged += new System.EventHandler(this.comboBox_learn_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "Learn";
            // 
            // button_update
            // 
            this.button_update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_update.Location = new System.Drawing.Point(406, 266);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(66, 23);
            this.button_update.TabIndex = 18;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_mean2
            // 
            this.button_mean2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_mean2.Location = new System.Drawing.Point(524, 209);
            this.button_mean2.Name = "button_mean2";
            this.button_mean2.Size = new System.Drawing.Size(74, 41);
            this.button_mean2.TabIndex = 13;
            this.button_mean2.Text = "Mean";
            this.button_mean2.UseVisualStyleBackColor = true;
            this.button_mean2.Click += new System.EventHandler(this.button_mean2_Click);
            // 
            // button_mean1
            // 
            this.button_mean1.Location = new System.Drawing.Point(12, 78);
            this.button_mean1.Name = "button_mean1";
            this.button_mean1.Size = new System.Drawing.Size(74, 41);
            this.button_mean1.TabIndex = 9;
            this.button_mean1.Text = "Mean";
            this.button_mean1.UseVisualStyleBackColor = true;
            this.button_mean1.Click += new System.EventHandler(this.button_mean1_Click);
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(610, 300);
            this.Controls.Add(this.button_mean1);
            this.Controls.Add(this.button_mean2);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_learn);
            this.Controls.Add(this.checkBox_have_learned);
            this.Controls.Add(this.comboBox_fontsize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_num);
            this.Controls.Add(this.radioButton_hiragana);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radioButton_mean);
            this.Controls.Add(this.radioButton_kanji);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.comboBox_second);
            this.Controls.Add(this.button_auto);
            this.Controls.Add(this.button_path);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(626, 250);
            this.Name = "DisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日本語";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_path;
        private System.Windows.Forms.Button button_auto;
        private System.Windows.Forms.ComboBox comboBox_second;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.RadioButton radioButton_kanji;
        private System.Windows.Forms.RadioButton radioButton_mean;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.RadioButton radioButton_hiragana;
        private System.Windows.Forms.Label label_num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_fontsize;
        private System.Windows.Forms.CheckBox checkBox_have_learned;
        private System.Windows.Forms.ComboBox comboBox_learn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_mean2;
        private System.Windows.Forms.Button button_mean1;
    }
}