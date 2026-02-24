using AutoMapper;
using Student_Form.Model.Dto;
using Student_Form.Model.Entity;

namespace Student_Form.AutoMapper
{ 
    public class StudentMapper:Profile
    {
        
        public StudentMapper()
        {
            CreateMap<StudentAdmissionDto,StudentAdmission>().ForMember(dest=>dest.Class,opt =>opt.MapFrom(src=>src.Classs)).ReverseMap();
            //i changed the name of the property in the StudentAdmissionDto to Classs because Class is a reserved keyword in C#. So, I mapped it to the Class property in the StudentAdmission entity.
        }
    }
}
