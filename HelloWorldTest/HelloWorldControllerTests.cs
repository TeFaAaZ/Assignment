using MvcMovie.Controllers;
using System;
using Xunit;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var controller = new HelloWorldController();
            var expectedResult = "This is my default action...";

            // Act
            var result = controller.Index();

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
