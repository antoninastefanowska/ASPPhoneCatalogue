using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace KatalogTelefonow
{
    public partial class SzukajWybor : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void bindXML()
        {
            DataSet ds = new DataSet();
            XmlDataSource source = Page.Master.FindControl("source") as XmlDataSource;
            ds.ReadXml(new XmlNodeReader(source.GetXmlDocument()));

            dt = ds.Tables[0];
        }

        protected void btZatwierdz_Click(object sender, EventArgs e)
        {
            bindXML();
            bool znaleziono = false;
            string parametr = tbNazwa.Text.ToLower();
            int i;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString().ToLower().Contains(parametr))
                {
                    znaleziono = true;
                    break;
                }
            }

            if (!znaleziono) i = -1;
            else i++;

            string url = "Szukaj.aspx";
            string param = "?";

            param += "index=" + i.ToString();
            Server.Transfer(url + param);
        }
    }
}