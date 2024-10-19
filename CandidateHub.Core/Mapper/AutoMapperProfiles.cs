using AutoMapper;
using CandidateHub.Core.Dto;
using CandidateHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateHub.Core.Mapper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CandidateDetail,CandidateDetailDto>().ReverseMap();
        }
    }
}
