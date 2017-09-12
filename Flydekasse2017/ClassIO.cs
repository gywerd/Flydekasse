using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Flydekasse2017
{
    class ClassIO
    {
        private string strDocPathLoad = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MaterialData.data";

        public ClassIO()
        {

        }


        //Method to read material data from file
        protected List<string> ReadListOfStringFromFile()
        {
            List<string> listRes = new List<string>();

            try
            {
                string strLine;

                StreamReader file = new StreamReader(strDocPathLoad);

                while ((strLine = file.ReadLine()) != null)
                {
                    listRes.Add(strLine);
                }

                file.Close();
            }
            catch
            {

            }

            return listRes;
        }

        //Method to write report to file - opens the report afterwards
        protected void WriteListOfStringToFileReport(List<string> ListLine)
        {
            string strDocPathSave = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\FlydeKasse_Rapport_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".txt";

            using (StreamWriter outputFile = new StreamWriter(strDocPathSave))
            {
                foreach (string line in ListLine)
                {
                    outputFile.WriteLine(line);
                }
            }
            OpenFile(strDocPathSave);
        }

        //Method to at write material data to file
        protected void WriteListOfStringToFileMaterialData(List<string> ListLine)
        {

            using (StreamWriter outputFile = new StreamWriter(strDocPathLoad))
            {
                foreach (string line in ListLine)
                {
                    outputFile.WriteLine(line);
                }
            }
        }

        //Method, that open a file in system specific application
        private void OpenFile(string strPath)
        {
            System.Diagnostics.Process.Start(strPath);
        }
    }
}
