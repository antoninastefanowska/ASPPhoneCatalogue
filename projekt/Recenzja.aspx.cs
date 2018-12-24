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
    public partial class Recenzja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (getTryb() == "direct")
                {
                    lbModel1.Text = getModel();
                    MV.SetActiveView(view2);
                }
                else
                {
                    bindXML();
                    MV.SetActiveView(view1);
                }
            } 
        }

        private void bindXML()
        {
            DataSet ds = new DataSet();
            XmlDataSource source = Page.Master.FindControl("source") as XmlDataSource;
            ds.ReadXml(new XmlNodeReader(source.GetXmlDocument()));

            ddlModele.DataSource = ds;
            ddlModele.DataTextField = "Name";
            ddlModele.DataValueField = "ID";
            ddlModele.DataBind();
        }

        private string getTryb()
        {
            return Request.QueryString["tryb"];
        }

        private string getModel()
        {
            if (getTryb() == "direct")
                return Request.QueryString["model"];
            return ddlModele.SelectedItem.Text;
        }

        private int getOcena()
        {
            return Int32.Parse(ddlOcena.SelectedValue);
        }

        private string getAutor()
        {
            return tbAutor.Text;
        }

        private string getTresc()
        {
            return tbTresc.Text;
        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            lbModel1.Text = getModel();
            MV.SetActiveView(view2);
        }

        protected void bt2_Click(object sender, EventArgs e)
        {
            MV.SetActiveView(view3);
            lbModel2.Text = getModel();
            lbOcena.Text = getOcena().ToString();
            lbAutor.Text = getAutor();
            lbTresc.Text = getTresc();
        }
    }
}