using CandidateApp.Application.DTOs;
using CandidateApp.Application.Interfaces;
using CandidateApp.Application.Services;
using CandidateApp.Domain.Entities;
using Moq;

namespace CandidateApp.Tests
{
    public class CandidateServiceTests
    {

        [Fact]
        public async Task AddOrUpdateCandidate_ShouldCreateCandidate_WhenNotExists()
        {
            // Arrange
            var repoMock = new Mock<ICandidateRepository>();
            repoMock.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync((Candidate?)null);

            var service = new CandidateService(repoMock.Object);

            var dto = new CandidateDto
            {
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe"
            };

            // Act
            await service.AddOrUpdateCandidate(dto);

            // Assert
            repoMock.Verify(r => r.AddOrUpdateAsync(It.IsAny<Candidate>()), Times.Once);
        }
    }

}

