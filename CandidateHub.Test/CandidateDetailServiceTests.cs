using AutoMapper;
using CandidateHub.Core.Dto;
using CandidateHub.Core.Entities;
using CandidateHub.Core.Repository.Interfaces;
using CandidateHub.Core.Services.Implementations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MockQueryable.Moq;
using MockQueryable;

namespace CandidateHub.Test
{
    public class CandidateDetailServiceTests
    {
        private readonly Mock<ICandidateDetailRepository> _mockRepository;
        private readonly IMapper _mapper;
        private readonly CandidateDetailService _service;

        public CandidateDetailServiceTests()
        {
            _mockRepository = new Mock<ICandidateDetailRepository>();
            var config = new MapperConfiguration(cfg =>
            {
                // Assuming you have a mapping defined
                cfg.CreateMap<CandidateDetailDto, CandidateDetail>();
            });
            _mapper = config.CreateMapper();
            _service = new CandidateDetailService(_mockRepository.Object, _mapper);
        }

        [Fact]
        public async Task CreateOrUpdateCandidate_AddsNewCandidate()
        {
            // Arrange
            var candidateDto = new CandidateDetailDto
            {
                FirstName = "Shuvam",
                LastName = "Upreti",
                Email = "shuvamupreti@gmail.com",
                PhoneNumber = "9864837953",
                FreeTextComment = "Hello this is text comment!",
                LinkedInProfileUrl = "https://www.linkedin.com/in/shuvam-upreti/",
                GitHubProfileUrl = "https://github.com/Shuvam-Upreti"
            };

            // Create a mock candidate list
            var candidates = new List<CandidateDetail>().AsQueryable();

            _mockRepository.Setup(repo => repo.GetQueryable())
                .Returns(candidates.BuildMock());

            // Act
            await _service.CreateOrUpdateCandidate(candidateDto);

            // Assert
            _mockRepository.Verify(repo => repo.InsertAsync(It.IsAny<CandidateDetail>()), Times.Once);
            _mockRepository.Verify(repo => repo.Update(It.IsAny<CandidateDetail>()), Times.Never);
        }

        [Fact]
        public async Task CreateOrUpdateCandidate_UpdatesExistingCandidate()
        {
            // Arrange
            var candidateDto = new CandidateDetailDto
            {
                FirstName = "Shuvam",
                LastName = "Upreti",
                Email = "shuvamupreti@gmail.com",
                PhoneNumber = "9864837953",
                FreeTextComment = "Hello this is text comment!",
                LinkedInProfileUrl = "https://www.linkedin.com/in/shuvam-upreti/",
                GitHubProfileUrl = "https://github.com/Shuvam-Upreti"
            };
            // Creating a mock for existing candidate
            var existingCandidate = new CandidateDetail
            {
                FirstName = "Shuvam",
                LastName = "Upreti",
                Email = "shuvamupreti@gmail.com",  // This email should matches the candidateDto.Email
                PhoneNumber = "9864837953",
                FreeTextComment = "Hello this is text comment!",
                LinkedInProfileUrl = "https://www.linkedin.com/in/shuvam-upreti/",
                GitHubProfileUrl = "https://github.com/Shuvam-Upreti"
            };
            // Create a mock candidate list
            var candidates = new List<CandidateDetail> { existingCandidate }.AsQueryable();

            _mockRepository.Setup(repo => repo.GetQueryable())
                .Returns(candidates.BuildMock());

            // Act
            await _service.CreateOrUpdateCandidate(candidateDto);

            // Assert
            _mockRepository.Verify(repo => repo.Update(It.IsAny<CandidateDetail>()), Times.Once);
            _mockRepository.Verify(repo => repo.InsertAsync(It.IsAny<CandidateDetail>()), Times.Never);
        }
    }
}
