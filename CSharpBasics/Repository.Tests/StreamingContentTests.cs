using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Library;

namespace Repository.Tests
{
    [TestClass]
    public class StreamingContentTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            StreamingContent content = new StreamingContent();
            content.Title = "Forest Gump";

            Assert.AreEqual("Forest Gump", content.Title);
        }

        [TestMethod]
        public void TestConstructor()
        {
            StreamingContent content = new StreamingContent("Titanic", "The door was big enough", 9.0, MaturityRating.PG_13);

            Assert.AreEqual("Titanic", content.Title);
        }

        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            // Arrange
            StreamingContent content = new StreamingContent();
            StreamingContentRepository repository = new StreamingContentRepository();

            // Act
            bool addResult = repository.AddContentToDirectory(content);

            // Assert
            Assert.IsTrue(addResult);
        }

        // Testing the Read method (GET)
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            // Arrange
            StreamingContent content = new StreamingContent();
            StreamingContentRepository repo = new StreamingContentRepository();

            repo.AddContentToDirectory(content);

            // Act
            List<StreamingContent> contents = repo.GetContents();
            bool directoryHasContent = contents.Contains(content);

            // Assert
            Assert.IsTrue(directoryHasContent);
        }

        //Adding test Arrange
        private StreamingContentRepository _repo;
        private StreamingContent _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new StreamingContentRepository();
            _content = new StreamingContent("Titanic", "The door was big enough", 8.2, MaturityRating.R);

            _repo.AddContentToDirectory(_content);
        }

        // Testing the GetByTitle method
        [TestMethod]
        public void GetByTitle_ShouldReturnCorrectContent()
        {
            // Arrange
            // This will be replaced with the [TestInitialize] method now

            // Act
            StreamingContent searchResult = _repo.GetContentByTitle("Titanic");

            // Assert
            Assert.AreEqual(_content, searchResult);
        }

        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            // Arrange
            StreamingContent newContent = new StreamingContent("Titanic", "The door was big enough", 8.2, MaturityRating.PG_13);

            // Act
            bool updateResult = _repo.UpdateExistingContent("Titanic", newContent);

            // Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            // Arrange
            StreamingContent content = _repo.GetContentByTitle("Titanic");

            // Act
            bool removeResult = _repo.DeleteExistingContent(content);

            // Assert
            Assert.IsTrue(removeResult);
        }
    }
}
