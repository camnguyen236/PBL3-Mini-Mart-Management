
/*select Products.Name_P, Products.Unit_P,  InvoiceDetail.Quantity, InvoiceDetail.Unit_Price, InvoiceDetail.Amount
from((
Invoice
inner join InvoiceDetail on Invoice.ID_Invoice= InvoiceDetail.ID_Invoice and Invoice.Invoice_Date='2022-04-03')
inner join Products on InvoiceDetail.ID_P=Products.ID_P)*/

/*select Products.Name_P, Products.Unit_P,  DetailImportProduct.Amount_IP, DetailImportProduct.Amount_Price, DetailImportProduct.Total
from(( DetailImportProduct
left join  ImportProduct  
on ImportProduct.ID_IP= ImportProduct.ID_IP and Year(ImportProduct.Date_Import)='2022') 
left join Products 
on DetailImportProduct.ID_P=Products.ID_P)*/

/*select Products.ID_P, Products.Name_P,  DetailImportProduct.Total
from ImportProduct, DetailImportProduct ,Products
where DetailImportProduct.ID_P=Products.ID_P and ImportProduct.ID_IP = ImportProduct.ID_IP and Year(ImportProduct.Date_Import)='2022'*/

/*select Products.Name_P, Products.Unit_P,  sum(DetailImportProduct.Amount_IP) as Quantity, DetailImportProduct.IP_Price as Price, sum(DetailImportProduct.Total) as Total
from ((DetailImportProduct
left join  Products  
on DetailImportProduct.ID_P=Products.ID_P)
left join ImportProduct
on DetailImportProduct.ID_IP= ImportProduct.ID_IP and Year(ImportProduct.Date_Import)='2022'
)*/



/*select Products.Name_P, Products.Unit_P,  sum(DetailImportProduct.Amount_IP) as Quantity, DetailImportProduct.IP_Price as Price, sum(DetailImportProduct.Total) as Total 
                from((DetailImportProduct
                left join  Products on DetailImportProduct.ID_P = Products.ID_P) 
                left join ImportProduct on DetailImportProduct.ID_IP = ImportProduct.ID_IP and Year(ImportProduct.Date_Import)='2022')
                group by Products.Name_P , Products.Unit_P , DetailImportProduct.IP_Price

select Products.Name_P, Products.Unit_P,  sum(InvoiceDetail.Quantity) as Quantity, InvoiceDetail.Unit_Price, sum(InvoiceDetail.Amount) as Amount
from(
        (   
            InvoiceDetail
            left join Products
            on InvoiceDetail.ID_P= Products.ID_P 
        )
        left join  Invoice
        on InvoiceDetail.ID_Invoice = Invoice.ID_Invoice and Invoice.Invoice_Date = '2022'
)
group by Products.Name_P , Products.Unit_P, InvoiceDetail.Unit_Price*/


/*sale Year*/
/*string query = "select Products.Name_P, Products.Unit_P,  InvoiceDetail.Quantity, InvoiceDetail.Unit_Price, InvoiceDetail.Amount from(( Invoice " +
                "inner join InvoiceDetail " +
                $"on Invoice.ID_Invoice = InvoiceDetail.ID_Invoice and year(Invoice.Invoice_Date) = '{date.Year}')" +
                "inner join Products " +
                "on InvoiceDetail.ID_P = Products.ID_P)";*/
            /*string query = "select Products.Name_P, Products.Unit_P,  sum(InvoiceDetail.Quantity) as Quantity, InvoiceDetail.Unit_Price, sum(InvoiceDetail.Amount) as Amount " +
                "from((InvoiceDetail " +
                "left join Products " +
                "on InvoiceDetail.ID_P = Products.ID_P) " +
                "left join  Invoice " +
                $"on InvoiceDetail.ID_Invoice = Invoice.ID_Invoice and year(Invoice.Invoice_Date) = '{date.Year}') " +
                "group by Products.Name_P , Products.Unit_P, InvoiceDetail.Unit_Price ";*/
            /*string query = "select Products.Name_P, Products.Unit_P,  sum(InvoiceDetail.Quantity) as Quantity, InvoiceDetail.Unit_Price, sum(InvoiceDetail.Amount) as Amount " +
                "from((InvoiceDetail " +
                "left join Products " +
                "on InvoiceDetail.ID_P = Products.ID_P) " +
                "left join  Invoice " +
                $"on InvoiceDetail.ID_Invoice = Invoice.ID_Invoice and year(Invoice.Invoice_Date) = '{date.Year}') " +
                "group by Products.Name_P , Products.Unit_P, InvoiceDetail.Unit_Price ";*/
/*sale date*/
/*string query = "select Products.Name_P, Products.Unit_P,  InvoiceDetail.Quantity, InvoiceDetail.Unit_Price, InvoiceDetail.Amount from(( Invoice " +
                "inner join InvoiceDetail " +
                $"on Invoice.ID_Invoice = InvoiceDetail.ID_Invoice and Invoice.Invoice_Date = '{date.ToString("yyyy-MM-dd")}')" +
                "inner join Products " +
                "on InvoiceDetail.ID_P = Products.ID_P)";*/
            /*string query = "select Products.Name_P, Products.Unit_P,  sum(InvoiceDetail.Quantity) as Quantity, InvoiceDetail.Unit_Price, sum(InvoiceDetail.Amount) as Amount " +
                "from((InvoiceDetail " +
                "left join Products " +
                "on InvoiceDetail.ID_P = Products.ID_P) " +
                "left join  Invoice " +
                $"on InvoiceDetail.ID_Invoice = Invoice.ID_Invoice and Invoice.Invoice_Date = '{date.ToString("yyyy-MM-dd")}') " +
                "group by Products.Name_P , Products.Unit_P, InvoiceDetail.Unit_Price ";*/
            /*string query = "select Products.Name_P, Products.Unit_P,  sum(InvoiceDetail.Quantity) as Quantity, InvoiceDetail.Unit_Price, sum(InvoiceDetail.Amount) as Amount " +
                "from((Invoice " +
                "left join InvoiceDetail " +
                $"on InvoiceDetail.ID_Invoice = Invoice.ID_Invoice and Invoice.Invoice_Date = '{date.ToString("yyyy - MM - dd")}') " +
                "left join Products " +
                "on InvoiceDetail.ID_P = Products.ID_P) " +
                "group by Products.Name_P , Products.Unit_P, InvoiceDetail.Unit_Price ";*/

/*import year*/
/*string query = "select Products.Name_P, Products.Unit_P,  sum(DetailImportProduct.Amount_IP) as Quantity, DetailImportProduct.IP_Price as Price, sum(DetailImportProduct.Total) as Total " +
                "from((DetailImportProduct " +
                "left join  Products on DetailImportProduct.ID_P = Products.ID_P) " +
                $"left join ImportProduct on DetailImportProduct.ID_IP = ImportProduct.ID_IP and Year(ImportProduct.Date_Import)='{date.Year}') " +
                "group by Products.Name_P , Products.Unit_P , DetailImportProduct.IP_Price";*/

/*impor date*/
/* string query = "select Products.Name_P, Products.Unit_P,  sum(DetailImportProduct.Amount_IP) as Quantity, DetailImportProduct.IP_Price as Price, sum(DetailImportProduct.Total) as Total " +
                 "from((DetailImportProduct " +
                 "left join  Products on DetailImportProduct.ID_P = Products.ID_P) " +
                 $"left join ImportProduct on DetailImportProduct.ID_IP = ImportProduct.ID_IP and ImportProduct.Date_Import='{date.ToString("yyyy-MM-dd")}') " +
                 "group by Products.Name_P , Products.Unit_P , DetailImportProduct.IP_Price";*/

/*sale date*/
/*select Products.Name_P as "Name Product", Products.Unit_P as Unit,InvoiceDetail.Unit_Price as Price,  sum(InvoiceDetail.Quantity) as Quantity,  sum(InvoiceDetail.Amount) as Amount
from ((InvoiceDetail
inner join (select * from Invoice where Invoice.Invoice_Date = '2022-04-03') as Invoice
on InvoiceDetail.ID_Invoice = Invoice.ID_Invoice)
left join Products 
on Products.ID_P = InvoiceDetail.ID_P)
group by Products.Name_P , Products.Unit_P, InvoiceDetail.Unit_Price*/

/*sale Year*/
/*select Products.Name_P as "Name Product", Products.Unit_P as Unit,InvoiceDetail.Unit_Price as Price,  sum(InvoiceDetail.Quantity) as Quantity,  sum(InvoiceDetail.Amount) as Amount
from ((InvoiceDetail
inner join (select * from Invoice where Year(Invoice.Invoice_Date) = '2024') as Invoice
on InvoiceDetail.ID_Invoice = Invoice.ID_Invoice)
left join Products 
on Products.ID_P = InvoiceDetail.ID_P)
group by Products.Name_P , Products.Unit_P, InvoiceDetail.Unit_Price*/

/*import date*/
/*select Products.Name_P, Products.Unit_P, sum(DetailImportProduct.Amount_IP) as Quantity, DetailImportProduct.IP_Price as Price, sum(DetailImportProduct.Total) as Total
from ((DetailImportProduct
inner join (select * from ImportProduct where ImportProduct.Date_Import = '2022-03-28') as ImportProduct
on DetailImportProduct.ID_IP = ImportProduct.ID_IP)
left join Products 
on Products.ID_P = DetailImportProduct.ID_P)
group by Products.Name_P , Products.Unit_P, DetailImportProduct.IP_Price*/

/*import year*/
/*select Products.Name_P, Products.Unit_P, sum(DetailImportProduct.Amount_IP) as Quantity, DetailImportProduct.IP_Price as Price, sum(DetailImportProduct.Total) as Total
from ((DetailImportProduct
inner join (select * from ImportProduct where year(ImportProduct.Date_Import) = '2022') as ImportProduct
on DetailImportProduct.ID_IP = ImportProduct.ID_IP)
left join Products 
on Products.ID_P = DetailImportProduct.ID_P)
group by Products.Name_P , Products.Unit_P, DetailImportProduct.IP_Price*/

/*import date*/
/*select Products.Name_P, Products.Unit_P, sum(DetailImportProduct.Amount_IP) as Quantity, DetailImportProduct.IP_Price as Price, sum(DetailImportProduct.Total) as Total, ImportProduct.Date_Import
from ((DetailImportProduct
inner join (select * from ImportProduct where ImportProduct.Date_Import BETWEEN '2022-03-27' and '2022-04-26') as ImportProduct
on DetailImportProduct.ID_IP = ImportProduct.ID_IP)
left join Products 
on Products.ID_P = DetailImportProduct.ID_P)
group by Products.Name_P , Products.Unit_P, DetailImportProduct.IP_Price, ImportProduct.Date_Import*/


/*select top sale push to chart*/
/*select top(5) Products.Name_P , sum(InvoiceDetail.Quantity) as Quantity
                from((InvoiceDetail
                inner join(select * from Invoice where year(Invoice.Invoice_Date) BETWEEN '2022' and '2022') as Invoice
                on InvoiceDetail.ID_Invoice = Invoice.ID_Invoice)
                left join Products 
                on Products.ID_P = InvoiceDetail.ID_P)
                group by Products.Name_P
                order by sum(InvoiceDetail.Quantity) desc */
               
                
/*profit*/
/*import*/

 
 select Invoice.Invoice_Date as Date, sum(InvoiceDetail.Amount) as Cost from (select * from Invoice where Invoice_Date between '2022-01-01' and '2022-12-31') as Invoice 
left join InvoiceDetail on Invoice.ID_Invoice = InvoiceDetail.ID_Invoice
 group by Invoice.Invoice_Date

    




