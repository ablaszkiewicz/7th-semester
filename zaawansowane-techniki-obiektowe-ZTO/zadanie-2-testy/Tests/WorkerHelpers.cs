using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TDDLab.Core.Infrastructure;
using TDDLab.Core.InvoiceMgmt;

namespace Tests
{
    internal class WorkerHelpers
    {
        public static WorkerImpl CreateWorker()
        {
            var settings = CreateConfigurationSettings();
            var messagingFacility = CreateMessagingFacility();
            var exceptionHandler = CreateExceptionHandler();
            var invoiceProcessor = CreateInvoiceProcessor();

            return new WorkerImpl(settings, messagingFacility, exceptionHandler, invoiceProcessor);
        }

        public static IConfigurationSettings CreateConfigurationSettings()
        {
            var mock = new Mock<IConfigurationSettings>();
            mock.Setup(x => x.GetSettingsByKey(It.IsAny<string>())).Returns("abc");

            return mock.Object;
        }

        public static IMessagingFacility<Invoice, ProcessingResult> CreateMessagingFacility()
        {
            var mock = new Mock<IMessagingFacility<Invoice, ProcessingResult>>();
            return mock.Object;
        }

        public static IExceptionHandler CreateExceptionHandler()
        {
            var mock = new Mock<IExceptionHandler>();
            return mock.Object;
        }

        public static IInvoiceProcessor CreateInvoiceProcessor()
        {
            return new InvoiceProcessorImpl();
        }
    }
}
