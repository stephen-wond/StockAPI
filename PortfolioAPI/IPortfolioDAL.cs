using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioAPI
{
    public interface IPortfolioDAL<T> where T : class
    {
        IEnumerable<T> GetAllT();
        T GetT();
        T CreateT();
        T UpdateT();
        T DeleteT();
    }
}
