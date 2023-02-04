using Bussiness_Logic;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;


namespace Services.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class TrainerController: ControllerBase
    {
        ILogic _logic;

        public TrainerController(ILogic logic)
        {
            _logic = logic;
        }

        [HttpGet("GetAllTrainers")]
        public IActionResult Get()
        {
            try
            {
                var trainers = _logic.GetAllTrainerDetails();
                if(trainers.Count() > 0)
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
    }
}
