using AutoMapper;
using Student_Form.Model.Dto;
using Student_Form.Model.Entity;

namespace Student_Form.AutoMapper
{
    public class StudentMapper:Profile
    {
        //-hbhbihbi
        
        public StudentMapper()
        {
            CreateMap<StudentAdmissionDto,StudentAdmission>().ForMember(dest=>dest.Class,opt =>opt.MapFrom(src=>src.Classs)).ReverseMap();
            
        }
    }
}
