using System;
using System.Collections.Generic;
using System.Text;
using TDDLab.Core.InvoiceMgmt;

namespace Tests
{
    internal class InvoiceHelpers
    {
        public static Invoice CreateValidInvoice()
        {
            var invoiceNumber = "123";
            var address = new Address("Street", "City", "State", "Zip");
            var recipient = new Recipient("Name", address);
            var invoiceLines = new List<InvoiceLine>() { CreateValidInvoiceLine(), CreateValidInvoiceLine() };
            var billToAddress = address;
            var discount = new Money(5);

            return new Invoice(invoiceNumber, recipient, billToAddress, invoiceLines, discount);
        }

        public static Invoice CreateValidInvoice(IList<InvoiceLine> lines)
        {
            var invoiceNumber = "123";
            var address = new Address("Street", "City", "State", "Zip");
            var recipient = new Recipient("Name", address);
            var invoiceLines = lines;
            var billToAddress = address;
            var discount = new Money(5);

            return new Invoice(invoiceNumber, recipient, billToAddress, invoiceLines, discount);
        }

        public static Invoice CreateInvalidInvoice()
        {
            return new Invoice();
        }

        private static InvoiceLine CreateValidInvoiceLine()
        {
            return new InvoiceLine("Product", new Money(10, "USD"));
        }
    }
}
