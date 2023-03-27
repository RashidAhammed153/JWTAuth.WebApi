using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.WebApi.Interface
{
    public interface ICompanyInfo
    {
        public List<CompanyInfo> GetCompanyInfoList();

        public CompanyInfo GetCompanyDetails(int id);
       public void AddCompanyInfo(CompanyInfo companyInfo);
       public void UpdateCompanyInfo(CompanyInfo companyInfo);
       public bool CheckCompanyInfo(int id);
       public CompanyInfo DeleteCompanyInfo(int id);
    }
}
