using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ef_excercise.Model;

namespace ef_excercise.Context
{
    
    public class InvoiceContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }

    }
}
