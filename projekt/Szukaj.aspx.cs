using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KatalogTelefonow
{
    public partial class Szukaj : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                System.Diagnostics.Debug.WriteLine(getIndex());
                if (getIndex() == "-1")
                    details.Visible = false;
                else
                {
                    sourceDetails.XPath = "/Phones/ Phone[@ID= " + getIndex() + "]";
                    lbKomunikat.Visible = false;
                }
            }
        }

        private string getIndex()
        {
            return Request.QueryString["index"];
        }
    }
}