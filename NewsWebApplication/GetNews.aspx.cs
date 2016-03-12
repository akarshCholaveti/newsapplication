using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsWebApplication
{
    public partial class GetNews : System.Web.UI.Page
    {
        string[] links = new string[20];
        protected void Page_Load(object sender, EventArgs e)
        {
            BulletedList1.Visible = false;
            Label2.Visible = false;
            TextBox2.Visible = false;
            Button2.Visible = false;
            BulletedList2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            NewsFocus.Service1Client getNews = new NewsFocus.Service1Client();
            links = getNews.NewsFocus(TextBox1.Text);
            BulletedList1.DataSource = links;
            BulletedList1.DataBind();
            BulletedList1.Enabled = true;
            Session["links"] = links;
            Response.Redirect("SavePage.aspx");
            
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