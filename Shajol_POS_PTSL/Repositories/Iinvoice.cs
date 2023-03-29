using Shajol_POS_PTSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shajol_POS_PTSL.Repositories
{
    public interface Iinvoice
    {
        List<Invoice> GetAllInvoices();
        List<Invoice> GetSpecificInvoice(int id);
        List<Invoice> InsertInvoice(Invoice invoice);
        List<Invoice> UpdateInvoice(int id, Invoice invoice);
        List<Invoice> DeleteInvoice(int id);
    }
}
