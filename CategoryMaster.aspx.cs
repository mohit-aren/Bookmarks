using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


    public partial class CategoryMaster : System.Web.UI.Page
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

            string rownum = "0";
            if (Request.QueryString["ROWNUM"] != null)
            {
                rownum = Request.QueryString["ROWNUM"].ToString();
                string sql = "SELECT * FROM CAT_MASTER WHERE CATID = " + rownum;


                DataSet dsFac = objDB.ExecuteQuery(sql);

                if (dsFac != null && dsFac.Tables[0].Rows.Count > 0)
                {
                    DataRow drFac = dsFac.Tables[0].Rows[0];

                    txtCat.Text = drFac["CATEGORY"].ToString();
                }
            }
        }

        private void FillGrid()
        {
            DbCall objDB = new DbCall();

            string sql = "SELECT * FROM CAT_MASTER";

            DataSet dsSubj = objDB.ExecuteQuery(sql);

            if (dsSubj != null && dsSubj.Tables[0].Rows.Count > 0)
            {
                grdIns.DataSource = dsSubj.Tables[0];
                grdIns.DataBind();
            }
        }

        protected void PopulateDropDown()
        {
            if (Session["MASTER"] == null)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDel.Enabled = false;
            }
            FillGrid();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryMaster.aspx");
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

                sql = "SELECT * FROM CAT_MASTER WHERE CATEGORY = '" + txtCat.Text + "'";

                DataSet dsDocs = objDB.ExecuteQuery(sql);

                if (dsDocs != null && dsDocs.Tables[0].Rows.Count > 0)
                {
                    lblMessg.Text = "You have already added Category : " + txtCat.Text;
                    return;
                }
                sql = "SELECT MAX(CATID)+1 FROM CAT_MASTER";

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
                param += txtCat.Text + "~";

                sql = "INSERT INTO CAT_MASTER (CATID, CATEGORY) VALUES({0}, '{1}')";
 
                sql = String.Format(sql, param.Split('~'));

                int retval = objDB.ExecuteNonQuery(sql);

                if (retval == 1)
                {
                    lblMessg.Text = "Category details added successfully";
                    Response.Write("<script language='javascript'> alert('Category details added successfully'); </script>");
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
                param += txtCat.Text + "~";
                sql = "UPDATE CAT_MASTER SET CATEGORY = {1} WHERE CATID = {0}";

                sql = String.Format(sql, param.Split('~'));

                int retval = objDB.ExecuteNonQuery(sql);

                if (retval == 1)
                {
                    lblMessg.Text = "Category details updated successfully";
                    Response.Write("<script language='javascript'> alert('Category details updated successfully'); </script>");
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

                sql = "DELETE FROM CAT_MASTER WHERE CATID = {0}";

                sql = String.Format(sql, param.Split('~'));

                int retval = objDB.ExecuteNonQuery(sql);

                if (retval == 1)
                {
                    lblMessg.Text = "Category deleted successfully";
                    Response.Write("<script language='javascript'> alert('Category deleted successfully'); </script>");
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

 
        protected void btnEnable_Click(object sender, EventArgs e)
        {
            if (txtPasswd.Text == "Categ0ry")
            {
                Session["MASTER"] = "1";
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnDel.Enabled = true;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["MASTER"] = null;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDel.Enabled = false;
        }

     }
