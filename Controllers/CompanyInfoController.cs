using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Controllers
{
    [Authorize]
    [Route("api/company")]
    [ApiController]
    public class CompanyInfoController : ControllerBase
    {
        private readonly ICompanyInfo _companyInfo;

        public CompanyInfoController(ICompanyInfo IcompanyInfo)
        {
            _companyInfo = IcompanyInfo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyInfo>>> Get()
        {
            return await Task.FromResult(_companyInfo.GetCompanyInfoList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyInfo>> Get(int id)
        {
            var CompanyInfo = await Task.FromResult(_companyInfo.GetCompanyDetails(id));
            if (CompanyInfo == null)
            {
                return NotFound();
            }
            return CompanyInfo;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyInfo>> Post(CompanyInfo companyInfo)
        {
            _companyInfo.AddCompanyInfo(companyInfo);
            return await Task.FromResult(companyInfo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyInfo>> Put(int id, CompanyInfo companyInfo)
        {
            if (id != companyInfo.CompanyID)
            {
                return BadRequest();
            }
            try
            {
                _companyInfo.UpdateCompanyInfo(companyInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(companyInfo);
        }


        // DELETE api/CompanyInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyInfo>> Delete(int id)
        {
            var companyInfo = _companyInfo.DeleteCompanyInfo(id);
            return await Task.FromResult(companyInfo);
        }


        private bool CompanyInfoExists(int id)
        {
            return _companyInfo.CheckCompanyInfo(id);
        }

    }
}
