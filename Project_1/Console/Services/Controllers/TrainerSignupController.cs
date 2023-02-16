using Bussiness_Logic;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Services.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class TrainerSignupController : ControllerBase
    {
        ILogic _logic;

        public TrainerSignupController(ILogic logic, Validation validation)
        {
            _logic = logic;
        }

        [HttpPost("AddTrainer")]
        public ActionResult AddNewTrainer([FromBody] TrainerDetail trainer)
        {
            try
            {
                var addedtrainer = _logic.AddTrainer(trainer);
                return Created("AddTrainer", addedtrainer);
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


        [HttpPost("AddEducation")]
        public ActionResult AddNewEducation([FromBody] TrainerEducation trainer)
        {
            try
            {
                var addedtrainer = _logic.AddEducation(trainer);
                return Created("AddEducation", addedtrainer);
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

        [HttpPost("AddSkill")]
        public ActionResult AddNewSkill(TrainerSkill trainer)
        {
            try
            {
                var addedtrainer = _logic.AddSkill(trainer);
                return Created("AddSkill", addedtrainer);
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

        [HttpPost("AddCompany")]
        public ActionResult AddNewCompany([FromBody] TrainerCompany trainer)
        {
            try
            {
                var addedtrainer = _logic.AddCompany(trainer);
                return Created("AddCompany", addedtrainer);
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
