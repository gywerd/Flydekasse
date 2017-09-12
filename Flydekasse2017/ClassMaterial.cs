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
    public class ClassMaterial : INotifyPropertyChanged
    {
        //Declaration of public data types
        private string _strMaterialName;
        private string _strMaterialWeight;
        private string _strMaterialThickness;

        /// <summary>
        /// Eventhandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        //Declaration of the material class
        public ClassMaterial()
        {

        }

        //entity of field
        public string strMaterialName
        {
            get
            {
                return _strMaterialName;
            }
            set
            {
                if (value != _strMaterialName)
                {
                    _strMaterialName = value;
                    Notify("strMaterialName");
                }
            }
        }

        //entity of field
        public string strMaterialWeight
        {
            get
            {
                return _strMaterialWeight;
            }
            set
            {
                if (value != _strMaterialWeight)
                {
                    _strMaterialWeight = value;
                    Notify("strMaterialWeight");
                }
            }
        }

        //entity of field
        public string strMaterialThickness
        {
            get
            {
                return _strMaterialThickness;
            }
            set
            {
                if (value != _strMaterialThickness)
                {
                    _strMaterialThickness = value;
                    Notify("strMaterialThickness");
                }
            }
        }

        //Method, that notify about changed properties
        private void Notify(string v)
        {
            {
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(v));
                }
            }
        }

        //Method, that generates MaterialData
        public ClassMaterial(ClassMaterial cm)
        {
            if(cm != null)
            {
                strMaterialName = cm.strMaterialName;
                strMaterialWeight = cm.strMaterialWeight;
            }
        }

        //Method, thad generates ChosenMaterialData 
        public ClassMaterial(ClassMaterial cm, string strThickness)
        {
            if (cm != null)
            {
                strMaterialName = cm.strMaterialName;
                strMaterialWeight = cm.strMaterialWeight;
                strMaterialThickness = cm.strMaterialThickness;
            }
        }

        public void ClearAllData()
        {
            this.strMaterialName = "";
            this.strMaterialWeight = "";
        }

        /// <summary>
        /// Method, that refreshes data
        /// </summary>
        /// <param name="cm">An instance of ClassMaterial</param>
        /// <summary>
        public void RefreshData(ClassMaterial cm)
        {
            this.strMaterialName = cm.strMaterialName;
            this.strMaterialWeight = cm.strMaterialWeight;
        }
    }
}

