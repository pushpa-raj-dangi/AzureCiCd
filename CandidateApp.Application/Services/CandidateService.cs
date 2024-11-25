using CandidateApp.Application.DTOs;
using CandidateApp.Application.Interfaces;
using CandidateApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateApp.Application.Services
{
    public class CandidateService
    {
        private readonly ICandidateRepository _repository;

        public CandidateService(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task AddOrUpdateCandidate(CandidateDto dto)
        {
            var existingCandidate = await _repository.GetByEmailAsync(dto.Email);

            if (existingCandidate != null)
            {
                // Update
                existingCandidate.FirstName = dto.FirstName;
                existingCandidate.LastName = dto.LastName;
                existingCandidate.PhoneNumber = dto.PhoneNumber;
                existingCandidate.CallTimeInterval = dto.CallTimeInterval;
                existingCandidate.LinkedInUrl = dto.LinkedInUrl;
                existingCandidate.GitHubUrl = dto.GitHubUrl;
                existingCandidate.Comments = dto.Comments;
                existingCandidate.UpdatedAt = DateTime.UtcNow;

                await _repository.AddOrUpdateAsync(existingCandidate);
            }
            else
            {
                // Create
                var newCandidate = new Candidate
                {
                    Id = Guid.NewGuid(),
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email,
                    CallTimeInterval = dto.CallTimeInterval,
                    LinkedInUrl = dto.LinkedInUrl,
                    GitHubUrl = dto.GitHubUrl,
                    Comments = dto.Comments,
                    UpdatedAt = DateTime.UtcNow
                };

                await _repository.AddOrUpdateAsync(newCandidate);
            }
        }
    }
}
