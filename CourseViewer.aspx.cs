using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace EntityFramMsdnExample
{
    public partial class CourseViewer : System.Web.UI.Page
    {
        //Create an ObjectContext instance based on SchoolEntity
        private SchoolEntities schoolContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            schoolContext = new SchoolEntities();
            var departmentQuery = from d in schoolContext.Department.Include("Course")
                                  orderby d.Name
                                  select d.Name;
            departmentList.DataSource = ((ObjectQuery)departmentQuery).Execute(MergeOption.AppendOnly);
            departmentList.DataBind();

        }
    }
}