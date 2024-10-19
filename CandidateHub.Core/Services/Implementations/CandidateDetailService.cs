using CandidateHub.Core.Repository.Interfaces;
using CandidateHub.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateHub.Core.Services.Implementations
{
    public class CandidateDetailService : ICandidateDetailService
    {
        private readonly ICandidateDetailRepository _candidateDetailRepository;
        public CandidateDetailService(ICandidateDetailRepository candidateDetailRepository)
        {
            _candidateDetailRepository = candidateDetailRepository;
        }
    }
}
