using System.Threading.Tasks;

namespace PortfolioEndpoint.Supervisors
{
    public interface ICompanySupervisor
    {
        Task<string> GetCompanyDetails(string companyName);
    }
}