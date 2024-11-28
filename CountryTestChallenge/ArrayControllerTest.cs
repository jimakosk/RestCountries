using Countries_Server.Controllers;
using Countries_Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CountryTestChallenge
{
    public class ArrayControllerTest
    {
        [Fact]
        public void GetSecondLargest_ValidInput_ReturnsSecondLargest()
        {
            var mockLogger = new Mock<ILogger<ArrayController>>();
            var controller = new ArrayController(mockLogger.Object);
            var request = new RequestObj
            {
                RequestArrayObj = new List<int> { 5, 10, 20, 15 }
            };


            var result = controller.GetSecondLargest(request);


            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(15, okResult.Value);
        }

        [Fact]
        public void GetSecondLargest_LessThanTwoIntegers_ReturnsBadRequest()
        {

            var mockLogger = new Mock<ILogger<ArrayController>>();
            var controller = new ArrayController(mockLogger.Object);

            var request = new RequestObj
            {
                RequestArrayObj = new List<int> { 5 }
            };


            var result = controller.GetSecondLargest(request);


            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Array must have at least two integers.", badRequestResult.Value);
        }

        [Fact]
        public void GetSecondLargest_NoUniqueIntegers_ReturnsBadRequest()
        {
            var mockLogger = new Mock<ILogger<ArrayController>>();
            var controller = new ArrayController(mockLogger.Object);
            var request = new RequestObj
            {
                RequestArrayObj = new List<int> { 5, 5, 5 }
            };


            var result = controller.GetSecondLargest(request);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Array must have at least two unique integers.", badRequestResult.Value);
        }

        [Fact]
        public void GetSecondLargest_NullRequestArray_ReturnsBadRequest()
        {
            var mockLogger = new Mock<ILogger<ArrayController>>();
            var controller = new ArrayController(mockLogger.Object);
            var request = new RequestObj
            {
                RequestArrayObj = null
            };

            var result = controller.GetSecondLargest(request);


            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Array must have at least two integers.", badRequestResult.Value);
        }
    }
}

