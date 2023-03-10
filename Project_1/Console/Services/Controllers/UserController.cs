using Bussiness_Logic;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;


namespace Services.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        ILogic _logic;

        public UserController(ILogic logic)
        {
            _logic = logic;
        }

        [HttpGet("GetAllTrainers")]
        public ActionResult Get()
        {
            try
            {
                var trainers = _logic.GetAllTrainerDetails();
                if (trainers.Count() > 0)
                {
                    return Ok(trainers);
                }
                else
                {
                    return BadRequest("Database is Empty");
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("TrainerUsingFilter")]
        public ActionResult GetTrainerbyCity(string city = "ex:_chennai_or_delhi", string skill = "ex:_python_or_java")
        {
            try
            {
                var search = _logic.TrainerFilter(city, skill);
                if (search.Count() > 0)
                {
                    return Ok(search);
                }
                else
                {
                    return NotFound($"No trainer details found in this filter");
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
