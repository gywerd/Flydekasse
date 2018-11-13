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
        #region Fields
        private string _strMaterialName;
        private string _strMaterialWeight;
        private string _strMaterialThickness;

        #endregion

        #region Constructors
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public ClassMaterial()
        {

        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties
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

        #endregion

        #region Methods
        /// <summary>
        /// Method, that notify about changed properties
        /// </summary>
        /// <param name="v">string</param>
        private void Notify(string v)
        {
            {
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(v));
                }
            }
        }

        /// <summary>
        /// Method, that generates MaterialData
        /// </summary>
        /// <param name="cm">ClassMaterial</param>
        public ClassMaterial(ClassMaterial cm)
        {
            if(cm != null)
            {
                strMaterialName = cm.strMaterialName;
                strMaterialWeight = cm.strMaterialWeight;
            }
        }

        /// <summary>
        /// Method, thad generates ChosenMaterialData
        /// </summary>
        /// <param name="cm">ClassMaterial</param>
        /// <param name="strThickness">string</param>
        public ClassMaterial(ClassMaterial cm, string strThickness)
        {
            if (cm != null)
            {
                strMaterialName = cm.strMaterialName;
                strMaterialWeight = cm.strMaterialWeight;
                strMaterialThickness = cm.strMaterialThickness;
            }
        }

        /// <summary>
        /// Method, that clears data in Fields
        /// </summary>
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

        #endregion
    }
}

