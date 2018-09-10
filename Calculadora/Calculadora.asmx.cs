using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Calculadora
{
    /// <summary>
    /// Summary description for Calculadora
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    [WebService(Namespace = "http://demo.android.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Calculadora : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "";
        }

        [WebMethod]
        public int Multiplicar(int x, int y)
        {
            return (x * y);

        }

        [WebMethod]
        public int Somar(int x, int y)
        {
            return (x + y);
        }

        [WebMethod]
        public int Dividir(int x, int y)
        {
            //int resultado;
            //resultado = (x / y);
            //return resultado;

            return (x / y);
            //try
            //{
            //    resultado = (x / y);
            //    return resultado.tostring();
            //}
            //catch (dividebyzeroexception)
            //{
            //    return "não é possível dividir por zero.";
            //}

        }

        [WebMethod]
        public int Subtrair(int x, int y)
        {
            return (x - y);
        }


        [WebMethod]
        public String Get()
        {
            //string valor = "Data Source=DatabaseServer;Initial Catalog=Northwind;User ID=YourUserID;Password=YourPassword";
            string valor = "data source=JAILSON-PC\\SQLEXPRESS;initial catalog=hello_world;User ID=sa;Password=biq#296";
            //string constr = ConfigurationManager.ConnectionStrings["hello_worldEntities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(valor))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM hello_world"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "hello_world";
                            sda.Fill(dt);

                            string json = JsonConvert.SerializeObject(dt, Formatting.Indented);

                            //return json;
                            //Console.WriteLine(dt);
                            //Console.WriteLine(json);

                            //string JSONresult;
                            //JSONresult = JsonConvert.SerializeObject(dt);
                            //Response.Write(JSONresult);



                            return json;


                        }
                    }
                }
            }
        }

        private String ConvertDt_Json()
        {
            DataSet dataSet = new DataSet("dataSet");
            dataSet.Namespace = "NetFrameWork";
            DataTable table = new DataTable();
            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.AutoIncrement = true;

            DataColumn itemColumn = new DataColumn("first_name");
            table.Columns.Add(idColumn);
            table.Columns.Add(itemColumn);
            dataSet.Tables.Add(table);

            for (int i = 0; i < 2; i++)
            {
                DataRow newRow = table.NewRow();
                newRow["item"] = "item " + i;
                table.Rows.Add(newRow);
            }

            dataSet.AcceptChanges();

            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

            return json;
        }

    }
}
