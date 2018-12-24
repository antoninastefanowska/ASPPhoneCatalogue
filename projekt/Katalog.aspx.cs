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
    public partial class Katalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                details.Visible = false;
            }
        }

        protected void Grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            details.Visible = true;
            sourceDetails.XPath = "/Phones/ Phone[@ID= " + Grid.SelectedDataKey.Value.ToString() + "]";
        }

        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DodajRecenzje")
            {
                string url = "Recenzja.aspx";
                string param = "";
                string model = "";

                DataSet ds = new DataSet();
                XmlDataSource source = Page.Master.FindControl("source") as XmlDataSource;
                ds.ReadXml(new XmlNodeReader(source.GetXmlDocument()));

                int index = Convert.ToInt32(e.CommandArgument);
                model = ds.Tables[0].Rows[index][0].ToString();
                
                param = "?";
                param += "model=" + model;
                param += "&";
                param += "tryb=" + "direct";

                Server.Transfer(url + param);
            }
        }
    }
}