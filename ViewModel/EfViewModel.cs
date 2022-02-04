using System;
using System.Collections.Generic;
using System.Linq;
using ef_excercise.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ef_excercise.Context;
using System.Windows.Input;
using DownloadManager.ViewModel;
using System.Windows;

namespace ef_excercise.ViewModel
{
    class EfViewModel : INotifyPropertyChanged
    {
        public InvoiceContext InvoiceCTX { get; set; }
        public EfViewModel()
        {
            CreateCommand = new RelayCommand(e =>
            {
                addInvoice();
            }, c => true);

            DeleteCommand = new RelayCommand(e =>
            {
                deleteInvoice();
            }, c=> true);




        }

        public Invoice InvoiceToAdd { get; set; } = new Invoice();

        public Invoice InvoiceToDelete { get; set; } = new Invoice();

        public ICommand CreateCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public IList<Invoice> invoice
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
        public void addInvoice()
        {
            using (InvoiceCTX = new InvoiceContext())
            {
                
                try
                {
                    //Console.WriteLine(InvoiceToAdd.Id);
                    InvoiceToAdd.InvoiceDate = DateTime.Now;
                    InvoiceCTX.Invoices.Add(InvoiceToAdd);
                    InvoiceCTX.SaveChanges();
                    RaisePropertyChanged(nameof(invoice));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
        public void deleteInvoice()
        {
            using (InvoiceCTX = new InvoiceContext())
            {
                try
                {

                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Invoice?", "Delete", MessageBoxButton.YesNo);

                    if (MessageBoxResult.Yes == result)
                    {
                        using (var ctx = new InvoiceContext())
                        {
                            Invoice InvoiceBuffer = InvoiceCTX.Invoices.Find(InvoiceToDelete.Id);
                            InvoiceCTX.Invoices.Remove(InvoiceBuffer);
                            InvoiceCTX.SaveChanges();
                            RaisePropertyChanged(nameof(invoice));
                        }
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
