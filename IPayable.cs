using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_CashFlowManager
{
    interface IPayable
    {
        public decimal GetPayableAmount { get; }

        LedgerType GetType();
    }

    public enum LedgerType
    {
        Salaried,
        Hourly,
        Invoice
    }
}
