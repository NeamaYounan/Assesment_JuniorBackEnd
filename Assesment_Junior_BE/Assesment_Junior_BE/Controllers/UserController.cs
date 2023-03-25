using System;
using Microsoft.AspNetCore.Mvc;
using Assesment_Junior_BE.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Assesment_Junior_BE.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Web.Http;

namespace Assesment_Junior_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUserRepository _user;
        private readonly IJogingRepository _joging;

        public UserController(IWebHostEnvironment env,
            IUserRepository user,
            IJogingRepository joging)
        {
            _env = env;
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _joging = joging ?? throw new ArgumentNullException(nameof(joging));
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////
        
        [HttpPost]
        public IHttpActionResult userLogin(Login login)
        {
            var log =userLogins.Where(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password)).FirstOrDefault();

            if (log == null)
            {
                return Ok(new { status = 401, isSuccess = false, message = "Invalid User", });
            }
            else

                return Ok(new { status = 200, isSuccess = true, message = "User Login successfully", UserDetails = log });
        }
       
        [HttpPost]
        public object InsertUser(Register Reg)
        {
            try
            {

                UserLogin EL = new UserLogin();
                if (EL.Id == 0)
                {
                    EL.UserName = Reg.UserName;
                    EL.City = Reg.City;
                    EL.Email = Reg.Email;
                    EL.Password = Reg.Password;
                    EL.Department = Reg.Department;
                    UserLogins.Add(EL);
                    SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Record SuccessFully Saved." };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////

    [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _user.GetUsers());
        }


        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> Post(User use)
        {

            var result = await _user.InsertUser(use);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            return Ok("Added Successfully");
        }


        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> Put(User use)
        {
            var result = await _user.UpdateUser(use);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _user.DeleteUser(id);
            return new JsonResult("Deleted Successfully");
        }


        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    stream.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }


        [Route("GetAllJogings")]
        [HttpGet]
        public async Task<IActionResult> GetAllJogingNames()
        {
            return Ok(await _joging.GetJoging());
        }
    }
}
