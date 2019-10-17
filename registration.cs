using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SecondChance
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<string> countries = new List<string>();
                CultureInfo[] culture = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                foreach(CultureInfo item in culture)
                {
                    RegionInfo region = new RegionInfo(item.LCID);
                    if(!(countries.Contains(region.EnglishName)))
                        {
                        countries.Add(region.EnglishName);
                    }

                }
                countries.Sort();
                DropDownList1.DataSource = countries;
                DropDownList1.DataBind();
            }
        }

        protected void btnBacktoLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["SecondChanceConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[SecondChance.Users]
           ([UserID]
           ,[First_Name]
           ,[Last_Name]
           ,[Birth_Date]
           ,[Phone_Number]
           ,[Email]
           ,[Adress]
           ,[Password]
           ,[Username])
     VALUES
           ("+txtFirstName.Text+", "+txtLastName.Text+", "+txtBirthDate.Text+", "+txtPhoneNumber.Text+", "+txtEmail.Text+", "+txtAdress.Text+", "+txtPassword.Text+", "+txtUsername.Text+");
        }
    }
}
