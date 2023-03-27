using JWTAuth.WebApi.Interface;
using JWTAuth.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Repository
{
    public class CompanyInfoRepository : ICompanyInfo
    {

        readonly DatabaseContext _dbContext = new();

        public CompanyInfoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CompanyInfo> GetCompanyInfoList()
        {
            try
            {
                return _dbContext.CompanyInfo.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public CompanyInfo GetCompanyDetails(int id)
        {
            try
            {
                CompanyInfo ? companyInfo = _dbContext.CompanyInfo.Find(id);
                if (companyInfo != null)
                {
                    return companyInfo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddCompanyInfo(CompanyInfo companyInfo)
        {
            try
            {
                _dbContext.CompanyInfo.Add(companyInfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateCompanyInfo(CompanyInfo companyInfo)
        {
            try
            {
                _dbContext.Entry(companyInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool CheckCompanyInfo(int id)
        {
            return _dbContext.CompanyInfo.Any(e => e.CompanyID == id);
        }

        public CompanyInfo DeleteCompanyInfo(int id)
        {
            try
            {
                CompanyInfo? companyInfo = _dbContext.CompanyInfo.Find(id);

                if (companyInfo != null)
                {
                    _dbContext.CompanyInfo.Remove(companyInfo);
                    _dbContext.SaveChanges();
                    return companyInfo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
