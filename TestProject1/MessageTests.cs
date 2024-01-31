using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMessage.Model;

namespace TestProject1
{
    [TestFixture]
    public class MessageTests
    {
        [Test]
        public void Message_Properties_SetAndGet()
        {
            // Arrange
            var message = new Message();
            var Id = Guid.NewGuid();

            // Act
            message.Id = Id;
            message.SenderName = "";
            message.ReceiverName = "new User()";
            message.Text = "Hello, World!";
            message.IsReceived = true;

            // Assert
            Assert.AreEqual(message.Id, Id);
            Assert.IsNotNull(message.SenderName);
            Assert.IsNotNull(message.ReceiverName);
            Assert.AreEqual(message.Text, "Hello, World!");
            Assert.IsTrue(message.IsReceived);
        }
    }
}
