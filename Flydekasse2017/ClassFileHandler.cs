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
    class ClassFileHandler : ClassIO
    {
        public ClassFileHandler()
        {

        }

        //Method, that saves report to txt file
        public void SaveDataReport(List<string> listData)
        {
            WriteListOfStringToFileReport(listData);
        }

        //Method, that saves material data to data file
        public void SaveDataMaterialData(List<string> listData)
        {
            WriteListOfStringToFileMaterialData(listData);
        }

        //Method, that loads material data from datafile
        public List<string> GetData()
        {
            return ReadListOfStringFromFile();
        }
    }
}
