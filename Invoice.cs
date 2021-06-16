using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martin_CashFlowManager
{
    class Invoice: IPayable
    {

        private decimal _price;
        private int _quantity;
        private string _partNumber;
        private string _partDescription;
        private decimal _totalAmount;

        public Invoice(string partNumber, int quantity, string partDescription, decimal price)
        {
            _partNumber = partNumber;
            _quantity = quantity;
            _partDescription = partDescription;
            _price = price;
            _totalAmount = _quantity * _price;
        }

        public string PartNumber
        {
            get { return _partNumber; }
        }   

        public int Quantity
        {
            get { return _quantity; }
        }

        public string PartDescription
        {
            get { return _partDescription; }
        }

        public decimal Price
        {
            get { return _price; }
        }

        public decimal GetPayableAmount
        {
            get => _totalAmount;
        }

        LedgerType IPayable.GetType()
        {
            LedgerType currentType = LedgerType.Invoice;
            return currentType;
        }
       
    }
}
