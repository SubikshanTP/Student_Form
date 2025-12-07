using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Student_Form.Filter;
using Student_Form.Model.Dto;
using Student_Form.Repositry.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Student_Form.Controllers
{
    [TypeFilter(typeof(CustomExceptionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRepositry repositry;

        public StudentController(IRepositry repositry)
        {
            this.repositry = repositry;
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(StudentAdmissionDto studentAdmissionDto)
        {
            var result = await repositry.PostAsync(studentAdmissionDto);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [Authorize]
        [HttpDelete("{Id:int}")]

        public async Task<IActionResult> Delete(int Id)
        {
            var result = await repositry.DeleteAsync(Id);
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var result = await repositry.GetAsync();
            return Ok(result);
        }


        [Authorize]
        [HttpGet("{Id:int}")]

        public async Task<IActionResult> Getbyid(int Id)
        {
            var result = await repositry.GetbyidAsync(Id);
            return Ok(result);
        }
       
        [Authorize]
        [HttpPut("{Id:int}")]

        public async Task <IActionResult> Update(int Id,StudentAdmissionDto studentAdmissionDto)
        {

            var result = await repositry.UpdateAsync(Id, studentAdmissionDto);
           
            return Ok(result);
        }


        //[HttpPost("Login")]

        //public async Task<IActionResult> Login( LoginNoTokenDto loginNoTokenDto)
        //{

        //    var result = await repositry.LoginAsync(loginNoTokenDto);

        //    return Ok(result);
        //}

        [AllowAnonymous]
        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginTokenDto loginTokenDto)
        {

            var result = await repositry.LoginAsync(loginTokenDto);
            if (result == true)
            {
                var token = GenerateToken(loginTokenDto.StudentName);
                //return Ok(new { AccessToken = new JwtSecurityTokenHandler().WriteToken(token) });
            
                loginTokenDto.Token = new JwtSecurityTokenHandler().WriteToken(token);

                // Return the token DTO as JSON
                return Ok(loginTokenDto);

            }
            else
            {
                return Unauthorized("Invalid Credentials");
            }
        }
        private JwtSecurityToken GenerateToken(string StudentName)
        //private JwtSecurityToken GenerateToken(string username)
        {
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,StudentName),
                new Claim(ClaimTypes.Role,StudentName== "Admin" ? "Admin" : "User")
            };





            var token = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: Claims,
                expires: DateTime.UtcNow.AddMinutes(5), // DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey_ChangeThisToBeAtLeast32CharsLong!")), SecurityAlgorithms.HmacSha256));

            return token;
        }






        // Only authorized users can access this API
        [Authorize]
        [HttpGet("byname/{studentName}")]

        public async Task<IActionResult> GetByName(string studentName)
        {
            var result = await repositry.GetByNameAsync( studentName);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

    }

       
    
}
