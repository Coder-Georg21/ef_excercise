using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_excercise.Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress {get;set;}
        public double Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Vat { get; set; }
    }
}
