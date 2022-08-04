using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nihongo
{
    internal class Infor
    {
        internal string Kanji { get; private set; }
        internal string Hiragana { get; private set; }
        internal string VietNamese { get; private set; }
        internal bool HaveLearned { get; private set; }

        internal Infor(string kanji, string Hiragana, string vietNamese, bool haveLearned)
        {
            this.Kanji = kanji.Trim();
            this.Hiragana = Hiragana.Trim();
            this.VietNamese = vietNamese.Trim();
            this.HaveLearned = haveLearned;
        }

        internal void SetHaveLearned(bool f) => HaveLearned = f;

        internal string GetStringOneLine()
        {
            string learned() => HaveLearned ? "X" : "";
            return $"{ Kanji}, {Hiragana},{VietNamese},{learned()}";
        }
    }

    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DisplayForm());
        }
    }
}
