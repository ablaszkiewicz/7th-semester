using System;
using Moq;
using TDDLab.Core.InvoiceMgmt;
using Xunit;

namespace Tests
{
    public class InvoiceTests
    {
        public InvoiceTests()
        {
        }

        [Fact]
        public void ShouldAttachInvoiceLine()
        {
            var invoiceLine = new InvoiceLine("", new Money(1));
            var invoice = new Invoice();

            invoice.AttachInvoiceLine(invoiceLine);

            var lines = invoice.Lines;
            Assert.Equal(1, lines.Count);
        }
    }
}

