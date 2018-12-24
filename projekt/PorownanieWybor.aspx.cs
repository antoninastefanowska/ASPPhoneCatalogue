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
    public partial class PorownanieWybor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindXML();
            }
        }

        private void bindXML()
        {
            DataSet ds = new DataSet();
            XmlDataSource source = Page.Master.FindControl("source") as XmlDataSource;
            ds.ReadXml(new XmlNodeReader(source.GetXmlDocument()));

            ddlModel1.DataSource = ds;
            ddlModel2.DataSource = ds;
            ddlModel1.DataTextField = "Name";
            ddlModel2.DataTextField = "Name";
            ddlModel1.DataValueField = "ID";
            ddlModel2.DataValueField = "ID";
            ddlModel1.DataBind();
            ddlModel2.DataBind();
        }

        protected void btZatwierdz_Click(object sender, EventArgs e)
        {
            string url = "Porownanie.aspx";
            string param = "";

            param = "?";
            param += "model1=" + ddlModel1.SelectedValue;
            param += "&";
            param += "model2=" + ddlModel2.SelectedValue;
            
            Response.Redirect(url + param);
        }
    }
}