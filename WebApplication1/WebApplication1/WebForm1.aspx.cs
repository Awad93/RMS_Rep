using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string chartData_Cat { get; set; }
        public string chartData_Val { get; set; }

        #region Page Load events

        #region Page load + DDL Bind

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDLs();
            }
        }

        protected void BindDDLs()
        {
            #region Time span - From / To DDL
            for (int i = DateTime.Now.Year - 11; i < DateTime.Now.Year; i++)
                ddlFromYear.Items.Add(new ListItem(i.ToString(), i.ToString()));

            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 10; i--)
                ddlToYear.Items.Add(new ListItem(i.ToString(), i.ToString()));

            #endregion

            #region College            
            ddlCollege.DataSource = DepartmentController.getAllColleges();
            ddlCollege.DataTextField = Department.Department_Name;
            ddlCollege.DataValueField = Department.Department_Code;     
            ddlCollege.DataBind();
            ddlCollege.Items.Insert(0, new ListItem("--All--", "All"));
            #endregion

            ddlDepartment.Items.Insert(0, new ListItem("Please select a College...", "0"));

        }

        #endregion

        #region DDL -> Selected Index Changed

        protected void rblClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblClass.SelectedItem.Value.Equals("ISI"))
            {
                divType_ISI.Attributes.Add("class", divType_ISI.Attributes["class"].Replace("hide", "show"));

                divType_NonISI.Attributes.Add("class", divType_NonISI.Attributes["class"].Replace("show", "hide"));
            }
            else
            {
                divType_NonISI.Attributes.Add("class", divType_NonISI.Attributes["class"].Replace("hide", "show"));

                divType_ISI.Attributes.Add("class", divType_ISI.Attributes["class"].Replace("show", "hide"));
            }
        }

        protected void ddlCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCollege.SelectedItem.Value != "0")
            {
                ddlDepartment.Enabled = true;
                ddlDepartment.DataSource = DepartmentController.getDepartmentsByCollege(ddlCollege.SelectedItem.Value);
                ddlDepartment.DataTextField = Department.Department_Name;
                ddlDepartment.DataValueField = Department.Department_Code;                          
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem("--All--", "All"));
            }
            else
            {
                ddlDepartment.Items.Clear();
                ddlDepartment.Enabled = false;
            }
        }

        protected void ddlTimeSpan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTimeSpan.SelectedItem.Value.Equals("Last5Years"))
                {
                    rbPeriod.Checked = false;
                    rbPeriodRange.Checked = true;

                    ddlFromYear.SelectedItem.Text = ((DateTime.Now.Year - 5).ToString());
                    ddlToYear.SelectedItem.Text = (DateTime.Now.Year.ToString());
                }
                else if (ddlTimeSpan.SelectedItem.Value.Equals("LastYear"))
                {
                    rbPeriod.Checked = false;
                    rbPeriodRange.Checked = true;

                    ddlFromYear.SelectedItem.Text = ((DateTime.Now.Year - 1).ToString());
                    ddlToYear.SelectedItem.Text = (DateTime.Now.Year.ToString());
                }
                else if (ddlTimeSpan.SelectedItem.Value.Equals("All"))
                {
                    rbPeriod.Checked = true;
                    rbPeriodRange.Checked = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #endregion

        #region Button Click

        //protected void btnGenerate_Click(object sender, EventArgs e)
        //{
        //    #region Show papers
        //    rptArticles.DataSource = Publication_ISIController.GetAllISIPublicationsForAllDocTypes();
        //    rptArticles.DataBind();
        //    #endregion

        //    DataTable dt = new DataTable();

        //    #region First Option - All Years
        //    if (rbPeriod.Checked)
        //    {
        //        #region ISI
        //        if (rblClass.SelectedItem.Value.Equals("ISI"))
        //        {
        //            if (ddlCollege.SelectedItem.Value.Equals("All"))
        //                dt = Publication_ISIController.GetStatsForISIPublicationsForAllDocTypesAllCollegesAllYears();
        //            else if (ddlDepartment.SelectedItem.Value.Equals("All"))
        //                dt = Publication_ISIController.GetStatsForISIPublicationsForAllDocTypesSingleCollegeAllYears(ddlCollege.SelectedItem.Value);
        //            else
        //                dt = Publication_ISIController.GetStatsForISIPublicationsForAllDocTypesSingleDepartmentAllYears(ddlDepartment.SelectedItem.Value);
        //        }
        //        #endregion

        //        #region Non-ISI
        //        TODO
        //        #endregion
        //    }
        //    #endregion
        //    #region Second Option - Time Period
        //    else
        //    {
        //        TO DO
        //        dt = Publication_ISIController.GetStatsForISIPublicationsForAllDocTypesAllCollegesAllYears();

        //    }
        //    #endregion

        //    #region Get x/y coordinate vales from Database
        //    List<int> _dataCat = new List<int>();
        //    List<int> _data1Val = new List<int>();
        //    foreach (DataRow dr1 in dt.Rows)
        //    {
        //        _dataCat.Add((int)dr1["publication_year"]);
        //        _data1Val.Add((int)dr1["Publication_Count"]);

        //    }
        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    chartData_Cat = jss.Serialize(_dataCat); //this make your list in jSON format like [88,99,10]
        //    chartData_Val = jss.Serialize(_data1Val);
        //    #endregion

        //    string strChart = CreateChart("All College Publications - All Years ", "123", "Years", "Publication Count", "All Colleges");

        //    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "myFunction", strChart, true);

        //    divResults.Style.Add("display", "block");
        //}

        //protected string CreateChart(string strChartTitle, string strChartSubTitle, string strXAxisTitle, string strYAxisTitle, string strSeriesName)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine("         <!-- HIGHCHART SCRIPT STARTS HERE --> ");
        //    sb.AppendLine("                 var chart = new Highcharts.Chart({");
        //    sb.AppendLine("                                                 chart: {  ");
        //    sb.AppendLine("                                                         type: 'column' ,");
        //    sb.AppendLine("                                                         renderTo: 'container_highchart'");
        //    sb.AppendLine("                                                     },  ");
        //    sb.AppendLine("                                                 title: {  ");
        //    sb.AppendLine("                                                         text: '" + strChartTitle + "'  ");
        //    sb.AppendLine("                                                     },  ");
        //    sb.AppendLine("                                                 subtitle: {  ");
        //    sb.AppendLine("                                                         text: '" + strChartSubTitle + "'  ");
        //    sb.AppendLine("                                                     },  ");
        //    sb.AppendLine("                                                 xAxis: {  ");
        //    sb.AppendLine("                                                         title: {  ");
        //    sb.AppendLine("                                                                 text: '" + strXAxisTitle + "'");
        //    sb.AppendLine("                                                             }, ");
        //    sb.AppendLine("                                                         labels:{");
        //    sb.AppendLine("                                                                 rotation: 0,");
        //    sb.AppendLine("                                                                 y:15");
        //    sb.AppendLine("                                                             },");
        //    sb.AppendLine("                                                         categories: " + chartData_Cat);
        //    sb.AppendLine("                                                     },  ");
        //    sb.AppendLine("                                                 yAxis: {  ");
        //    sb.AppendLine("                                                         linewidth : 1,");
        //    sb.AppendLine("                                                         gridLineWidth: 1,");
        //    sb.AppendLine("                                                         min: 0,  ");
        //    sb.AppendLine("                                                         title: {  ");
        //    sb.AppendLine("                                                                 text: '" + strYAxisTitle + "'  ");
        //    sb.AppendLine("                                                             }");
        //    sb.AppendLine("                                                     },  ");
        //    sb.AppendLine("                                                 tooltip: {  ");
        //    sb.AppendLine("                                                         headerFormat: '<span style=\"font-size:10px;\">{point.key}</span><table>',  ");
        //    sb.AppendLine("                                                         pointFormat: '<tr><td style=\"color:{series.color};padding:0\">{series.name}: </td>' + '<td style=\"padding:0\"><b>{point.y} </b></td></tr>',  ");
        //    sb.AppendLine("                                                         footerFormat: '</table>',  ");
        //    sb.AppendLine("                                                         shared: true,  ");
        //    sb.AppendLine("                                                         useHTML: true  ");
        //    sb.AppendLine("                                                     },  ");
        //    sb.AppendLine("                                                 plotOptions: {  ");
        //    sb.AppendLine("                                                         column: {  ");
        //    sb.AppendLine("                                                                 pointPadding: 0,  ");
        //    sb.AppendLine("                                                                 borderWidth: 0  ");
        //    sb.AppendLine("                                                             }");
        //    sb.AppendLine("                                                     },");
        //    sb.AppendLine("                                                 series: [{");
        //    sb.AppendLine("                                                         name: '" + strSeriesName + "',");
        //    sb.AppendLine("                                                         data: " + chartData_Val + ",");
        //    sb.AppendLine("                                                         dataLabels: {");
        //    sb.AppendLine("                                                                     enabled: true,");
        //    sb.AppendLine("                                                                     rotation: 0,");
        //    sb.AppendLine("                                                                     color: '#000000',");
        //    sb.AppendLine("                                                                     align: 'top',");
        //    sb.AppendLine("                                                                     x: 1,");
        //    sb.AppendLine("                                                                     y: 5");
        //    sb.AppendLine("                                                                 }");
        //    sb.AppendLine("                                                         }]    ");
        //    sb.AppendLine("                                     });  ");
        //    sb.AppendLine("             <!-- HIGHCHART SCRIPT ENDS HERE -->");

        //    return sb.ToString();
        //}

        //protected void rptArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        ((HtmlButton)e.Item.FindControl("lblPaperTItle")).InnerText = (e.Item.ItemIndex + 1).ToString() + ". " + ((Publication_ISIController)e.Item.DataItem).Paper_Title;
        //        string strDataTargetID = "#h" + e.Item.ItemIndex.ToString();
        //        ((HtmlButton)e.Item.FindControl("lblPaperTItle")).Attributes.Add("onclick", "$('" + strDataTargetID + "').slideToggle(\"slow\")");

        //        ((Label)e.Item.FindControl("lblWOSNumber")).Text = ((Publication_ISIController)e.Item.DataItem).WOS_Number;
        //        ((Label)e.Item.FindControl("lblPublicationYear")).Text = ((Publication_ISIController)e.Item.DataItem).Publication_Year.ToString();
        //    }
        //}

        #endregion
    }
}