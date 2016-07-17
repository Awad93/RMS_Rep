using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Update_publications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<Models.rms_Departments> departmentList = Models.rms_Departments.getDepartmentsByCollege("CCSE");
            //string list_html = "";
            //for (int i = 0; i < departmentList.Count; i++)
            //{
            //    list_html += "<li><a>" + departmentList[i].DepartmentName + "</a></li>";
            //    deptlist2.InnerHtml = list_html;
            //}            
            string html_code = "";            
            List<DepartmentController> collegeList = DepartmentController.getAllColleges();
            for(int i = 0; i < collegeList.Count; i++)
            {
                List<DepartmentController> departmentList = DepartmentController.getDepartmentsByCollege(collegeList[i].Department_Code);
                string dept_html_code = "<ul id=\"deptlist" + i + "\" class=\"collapse list-unstyled\">";
                for (int j = 0; j < departmentList.Count; j++)
                {
                    dept_html_code += "<li><a>" + departmentList[j].Department_Name + "</a></li>";
                }
                dept_html_code += "</ul>";
                html_code += "<span class=\"panel\"><li data-toggle=\"collapse\""+ 
                    "href=\"#deptlist"+i+"\""+  
                    "data-parent=\"#listCollege\">"+
                    "<a>" + collegeList[i].Department_Name + "</a>" + 
                    "</li>" + dept_html_code + "</span>";
            }
            listCollege.InnerHtml = html_code;           
        }
    }
}