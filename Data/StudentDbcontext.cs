using Microsoft.EntityFrameworkCore;
using Student_Form.Model.Entity;

namespace Student_Form.Data
{
    public class StudentDbcontext:DbContext
    {
///CHANGED
        public StudentDbcontext(DbContextOptions <StudentDbcontext>options):base(options)
        {
            
        }


        

        public DbSet <StudentAdmission> StudentAdmissions_Table { get; set; }
    }
}
