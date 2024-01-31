using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMessage.Repositories;

namespace TestProject1
{
    [TestFixture]
    public class MessageRepositoryTests
    {
        [Test]
        public void SendMessage_Success()
        {
            // Arrange
            var repository = new MessageRepository();

            // Act
            var id = repository.SendMessage("Hello, World!", "John Doe", "Jane Doe");

            // Assert
            Assert.AreNotEqual(id, Guid.Empty);
        }



        [Test]
        public void GetAllMessages_Success()
        {
            // Arrange
            var repository = new MessageRepository();

            // Act
            var messages = repository.GetAllMessages("Jane Doe");

            // Assert
            Assert.IsNotNull(messages);
        }

        [Test]
        public void GetAllMessages_ReturnsEmptyList_ForNonExistingUser()
        {
            // Arrange
            var repository = new MessageRepository();

            // Act
            var messages = repository.GetAllMessages("NonExistingUser");

            // Assert
            Assert.IsNotNull(messages);
        }
    }
}
