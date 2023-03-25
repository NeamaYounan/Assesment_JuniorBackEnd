using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Assesment_Junior_BE.Models;
using Assesment_Junior_BE.Repository;

namespace Assesment_Junior_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAngularController : ControllerBase
    {
        private readonly IUserAngularRepository _user;
        private readonly IJogingRepository _joging;

        public UserAngularController(IUserAngularRepository user,
                                         IJogingRepository joging)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _joging = joging ?? throw new ArgumentNullException(nameof(joging));
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _user.GetUsers());
        }

        [HttpGet]
        [Route("GetUserByID/{Id}")]
        public async Task<IActionResult> GetUseByID(int Id)
        {
            return Ok(await _user.GetUserByID(Id));
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> Post(UserAngular emp)
        {
            var result = await _user.InsertUser(emp);
            if (result.UserID == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }


        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> Put(UserAngular use)
        {
            await _user.UpdateUser(use);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteUser")]
        //[HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _user.DeleteUser(id);
            return new JsonResult("Deleted Successfully");
        }

        [HttpGet]
        [Route("GetJogingt")]
        public async Task<IActionResult> GetAllJogingNames()
        {
            return Ok(await _joging.GetJoging());
        }
    }
}
