using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ef_excercise.Model;
using ef_excercise.Context;

namespace ef_excercise.ViewModel
{
    class EfViewModel
    {

        public List<Invoice> invoice
        {
            get
            {
                using (InvoiceContext ctx = new InvoiceContext())
                {
                    return (from data in ctx.Invoices select data).ToList();
                }

            }
        }
                public EfViewModel()
        {
            using (var ctx = new InvoiceContext())
            {
              
            }
        }
}
}
