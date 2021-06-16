using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_CashFlowManager
{
    class SalariedEmployee : Employee, IPayable
    {
        private decimal _weeklySalary;
        private decimal [] _storeSalary = new decimal [100];

        public SalariedEmployee(string FirstName, string LastName, string ssn, decimal WeeklySalary) : base(FirstName, LastName, ssn)
        {
            _weeklySalary = WeeklySalary;
        }

        LedgerType IPayable.GetType()
        {
            LedgerType currentType = LedgerType.Salaried;
            return currentType;
        }

        public decimal GetPayableAmount
        {
            get => _weeklySalary;
        }

    }
}
