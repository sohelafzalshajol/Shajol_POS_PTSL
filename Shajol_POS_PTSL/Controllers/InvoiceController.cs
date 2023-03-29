using Shajol_POS_PTSL.Data;
using Shajol_POS_PTSL.DataServices;
using Shajol_POS_PTSL.Models;
using Shajol_POS_PTSL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shajol_POS_PTSL.Controllers
{
    public class InvoiceController : ApiController
    {

        readonly Iinvoice _dataService = new InvoiceDataServices();
        public HttpResponseMessage Get()
        {
            var data = _dataService.GetAllInvoices();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        public HttpResponseMessage Get(int id)
        {
            var data = _dataService.GetSpecificInvoice(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invoice With Id " + id + " Not Found In Database!");
            }
        }
        public HttpResponseMessage Post(Invoice invoice)
        {
            var data = _dataService.InsertInvoice(invoice);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please give proper input data!!!");
            }
        }
        public HttpResponseMessage Put(int id, Invoice invoice)
        {
            var data = _dataService.UpdateInvoice(id, invoice);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invoice With Id " + id + " Not Found In Database! Update Failed!!!");
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            var data = _dataService.DeleteInvoice(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invoice With Id " + id + " Not Found In Database! Delete Failed!!!");
            }
        }
    }
}
