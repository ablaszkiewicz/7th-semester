using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TDDLab.Core.Infrastructure;
using TDDLab.Core.InvoiceMgmt;
using Xunit;

namespace Tests
{
    public class WorkerTests
    {
        private readonly Mock<IConfigurationSettings> _configurationSettings = new Mock<IConfigurationSettings>();
        private readonly Mock<IMessagingFacility<Invoice, ProcessingResult>> _messagingFacility = new Mock<IMessagingFacility<Invoice, ProcessingResult>>();
        private readonly Mock<IExceptionHandler> _exceptionHandler = new Mock<IExceptionHandler>();
        private readonly Mock<IInvoiceProcessor> _invoiceProcessor = new Mock<IInvoiceProcessor>();
        
        private WorkerImpl CreateWorkerWithMocks()
        {
            return new WorkerImpl(_configurationSettings.Object, _messagingFacility.Object, _exceptionHandler.Object, _invoiceProcessor.Object);
        }

        [Fact]
        public void ShouldInitializeChannelsUponStart()
        {
            var worker = CreateWorkerWithMocks();

            worker.Start();

            _messagingFacility.Verify(x => x.InitializeInputChannel(It.IsAny<string>()), Times.Once());
            _messagingFacility.Verify(x => x.InitializeOutputChannel(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void ShouldDisposeMessagingFacility()
        {
            var worker = CreateWorkerWithMocks();

            worker.Stop();

            _messagingFacility.Verify(x => x.Dispose(), Times.Once());
        }

        [Fact]
        public void ShouldHandleException()
        {
            var worker = CreateWorkerWithMocks();
            _messagingFacility.Setup(x => x.ReadMessage()).Throws(new Exception());

            worker.DoJob();

            _exceptionHandler.Verify(x => x.HandleException(It.IsAny<Exception>()), Times.Once());
        }
    }
}
