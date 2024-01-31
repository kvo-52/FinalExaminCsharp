using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMessage.Abstraction;
using WebAppMessage.Controllers;
using WebAppMessage.Model;

namespace TestProject1
{
    [TestFixture]
    public class MessageControllerTests
    {
        private MessageController _controller;
        private Mock<IMessageRepository> _mockMessageRepository;

        [SetUp]
        public void Setup()
        {
            _mockMessageRepository = new Mock<IMessageRepository>();
            _controller = new MessageController(null, _mockMessageRepository.Object);
        }

        [Test]
        public void GetAllMessages_ReturnsOkResult()
        {
            // Arrange
            var expectedMessages = new List<Message> {
            new Message {
                Text = "Hello, world!", SenderName = "Kat Black",
                ReceiverName = "Kat Black"
            },
            new Message {
                Text = "How are you?", SenderName = "Kat Blacke",
                ReceiverName = "Kat Black"
            }
        };
            _mockMessageRepository.Setup(x => x.GetAllMessages(It.IsAny<string>())).Returns(expectedMessages);

            // Act
            var result = _controller.GetAllMessages("Kat Black");

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void SendMessage_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var message = new MessagesDB { Text = "Hello, world!", SenderName = "Kat Black", ReceiverName = "Janey Red" };
            _mockMessageRepository.Setup(x => x.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(id);

            // Act
            var result = _controller.SendMessage(message).ToString();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual(id.ToString(), result);
        }
    }
}
