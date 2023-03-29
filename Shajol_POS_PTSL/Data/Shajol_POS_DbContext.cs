using Shajol_POS_PTSL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shajol_POS_PTSL.Data
{
    public class Shajol_POS_DbContext : DbContext
    {
        public Shajol_POS_DbContext() : base("Shajol_POS_dbconnection") { }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
    }
}