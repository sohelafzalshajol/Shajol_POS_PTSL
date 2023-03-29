var invoiceId = 0;
$(document).ready(function () {
    showInvoices();

    $("#btnUpdateInvoice").click(function () {
        debugger;
        invoiceId = $('#hdnInvoiceId').val();
        if (invoiceId != 0) {
            updateInvoice(invoiceId);
        } else {
            alert("No Proper Data Found By This Invoice Id!!!");
        }
    });
});

function clearForm() {
    $('#hdnInvoiceId').val(0);
    $('#txtInvoiceDetailsId').val('');
    $('#txtproductId').val('');
    $('#txtproductName').val('');
    $('#txtproductAmount').val('');
    $('#txtIsPaid').val('');
}

function showInvoices() {
    var url = "/api/Invoice";
    $.ajax({
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "Get",
        success: function (result) {
            if (result) {
                $("#tblInvoice").html('');
                var row = '';
                for (var i = 0; i < result.length; i++) {
                    row = row
                        + "<tr>"
                        + "<td>" + result[i].InvoiceDetailsId + "</td>"
                        + "<td>" + result[i].productId + "</td>"
                        + "<td>" + result[i].productName + "</td>"
                        + "<td>" + result[i].productAmount + "</td>"
                        + "<td>" + result[i].IsPaid + "</td>"
                        + "<td><button type='button' class='btn btn-info' id='btnEditInvoice' onclick='populateInvoice(" + result[i].Id + ")'>Edit</button>&nbsp;&nbsp;&nbsp;<button type='button' class='btn btn-danger' id='btnDeleteInvoice' onclick='deleteInvoice(" + result[i].Id + ")'>Delete</button></td>"
                        + "</tr>"
                }
                if (row != '') {
                    $("#tblInvoice").append(row);
                }
            }
        },
        error: function (msg) {
            alert(msg);
        }
    });
}

function createInvoice() {
    var url = "/api/Invoice";
    var invoice = {};
    if ($('#txtInvoiceDetailsId').val() === '' || $('#txtproductId').val() === '' || $('#txtproductName').val() === '' || $('#txtproductAmount').val() === '' || $('#txtIsPaid').val() === '') {
        alert("No field can be blank!!!");
    } else {
        invoice.InvoiceDetailsId = $('#txtInvoiceDetailsId').val();
        invoice.productId = $('#txtproductId').val();
        invoice.productName = $('#txtproductName').val();
        invoice.productAmount = $('#txtproductAmount').val();
        invoice.IsPaid = $('#txtIsPaid').val();

        if (invoice) {
            $.ajax({
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(invoice),
                type: "Post",
                success: function (result) {
                    clearForm();
                    showInvoices();
                },
                error: function (msg) {
                    alert(msg);
                }
            });
        }
    }
}

function deleteInvoice(id) {
    var url = "/api/Invoice/" + id;
    $.ajax({
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "Delete",
        success: function (result) {
            if (result) {
                alert(JSON.stringify(result) + "Deleted Successfully!");
            }
            clearForm();
            showInvoices();
        },
        error: function (msg) {
            alert(msg);
        }
    });
}

function populateInvoice(id) {
    debugger;
    var url = "/api/Invoice/" + id;
    $.ajax({
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "Get",
        success: function (result) {
            if (result) {
                debugger;
                $("#hdnInvoiceId").val(result[0].Id);
                $('#txtInvoiceDetailsId').val(result[0].InvoiceDetailsId);
                $('#txtproductId').val(result[0].productId);
                $('#txtproductName').val(result[0].productName);
                $('#txtproductAmount').val(result[0].productAmount);
                $('#txtIsPaid').val(result[0].IsPaid);
            }
            $("#btnCreateInvoice").prop('disabled', true);
            $("#btnUpdateInvoice").prop('disabled', false);
        },
        error: function (msg) {
            alert(msg);
        }
    });
}


function updateInvoice(id) {
    var url = "/api/Invoice/" + id;
    var invoice = {};
    if ($('#txtInvoiceDetailsId').val() === '' || $('#txtproductId').val() === '' || $('#txtproductName').val() === '' || $('#txtproductAmount').val() === '' || $('#txtIsPaid').val() === '') {
        alert("No field can be blank!!!");
    } else {
        invoice.InvoiceDetailsId = $('#txtInvoiceDetailsId').val();
        invoice.productId = $('#txtproductId').val();
        invoice.productName = $('#txtproductName').val();
        invoice.productAmount = $('#txtproductAmount').val();
        invoice.IsPaid = $('#txtIsPaid').val();

        if (invoice) {
            $.ajax({
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(invoice),
                type: "Put",
                success: function (result) {
                    clearForm();
                    showInvoices();
                    $("#btnCreateInvoice").prop('disabled', false);
                    $("#btnUpdateInvoice").prop('disabled', true);
                },
                error: function (msg) {
                    alert(msg);
                }
            });
        }
    }
}
