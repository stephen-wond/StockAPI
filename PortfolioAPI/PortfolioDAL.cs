using PortfolioAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioAPI
{
    public class PortfolioDAL<T> : IPortfolioDAL<T> where T : class
    {
        private readonly PortfolioContext _context;

        public PortfolioDAL(PortfolioContext context)
        {
            _context = context;
        }

        public T CreateT()
        {
            throw new NotImplementedException();
        }

        public T DeleteT()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllT()
        {
            throw new NotImplementedException();
        }

        public T GetT()
        {
            throw new NotImplementedException();
        }

        public T UpdateT()
        {
            throw new NotImplementedException();
        }
    }
}
