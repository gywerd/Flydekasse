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
using AspITDBClassLibrary;

namespace Flydekasse2017
{
    class ClassFlydekasseBizz : INotifyPropertyChanged
    {
        #region Fields
        public string strMaterialDataSource = @"FILE";
        public static string myServerAddress = @"CV-BB-5478\SQLEKSPRESS";
        public static string myDatabase = @"Test22";
        public static string strCon = @"Server=" + myServerAddress + @";Database=" + @";Trusted_Connection=True";

        public ClassMaterial CM = new ClassMaterial();
        public ClassBox CB = new ClassBox();
        public Class_YourProjectname CYP = new Class_YourProjectname(strCon);
        public DbConn DBC = new DbConn();
        public ClassFileHandler CFH = new ClassFileHandler();

        ObservableCollection<ClassBox> boxData = new ObservableCollection<ClassBox>();
        ObservableCollection<ClassMaterial> materialData = new ObservableCollection<ClassMaterial>();
        ObservableCollection<ClassMaterial> chosenMaterialData = new ObservableCollection<ClassMaterial>();
        #endregion

        #region Constructors
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public ClassFlydekasseBizz()
        {

        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties
        public ObservableCollection<ClassBox> BoxData
        {
            get
            {
                return boxData;
            }
        }


        public ObservableCollection<ClassMaterial> MaterialData
        {
            get
            {
                if (materialData.Count <= 0)
                {
                    MaterialDataLoad();
                }
                return materialData;
            }
        }

        public ObservableCollection<ClassMaterial> ChosenMaterialData
        {
            get
            {
                return chosenMaterialData;
            }
        }


        #endregion

        #region Methods
        /// <summary>
        /// Method, that load material data from file
        /// </summary>
        public void MaterialDataLoad()
        {
            if (strMaterialDataSource == "FILE")
            {
                List<string> listLoadData = CFH.GetData();
                foreach (string data in listLoadData)
                {
                    if (data.Contains(";"))
                    {
                        string[] strArray = data.Split(';');

                        ClassMaterial myCM = new ClassMaterial();

                        myCM.strMaterialName = strArray[0];
                        myCM.strMaterialWeight = strArray[1];

                        materialData.Add(myCM);
                    }
                }
            }
            else
            {
                List<string> listLoadData = CYP.ReadListFromDataBase();
                foreach (string data in listLoadData)
                {
                    if (data.Contains(";"))
                    {
                        string[] strArray = data.Split(';');

                        ClassMaterial myCM = new ClassMaterial();

                        myCM.strMaterialName = strArray[0];
                        myCM.strMaterialWeight = strArray[1];

                        materialData.Add(myCM);
                    }
                }

            }
        }

        /// <summary>
        /// Method, that clears Material Data Collection
        /// </summary>
        public void ClearMaterialData()
        {
            materialData.Clear();
            MaterialDataLoad();
        }

        /// <summary>
        /// Method, that resets program
        /// </summary>
        public void ClearAll()
        {
            materialData.Clear();
            boxData.Clear();
            chosenMaterialData.Clear();
            MaterialDataLoad();
        }

        /// <summary>
        /// Method that saves material data to file
        /// Used from within the Admin module
        /// </summary>
        public void SaveMaterialData()
        {
            try
            {
                string strTemp = "";
                List<string> listData = new List<string>();

                foreach (ClassMaterial MD in MaterialData)
                {
                    strTemp = $"{MD.strMaterialName};{MD.strMaterialWeight}";
                    listData.Add(strTemp);
                }
                listData.Add(" ");
                listData.Sort();
                CFH.SaveDataMaterialData(listData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Method, that adds new available material to MaterialData
        /// Used from within the Admin module
        /// </summary>
        public void AddToMaterialData()
        {
            ClassMaterial myMD = new ClassMaterial(CM);
            foreach (ClassMaterial md in MaterialData)
            {
                if (myMD.strMaterialName == md.strMaterialName)
                {
                    MessageBox.Show("Material already exists in list.");
                    return;
                }
            }
            MaterialData.Add(myMD);
        }

        /// <summary>
        /// Method, that clear a set of data from the MaterialData.
        /// </summary>
        public void RemoveFromMaterialData()
        {
            try    //LINQ
            {
                ClassMaterial cm = (ClassMaterial)CM;
                ClassMaterial valgtCm = MaterialData.Where(x => x.strMaterialName == cm.strMaterialName).FirstOrDefault();
                if (valgtCm != null)
                {
                    MaterialData.RemoveAt(MaterialData.IndexOf(valgtCm));
                }
            }
            catch
            {

            }
            CM.ClearAllData();
        }

        /// <summary>
        /// Method, that Updates content of Material Data Collection
        /// </summary>
        public void UpdateMaterial()
        {
            ClassMaterial cm = MaterialData.FirstOrDefault(Cm => Cm.strMaterialName == CM.strMaterialName);
            if (cm != null)
            {
                cm.strMaterialName = CM.strMaterialName;
                cm.strMaterialWeight = CM.strMaterialWeight;
            }
        }

        /// <summary>
        /// Method, that adds materials to ChosenMaterialData
        /// </summary>
        /// <param name="cb">Data from combobox</param>
        /// <param name="strMatDim">Material Thickness</param>
        public void AddToChosenMaterialData(ComboBox cb, string strMatDim)
        {
            ClassMaterial myCM = new ClassMaterial((ClassMaterial)cb.SelectedItem);
            myCM.strMaterialThickness = strMatDim;
            chosenMaterialData.Add(myCM);
        }

        /// <summary>
        /// Method, that adds dimensions to BoxData
        /// </summary>
        /// <param name="decH">Box Height</param>
        /// <param name="decW">Box Width</param>
        /// <param name="decD">BoxDepth</param>
        public void AddToDimData(decimal decH, decimal decW, decimal decD)
        {
            ClassBox myCB = new ClassBox();
            myCB.decBoxHeight = decH;
            myCB.decBoxWidth = decW;
            myCB.decBoxDepth = decD;
            boxData.Add(myCB);
        }

        /// <summary>
        /// Method, that makes a rebort based on ChosenMaterialData and BoxData,
        /// saves it in a txt.file, opens the report and resets the app
        /// </summary>
        public void MakeReport()
        {

            try
            {
                string strTemp = "";
                List<string> listData = new List<string>();


                listData.Add($"{Environment.NewLine}{Environment.NewLine}        Flydekasse Rapport - {DateTime.Now.ToString()}{Environment.NewLine}{Environment.NewLine}");

                foreach (ClassMaterial CM in ChosenMaterialData)
                {
                    strTemp = MakeMaterialHeader(CM);
                    listData.Add(strTemp);

                    foreach (ClassBox CB in BoxData)
                    {
                        strTemp = MakeMaterialLine(CM, CB);
                        listData.Add(strTemp);
                    }
                }
                listData.Add(" ");
                CFH.SaveDataReport(listData);
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Method, that generates a material header for the report
        /// </summary>
        /// <param name="cm">ChosenMaterialData</param>
        /// <returns>string with Material Header</returns>
        private string MakeMaterialHeader(ClassMaterial cm)
        {
            string strTemp = "";

            try
            {
                if (cm != null)
                {
                    strTemp = "** " + cm.strMaterialName + " - " + cm.strMaterialThickness + " **";
                }
                else
                {
                    strTemp = "** Unknown Material - Unknown Material Thickness **";
                }
                return strTemp;
            }
            catch
            {
                return strTemp;
            }
        }

        /// <summary>
        /// Method, that generates a "line" with enhanced material data
        /// </summary>
        /// <param name="cM">ChosenMaterialData</param>
        /// <param name="cB">BoxData</param>
        /// <returns>string with enhanced material data</returns>
        private string MakeMaterialLine(ClassMaterial cM, ClassBox cB)
        {
            string strTemp = "";

            try
            {
                strTemp = $"Box dimensions: {cB.decBoxHeight} m. x {cB.decBoxWidth} m. x {cB.decBoxDepth} m.   Material Thickness: {cM.strMaterialThickness} mm.{Environment.NewLine}Box volume: {Convert.ToString(CalculateBoxCubic(cB))} m3.   Material volume: {Convert.ToString(CalculateMaterialCubic(cM, cB))} m3.{Environment.NewLine}Box weight: {Convert.ToString(CalculateBoxMaterialWeight(cM, cB))} Kg.   Floating Capacity: {Convert.ToString(CalculateBoxFluidability(cM, cB))} Kg.{Environment.NewLine}";
                return strTemp;
            }
            catch
            {
                strTemp = "Box dimensions: ERROR m. x ERROR m. x ERROR m.   Material Thickness: ERROR mm.   Box Volume: ERROR m3.   Material volume: ERROR m3.   Box weight: ERROR Kg.   Floating Capacity: ERROR Kg.";
                return strTemp;
            }
        }

        /// <summary>
        /// Method, that calculates the volume of the box
        /// </summary>
        /// <param name="cbb">BoxData</param>
        /// <returns>decimal with Box Volume</returns>
        private decimal CalculateBoxCubic(ClassBox cbb)
        {
            try
            {
                decimal decTemp = cbb.decBoxHeight * cbb.decBoxWidth * cbb.decBoxDepth;
                return decTemp;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Method, that calculates the volume of the material
        /// </summary>
        /// <param name="cmM">ChosenMaterialData</param>
        /// <param name="cbB">BoxData</param>
        /// <returns>decimal with material volume</returns>
        private decimal CalculateMaterialCubic(ClassMaterial cmM, ClassBox cbB)
        {
            try
            {
                decimal decTempThick = Convert.ToDecimal(cmM.strMaterialThickness) / 1000 * 2;
                decimal decTempAirVol = (cbB.decBoxHeight - decTempThick) * (cbB.decBoxWidth - decTempThick) * (cbB.decBoxDepth - decTempThick);
                decimal decTempBoxVol = CalculateBoxCubic(cbB);
                decimal decTempMatVol = decTempBoxVol - decTempAirVol;
                return decTempMatVol;

            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Method, that calculate the Material Weight of the Box
        /// </summary>
        /// <param name="cMM">ChosenMaterialData</param>
        /// <param name="cBB">BoxData</param>
        /// <returns></returns>
        private decimal CalculateBoxMaterialWeight(ClassMaterial cMM, ClassBox cBB)
        {
            try
            {
                decimal decTempMatVol = CalculateMaterialCubic(cMM, cBB);
                decimal decTempMatWeightPerM3 = Convert.ToDecimal(cMM.strMaterialWeight);
                decimal decTempMatWeight = decTempMatVol * decTempMatWeightPerM3;
                return decTempMatWeight;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Method, that calculates the buoyance of the box
        /// </summary>
        /// <param name="cMm">ChosenMaterialData</param>
        /// <param name="cBb">BoxData</param>
        /// <returns>decimal with buoyance</returns>
        private decimal CalculateBoxFluidability(ClassMaterial cMm, ClassBox cBb)
        {
            try
            {
                decimal decTempAirWeight = CalculateBoxCubic(cBb) * 1000;
                decimal decTempBoxWeight = CalculateBoxMaterialWeight(cMm, cBb);
                decimal decTempBoxFluidability = decTempAirWeight - decTempBoxWeight;
                return decTempBoxFluidability;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Method, that refreshes data
        /// </summary>
        /// <param name="cm">MaterialData</param>
        public void UpdateDataView(ClassMaterial cm)
        {
            CM.RefreshData(cm);
        }

        #endregion

    }
}
