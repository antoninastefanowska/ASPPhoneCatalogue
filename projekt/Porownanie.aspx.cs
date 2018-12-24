using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace KatalogTelefonow
{
    public partial class Porownanie : System.Web.UI.Page
    {
        int model1;
        int model2;
        DataSet ds = new DataSet();
        bool system = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindXML();
            }
        }

        private int getModel1()
        {
            return Int32.Parse(Request.QueryString["model1"]);
        }

        private int getModel2()
        {
            return Int32.Parse(Request.QueryString["model2"]);
        }

        private void bindXML()
        {
            XmlDataSource source = Page.Master.FindControl("source") as XmlDataSource;
            ds.ReadXml(new XmlNodeReader(source.GetXmlDocument()));

            DataTable dt = ds.Tables[0];
            dt = buildTable(dt);

            Grid.ShowHeader = false;
            Grid.DataSource = dt;
            Grid.DataBind();
        }

        private DataTable buildTable(DataTable dt)
        {
            model1 = getModel1();
            model2 = getModel2();
            DataTable dt2 = new DataTable();

            for (int i = 0; i <= dt.Rows.Count; i++)
                dt2.Columns.Add();

            for (int i = 0; i < dt.Columns.Count - 3; i++)
                dt2.Rows.Add();

            dt2.Rows[0][0] = "Nazwa";
            dt2.Rows[1][0] = "Model";
            dt2.Rows[2][0] = "Data wypuszczenia";
            dt2.Rows[3][0] = "Typ";
            dt2.Rows[4][0] = "Klawiatura";
            dt2.Rows[5][0] = "Rozmiar wyświetlacza";
            dt2.Rows[6][0] = "Ekran dotykowy";
            dt2.Rows[7][0] = "Typ karty SIM";
            dt2.Rows[8][0] = "Dual-SIM";
            dt2.Rows[9][0] = "Karta pamięci";
            dt2.Rows[10][0] = "Pamięć wewnętrzna";
            dt2.Rows[11][0] = "Pamięć RAM";
            dt2.Rows[12][0] = "System operacyjny";
            dt2.Rows[13][0] = "Wersja systemu";
            dt2.Rows[14][0] = "Procesor";
            dt2.Rows[15][0] = "Taktowanie procesora";
            dt2.Rows[16][0] = "Liczba rdzeni";
            dt2.Rows[17][0] = "Bateria";
            dt2.Rows[18][0] = "Aparat";
            dt2.Rows[19][0] = "Lampa błyskowa";
            dt2.Rows[20][0] = "Odbiornik radiowy";

            for (int i = 0; i < dt.Columns.Count - 3; i++)
            {
                dt2.Rows[i][model1] = dt.Rows[model1 - 1][i];
                dt2.Rows[i][model2] = dt.Rows[model2 - 1][i];
            }

            DataTable temp = ds.Tables[2];
            dt2.Rows.Add();
            dt2.Rows[dt2.Rows.Count - 1][0] = "Komunikacja";
            for (int i = 0; i < temp.Rows.Count; i++)
                dt2.Rows[dt2.Rows.Count - 1][Convert.ToInt32(temp.Rows[i][1]) + 1] += temp.Rows[i][0].ToString() + ' ';

            temp = ds.Tables[4];
            dt2.Rows.Add();
            dt2.Rows[dt2.Rows.Count - 1][0] = "Czujniki";
            for (int i = 0; i < temp.Rows.Count; i++)
                dt2.Rows[dt2.Rows.Count - 1][Convert.ToInt32(temp.Rows[i][1]) + 1] += temp.Rows[i][0].ToString() + ' ';

            return dt2; 
        }

        protected void Grid_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                if ((i != model1) && (i != model2))
                    e.Row.Cells[i].Visible = false;
            }

            e.Row.Cells[0].CssClass = "headerCell";
            
            if (e.Row.Cells[0].Text == "Nazwa")
            {
                e.Row.Cells[model1].CssClass = "headerCell";
                e.Row.Cells[model2].CssClass = "headerCell";
            }

            if (e.Row.Cells[model1].Text != e.Row.Cells[model2].Text)
            {
                if (e.Row.Cells[model1].Text == "Yes")
                {
                    e.Row.Cells[model1].CssClass = "betterChoice";
                    e.Row.Cells[model2].CssClass = "worseChoice";
                }
                else if (e.Row.Cells[model2].Text == "Yes")
                {
                    e.Row.Cells[model2].CssClass = "betterChoice";
                    e.Row.Cells[model1].CssClass = "worseChoice";
                }

                if (e.Row.Cells[model1].Text == "none")
                {
                    e.Row.Cells[model2].CssClass = "betterChoice";
                    e.Row.Cells[model1].CssClass = "worseChoice";
                }
                else if (e.Row.Cells[model2].Text == "none")
                {
                    e.Row.Cells[model1].CssClass = "betterChoice";
                    e.Row.Cells[model2].CssClass = "worseChoice";
                }

                if ((e.Row.Cells[0].Text == "Pamięć wewnętrzna") || (e.Row.Cells[0].Text == "Pamięć RAM"))
                {
                    string[] s1, s2;
                    s1 = e.Row.Cells[model1].Text.Split(' ');
                    s2 = e.Row.Cells[model2].Text.Split(' ');

                    if (s1[1] == s2[1])
                    {
                        if (Int32.Parse(s1[0]) > Int32.Parse(s2[0]))
                        {
                            e.Row.Cells[model1].CssClass = "betterChoice";
                            e.Row.Cells[model2].CssClass = "worseChoice";
                        }
                        else
                        {
                            e.Row.Cells[model2].CssClass = "betterChoice";
                            e.Row.Cells[model1].CssClass = "worseChoice";
                        }
                    }
                    else
                    {
                        if ((s1[1] == "GB") || (s2[1] == "GB"))
                        {
                            if (s1[1] == "GB")
                            {
                                e.Row.Cells[model1].CssClass = "betterChoice";
                                e.Row.Cells[model2].CssClass = "worseChoice";
                            }
                            else
                            {
                                e.Row.Cells[model2].CssClass = "betterChoice";
                                e.Row.Cells[model1].CssClass = "worseChoice";
                            }
                        }
                        else if ((s1[1] == "MB") || (s2[1] == "MB"))
                        {
                            if (s1[1] == "MB")
                            {
                                e.Row.Cells[model1].CssClass = "betterChoice";
                                e.Row.Cells[model2].CssClass = "worseChoice";
                            }
                            else
                            {
                                e.Row.Cells[model2].CssClass = "betterChoice";
                                e.Row.Cells[model1].CssClass = "worseChoice";
                            }
                        }
                    }
                }

                if (((e.Row.Cells[0].Text == "Wersja systemu") && system) || (e.Row.Cells[0].Text == "Taktowanie procesora") || (e.Row.Cells[0].Text == "Aparat") || (e.Row.Cells[0].Text == "Rozmiar wyświetlacza"))
                {
                    string[] s1, s2;
                    s1 = e.Row.Cells[model1].Text.Split(' ');
                    s2 = e.Row.Cells[model2].Text.Split(' ');
                    if (double.Parse(s1[0], CultureInfo.InvariantCulture) > double.Parse(s2[0], CultureInfo.InvariantCulture))
                    {
                        e.Row.Cells[model1].CssClass = "betterChoice";
                        e.Row.Cells[model2].CssClass = "worseChoice";
                    }
                    else
                    {
                        e.Row.Cells[model2].CssClass = "betterChoice";
                        e.Row.Cells[model1].CssClass = "worseChoice";
                    }
                }

                if ((e.Row.Cells[0].Text == "Liczba rdzeni") || (e.Row.Cells[0].Text == "Bateria"))
                {
                    string[] s1, s2;
                    s1 = e.Row.Cells[model1].Text.Split(' ');
                    s2 = e.Row.Cells[model2].Text.Split(' ');
                    if (Int32.Parse(s1[0]) > Int32.Parse(s2[0]))
                    {
                        e.Row.Cells[model1].CssClass = "betterChoice";
                        e.Row.Cells[model2].CssClass = "worseChoice";
                    }
                    else
                    {
                        e.Row.Cells[model2].CssClass = "betterChoice";
                        e.Row.Cells[model1].CssClass = "worseChoice";
                    }
                }
            }
            else if (e.Row.Cells[0].Text == "System operacyjny")
                system = true;
        }
    }
}