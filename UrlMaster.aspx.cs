using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;

    public partial class UrlMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateDropDown();
                FillData();
            }
        }

        protected void FillData()
        {
            DbCall objDB = new DbCall();
            objDB.set_conn1(1);

            string rownum = "0";
            if (Request.QueryString["ROWNUM"] != null)
            {
                rownum = Request.QueryString["ROWNUM"].ToString();
                string sql = "SELECT * FROM URL_MASTER WHERE URLID = " + rownum;


                DataSet dsFac = objDB.ExecuteQuery(sql);

                if (dsFac != null && dsFac.Tables[0].Rows.Count > 0)
                {
                    DataRow drFac = dsFac.Tables[0].Rows[0];

                    cmbCat.Text = drFac["CATEGORY"].ToString();
                    txtUrl.Text = drFac["URL"].ToString();
                    txtRem.Text = drFac["REMARKS"].ToString();
                    txtNam.Text = drFac["ADDED_BY"].ToString();

                    txtNam.Enabled = false;

                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDel.Enabled = true;

                }
            }
            else
            {
                txtNam.Enabled = true;
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDel.Enabled = false;

            }
        }

        private void FillGrid()
        {
            DbCall objDB = new DbCall();
            objDB.set_conn1(1);

            string sql = "SELECT * FROM URL_MASTER WHERE CATEGORY = '" + cmbCat.SelectedItem.Text + "'";

            DataSet dsSubj = objDB.ExecuteQuery(sql);

            string html = "<table border='1'><tr><td><b>Edit Record</b></td><td><b>Category</b></td><td><b>Url</b></td><td><b>Remarks</b></td><td><b>Added By</b></td><td><b>Added Date</b></td></tr>";
            if (dsSubj != null && dsSubj.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drSubj in dsSubj.Tables[0].Rows)
                {
                    html += "<tr>";

                    html += "<td><a href='UrlMaster.aspx?ROWNUM=" + drSubj["URLID"].ToString() + "'>" + drSubj["URLID"].ToString() + "</a></td>";
                    html += "<td>" + drSubj["CATEGORY"].ToString() + "</td>";
                    html += "<td><a target='_blank' href='" + drSubj["URL"].ToString() + "'>" + drSubj["URL"].ToString() + "</a></td>";
                    html += "<td>" + drSubj["REMARKS"].ToString() + "</td>";
                    html += "<td>" + drSubj["ADDED_BY"].ToString() + "</td>";
                    html += "<td>" + drSubj["ADDED_DATE"].ToString().Split(' ')[0] + "</td>";
                    html += "</tr>";

                }
            }
            html += "</table>";

            lblUrls.Text = html;
            //if (dsSubj != null && dsSubj.Tables[0].Rows.Count > 0)
            //{
            //    grdIns.DataSource = dsSubj.Tables[0];
            //    grdIns.DataBind();
            //}
            //else
            //{
            //    grdIns.DataSource = null;
            //    grdIns.DataBind();
            //}
        }

        protected void PopulateDropDown()
        {
            cmbCat.Items.Clear();
            DbCall objDB = new DbCall();

            string sql = "SELECT * FROM CAT_MASTER";

            DataSet dsDocs = objDB.ExecuteQuery(sql);

            if (dsDocs != null && dsDocs.Tables[0].Rows.Count > 0)
            {
                cmbCat.DataTextField = "CATEGORY";
                cmbCat.DataValueField = "CATEGORY";
                cmbCat.DataSource = dsDocs.Tables[0];
                cmbCat.DataBind();
            }

            if (Session["CATEGORY"] != null)
                cmbCat.SelectedValue = Session["CATEGORY"].ToString();
            FillGrid();

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("UrlMaster.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string param = "";
            string row_num = "0";
            string sql = "";

            DbCall objDB = new DbCall();

            if (Request.QueryString["ROWNUM"] == null)
            {
                row_num = "0";

                sql = "SELECT * FROM URL_MASTER WHERE CATEGORY = '" + cmbCat.SelectedItem.Text + "' AND URL = '" + txtUrl.Text + "'";

                DataSet dsDocs = objDB.ExecuteQuery(sql);

                if (dsDocs != null && dsDocs.Tables[0].Rows.Count > 0)
                {
                    lblMessg.Text = "You have already added Url: " + txtUrl.Text + " for category : " + cmbCat.SelectedItem.Text;
                    return;
                }
                sql = "SELECT MAX(URLID)+1 FROM URL_MASTER";

                dsDocs = objDB.ExecuteQuery(sql);

                if (dsDocs != null && dsDocs.Tables[0].Rows.Count > 0)
                {
                    row_num = dsDocs.Tables[0].Rows[0][0].ToString();
                }
                else
                    row_num = "1";

                if (row_num == "")
                    row_num = "1";

                param += row_num + "~";
                param += cmbCat.SelectedItem.Text + "~";
                param += txtUrl.Text + "~";
                param += txtRem.Text + "~";
                param += txtNam.Text + "~";
                param += DateTime.Today.ToString("MM/dd/yyyy") + "~";

                sql = "INSERT INTO URL_MASTER (URLID, CATEGORY, URL, REMARKS, ADDED_BY, ADDED_DATE) VALUES({0}, '{1}', '{2}', '{3}', '{4}', '{5}')";
 
                sql = String.Format(sql, param.Split('~'));

                int retval = objDB.ExecuteNonQuery(sql);

                if (retval == 1)
                {
                    lblMessg.Text = "Url details added successfully";
                    Response.Write("<script language='javascript'> alert('Url details added successfully'); </script>");
                    FillGrid();
                    btnAdd.Enabled = false;
                }
                else
                {
                    lblMessg.Text = "Error encountered, please try again";
                    Response.Write("<script language='javascript'> alert('Error encountered, please try again'); </script>");
                }
             }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string param = "";
            string row_num = "0";
            string sql = "";

            DbCall objDB = new DbCall();

            if (Request.QueryString["ROWNUM"] != null)
            {

                row_num = Request.QueryString["ROWNUM"].ToString();

                param += row_num + "~";
                param += cmbCat.SelectedItem.Text + "~";
                param += txtUrl.Text + "~";
                param += txtRem.Text + "~";

                sql = "UPDATE URL_MASTER SET URL = '{2}', CATEGORY = '{1}', REMARKS = '{3}' WHERE URLID = {0}";

                sql = String.Format(sql, param.Split('~'));

                int retval = objDB.ExecuteNonQuery(sql);

                if (retval == 1)
                {
                    lblMessg.Text = "Url details updated successfully";
                    Response.Write("<script language='javascript'> alert('Url details updated successfully'); </script>");
                    FillGrid();
                    btnAdd.Enabled = false;
                }
                else
                {
                    lblMessg.Text = "Error encountered, please try again";
                    Response.Write("<script language='javascript'> alert('Error encountered, please try again'); </script>");
                }
            }
            else
                lblMessg.Text = "Please select any item to be updated from grid below";
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            string param = "";
            string row_num = "0";
            string sql = "";

            DbCall objDB = new DbCall();

            if (Request.QueryString["ROWNUM"] != null)
            {

                row_num = Request.QueryString["ROWNUM"].ToString();

                param += row_num + "~";

                sql = "DELETE FROM URL_MASTER WHERE URLID = {0}";

                sql = String.Format(sql, param.Split('~'));

                int retval = objDB.ExecuteNonQuery(sql);

                if (retval == 1)
                {
                    lblMessg.Text = "Url deleted successfully";
                    Response.Write("<script language='javascript'> alert('Url deleted successfully'); </script>");
                    FillGrid();
                    btnAdd.Enabled = false;
                }
                else
                {
                    lblMessg.Text = "Error encountered, please try again";
                    Response.Write("<script language='javascript'> alert('Error encountered, please try again'); </script>");
                }
            }
            else
                lblMessg.Text = "Please select any item to be deleted from grid below";

        }

       protected void cmbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
            Session["CATEGORY"] = cmbCat.SelectedItem.Text;
        }
       protected void btnOpenAll_Click(object sender, EventArgs e)
       {
           DbCall objDB = new DbCall();
            objDB.set_conn1(1);

            string sql = "SELECT * FROM URL_MASTER WHERE CATEGORY = '" + cmbCat.SelectedItem.Text + "'";

            DataSet dsSubj = objDB.ExecuteQuery(sql);

            if (dsSubj != null && dsSubj.Tables[0].Rows.Count > 0)
            {
                int iFileCnt = 0;
                foreach (DataRow drSubj in dsSubj.Tables[0].Rows)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_File" + iFileCnt,
                    "window.open('" + drSubj["URL"].ToString() + "','_blank');", true);

                    iFileCnt += 1;
                    //Response.Write("<script language='javascript'> window.open('" + drSubj["URL"].ToString() + "','_newtab');</script>");
                    //Thread.Sleep(1000);
                }
            }
       }
}
