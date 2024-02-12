using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnnoRokom_test.Models;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace OnnoRokom_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        SqlConnection connection = null;
        public RegisterController(IConfiguration configuration)
        {
            _configuration= configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("TeacherLog").ToString());
        }
        [HttpPost]
        [Route("RegisterNewTeacher")]

        public Response RegisterNewTeacher(UserModel users)
        {
            Response response = new Response();
            DAL dal = new DAL();
            response= dal.Registration(users,connection);
            return response;


        }

        [HttpPost]
        [Route("Login")]

        public Response Login(UserModel users)
        {
            Response response = new Response();
            DAL dal =new DAL();
            response = dal.Login(users,connection); 
            return response;
        }



    }
}
