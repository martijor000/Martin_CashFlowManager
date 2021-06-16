using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_CashFlowManager
{
    class Employee
    {
        private string _firstName;
        private string _ssn;
        private string _lastName;

        public Employee(string firstName, string lastName, string ssn)
        {
            _firstName = firstName;
            _ssn = ssn;
            _lastName = lastName;
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public string SSN
        {
            get { return _ssn; }
        }



    }
}
