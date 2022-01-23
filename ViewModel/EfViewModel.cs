using System;
using System.Collections.Generic;
using System.Linq;
using ef_excercise.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ef_excercise.Context;
using System.Windows.Input;
using DownloadManager.ViewModel;

namespace ef_excercise.ViewModel
{
    class EfViewModel : INotifyPropertyChanged
    {
        public InvoiceContext InvoiceCTX { get; set; }
        public EfViewModel()
        {
            CreateCommand = new RelayCommand(e =>
            {
                addUser();
            }, c => true);



        }
        public ICommand CreateCommand { get; private set; }

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

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void addUser()
        {
            using (InvoiceCTX = new InvoiceContext())
            {
                Invoice inv = new Invoice()
                {
                    CustomerName = "Juergen",
                    CustomerAddress = "Ballerstreet 1",
                    Amount = 10000.0,
                    Vat = 10,
                    InvoiceDate = DateTime.Now
                };

                try
                {
                    Console.WriteLine(inv.Id);
                    InvoiceCTX.Invoices.Add(inv);
                    InvoiceCTX.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
