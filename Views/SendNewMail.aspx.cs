using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebToolz.Views
{
    public partial class SendNewMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = ConfigurationManager.ConnectionStrings["Server01ConnectionString"].ConnectionString;
            using (SqlConnection Sqlcon = new SqlConnection(connStr))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    Sqlcon.Open();
                    cmd.Connection = Sqlcon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SendedMails";

                    cmd.Parameters.Add("@charId", SqlDbType.VarChar);
                    cmd.Parameters["@charId"].Value = "GM-FOUKAN";
                    Int64 tmp;
                    tmp = Convert.ToInt64(AlzTextBox.Text);
                    cmd.Parameters.Add("@Alz", SqlDbType.Money);
                    cmd.Parameters["@Alz"].Value = tmp;

                    cmd.Parameters.Add("@ReceiverName", SqlDbType.VarChar);
                    cmd.Parameters["@ReceiverName"].Value = DropDownList1.SelectedItem.Text;
                    
                    cmd.Parameters.Add("@Title", SqlDbType.VarChar);
                    cmd.Parameters["@Title"].Value = TitleTextBox.Text;

                    cmd.Parameters.Add("@Content", SqlDbType.VarChar);
                    cmd.Parameters["@Content"].Value = MessageTextBox.Text;

                    cmd.ExecuteNonQuery();
                    Sqlcon.Close();

                }
            }
        }

        protected void MessageTextBox_TextChanged(object sender, EventArgs e)
        {
    
        }
    }
}