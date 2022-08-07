using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace Nihongo
{
    internal static class PathCommon
    {
        internal static string getPath()
        {
            using (var dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK){
                    return dlg.FileName;
                } else {
                    return null;
                }
            }
        }
    }

    internal static class FileCommon
    {
        internal static void WriteFile(string path, IEnumerable<string> strs)
        {
            if (!File.Exists(path))
                return;
            File.WriteAllLines(path, strs, Encoding.UTF8);
        }
    }

    internal static class ValueExt
    {
        internal static double? ToDouble(this string s)
        {
            var res = 0.0;
            return Double.TryParse(s, out res) ? res : (double?)null;
        }
    }
}
