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
    public class JogingController : ControllerBase
    {
        private readonly IJogingRepository _joging;

        public JogingController(IJogingRepository joging)
        {
            _joging = joging ?? throw new ArgumentNullException(nameof(Joging));
        }

        [HttpGet]
        [Route("GetJoging")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _joging.GetJoging());
        }

        [HttpGet]
        [Route("GetJogingByID/{Id}")]
        public async Task<IActionResult> GetJogById(int Id)
        {
            return Ok(await _joging.GetJogingByID(Id));
        }

        [HttpPost]
        [Route("AddJoging")]
        public async Task<IActionResult> Post(Joging jog)
        {
            var result = await _joging.InsertJoging(jog);
            if (result.UserId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }

        [HttpPut]
        [Route("UpdateJoging")]
        public async Task<IActionResult> Put(Joging jog)
        {
            await _joging.UpdateJoging(jog);
            return Ok("Updated Successfully");
        }


        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteDepartment")]
        public JsonResult Delete(int id)
        {
            _joging.DeleteJoging(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
