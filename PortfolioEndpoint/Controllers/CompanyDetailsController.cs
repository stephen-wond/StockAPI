using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.OutputModels;
using PortfolioEndpoint.Supervisors;

namespace PortfolioEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDetailsController : ControllerBase
    {
        private readonly ICompanySupervisor _companySupervisor;
        public CompanyDetailsController(ICompanySupervisor companySupervisor)
        {
            _companySupervisor = companySupervisor;
        }

        [HttpGet("{companyName}")]
        public async Task<ActionResult<string>> GetCompanyDetails(string companyName)
        {
            return await _companySupervisor.GetCompanyDetails(companyName);
        }
    }
}
