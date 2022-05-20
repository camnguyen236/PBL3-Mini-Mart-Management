select Products.Name_P, Products.Unit_P,  InvoiceDetail.Quantity, InvoiceDetail.Unit_Price, InvoiceDetail.Amount
from((
Invoice
inner join InvoiceDetail on Invoice.ID_Invoice= InvoiceDetail.ID_Invoice and Invoice.Invoice_Date='2022-04-03')
inner join Products on InvoiceDetail.ID_P=Products.ID_P)

select Products.Name_P, Products.Unit_P,  DetailImportProduct.Amount_IP, DetailImportProduct.Amount_Price, DetailImportProduct.Total from(( ImportProduct inner join DetailImportProduct on ImportProduct.ID_IP= ImportProduct.ID_IP and ImportProduct.Date_Import='2022-04-23') inner join Products on DetailImportProduct.ID_P=Products.ID_P)