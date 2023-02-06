using Bussiness_Logic;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;


namespace Services.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class TrainerSignupController: ControllerBase
    {
        ILogic _logic;
        Validation validation; 

        public TrainerSignupController(ILogic logic, Validation validation)
        {
            _logic = logic;
            this.validation = validation;
        }

        [HttpPost("AddTrainer")]
        public ActionResult AddNewTrainer([FromBody] TrainerDetail trainer, string Email)
        {
            try
            {
                if(validation.IsValidEmail(Email))
                {
                    if(validation.IsValidPhoneNumber(trainer.Phonenumber))
                    {
                        var addedtrainer = _logic.AddTrainer(trainer, Email);
                        return Created("AddTrainer", addedtrainer);
                    }
                    else
                    {
                        return BadRequest("Phonenumber format is incorrect");
                    }
                }
                else
                {
                    return BadRequest("Email format is invalid");
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

        [HttpPost("AddEducation")]
        public ActionResult AddNewEducation([FromBody] TrainerEducation trainer, string Email)
        {
            try
            {
                var addedtrainer = _logic.AddEducation(trainer, Email);
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
        public ActionResult AddNewSkill(TrainerSkill trainer, string Email)
        {
            try
            {
                var addedtrainer = _logic.AddSkill(trainer, Email);
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
        public ActionResult AddNewCompany([FromBody] TrainerCompany trainer, string Email)
        {
            try
            {
                var addedtrainer = _logic.AddCompany(trainer, Email);
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
