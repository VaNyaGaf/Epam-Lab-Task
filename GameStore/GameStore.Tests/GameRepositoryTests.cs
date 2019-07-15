using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GameStore.Core.Entities;
using GameStore.Core.Interfaces;
using GameStore.Infrastructure.Services;
using Moq;
using Xunit;

namespace GameStore.Tests
{
    public class GameRepositoryTests
    {
        [Fact]
        public async void GetAllAsync_ValidCall()
        {
            var mock = new Mock<IGameRepository>();

            mock.Setup(repo => repo.GetAllAsync())
                .Returns(Task.FromResult(GetGames()));

            var service = new GameService(mock.Object);

            var expected = GetGames();
            var actual = await service.GetAllAsync();

            Assert.NotNull(actual);
            Assert.Equal(expected.Count, actual.Count);
        }

        [Fact]
        public async void GetByIdAsync_ValidCall()
        {
            var mock = new Mock<IGameRepository>();

            mock.Setup(repo => repo.GetByIdAsync(1))
                .ReturnsAsync(GetGame());

            var service = new GameService(mock.Object);

            var expected = GetGame();
            var actual = await service.GetByIdAsync(1);

            // Assert.True(expected.Equals(actual));     //  Why this don't work???
            expected.Should().BeEquivalentTo(actual);
        }

        private IReadOnlyCollection<Game> GetGames()
        {
            return new List<Game>
            {
                new Game() { Id = 1, Name = "CS:GO" },
                new Game() { Id = 2, Name = "Dota2" }
            };
        }

        private Game GetGame()
        {
            return new Game() { Id = 1, Name = "CS:GO" };
        }
    }
}
