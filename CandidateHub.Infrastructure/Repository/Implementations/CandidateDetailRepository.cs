using CandidateHub.Core.Entities;
using CandidateHub.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateHub.Infrastructure.Repository.Implementations
{
    public class CandidateDetailRepository : BaseRepository<CandidateDetail>, ICandidateDetailRepository
    {
        public CandidateDetailRepository(CandidateContext context) : base(context)
        {

        }
    }
}
