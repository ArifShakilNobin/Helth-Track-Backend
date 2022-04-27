using Health.DataService.Data;
using Health.Entity;
using Health.Entity.Entity;
using Health.Entity.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Base;
using System.Linq;

namespace Health_Tracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly AppDbContext dbContext;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCompany()
        {
            try
            {
                var response = _unitOfWork.Companies.GetAllCompany().OrderByDescending(c => c.companyName).ThenBy(c => c.AddedDate);
                return Ok(new ApiResponse(true, "Company data load successfully", response));

            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(true, "Company data load failed", null));
            }
        }



        [HttpPost]
        public IActionResult AddCompany([FromBody] Company company)
        {
            try
            {
                if (company == null)
                {
                    return BadRequest(new ApiResponse(true, "Company object is null", null));
                }
                if (ModelState.IsValid)
                {
                    var isCompanyNameAlreadyExists = _unitOfWork.Companies.companyAlreadyexist(company.companyName);
                    if (isCompanyNameAlreadyExists)
                    {
                        ModelState.AddModelError("Company Name", "Company with this name already exists");
                        return BadRequest(new ApiResponse(true, "Company with this name already exists", null));

                    }
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(true, "Invalid model object", null));

                }
                else
                {
                    _unitOfWork.Companies.Add(company);
                    _unitOfWork.Save();
                }
                return Ok(new ApiResponse(true, "Data Saved"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
