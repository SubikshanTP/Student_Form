using AutoMapper;
using Student_Form.Model.Dto;
using Student_Form.Model.Entity;

namespace Student_Form.AutoMapper
{ 
    public class StudentMapper:Profile
    {
<<<<<<< HEAD

       //subikshan
   

=======
      //hiii  
>>>>>>> a3322ad59004e4b81b7a9228d126825ba3a09a17
        public StudentMapper()
        {
            CreateMap<StudentAdmissionDto,StudentAdmission>().ForMember(dest=>dest.Class,opt =>opt.MapFrom(src=>src.Classs)).ReverseMap();
            
        }
    }
}
