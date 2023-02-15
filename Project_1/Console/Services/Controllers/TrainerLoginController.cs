using Bussiness_Logic;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Trainer_EF_Layer.Entities;


namespace Services.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class TrainerLoginController : ControllerBase
    {
        ILogic _logic;

        public TrainerLoginController(ILogic logic)
        {
            _logic = logic;
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

        [HttpGet("ForgetPassword/{Email}/{Phonenumber}/{Password}")]
        public ActionResult Forgetpass(string Email, string Phonenumber, string Password)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var delete = _logic.ForgetPassword(Email, Phonenumber, Password);
                    if (delete)
                    {
                        return Ok("Password Changed Sucessfully");
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

        [HttpPut("UpdateTrainer")]
        public ActionResult Updatetrainer([FromBody] Models.TrainerDetail trainer, string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    _logic.UpdateTrainer(trainer, email);
                    return Ok(trainer);
                }
                else
                {
                    return BadRequest($"Something went wrong");
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

        [HttpPut("UpdateEducation")]
        public ActionResult UpdateEducation([FromBody] TrainerEducation education, string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    _logic.UpdateEducation(education, email);
                    return Ok(education);
                }
                else
                {
                    return BadRequest($"Something went wrong");
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

        [HttpPut("UpdateSkill")]
        public ActionResult UpdateSkill([FromBody] TrainerSkill skill, string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    _logic.UpdateSkill(skill, email);
                    return Ok(skill);
                }
                else
                {
                    return BadRequest($"Something went wrong");
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

        [HttpPut("UpdateCompany")]
        public ActionResult UpdateCompany([FromBody] TrainerCompany company, string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    _logic.UpdateCompany(company, email);
                    return Ok(company);
                }
                else
                {
                    return BadRequest($"Something went wrong");
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

        [HttpDelete("DeleteProfile/{Email}/{Password}")]
        public ActionResult DeleteTrainer(string Email, string Password)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var delete = _logic.DeleteTrainer(Email, Password);
                    if (delete)
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
