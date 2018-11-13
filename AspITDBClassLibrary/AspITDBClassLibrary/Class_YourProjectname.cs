using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspITDBClassLibrary
{
    public class Class_YourProjectname : DbConn
    {
        
        /// <summary>
        /// Constructoren Class_YourProjectname initierer class DbConn med passende parametre
        /// der fortæller hvilken server, og hvilken database der skal kopbles op med.
        /// Connection med PW: Data Source=YYY.205.XX.31,\ASPITSQLSERVER;Initial Catalog = JensVen; User ID = sa; Password=QQQQQQQQQQQQQQQQ;
        /// Connection trusted: Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
        /// Connection IP-address: Data Source=190.190.200.100,1433;Network Library=DBMSSOCN;Initial Catalog = myDataBase; User ID = myUsername; Password=myPassword;
        /// For yderligere info se: https://www.connectionstrings.com/sql-server/
        /// </summary>
        /// <param name="strCon"></param>
        public Class_YourProjectname(string strCon)
        {
            strConnectionString = strCon;
        }
        public List<string> ReadListFromDataBase()
        {
            List<string> listRes = new List<string>();
            DataTable dm = DbReturnDataTable("SELECT * FROM MaterialData");
            foreach (DataRow row in dm.Rows)
            {
                listRes.Add(row[1].ToString() + ";" + row[2].ToString());
            }
            return listRes;
        }
    }
}
