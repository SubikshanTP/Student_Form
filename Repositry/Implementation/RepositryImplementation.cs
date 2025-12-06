using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Student_Form.Data;
using Student_Form.Model.Dto;
using Student_Form.Model.Entity;
using Student_Form.Repositry.Interface;

namespace Student_Form.Repositry.Implementation
{
    public class RepositryImplementation:IRepositry
    {
        private readonly IMapper mapper;
        private readonly StudentDbcontext studentDbcontext;

        public RepositryImplementation(IMapper mapper,StudentDbcontext studentDbcontext)
        {
            this.mapper = mapper;
            this.studentDbcontext = studentDbcontext;
        }
        //delete curd
        public async Task<bool> DeleteAsync(int Id)
        {


            var result = await studentDbcontext.StudentAdmissions_Table.FirstOrDefaultAsync(x => x.StudentAdmissionNumber == Id);
            if (result != null)
            {
                studentDbcontext.StudentAdmissions_Table.Remove(result);
                await studentDbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }
       
        

        public async Task<IEnumerable<StudentAdmissionDto>> GetAsync()
        {

            var result = studentDbcontext.StudentAdmissions_Table;
           var res=  mapper.Map<IEnumerable<StudentAdmissionDto>>(result);
            return res; 

        }
        
        public async Task<StudentAdmissionDto> GetbyidAsync( int Id)
        {
          var result = await studentDbcontext.StudentAdmissions_Table.FirstOrDefaultAsync(x=>x.StudentAdmissionNumber==Id);
            var res=mapper.Map<StudentAdmissionDto>(result);
            return res;
            
             

        }

       

        public async Task<string> PostAsync(StudentAdmissionDto studentAdmissionDto)
        {
          
            var result = mapper.Map<StudentAdmission>(studentAdmissionDto);
            await studentDbcontext.StudentAdmissions_Table.AddAsync(result);
            await studentDbcontext.SaveChangesAsync();
            return "sucessfuly inserted !!";


        }

        public  async Task<string> UpdateAsync(int Id,StudentAdmissionDto studentAdmissionDto)
        {
            var result = await studentDbcontext.StudentAdmissions_Table.FirstOrDefaultAsync(x => x.StudentAdmissionNumber == Id);
            mapper.Map(studentAdmissionDto,result);
            await studentDbcontext.SaveChangesAsync();
            return( "updated");
        }


        public async Task<bool> LoginAsync(LoginTokenDto loginNoTokenDto)
        {
            var result = await studentDbcontext.StudentAdmissions_Table.FirstOrDefaultAsync(x => x.StudentName == loginNoTokenDto.StudentName && x.StudentEmail == loginNoTokenDto.StudentEmail);
            if (result != null) return true;
            return false;
            
        }

        public async Task<StudentAdmissionDto> GetByNameAsync(string studentName)
        {
            var result = await studentDbcontext.StudentAdmissions_Table.FirstOrDefaultAsync(x => x.StudentName == studentName);
            var res = mapper.Map<StudentAdmissionDto>(result);
            return res;
        }


        //---------------------------------------------------------------
    }
}
