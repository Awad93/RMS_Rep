using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Script.Serialization;
using Models;
using App_Code;

namespace WebApplication1
{
    public partial class admin_page_test : System.Web.UI.Page
    {
        #region Fields
        int numOfBooks;
        int numOfISIPublications;
        int numOfNonISIPublications;
        int publication_year = 0;
        StringBuilder str = new StringBuilder();
        string chartData_Cat;
        string chartData_Val;
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
                    List<DepartmentController> Departments = DepartmentController.getDepartmentsByCollege(Department_Code);
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
                List<DepartmentController> Colleges = DepartmentController.getAllColleges();
                repeaterColleges.DataSource = Colleges;
                repeaterColleges.DataBind();
                #endregion

                #region Get Books            
                List<Book_AuthoredController> Books = Book_AuthoredController.getBooksAll();
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
                List<Publication_NonISIController> NonISIPublications = Publication_NonISIController.getNonISIPublicationsByCollege("CCSE");
                numOfNonISIPublications = NonISIPublications.Count;

                repeaterNonISIPublications.DataSource = NonISIPublications;
                repeaterNonISIPublications.DataBind();
                #endregion

                #region Get Faculty
                List<ResearcherController> Researchers = ResearcherController.getFacultyByFirstCharacter('A');
                repeaterFaculty.DataSource = Researchers;
                repeaterFaculty.DataBind();

                char[] unicodes = new char[26];
                for (int i = 0; i < 26; i++)
                    unicodes[i] = (char)(i + 65);
                repeaterFaculty_filter.DataSource = unicodes;
                repeaterFaculty_filter.DataBind();
                #endregion

                #region Fill Statistics table
                getData();
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
        protected void btnDepartment_OnClick(object sender, EventArgs e)
        {
            string code = hfvDepartmentCode.Value;
            if (hfvDepartmentType.Value == "COLLEGE")
            {
                ltrlCollege.Text = "<li><a>" + code + "</a></li>";
                ltrlDepartment.Text = "";
                ltrlFaculty.Text = "";
                hfvIsFaculty.Value = "FALSE";

                List<Book_AuthoredController> Books = Book_AuthoredController.getBooksByCollege(code);
                List<Publication_ISIController> ISIPublications = Publication_ISIController.getISIPublicationsByCollege(code);
                List<Publication_NonISIController> NonISIPublications = Publication_NonISIController.getNonISIPublicationsByCollege(code);
                List<ResearcherController> Faculty = ResearcherController.getFacultyByCollegeAndFirstCharacter(code, 'A');

                BindRepeaters(Books, ISIPublications, NonISIPublications, Faculty);
            }
            else if (hfvDepartmentType.Value == "DEPARTMENT")
            {
                ltrlDepartment.Text = "<li><a>" + code + "</a></li>";
                ltrlFaculty.Text = "";
                hfvIsFaculty.Value = "FALSE";

                List<Book_AuthoredController> Books = Book_AuthoredController.getBooksByDepartment(code);
                List<Publication_ISIController> ISIPublications = Publication_ISIController.getISIPublicationsByDepartment(code);
                List<Publication_NonISIController> NonISIPublications = Publication_NonISIController.getNonISIPublicationsByDepartment(code);
                List<ResearcherController> Faculty = ResearcherController.getFacultyByDepartmentAndFirstCharacter(code, 'A');

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

            List<Book_AuthoredController> Books = Book_AuthoredController.getBooksByFaculty(id);
            List<Publication_ISIController> ISIPublications = Publication_ISIController.getISIPublicationsByFaculty(id);
            List<Publication_NonISIController> NonISIPublications = Publication_NonISIController.getNonISIPublicationsByFaculty(id);

            BindRepeaters(Books, ISIPublications, NonISIPublications);
        }

        private void BindRepeaters(List<Book_AuthoredController> Books,
            List<Publication_ISIController> ISIPublications,
            List<Publication_NonISIController> NonISIPublications,
            List<ResearcherController> Faculty)
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
        private void BindRepeaters(List<Book_AuthoredController> Books,
            List<Publication_ISIController> ISIPublications,
            List<Publication_NonISIController> NonISIPublications)
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
            List<ResearcherController> Researchers;
            string search_value = ((HtmlInputControl)((HtmlButton)sender).FindControl("inptSearchBar")).Value;
            if (hfvDepartmentType.Value == "COLLEGE")
            {
                string code = hfvDepartmentCode.Value;
                Researchers = ResearcherController.SearchFacultyByNameAndCollege(search_value, code);
            }
            else if (hfvDepartmentType.Value == "DEPARTMENT")
            {
                string code = hfvDepartmentCode.Value;
                Researchers = ResearcherController.SearchFacultyByNameAndDepartment(search_value, code);
            }
            else
            {
                Researchers = ResearcherController.SearchFacultyByName(search_value);
            }

            repeaterFaculty.DataSource = Researchers;
            repeaterFaculty.DataBind();

        }
        protected void btnFacultyFilter_OnClick(object sender, EventArgs e)
        {
            List<ResearcherController> Researchers;
            char c = hfvFirstChar.Value[0];
            if (hfvDepartmentType.Value == "COLLEGE")
            {
                string code = hfvDepartmentCode.Value;
                Researchers = ResearcherController.getFacultyByCollegeAndFirstCharacter(code, c);
            }
            else if (hfvDepartmentType.Value == "DEPARTMENT")
            {
                string code = hfvDepartmentCode.Value;
                Researchers = ResearcherController.getFacultyByDepartmentAndFirstCharacter(code, c);
            }
            else
            {
                Researchers = ResearcherController.getFacultyByFirstCharacter(c);
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
            if (hfvIsFaculty.Value == "TRUE")
            {
                title = ltrlFaculty.Text;
                subtitle = "Faculty";
                if (value.Equals("pp"))
                {
                    yaxis = "Publication Points";                    
                    dt = Publication_ISI_AuthorController.GetStatsForPublicationPointsByFaculty(Convert.ToInt32(hfvFacultyID.Value));
                }
                else if (value.Equals("isi"))
                {
                    yaxis = "Publications";
                    dt = Publication_ISIController.getStatsForISIPublicationsByFaculty(Convert.ToInt32(hfvFacultyID.Value));
                }
            }
            else if (hfvDepartmentType.Value == "COLLEGE")
            {
                if (value.Equals("pp"))
                {
                    yaxis = "Publication Points";
                    dt = Publication_ISI_AuthorController.GetStatsForPublicationPointsByCollege(code);
                }
                else if (value.Equals("isi"))
                {
                    yaxis = "Publications";
                    dt = Publication_ISIController.getStatsForISIPublicationsByCollege(code);
                }
            }
            else if (hfvDepartmentType.Value == "DEPARTMENT")
            {
                if (value.Equals("pp"))
                {
                    yaxis = "Publication Points";
                    dt = Publication_ISI_AuthorController.GetStatsForPublicationPointsByDepartment(code);
                }
                else if (value.Equals("isi"))
                {
                    yaxis = "Publications";
                    dt = Publication_ISIController.getStatsForISIPublicationsByDepartment(code);
                }
            }
            else
            {
                if (value.Equals("pp"))
                {
                    yaxis = "Publication Points";
                    dt = Publication_ISI_AuthorController.GetStatsForPublicationPoints();
                }
                if (value.Equals("isi"))
                {
                    yaxis = "Publications";
                    dt = Publication_ISIController.getStatsForISIPublications();
                }
            }
            #endregion

            #region Get x/y coordinate values from Database
            List<int> _dataCat = new List<int>();
            List<double> _data1Val = new List<double>();
            foreach (DataRow dr1 in dt.Rows)
            {
                _dataCat.Add((int)dr1["Year"]);
                if (yaxis == "Publication Points")
                    _data1Val.Add((double)dr1[yaxis]);
                else if (yaxis == "Publications")
                    _data1Val.Add((int)dr1[yaxis]);

            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            chartData_Cat = jss.Serialize(_dataCat); //this make your list in jSON format like [88,99,10]
            chartData_Val = jss.Serialize(_data1Val);
            #endregion

            string strChart = CreateChart(title, subtitle, "Years", yaxis, "All Colleges");

            ScriptManager.RegisterStartupScript(UpdatePanel, this.GetType(), "myFunction", strChart, true);

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
            sb.AppendLine("                                                 series: [{");
            sb.AppendLine("                                                         name: '" + strSeriesName + "',");
            sb.AppendLine("                                                         data: " + chartData_Val + ",");
            sb.AppendLine("                                                         dataLabels: {");
            sb.AppendLine("                                                                     enabled: true,");
            sb.AppendLine("                                                                     rotation: 0,");
            sb.AppendLine("                                                                     color: '#000000',");
            sb.AppendLine("                                                                     align: 'top',");
            sb.AppendLine("                                                                     x: 1,");
            sb.AppendLine("                                                                     y: 5");
            sb.AppendLine("                                                                 }");
            sb.AppendLine("                                                         }]    ");
            sb.AppendLine("                                     });  ");
            sb.AppendLine("             <!-- HIGHCHART SCRIPT ENDS HERE -->");

            return sb.ToString();
        }
        #endregion

        #region Summary table
        public void getData()
        {
            DataTable summary = Summary.SummaryAll(DateTime.Now.Year - 8, DateTime.Now.Year);
            repeaterStatistics.DataSource = summary;
            repeaterStatistics.DataBind();

            //DataTable publicationTable = publicationData(summary);
            //publTable.DataSource = publicationTable;
            //publTable.DataBind();

            //DataTable conferenceTable = conferenceData(summary);
            //conf_patent.DataSource = conferenceTable;
            //conf_patent.DataBind();

            //DataTable projectTable = projectData(summary);
            //project.DataSource = projectTable;
            //project.DataBind();

            //DataTable courseTable = courseData(summary);
            //courses_graduate.DataSource = courseTable;
            //courses_graduate.DataBind();
        }
        protected void repeaterStatistics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ((Literal)e.Item.FindControl("ltrlYear")).Text = (DataBinder.Eval(e.Item.DataItem, "Year")).ToString();
            ((Literal)e.Item.FindControl("ltrlISI")).Text = (DataBinder.Eval(e.Item.DataItem, "ISI_Publications")).ToString();
            ((Literal)e.Item.FindControl("ltrlNonISI")).Text = (DataBinder.Eval(e.Item.DataItem, "NonISI_Publications")).ToString();
            ((Literal)e.Item.FindControl("ltrlPublicationPoint")).Text = (DataBinder.Eval(e.Item.DataItem, "Publication_Points")).ToString();
            ((Literal)e.Item.FindControl("ltrlConference")).Text = (DataBinder.Eval(e.Item.DataItem, "Conferences")).ToString();
            ((Literal)e.Item.FindControl("ltrlPatent")).Text = (DataBinder.Eval(e.Item.DataItem, "Patents")).ToString();
            ((Literal)e.Item.FindControl("ltrlBook")).Text = (DataBinder.Eval(e.Item.DataItem, "Books")).ToString();
            ((Literal)e.Item.FindControl("ltrlInternalProject")).Text = (DataBinder.Eval(e.Item.DataItem, "Projects")).ToString();
            ((Literal)e.Item.FindControl("ltrlNSTPProject")).Text = (DataBinder.Eval(e.Item.DataItem, "Projects")).ToString();
            ((Literal)e.Item.FindControl("ltrlInternalFund")).Text = (DataBinder.Eval(e.Item.DataItem, "Project_Funds")).ToString();
            ((Literal)e.Item.FindControl("ltrlNSTPFund")).Text = (DataBinder.Eval(e.Item.DataItem, "Project_Funds")).ToString();
            ((Literal)e.Item.FindControl("ltrlGraduateStudents")).Text = (DataBinder.Eval(e.Item.DataItem, "Graduate_Students")).ToString();
        }
        #endregion
    }
}