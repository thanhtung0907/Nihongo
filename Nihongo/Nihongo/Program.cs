using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nihongo
{
    public enum Position
    {
        Kanji,
        Hiragana,
        Mean,
        Struct,
    }

    public static class PositonExt
    {
        public static bool IsKanji(this Position position) => position == Position.Kanji;
        public static bool IsHiragana(this Position position) => position == Position.Hiragana;
        public static bool IsMean(this Position position) => position == Position.Mean;
        public static bool IsStruct(this Position position) => position == Position.Struct;

    }

    internal class Infor
    {
        internal string Kanji { get; private set; }
        internal string Hiragana { get; private set; }
        internal string VietNamese { get; private set; }
        internal string StructGrammar { get; private set; }

        internal bool HaveLearned { get; private set; }
        internal Position Position { get; private set; }

        internal Infor(string hiragana, string kanji, string vietNamese, bool haveLearned, Position position, string strStruct = null)
        {
            this.Kanji = kanji.Trim();
            this.Hiragana = hiragana.Trim();
            this.VietNamese = vietNamese.Trim();
            this.HaveLearned = haveLearned;
            this.Position = position;
            this.StructGrammar = strStruct?.Trim();
        }

        internal void SetHaveLearned(bool f) => HaveLearned = f;

        internal string GetStringOneLine()
        {
            string learned() => HaveLearned ? "X" : "";
            if (StructGrammar is null) {
                return $"{ Hiragana}, {Kanji},{VietNamese},{learned()}";
            } else {
                return $"{ Hiragana}, {Kanji},{VietNamese},{StructGrammar},{learned()}";
            }
        }

        internal Infor Clone()
        {
            return new Infor(this.Hiragana, this.Kanji, this.VietNamese, this.HaveLearned, this.Position, this.StructGrammar);
        }

        internal void SetPostion(Position position)
        {
            this.Position = position;
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
