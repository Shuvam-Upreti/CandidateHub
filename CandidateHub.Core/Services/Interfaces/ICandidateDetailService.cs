using CandidateHub.Core.Dto;
using CandidateHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateHub.Core.Services.Interfaces
{
    public interface ICandidateDetailService
    {
        Task<CandidateDetail> CreateOrUpdateCandidate(CandidateDetailDto model);
    }
}
