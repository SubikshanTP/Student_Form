using Student_Form.Model.Dto;

namespace Student_Form.Repositry.Interface
{
    public interface IRepositry
    {

        Task<string> PostAsync(StudentAdmissionDto studentAdmissionDto);

        Task<bool> DeleteAsync(int Id);

        Task<IEnumerable<StudentAdmissionDto>>GetAsync();

        Task<StudentAdmissionDto> GetbyidAsync(int Id);

        Task<string> UpdateAsync(int Id,StudentAdmissionDto studentAdmissionDto);

       
       Task<bool> LoginAsync(LoginTokenDto loginNoTokenDto);

        Task<StudentAdmissionDto> GetByNameAsync(string studentName);

    }
}
