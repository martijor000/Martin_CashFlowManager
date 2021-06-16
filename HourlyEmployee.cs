using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_CashFlowManager
{
    class HourlyEmployee : Employee, IPayable
    {
        private const int _regularHours = 40;
        private const decimal _divideHalf = 0.5M;
        private decimal _hourlywage;
        private int _hoursWorked;
        private decimal _earnings;

        public HourlyEmployee(string FirstName, string LastName, string SSN, decimal HourlyWage, int HoursWorked) : base (FirstName, LastName, SSN)
        {
            _hourlywage = HourlyWage;
            _hoursWorked = HoursWorked;
            Earnings();
        }

        public int TotalWorkHours
        {
            get { return _hoursWorked; }
        }

        public decimal HourlyPay
        {
            get { return _hourlywage; }
        }

        public decimal Earnings()
        {
            if (_hoursWorked <= _regularHours)
            {
                _earnings = _hoursWorked * _hourlywage;
                return _earnings;
            }
            else
            {
                _earnings = _hoursWorked * _regularHours + ((_hoursWorked - _regularHours) * ((_hourlywage * _divideHalf) + (_hourlywage)));
                return _earnings;
            }
        }

        LedgerType IPayable.GetType()
        {
            LedgerType currentType = LedgerType.Hourly;
            return currentType;
        }

        public decimal GetPayableAmount
        {
            get => _earnings; 
        }

    }
}
