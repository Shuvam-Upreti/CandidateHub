using AutoMapper;
using CandidateHub.Core.Dto;
using CandidateHub.Core.Entities;
using CandidateHub.Core.Exceptions;
using CandidateHub.Core.Helpers;
using CandidateHub.Core.Repository.Interfaces;
using CandidateHub.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CandidateHub.Core.Services.Implementations
{
    public class CandidateDetailService : ICandidateDetailService
    {
        private readonly ICandidateDetailRepository _candidateDetailRepository;
        private readonly IMapper _mapper;
        public CandidateDetailService(ICandidateDetailRepository candidateDetailRepository, IMapper mapper)
        {
            _candidateDetailRepository = candidateDetailRepository;
            _mapper = mapper;
        }

        public async Task CreateOrUpdateCandidate(CandidateDetailDto model)
        {
            using var tx = TransactionScopeHelper.GetInstance();

            var existingCandidate = await _candidateDetailRepository.GetQueryable().FirstOrDefaultAsync(a => a.Email == model.Email);
            if (existingCandidate != null)
            {
                _mapper.Map(model, existingCandidate);
                _candidateDetailRepository.Update(existingCandidate);
            }
            else
            {
                var entity = _mapper.Map<CandidateDetail>(model);
                await _candidateDetailRepository.InsertAsync(entity);
            }
            tx.Complete();
        }
    }
}
