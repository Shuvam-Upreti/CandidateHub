using CandidateHub.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateDetailService _candidateDetailService;
        public CandidateController(ICandidateDetailService candidateDetailService)
        {
            _candidateDetailService = candidateDetailService;
        }


    }
}
