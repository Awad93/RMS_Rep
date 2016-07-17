using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

namespace WebApplication1
{
    public partial class results_page : System.Web.UI.Page
    {
        #region Fields
        int numOfBooks;
        int numOfISIPublications;
        int numOfNonISIPublications;
        int publication_year = 0;
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
                if((DataBinder.Eval(e.Item.DataItem, "KFUPMID")) != null)
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

                List<Models.rms_Books_Authored> Books = Models.rms_Books_Authored.getBooksByDepartment(code);
                List<Models.rms_Publications_ISI> ISIPublications = Models.rms_Publications_ISI.getISIPublicationsByDepartment(code);
                List<Models.rms_Publications_NonISI> NonISIPublications = Models.rms_Publications_NonISI.getNonISIPublicationsByDepartment(code);
                List<Models.rms_Researchers> Faculty = Models.rms_Researchers.getFacultyByDepartment(code, 'A');

                BindRepeaters(Books, ISIPublications, NonISIPublications, Faculty);
            }
        }
        protected void aFaculty_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((HiddenField)((HtmlAnchor)sender).FindControl("hfvKFUPMID")).Value);
            
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
    }
}