using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;
using System.Text;
using System.Web.Script.Serialization;

namespace WebApplication1
{
    public partial class admin_page_test2 : System.Web.UI.Page
    {
        #region Fields
        int numOfBooks;
        int numOfISIPublications;
        int numOfNonISIPublications;
        int publication_year = 0;
        StringBuilder str = new StringBuilder();
        string chartData_Cat;
        string chartData_Val;
        List<string> seriesData_Vals;
        #endregion

        #region Repeater Events
        #region Repeater: Publications
        //protected void repeaterISIPublicationsYears_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        HtmlAnchor ISI_Year = (HtmlAnchor)e.Item.FindControl("ISI_Year");
        //        ISI_Year.Attributes.Add("href", "#" + ((HtmlGenericControl)e.Item.FindControl("ISI_Year_Entry")).ClientID);

        //        if ((DataBinder.Eval(e.Item.DataItem, "Publication_Year") != null))
        //            ((Literal)e.Item.FindControl("ltrlYear")).Text = (DataBinder.Eval(e.Item.DataItem, "Publication_Year")).ToString(); ;

        //        int Publication_Year = (int)(DataBinder.Eval(e.Item.DataItem, "Publication_Year"));
        //        List<Models.rms_Publications_ISI> Publications = Models.rms_Publications_ISI.getISIPublicationsByYear((Publication_Year));
        //        Repeater repeaterISIPublicationsByYear = (Repeater)e.Item.FindControl("repeaterISIPublicationsByYear");
        //        repeaterISIPublicationsByYear.DataSource = Publications;
        //        repeaterISIPublicationsByYear.DataBind();
        //    }
        //}
        //protected void repeaterISIPublicationsByYear_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        HtmlGenericControl ISIEntry = (HtmlGenericControl)e.Item.FindControl("ISIEntry");
        //        ISIEntry.Attributes.Add("href", "#" + ((HtmlGenericControl)e.Item.FindControl("ISIEntry_Showmore")).ClientID);

        //        if ((DataBinder.Eval(e.Item.DataItem, "Paper_Title") != null))
        //            ((Literal)e.Item.FindControl("ltrlPaperTitle")).Text = (DataBinder.Eval(e.Item.DataItem, "Paper_Title")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Authors") != null))
        //            ((Literal)e.Item.FindControl("ltrlAuthors")).Text = (DataBinder.Eval(e.Item.DataItem, "Authors")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Publication_Year") != null))
        //            ((Literal)e.Item.FindControl("ltrlPublicationYear")).Text = (DataBinder.Eval(e.Item.DataItem, "Publication_Year")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "WOS_Number") != null))
        //            ((Literal)e.Item.FindControl("ltrlWOS")).Text = (DataBinder.Eval(e.Item.DataItem, "WOS_Number")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Publication_Date") != null))
        //            ((Literal)e.Item.FindControl("ltrlDate")).Text = (DataBinder.Eval(e.Item.DataItem, "Publication_Date")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Source") != null))
        //            ((Literal)e.Item.FindControl("ltrlJournal")).Text = (DataBinder.Eval(e.Item.DataItem, "Source")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Wide_Category") != null))
        //            ((Literal)e.Item.FindControl("ltrlArea")).Text = (DataBinder.Eval(e.Item.DataItem, "Wide_Category")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Keywords") != null))
        //            ((Literal)e.Item.FindControl("ltrlKeywords")).Text = (DataBinder.Eval(e.Item.DataItem, "Keywords")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Abstract") != null))
        //            ((Literal)e.Item.FindControl("ltrlAbstract")).Text = (DataBinder.Eval(e.Item.DataItem, "Abstract")).ToString();
        //    }
        //}

        protected void repeaterISIPublications_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string not_first_loop = "</ul>";
            if (e.Item.ItemType == ListItemType.Header)
            {
                ((Label)e.Item.FindControl("lblTotalPublications")).Text = numOfISIPublications + "";
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (publication_year == 0)
                {
                    not_first_loop = "";
                }
                int current_publication_year = (int)(DataBinder.Eval(e.Item.DataItem, "Publication_Year"));
                if (current_publication_year != publication_year)
                {
                    ((Literal)e.Item.FindControl("ltrlYear")).Text = not_first_loop + "<li><a data-toggle='collapse' href='#YearlyList"
                        //+ ((HtmlGenericControl)e.Item.FindControl("YearlyList")).ClientID
                        + current_publication_year
                        + "'>" + current_publication_year + "</a></li>"
                        + "<ul id='YearlyList" + current_publication_year + "' class='result collapse'>";
                    publication_year = current_publication_year;
                }

                HtmlGenericControl ISIEntry = (HtmlGenericControl)e.Item.FindControl("ISIEntry");
                ISIEntry.Attributes.Add("href", "#" + ((HtmlGenericControl)e.Item.FindControl("ISIEntry_Showmore")).ClientID);

                if ((DataBinder.Eval(e.Item.DataItem, "Paper_Title") != null))
                    ((Literal)e.Item.FindControl("ltrlPaperTitle")).Text = (DataBinder.Eval(e.Item.DataItem, "Paper_Title")).ToString();
                if ((DataBinder.Eval(e.Item.DataItem, "Authors") != null))
                    ((Literal)e.Item.FindControl("ltrlAuthors")).Text = (DataBinder.Eval(e.Item.DataItem, "Authors")).ToString();
                if ((DataBinder.Eval(e.Item.DataItem, "Wide_Category") != null))
                    ((Literal)e.Item.FindControl("ltrlWideCategory")).Text = (DataBinder.Eval(e.Item.DataItem, "Wide_Category")).ToString();
                if ((DataBinder.Eval(e.Item.DataItem, "WOS_Number") != null))
                    ((Literal)e.Item.FindControl("ltrlWOS")).Text = (DataBinder.Eval(e.Item.DataItem, "WOS_Number")).ToString();
                if ((DataBinder.Eval(e.Item.DataItem, "Publication_Date") != null))
                    ((Literal)e.Item.FindControl("ltrlDate")).Text = (DataBinder.Eval(e.Item.DataItem, "Publication_Date")).ToString();
                if ((DataBinder.Eval(e.Item.DataItem, "Source") != null))
                    ((Literal)e.Item.FindControl("ltrlJournal")).Text = (DataBinder.Eval(e.Item.DataItem, "Source")).ToString();
                if ((DataBinder.Eval(e.Item.DataItem, "Subject_Category") != null))
                    ((Literal)e.Item.FindControl("ltrlArea")).Text = (DataBinder.Eval(e.Item.DataItem, "Subject_Category")).ToString();
                if ((DataBinder.Eval(e.Item.DataItem, "Keywords") != null))
                    ((Literal)e.Item.FindControl("ltrlKeywords")).Text = (DataBinder.Eval(e.Item.DataItem, "Keywords")).ToString();
                if ((DataBinder.Eval(e.Item.DataItem, "Abstract") != null))
                    ((Literal)e.Item.FindControl("ltrlAbstract")).Text = (DataBinder.Eval(e.Item.DataItem, "Abstract")).ToString();
            }
            if (e.Item.ItemType == ListItemType.Footer)
            {
                if (publication_year == 0)
                    not_first_loop = "";
                ((Literal)e.Item.FindControl("ltrlDone")).Text = not_first_loop;
            }

        }
        //protected void repeaterISIPublications_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Header)
        //    {
        //        ((Label)e.Item.FindControl("lblTotalPublications")).Text = numOfISIPublications + "";
        //    }
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        HtmlGenericControl ISIEntry = (HtmlGenericControl)e.Item.FindControl("ISIEntry");               
        //        ISIEntry.Attributes.Add("href", "#"+((HtmlGenericControl)e.Item.FindControl("ISIEntry_Showmore")).ClientID);                

        //        if ((DataBinder.Eval(e.Item.DataItem, "Paper_Title") != null))
        //            ((Literal)e.Item.FindControl("ltrlPaperTitle")).Text = (DataBinder.Eval(e.Item.DataItem, "Paper_Title")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Authors") != null))
        //            ((Literal)e.Item.FindControl("ltrlAuthors")).Text = (DataBinder.Eval(e.Item.DataItem, "Authors")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Publication_Year") != null))
        //            ((Literal)e.Item.FindControl("ltrlPublicationYear")).Text = (DataBinder.Eval(e.Item.DataItem, "Publication_Year")).ToString();
        //        if((DataBinder.Eval(e.Item.DataItem, "WOS_Number") != null))
        //            ((Literal)e.Item.FindControl("ltrlWOS")).Text = (DataBinder.Eval(e.Item.DataItem, "WOS_Number")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Publication_Date") != null))
        //            ((Literal)e.Item.FindControl("ltrlDate")).Text = (DataBinder.Eval(e.Item.DataItem, "Publication_Date")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Source") != null))
        //            ((Literal)e.Item.FindControl("ltrlJournal")).Text = (DataBinder.Eval(e.Item.DataItem, "Source")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Wide_Category") != null))
        //            ((Literal)e.Item.FindControl("ltrlArea")).Text = (DataBinder.Eval(e.Item.DataItem, "Wide_Category")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Keywords") != null))
        //            ((Literal)e.Item.FindControl("ltrlKeywords")).Text = (DataBinder.Eval(e.Item.DataItem, "Keywords")).ToString();
        //        if ((DataBinder.Eval(e.Item.DataItem, "Abstract") != null))
        //            ((Literal)e.Item.FindControl("ltrlAbstract")).Text = (DataBinder.Eval(e.Item.DataItem, "Abstract")).ToString();
        //    }
        //}
        protected void repeaterNonISIPublications_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                ((Label)e.Item.FindControl("lblTotalPublications")).Text = numOfNonISIPublications + "";
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if ((DataBinder.Eval(e.Item.DataItem, "Paper_Title") != null))
                    ((Literal)e.Item.FindControl("ltrlPaperTitle")).Text = (DataBinder.Eval(e.Item.DataItem, "Paper_Title")).ToString(); ;
                if ((DataBinder.Eval(e.Item.DataItem, "Authors") != null))
                    ((Literal)e.Item.FindControl("ltrlAuthors")).Text = (DataBinder.Eval(e.Item.DataItem, "Authors")).ToString();
                if ((DataBinder.Eval(e.Item.DataItem, "Publication_Year") != null))
                    ((Literal)e.Item.FindControl("ltrlPublicationYear")).Text = (DataBinder.Eval(e.Item.DataItem, "Publication_Year")).ToString();
            }
        }
        protected void repeaterBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                ((Label)e.Item.FindControl("lblTotalBooks")).Text = numOfBooks + "";
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if ((DataBinder.Eval(e.Item.DataItem, "Book_Title") != null))
                    ((Literal)e.Item.FindControl("ltrlBookTitle")).Text = (DataBinder.Eval(e.Item.DataItem, "Book_Title")).ToString(); ;
                if ((DataBinder.Eval(e.Item.DataItem, "Authors") != null))
                    ((Literal)e.Item.FindControl("ltrlAuthors")).Text = (DataBinder.Eval(e.Item.DataItem, "Authors")).ToString();
                if ((DataBinder.Eval(e.Item.DataItem, "Publication_Year") != null))
                    ((Literal)e.Item.FindControl("ltrlPublicationYear")).Text = (DataBinder.Eval(e.Item.DataItem, "Publication_Year")).ToString();
            }
        }
        #endregion
        #region Repeater: Departments
        protected void repeaterColleges_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if ((DataBinder.Eval(e.Item.DataItem, "Department_Name") != null))
                    ((Literal)e.Item.FindControl("ltrlCollege")).Text = (DataBinder.Eval(e.Item.DataItem, "Department_Name")).ToString();
                if ((DataBinder.Eval(e.Item.DataItem, "Department_Code") != null))
                {
                    string Department_Code = (DataBinder.Eval(e.Item.DataItem, "Department_Code")).ToString();
                    List<Models.rms_Departments> Departments = Models.rms_Departments.getDepartmentsByCollege(Department_Code);
                    Repeater repeaterDepartments = (Repeater)e.Item.FindControl("repeaterDepartments");
                    repeaterDepartments.DataSource = Departments;
                    repeaterDepartments.DataBind();
                }
            }
        }

        protected void repeaterDepartments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if ((DataBinder.Eval(e.Item.DataItem, "Department_Name") != null))
                    ((Literal)e.Item.FindControl("ltrlDepartment")).Text = (DataBinder.Eval(e.Item.DataItem, "Department_Name")).ToString();
            }
        }
        #endregion
        #region Repeater: Faculty
        protected void repeaterFaculty_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if ((DataBinder.Eval(e.Item.DataItem, "Full_Name") != null))
                {
                    ((HtmlAnchor)e.Item.FindControl("aFaculty")).InnerHtml = (DataBinder.Eval(e.Item.DataItem, "Full_Name")).ToString();
                }
                if ((DataBinder.Eval(e.Item.DataItem, "KFUPMID")) != null)
                    ((HiddenField)e.Item.FindControl("hfvKFUPMID")).Value = (DataBinder.Eval(e.Item.DataItem, "KFUPMID")).ToString();
            }
        }
        protected void repeaterFaculty_filter_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((Literal)e.Item.FindControl("ltrlCharacter")).Text = "<a onclick='document.getElementById(\"hfvFirstChar\").setAttribute(\"Value\",\""
                    + e.Item.DataItem.ToString() + "\");"
                    + "document.getElementById(\"btnFacultyFilter\").click();'>" + e.Item.DataItem.ToString() + "</a>";
            }
        }
        #endregion
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Get Colleges
                List<Models.rms_Departments> Colleges = Models.rms_Departments.getAllColleges();
                repeaterColleges.DataSource = Colleges;
                repeaterColleges.DataBind();
                #endregion

                #region Get Books            
                List<Models.rms_Books_Authored> Books = Models.rms_Books_Authored.getAllBooks();
                // Get the total number of books
                numOfBooks = Books.Count;

                repeaterBooks.DataSource = Books;
                repeaterBooks.DataBind();
                #endregion

                #region Get ISI Publications
                //List<Models.rms_Publications_ISI> ISIPublications = Models.rms_Publications_ISI.getAllISIPublications();
                //numOfISIPublications = ISIPublications.Count;

                //repeaterISIPublications.DataSource = ISIPublications;
                //repeaterISIPublications.DataBind();
                //DataTable ISIPublications = Models.rms_Publications_ISI.getYearsOfISIPublicationsByCollege("CCSE");
                //repeaterISIPublicationsYears.DataSource = ISIPublications;
                //repeaterISIPublicationsYears.DataBind();
                #endregion

                #region Get NonISI Publications
                List<Models.rms_Publications_NonISI> NonISIPublications = Models.rms_Publications_NonISI.getNonISIPublicationsByCollege("CCSE");
                numOfNonISIPublications = NonISIPublications.Count;

                repeaterNonISIPublications.DataSource = NonISIPublications;
                repeaterNonISIPublications.DataBind();
                #endregion

                #region Get Faculty
                List<Models.rms_Researchers> Researchers = Models.rms_Researchers.getAllFaculty('A');
                repeaterFaculty.DataSource = Researchers;
                repeaterFaculty.DataBind();

                char[] unicodes = new char[26];
                for (int i = 0; i < 26; i++)
                    unicodes[i] = (char)(i + 65);
                repeaterFaculty_filter.DataSource = unicodes;
                repeaterFaculty_filter.DataBind();
                #endregion

                #region Navigate
                //string parameter = Request["__EVENTARGUMENT"];
                //if (parameter != null)
                //{
                //    Books = Models.rms_Books_Authored.getBooksByCollege(parameter);
                //    // Get the total number of books
                //    numOfBooks = Books.Count;

                //    repeaterBooks.DataSource = Books;
                //    repeaterBooks.DataBind();
                //}
                #endregion
            }
        }

        #region UpdateMainPanel Events
        //protected void college_event(object sender, EventArgs e)
        //{
        //    string code = hfvTest.Value;

        //    ltrlCollege.Text = "<li><a>" + code + "</a></li>";
        //    ltrlDepartment.Text = "";
        //    ltrlFaculty.Text = "";

        //    List<Models.rms_Books_Authored> Books = Models.rms_Books_Authored.getBooksByCollege(code);
        //    List<Models.rms_Publications_ISI> ISIPublications = Models.rms_Publications_ISI.getISIPublicationsByCollege(code);
        //    List<Models.rms_Publications_NonISI> NonISIPublications = Models.rms_Publications_NonISI.getNonISIPublicationsByCollege(code);
        //    List<Models.rms_Researchers> Faculty = Models.rms_Researchers.getFacultyByCollege(code);

        //    BindRepeaters(Books, ISIPublications, NonISIPublications, Faculty);
        //}
        //protected void department_event(object sender, EventArgs e)
        //{
        //    string code = hfvTest.Value;

        //    ltrlDepartment.Text = "<li><a>" + code + "</a></li>";
        //    ltrlFaculty.Text = "";

        //    List<Models.rms_Books_Authored> Books = Models.rms_Books_Authored.getBooksByDepartment(code);
        //    List<Models.rms_Publications_ISI> ISIPublications = Models.rms_Publications_ISI.getISIPublicationsByDepartment(code);
        //    List<Models.rms_Publications_NonISI> NonISIPublications = Models.rms_Publications_NonISI.getNonISIPublicationsByDepartment(code);
        //    List<Models.rms_Researchers> Faculty = Models.rms_Researchers.getFacultyByCollege(code);

        //    BindRepeaters(Books, ISIPublications, NonISIPublications, Faculty);
        //}
        protected void btnDepartment_OnClick(object sender, EventArgs e)
        {
            string code = hfvDepartmentCode.Value;
            if (hfvDepartmentType.Value == "COLLEGE")
            {
                ltrlCollege.Text = "<li><a>" + code + "</a></li>";
                ltrlDepartment.Text = "";
                ltrlFaculty.Text = "";
                hfvIsFaculty.Value = "FALSE";

                List<Models.rms_Books_Authored> Books = Models.rms_Books_Authored.getBooksByCollege(code);
                List<Models.rms_Publications_ISI> ISIPublications = Models.rms_Publications_ISI.getISIPublicationsByCollege(code);
                List<Models.rms_Publications_NonISI> NonISIPublications = Models.rms_Publications_NonISI.getNonISIPublicationsByCollege(code);
                List<Models.rms_Researchers> Faculty = Models.rms_Researchers.getFacultyByCollege(code, 'A');

                BindRepeaters(Books, ISIPublications, NonISIPublications, Faculty);
            }
            else if (hfvDepartmentType.Value == "DEPARTMENT")
            {
                ltrlDepartment.Text = "<li><a>" + code + "</a></li>";
                ltrlFaculty.Text = "";
                hfvIsFaculty.Value = "FALSE";

                List<Models.rms_Books_Authored> Books = Models.rms_Books_Authored.getBooksByDepartment(code);
                List<Models.rms_Publications_ISI> ISIPublications = Models.rms_Publications_ISI.getISIPublicationsByDepartment(code);
                List<Models.rms_Publications_NonISI> NonISIPublications = Models.rms_Publications_NonISI.getNonISIPublicationsByDepartment(code);
                List<Models.rms_Researchers> Faculty = Models.rms_Researchers.getFacultyByDepartment(code, 'A');

                BindRepeaters(Books, ISIPublications, NonISIPublications, Faculty);
            }
            UpdatePanel.Update();
        }
        protected void aFaculty_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((HiddenField)((HtmlAnchor)sender).FindControl("hfvKFUPMID")).Value);

            hfvFacultyID.Value = id.ToString();
            hfvIsFaculty.Value = "TRUE";

            ltrlFaculty.Text = "<li><a>" + ((HtmlAnchor)sender).InnerText + "</a></li>";

            List<Models.rms_Books_Authored> Books = Models.rms_Books_Authored.getBooksByFaculty(id);
            List<Models.rms_Publications_ISI> ISIPublications = Models.rms_Publications_ISI.getISIPublicationsByFaculty(id);
            List<Models.rms_Publications_NonISI> NonISIPublications = Models.rms_Publications_NonISI.getNonISIPublicationsByFaculty(id);

            BindRepeaters(Books, ISIPublications, NonISIPublications);
        }

        private void BindRepeaters(List<Models.rms_Books_Authored> Books,
            List<Models.rms_Publications_ISI> ISIPublications,
            List<Models.rms_Publications_NonISI> NonISIPublications,
            List<Models.rms_Researchers> Faculty)
        {
            // Get the total number of books and papers
            numOfBooks = Books.Count;
            numOfISIPublications = ISIPublications.Count;
            numOfNonISIPublications = NonISIPublications.Count;

            // Databind repeaters
            repeaterBooks.DataSource = Books;
            repeaterBooks.DataBind();

            repeaterISIPublications.DataSource = ISIPublications;
            repeaterISIPublications.DataBind();
            //repeaterISIPublicationsYears.DataSource = ISIPublications;
            //repeaterISIPublicationsYears.DataBind();

            repeaterNonISIPublications.DataSource = NonISIPublications;
            repeaterNonISIPublications.DataBind();

            repeaterFaculty.DataSource = Faculty;
            repeaterFaculty.DataBind();

            DisplayChart();

            UpdatePanel.Update();
        }
        private void BindRepeaters(List<Models.rms_Books_Authored> Books,
            List<Models.rms_Publications_ISI> ISIPublications,
            List<Models.rms_Publications_NonISI> NonISIPublications)
        {
            // Get the total number of books and papers
            numOfBooks = Books.Count;
            numOfISIPublications = ISIPublications.Count;
            numOfNonISIPublications = NonISIPublications.Count;

            // Databind repeaters
            repeaterBooks.DataSource = Books;
            repeaterBooks.DataBind();

            repeaterISIPublications.DataSource = ISIPublications;
            repeaterISIPublications.DataBind();
            //repeaterISIPublicationsYears.DataSource = ISIPublications;
            //repeaterISIPublicationsYears.DataBind();

            repeaterNonISIPublications.DataSource = NonISIPublications;
            repeaterNonISIPublications.DataBind();

            DisplayChart();

            UpdatePanel.Update();
        }
        #endregion

        #region UpdateFacultyPanel Events
        protected void btnSearchFaculty_Click(object sender, EventArgs e)
        {
            List<Models.rms_Researchers> Researchers;
            string search_value = ((HtmlInputControl)((HtmlButton)sender).FindControl("inptSearchBar")).Value;
            if (hfvDepartmentType.Value == "COLLEGE")
            {
                string code = hfvDepartmentCode.Value;
                Researchers = Models.rms_Researchers.SearchFacultyByCollege(code, search_value);
            }
            else if (hfvDepartmentType.Value == "DEPARTMENT")
            {
                string code = hfvDepartmentCode.Value;
                Researchers = Models.rms_Researchers.SearchFacultyByDepartment(code, search_value);
            }
            else
            {
                Researchers = Models.rms_Researchers.SearchFaculty(search_value);
            }

            repeaterFaculty.DataSource = Researchers;
            repeaterFaculty.DataBind();

        }
        protected void btnFacultyFilter_OnClick(object sender, EventArgs e)
        {
            List<Models.rms_Researchers> Researchers;
            char c = hfvFirstChar.Value[0];
            if (hfvDepartmentType.Value == "COLLEGE")
            {
                string code = hfvDepartmentCode.Value;
                Researchers = Models.rms_Researchers.getFacultyByCollege(code, c);
            }
            else if (hfvDepartmentType.Value == "DEPARTMENT")
            {
                string code = hfvDepartmentCode.Value;
                Researchers = Models.rms_Researchers.getFacultyByDepartment(code, c);
            }
            else
            {
                Researchers = Models.rms_Researchers.getAllFaculty(c);
            }

            repeaterFaculty.DataSource = Researchers;
            repeaterFaculty.DataBind();

            UpdateFacultyPanel.Update();
        }
        #endregion

        #region Chart
        protected void ddlChart_onChange(object sender, EventArgs e)
        {
            DisplayChart();
        }
        protected void DisplayChart()
        {
            DataTable dt = new DataTable();
            string value = ddlChart.SelectedValue;
            string code = hfvDepartmentCode.Value;
            string yaxis = "";
            string title = "";
            string subtitle = "";

            #region Check if page is for a college, department, or faculty
            dt = Models.Statistics.getPublicationStatistics(2007,2016);
            #endregion

            #region Get x/y coordinate values from Database
            List<int> _dataCat = new List<int>();
            List<int> _data1Val = new List<int>();
            List<double> _data2Val = new List<double>();
            List<int> _data3Val = new List<int>();
            List<int> _data4Val = new List<int>();
            foreach (DataRow dr1 in dt.Rows)
            {
                _dataCat.Add((int)dr1["Year"]);               
                _data1Val.Add((int)dr1["ISI"]);
                _data2Val.Add((double)dr1["Publication Points"]);
                _data3Val.Add((int)dr1["Non-ISI"]);
                _data4Val.Add((int)dr1["Books"]);

            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            chartData_Cat = jss.Serialize(_dataCat); //this make your list in jSON format like [88,99,10]
            chartData_Val = jss.Serialize(_data1Val);
            string seriesData_Val1 = jss.Serialize(_data1Val);
            string seriesData_Val2 = jss.Serialize(_data2Val);
            string seriesData_Val3 = jss.Serialize(_data3Val);
            string seriesData_Val4 = jss.Serialize(_data4Val);
            seriesData_Vals = new List<string>();
            seriesData_Vals.Add(seriesData_Val1);
            seriesData_Vals.Add(seriesData_Val2);
            seriesData_Vals.Add(seriesData_Val3);
            seriesData_Vals.Add(seriesData_Val4);

            #endregion

            string strChart = CreateChart(title, subtitle, "Years", yaxis, "All Colleges");

            ScriptManager.RegisterStartupScript(UpdatePanel.Page, this.GetType(), "myFunction", strChart, true);

        }
        protected string CreateChart(string strChartTitle, string strChartSubTitle, string strXAxisTitle, string strYAxisTitle, string strSeriesName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("         <!-- HIGHCHART SCRIPT STARTS HERE --> ");
            sb.AppendLine("                 var chart = new Highcharts.Chart({");
            sb.AppendLine("                                                 chart: {  ");
            sb.AppendLine("                                                         type: 'column' ,");
            sb.AppendLine("                                                         renderTo: 'mychart'");
            sb.AppendLine("                                                     },  ");
            sb.AppendLine("                                                 title: {  ");
            sb.AppendLine("                                                         text: '" + strChartTitle + "'  ");
            sb.AppendLine("                                                     },  ");
            sb.AppendLine("                                                 subtitle: {  ");
            sb.AppendLine("                                                         text: '" + strChartSubTitle + "'  ");
            sb.AppendLine("                                                     },  ");
            sb.AppendLine("                                                 xAxis: {  ");
            sb.AppendLine("                                                         title: {  ");
            sb.AppendLine("                                                                 text: '" + strXAxisTitle + "'");
            sb.AppendLine("                                                             }, ");
            sb.AppendLine("                                                         labels:{");
            sb.AppendLine("                                                                 rotation: 0,");
            sb.AppendLine("                                                                 y:15");
            sb.AppendLine("                                                             },");
            sb.AppendLine("                                                         categories: " + chartData_Cat);
            sb.AppendLine("                                                     },  ");
            sb.AppendLine("                                                 yAxis: {  ");
            sb.AppendLine("                                                         linewidth : 1,");
            sb.AppendLine("                                                         gridLineWidth: 1,");
            sb.AppendLine("                                                         min: 0,  ");
            sb.AppendLine("                                                         title: {  ");
            sb.AppendLine("                                                                 text: '" + strYAxisTitle + "'  ");
            sb.AppendLine("                                                             }");
            sb.AppendLine("                                                     },  ");
            sb.AppendLine("                                                 tooltip: {  ");
            sb.AppendLine("                                                         headerFormat: '<span style=\"font-size:10px;\">{point.key}</span><table>',  ");
            sb.AppendLine("                                                         pointFormat: '<tr><td style=\"color:{series.color};padding:0\">{series.name}: </td>' + '<td style=\"padding:0\"><b>{point.y} </b></td></tr>',  ");
            sb.AppendLine("                                                         footerFormat: '</table>',  ");
            sb.AppendLine("                                                         shared: true,  ");
            sb.AppendLine("                                                         useHTML: true  ");
            sb.AppendLine("                                                     },  ");
            sb.AppendLine("                                                 plotOptions: {  ");
            sb.AppendLine("                                                         column: {  ");
            sb.AppendLine("                                                                 pointPadding: 0,  ");
            sb.AppendLine("                                                                 borderWidth: 0  ");
            sb.AppendLine("                                                             }");
            sb.AppendLine("                                                     },");
            sb.AppendLine("                                                 series: [");  
            for(int i = 0; i < seriesData_Vals.Count; i++)
            {
                if (i > 0)
                    sb.Append(", ");
                sb.AppendLine("                                                         {name: '" + strSeriesName + i + "',");
                sb.AppendLine("                                                         data: " + seriesData_Vals.ElementAt(i) + ",");
                sb.AppendLine("                                                         dataLabels: {");
                sb.AppendLine("                                                                     enabled: true,");
                sb.AppendLine("                                                                     rotation: 0,");
                sb.AppendLine("                                                                     color: '#000000',");
                sb.AppendLine("                                                                     align: 'top',");
                sb.AppendLine("                                                                     x: 1,");
                sb.AppendLine("                                                                     y: 5");
                sb.AppendLine("                                                                 }");
                sb.AppendLine("                                                         }    ");
            }
            sb.AppendLine("                                                         ]    ");
            sb.AppendLine("                                     });  ");
            sb.AppendLine("             <!-- HIGHCHART SCRIPT ENDS HERE -->");

            return sb.ToString();
        }
    }

    #endregion
}