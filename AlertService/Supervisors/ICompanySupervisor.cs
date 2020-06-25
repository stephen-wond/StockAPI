namespace AlertService.Supervisors
{
    public interface ICompanySupervisor
    {
        string GetCompanyDetails(string ticker);
    }
}