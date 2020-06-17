using System;
using System.Threading.Tasks;
using BLL.Services;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using Xunit;

namespace BLL.Test
{
    public class ActualTimeServiceTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;

        public ActualTimeServiceTest()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void ActualTimeServiceCtor_NullConstructionParams_ExceptionThrows()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new ActualTimeService(nullUnitOfWork));
        }

        [Fact]
        public void ActualTimeServiceRemoveActualTime_UserIsUser_ThrowMethodAccessException()
        {
            // Arrange
            var user = new User(Guid.NewGuid(), Guid.NewGuid().ToString());
            Authorization.SetUser(user);

            IActualTimeService actualTimeService = new ActualTimeService(_mockUnitOfWork.Object);

            // Act

            // Assert
            Assert.ThrowsAsync<MethodAccessException>(() => actualTimeService.RemoveActualTimeAsync(1));
        }

        [Fact]
        public async Task GetActualTime_ActualTimeFromDAL_CorrectMappingToActualTimeDTO()
        {
            // Arrange
            var user = new Administrator(Guid.NewGuid(), Guid.NewGuid().ToString());
            Authorization.SetUser(user);

            var enterTime = DateTime.UtcNow.AddHours(-8);
            var exitTime = DateTime.UtcNow;

            var itemId = 1;
            var actualTimeService = GetActualTimeService(itemId, enterTime, exitTime);

            // Act
            var actualProductDto = await actualTimeService.GetActualTimeAsync(itemId);

            // Assert
            Assert.True(
                actualProductDto.Id == itemId
                && actualProductDto.TimeEnter == enterTime
                && actualProductDto.TimeExit == exitTime
            );
        }

        private IActualTimeService GetActualTimeService(int itemId, DateTime timeEnter, DateTime timeExit)
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedActualTime = new ActualTime()
            {
                Id = itemId,
                TimeEnter = timeEnter,
                TimeExit = timeExit
            };
            var repMock = new Mock<IActualTimeRepository>();

            repMock.Setup(mock => mock.GetAsync(itemId)).ReturnsAsync(expectedActualTime);

            mockContext
                .Setup(context =>
                    context.ActualTimeRepository)
                .Returns(repMock.Object);
            mockContext.Setup(mock => mock.ActualTimeRepository.GetAsync(itemId)).ReturnsAsync(expectedActualTime);

            IActualTimeService actualTimeService = new ActualTimeService(mockContext.Object);

            return actualTimeService;
        }
    }
}

/*
 using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using DAL.UnitOfWork.Interfaces;
using Moq;
using Xunit;

namespace BLL.Tests
{
    public class ActualTimeServiceTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [SetUp]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Test]
        public void ProductServiceCtor_NullConstructionParams_ExceptionThrows()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new ProductService(nullUnitOfWork));
        }

        [Test]
        public void ProductServiceRemoveProduct_UserIsUser_ThrowMethodAccessException()
        {
            // Arrange
            var user = new User(Guid.NewGuid(), Guid.NewGuid().ToString());
            Authorization.SetUser(user);

            IProductService productService = new ProductService(_mockUnitOfWork.Object);

            // Act

            // Assert
            Assert.ThrowsAsync<MethodAccessException>(() => productService.RemoveProductAsync(Guid.NewGuid()));
        }

        [Test]
        public async Task GetProduct_ProductFromDAL_CorrectMappingToProductDTO()
        {
            // Arrange
            var user = new Administrator(Guid.NewGuid(), Guid.NewGuid().ToString());
            Authorization.SetUser(user);

            var itemId = Guid.NewGuid();
            var productService = GetProductService(itemId);

            // Act
            var actualProductDto = await productService.GetProductAsync(itemId);

            // Assert
            Assert.True(
                actualProductDto.Id == itemId
                && actualProductDto.Name == "testName"
                && actualProductDto.Description == "testDescription"
            );
        }

        private IProductService GetProductService(Guid itemId)
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedLocalPoint = new Product()
            {
                Id = itemId,
                Name = "testName",
                Description = "testDescription"
            };
            var mockDbSet = new Mock<IRepository<Product>>();

            mockDbSet.Setup(mock => mock.GetByIdAsync(itemId)).ReturnsAsync(expectedLocalPoint);

            mockContext
                .Setup(context =>
                    context.Repository<Product>())
                .Returns(mockDbSet.Object);
            mockContext.Setup(mock => mock.GetByIdAsync<Product>(itemId)).ReturnsAsync(expectedLocalPoint);

            IProductService productService = new ProductService(mockContext.Object);

            return productService;
        }

    }
}
 */
