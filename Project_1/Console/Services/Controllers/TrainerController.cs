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
        public ActionResult Get()
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


        [HttpGet("TrainerUsingFilter")]
        public ActionResult GetTrainerbyCity(string city = "ex: chennai or delhi", string skill = "ex: python or java") 
        {
            try
            {
                var search = _logic.TrainerFilter(city, skill);
                if(search.Count() > 0)
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

        [HttpGet("LoginPage/{Email}/{Password}")]
        public ActionResult Login(string Email, string Password)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var delete = _logic.login(Email, Password);
                    if (delete)
                    {
                        return Ok("Login Successfull");
                    }
                    else
                    {
                        return NotFound("Please check the credentails");
                    }
                }
                else
                {
                    return BadRequest("Please check the credentails");
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


        [HttpPost("AddTrainer")]
        public ActionResult AddNewTrainer([FromBody] TrainerDetail trainer, string Email)
        {
            try
            {
                var addedtrainer = _logic.AddTrainer(trainer, Email);
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

        [HttpDelete("DeleteProfile/{Email}/{Password}")]
      public ActionResult DeleteTrainer(string Email, string Password)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var delete = _logic.DeleteTrainer(Email, Password);
                    if(delete)
                    {
                        return Ok("Your account deleted successfully");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest("Please check the credentails");
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
