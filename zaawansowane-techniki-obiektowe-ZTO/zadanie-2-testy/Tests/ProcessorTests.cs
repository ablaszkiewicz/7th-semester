using System;
using System.Collections.Generic;
using System.Linq;
using TDDLab.Core.InvoiceMgmt;
using Xunit;

namespace Tests
{
    public class ProcessorTests
    {
        [Fact]
        public void ValidInvoiceShouldSuceed()
        {
            var invoice = InvoiceHelpers.CreateValidInvoice();
            var processor = new InvoiceProcessorImpl();

            var result = processor.Process(invoice);

            Assert.Equal(InvoiceResult.Succeeded, result.Result);
        }

        [Fact]
        public void InvalidInvoiceShouldFail()
        {
            var invoice = InvoiceHelpers.CreateInvalidInvoice();
            var processor = new InvoiceProcessorImpl();

            var result = processor.Process(invoice);

            Assert.Equal(InvoiceResult.Failed, result.Result);
        }

        [Fact]
        public void ShouldGenerateProductsMapFromInvoice()
        {
            var line1 = new InvoiceLine("Product1", new Money(10));
            var line2 = new InvoiceLine("Product2", new Money(10));
            var line3 = new InvoiceLine("Product2", new Money(10));

            var invoice = InvoiceHelpers.CreateValidInvoice(new List<InvoiceLine>() { line1, line2, line3 });
            var processor = new InvoiceProcessorImpl();

            processor.Process(invoice);

            Assert.Equal(2, processor.Products.Count);
            Assert.Equal(new Money(10), processor.Products["Product1"]);
            Assert.Equal(new Money(15), processor.Products["Product2"]);
        }

        [Fact]
        public void ShouldGenerateProductsMapFromMultipleInvoices()
        {
            var line1 = new InvoiceLine("Product1", new Money(10));
            var line2 = new InvoiceLine("Product2", new Money(10));
            var line3 = new InvoiceLine("Product2", new Money(10));
            var invoice1 = InvoiceHelpers.CreateValidInvoice(new List<InvoiceLine>() { line1, line2, line3 });

            var line4 = new InvoiceLine("Product2", new Money(10));
            var invoice2 = InvoiceHelpers.CreateValidInvoice(new List<InvoiceLine>() { line4 });

            var processor = new InvoiceProcessorImpl();

            processor.Process(invoice1);
            processor.Process(invoice2);

            Assert.Equal(2, processor.Products.Count);
            Assert.Equal(new Money(10), processor.Products["Product1"]);
            Assert.Equal(new Money(20), processor.Products["Product2"]);
        }
    }
}
