using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using System.Xml;


    public partial class MenuCommon : System.Web.UI.UserControl
    {
        private string url = "";

        public string Url
        {
            set { url = value; }
            get { return url; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            {
                Menu menu = new Menu();
                menu.MenuItemClick += new MenuEventHandler(menu_MenuItemClick);

                menu.CssClass = "header";
                menu.StaticMenuItemStyle.CssClass = "header";
                menu.StaticMenuStyle.CssClass = "header";
                menu.StaticSelectedStyle.CssClass = "header";
                menu.DynamicMenuItemStyle.CssClass = "header";
                menu.DynamicMenuStyle.CssClass = "header";
                menu.DynamicSelectedStyle.CssClass = "header";
                menu.ForeColor = System.Drawing.Color.DarkBlue;
                menu.Font.Size = 12;
                menu.StaticMenuItemStyle.HorizontalPadding = 20;


                DataSet ds = createMenuDataSet();
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    string menuval = (string)ds.Tables[i].TableName;
                    string[] mvals = menuval.Split('~');
                    MenuItem parentItem = new MenuItem(mvals[0]);
                    menu.Items.Add(parentItem);
                    if (mvals.Length == 2)
                        parentItem.NavigateUrl = "javascript:NavMenu('" + mvals[1] + "')";

                    for (int c = 0; c < ds.Tables[i].Columns.Count; c++)
                    {
                        menuval = (string)ds.Tables[i].Columns[c].ColumnName;
                        mvals = menuval.Split('~');
                        MenuItem column = new MenuItem(mvals[0]);

                        parentItem.ChildItems.Add(column);
                        if (mvals.Length == 2)
                            column.NavigateUrl = "javascript:NavMenu('" + mvals[1] + "')";
                    }
                }

                if (Session["Login"] != null && Session["Login"].ToString() == "1")
                {
                    if (Session["Name"] != null)
                    {
                        MenuItem wel = new MenuItem("Welcome : " + Session["Name"].ToString() + " (" + Session["REG_NUM"].ToString() + ")");
                        menu.Items.Add(wel);
                    }
                 }

                menu.Orientation = Orientation.Horizontal;
                //menu.BackColor = System.Drawing.Color.LightBlue;
                //menu.ForeColor = System.Drawing.Color.DarkBlue;
                menu.Font.Bold = true;

                Panel1.Controls.Add(menu);
                Panel1.DataBind();

            }
        }

        void menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            string selected = e.Item.Text;
        }

        private DataSet createMenuDataSet()
        {

            string filename = "";

            filename = Server.MapPath("Hosp");

            filename = filename.Substring(0, filename.LastIndexOf("\\"));

            filename += "\\Menu.xml";

            XmlDocument objxml = new XmlDocument();

            objxml.Load(filename);

            XmlNodeList nodelist = objxml.SelectNodes("Menus//Menu");

            DataSet ds = new DataSet();

            int index = 0;
            foreach (XmlNode node in nodelist)
            {
                ds.Tables.Add();
                ds.Tables[index].TableName = node.Attributes["ID"].Value + "~" + node.Attributes["URL"].Value;
                foreach (XmlNode nodec in node.SelectNodes("SubMenu"))
                {
                    ds.Tables[index].Columns.Add(nodec.InnerText);
                }
                index++;
            }
            return ds;
        }
    }
