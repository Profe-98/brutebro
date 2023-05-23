using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bruteBro.Dialog.Secondary
{
    public static class FileManager
    {
        public static List<string> OpenFiles()
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.AddExtension = true;
                fileDialog.Multiselect = true;
                DialogResult dr = fileDialog.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    return ExtractFileData(fileDialog).ToList();
                }
                return null;

            }

        }

        public static string[] ExtractFileData(OpenFileDialog dialog)
        {
            string[] files = dialog.FileNames;
            foreach ( string file in files)
            {
                using(StreamReader sr = File.OpenText(file))
                {
                    string data = sr.ReadToEnd();
                    ObjectManager.Filedatapairs.Add(file, data);
                }
            }
            return dialog.SafeFileNames;
        }


    }
}
