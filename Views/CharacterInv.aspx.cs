using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebToolz.Controller;

namespace WebToolz.Views
{
    public partial class CharacterInv : System.Web.UI.Page
    {
         public  static List<Item> ITEMY;
        protected void Page_Load(object sender, EventArgs e)
        {
            CharInvInfoController charinfoc = new CharInvInfoController();
        }
        public class Item{
           public string name { get; set;}
            public string grade { get; set;}
            public string craft { get; set;}
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
          ITEMY = new List<Item>();
            Dictionary<int, string> itemyWszystkie = new Dictionary<int, string>();
           List<string> GradesValues = new List<string>();
            List<int> listaID = new List<int>();
            List<Byte[]> listaItemow = getItemId();
            List<String> toJuzKurwaNaPewnoItemow = new List<String>();
            foreach (Byte[] listaBajtow in listaItemow)
            {
                byte gradeId1 = listaBajtow[15];
                byte bindId = listaBajtow[16];
                byte itemId1 = listaBajtow[16];
                byte itemId2 = listaBajtow[17];
                int id1 = (int)(itemId1);
                int id2 = (int)(itemId2);
                int grade1 = (int)(gradeId1);
                int bind1 = (int)(bindId);
                string hex = id1.ToString("X");
                string hex2 = id2.ToString("X");
                string hexGrade = grade1.ToString("X");
                string hexBind1 = bind1.ToString("X");
                if (hexBind1.Length == 1)
                {
                    hexBind1 = "0" + hexBind1;
                }
                hexGrade = hexGrade.Substring(hexGrade.Length - 1);
                int gradeID = int.Parse(hexGrade, System.Globalization.NumberStyles.HexNumber);
                hexBind1 = hexBind1.Substring(0, 1);
                hex = hex.Substring(hex.Length - 1);
                string ID = string.Concat(hex, hex2);
                int intID = int.Parse(ID, System.Globalization.NumberStyles.HexNumber);
                if (gradeID == 0)
                {
                    switch (hexBind1)
                    {
                        case "0":
                            hexGrade = "+0 with no binding";
                            break;
                        case "1":
                            hexGrade = "+0 with binding";
                            break;
                        case "2":
                            hexGrade = "+1 with no binding";
                            break;
                        case "3":
                            hexGrade = "+1 with binding";
                            break;
                        case "4":
                            hexGrade = "+2 with no binding";
                            break;
                        case "5":
                            hexGrade = "+2 with binding";
                            break;
                        case "6":
                            hexGrade = "+3 with no binding";
                            break;
                        case "7":
                            hexGrade = "+3 with binding";
                            break;
                        case "8":
                            hexGrade = "+4 with no binding";
                            break;
                        case "9":
                            hexGrade = "+4 with binding";
                            break;
                        case "A":
                            hexGrade = "+5 with no binding";
                            break;
                        case "B":
                            hexGrade = "+5 with binding";
                            break;
                        case "C":
                            hexGrade = "+6 with no binding";
                            break;
                        case "D":
                            hexGrade = "+6 with binding";
                            break;
                        case "E":
                            hexGrade = "+7 with no binding";
                            break;
                        case "F":
                            hexGrade = "+7 with binding";
                            break;

                    }
                }
                else
                {
                    switch (hexBind1)
                    {
                        case "0":
                            hexGrade = "+8 with no binding";
                            break;
                        case "1":
                            hexGrade = "+8 with binding";
                            break;
                        case "2":
                            hexGrade = "+9 with no binding";
                            break;
                        case "3":
                            hexGrade = "+9 with binding";
                            break;
                        case "4":
                            hexGrade = "+10 with no binding";
                            break;
                        case "5":
                            hexGrade = "+10 with binding";
                            break;
                        case "6":
                            hexGrade = "+11 with no binding";
                            break;
                        case "7":
                            hexGrade = "+11 with binding";
                            break;
                        case "8":
                            hexGrade = "+12 with no binding";
                            break;
                        case "9":
                            hexGrade = "+12 with binding";
                            break;
                        case "A":
                            hexGrade = "+13 with no binding";
                            break;
                        case "B":
                            hexGrade = "+13 with binding";
                            break;
                        case "C":
                            hexGrade = "+14 with no binding";
                            break;
                        case "D":
                            hexGrade = "+14 with binding";
                            break;
                        case "E":
                            hexGrade = "+15 with no binding";
                            break;
                        case "F":
                            hexGrade = "+15 with binding";
                            break;

                    }
                }


                if (intID != 0)
                {
                    listaID.Add(intID);
                    GradesValues.Add(intID.ToString());
                    GradesValues.Add(hexGrade);
                }

            }
            itemyWszystkie = wczytajPlikZItem();
            foreach (int id in listaID)
            {
                if (itemyWszystkie.Keys.Contains(id))
                {
                    Item item = new Item();
                    
                    for (int j = 0; j < GradesValues.Count; j++)
                    {
                        if (Int32.Parse(GradesValues[j]) == id)
                        {
                            String value;
                            itemyWszystkie.TryGetValue(id, out value);
                            item.name=value;
                            item.grade=GradesValues[j + 1];
                            item.craft="chuj";
                            ITEMY.Add(item);
                           // toJuzKurwaNaPewnoItemow.Add(value);
                        }
                        j++;
                    }
                   
                }
            }
            GridView1.DataBind();
            
        }
        public List<Item> getItems()
        {
            return ITEMY;
        }
        public List<Byte[]> getItemId()
        {
            String connStr = ConfigurationManager.ConnectionStrings["Server01ConnectionString"].ConnectionString;
            DataSet ds = new DataSet();
            List<Byte[]> lista = new List<Byte[]>();
            using (SqlConnection Sqlcon = new SqlConnection(connStr))
            {
                string s = "select nazwa from invStatus(@charIdx)";
                using (SqlCommand cmd = new SqlCommand(s, Sqlcon))
                {
                    cmd.Connection = Sqlcon;
                    cmd.CommandType = CommandType.Text;
                    Sqlcon.Open();
                    cmd.Parameters.AddWithValue("@charIdx", DDL_Char.SelectedValue);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Byte[] ar = (Byte[])(dr[0]);
                        lista.Add(ar);
                    }
                    dr.Close();

                    //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    //  adapter.Fill(ds);


                    Sqlcon.Close();
                }
            }
            return lista;
        }
        public Dictionary<int, String> wczytajPlikZItem()
        {
            Dictionary<int, String> itemy = new Dictionary<int, string>();
            int counter = 0;
            string line;
            List<String> listaNazwRob = new List<String>();
            List<string[]> poteznaListaList = new List<string[]>();
            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(Server.MapPath("~/FILES/ItemList.txt"));
            while ((line = file.ReadLine()) != null)
            {
                listaNazwRob.Add(line);
            }

            file.Close();
            string[] result = new string[listaNazwRob.Count];
            foreach (String linia in listaNazwRob)
            {
                result = linia.Split(';');
                poteznaListaList.Add(result);

            }
            foreach (string[] chuj in poteznaListaList)
            {
                for (int i = 0; i < chuj.Length; i++)
                {
                    itemy.Add(Int32.Parse(chuj[i]), chuj[i + 1]);
                    i++;
                }
            }

            return itemy;
        }
        

    }
}