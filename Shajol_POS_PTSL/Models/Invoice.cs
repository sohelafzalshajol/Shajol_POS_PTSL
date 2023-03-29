using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shajol_POS_PTSL.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public int InvoiceDetailsId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public int productAmount { get; set; }
        public bool IsPaid { get; set; }
    }
}