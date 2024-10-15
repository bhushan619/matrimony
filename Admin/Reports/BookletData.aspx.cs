using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Reports_BookletData : System.Web.UI.Page
{
    static string empdesig = string.Empty;
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../register/FranchiseeRegisterj.aspx';</script>");
            Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
           
 //getPackageData();
        }
       
    }
    public void getPackageData()
    {

        dbc.con.Open();
        MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT DISTINCT tblampackages.varPackageId, tblampackages.varPackageName, tblampackagesdetails.intId ,tblampackagesdetails.varPackageDescription, tblampackagesdetails.varPackageDuration, tblampackagesdetails.varPackagePrice, tblampackagesdetails.varBenifits, tblampackagesdetails.varPackageDurationTime FROM tblampackages INNER JOIN tblampackagesdetails ON tblampackages.varPackageId = tblampackagesdetails.varPackageId", dbc.con);
        DataSet ds1 = new DataSet();
        adp.Fill(ds1);
        lstViewPackage.DataSource = ds1;
        lstViewPackage.DataBind();
        dbc.con.Close();
    }
    protected void btnExportProduction_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dbc.con.Open();
        string queryStr = "SELECT DISTINCT  tblampackages.varPackageName as 'Package',tblampackagesdetails.varPackageDuration, tblampackagesdetails.varPackageDurationTime ,tblampackagesdetails.varPackagePrice,tblampackagesdetails.varPackageDescription, tblampackagesdetails.varBenifits  FROM tblampackages INNER JOIN tblampackagesdetails ON tblampackages.varPackageId = tblampackagesdetails.varPackageId";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt);
        ExportTableData(dt);
        dbc.con.Close();

    }
    public void ExportTableData(DataTable dtdata)
    {
        string attach = "attachment;filename=ViewPackage.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attach);
        Response.ContentType = "application/ms-excel";
        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write(dc.ColumnName + "\t");
                //sep = ";";
            }
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                  
                }
                Response.Write("\n");
                
            }
            Response.End();
        }
    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            Session.Add("packid", e.CommandArgument.ToString());
            Response.Redirect("EditPackage.aspx");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
}