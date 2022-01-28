using ef_excercise.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_excercise.Context
{
    class InvoiceInitializer : DropCreateDatabaseAlways<InvoiceContext>
    {
        protected override void Seed(InvoiceContext context)
        {
            IList<Invoice> defaultInvoice = new List<Invoice>();

            defaultInvoice.Add(new Invoice
            {
                Id = 1,
                CustomerName = "Raphaela Kappela",
                CustomerAddress = "Homostrasse 1",
                Amount = 69,
                InvoiceDate = new DateTime(),
                Vat=420187,


            }) ;
        }
    }
}
