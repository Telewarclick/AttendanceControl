using System;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace DAL.Tests
{
    public class PositionRepositoryTest
    {
        private readonly IRepository<Position> _positionRepository;
        private readonly Mock<DbSet<Position>> _mockDbSet;
        private readonly Mock<DbContext> _mockContext;

        public PositionRepositoryTest()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DbContext>()
                .Options;
            _mockContext = new Mock<DbContext>(opt);
            _mockDbSet = new Mock<DbSet<Position>>();

            _mockContext
                .Setup(context =>
                    context.Set<Position>(
                    ))
                .Returns(_mockDbSet.Object);

            _positionRepository = new PositionRepository(_mockContext.Object);
        }

        [Fact]
        public void Repository_CalledInsertOneTime_InsertCorrect()
        {
            // Arrange
            var expectedPosition = new Mock<Position>().Object;

            //Act
            _positionRepository.Add(expectedPosition);

            // Assert
            _mockDbSet.Verify(
                set => set.Add(
                    expectedPosition
                ), Times.Once());
        }

        [Fact]
        public void Repository_CalledRemove_RemovedCorrect()
        {
            // Arrange
            const int id = 1;

            var expectedProduct = new Position { Id = id };
            _mockDbSet.Setup(mock => mock.Find(expectedProduct.Id)).Returns(expectedProduct);

            // Act
            var foundPosition = _positionRepository.Get(id);

            _positionRepository.Remove(foundPosition);

            // Assert
            _mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedProduct.Id
                ), Times.Once());

            _mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedProduct
                ), Times.Once());
        }
    }
}
