using Shajol_POS_PTSL.Data;
using Shajol_POS_PTSL.Models;
using Shajol_POS_PTSL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shajol_POS_PTSL.DataServices
{
    public class InvoiceDataServices : Iinvoice
    {
        public List<Invoice> DeleteInvoice(int id)
        {
            using (Shajol_POS_DbContext dbContext = new Shajol_POS_DbContext())
            {
                var emp = dbContext.Invoices.FirstOrDefault(e => e.Id == id);
                dbContext.Invoices.Remove(emp);
                dbContext.SaveChanges();
                List<Invoice> data = new List<Invoice> { emp };
                return data;
            }
        }

        public List<Invoice> GetAllInvoices()
        {
            using (Shajol_POS_DbContext dbContext = new Shajol_POS_DbContext())
            {
                return dbContext.Invoices.ToList();
            }
        }

        public List<Invoice> GetSpecificInvoice(int id)
        {
            using (Shajol_POS_DbContext dbContext = new Shajol_POS_DbContext())
            {
                var emp = dbContext.Invoices.FirstOrDefault(e => e.Id == id);
                List<Invoice> data = new List<Invoice> { emp };
                return data;
            }
        }

        public List<Invoice> InsertInvoice(Invoice invoice)
        {
            using (Shajol_POS_DbContext dbContext = new Shajol_POS_DbContext())
            {
                dbContext.Invoices.Add(invoice);
                dbContext.SaveChanges();
                List<Invoice> data = new List<Invoice> { invoice };
                return data;
            }
        }

        public List<Invoice> UpdateInvoice(int id, Invoice invoice)
        {
            using (Shajol_POS_DbContext dbContext = new Shajol_POS_DbContext())
            {
                var emp = dbContext.Invoices.FirstOrDefault(e => e.Id == id);
                emp.InvoiceDetailsId = invoice.InvoiceDetailsId;
                emp.productId = invoice.productId;
                emp.productName = invoice.productName;
                emp.productAmount = invoice.productAmount;
                emp.IsPaid = invoice.IsPaid;
                dbContext.SaveChanges();
                List<Invoice> data = new List<Invoice> { emp };
                return data;
            }
        }
    }
}