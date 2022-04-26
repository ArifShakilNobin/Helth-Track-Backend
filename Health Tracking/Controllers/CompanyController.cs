using Health.DataService.Data;
using Health.Entity.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Base;

namespace Health_Tracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetAllCompany()
        {
            var popularDevelopers = _unitOfWork.Companies.GetAllCompany();
            return Ok(popularDevelopers);
        }


        [HttpPost]
        public IActionResult AddCompany([FromBody] Company company)
        {
            try
            {
                if (company == null)
                {
                    return BadRequest("Company object is null");
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                else
                {
                    _unitOfWork.Companies.Add(company);
                    _unitOfWork.Save();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }



        }

    }
}
