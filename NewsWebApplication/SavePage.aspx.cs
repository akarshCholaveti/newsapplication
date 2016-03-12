using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsWebApplication
{
    public partial class SavePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BulletedList1.DataSource = Session["links"];
            BulletedList1.DataBind();
            BulletedList1.Enabled = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string[] linkNumbers = TextBox2.Text.Split(',');

            string[] savedUrls = new string[linkNumbers.Length];
            for (int i = 0; i < linkNumbers.Length; i++)
            {
                int n = Int32.Parse(linkNumbers[i]) - 1;
                string url = BulletedList1.Items[n].Value;
                SaveWebPage.Service1Client save = new SaveWebPage.Service1Client();
                savedUrls[i] = save.storeWebPage(url);
            }
            BulletedList2.DataSource = savedUrls;
            BulletedList2.DataBind();
            BulletedList2.Enabled = true;
        }
    }
}