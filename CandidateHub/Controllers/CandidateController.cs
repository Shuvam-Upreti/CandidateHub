using CandidateHub.Core.Dto;
using CandidateHub.Core.Services.Interfaces;
using CandidateHub.Extension;
using CandidateHub.Logging;
using CandidateHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


        [HttpPost]
        [ProducesResponseType(typeof(APIResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AddOrUpdateCandidate([FromBody] CandidateDetailDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Status = "Error",
                    Message = "Validation errors occurred.",
                    Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                });
            }
            try
            {
               var candidate= await _candidateDetailService.CreateOrUpdateCandidate(model);
                return this.ApiSuccessResponse(HttpStatusCode.OK, "Successfully added candidate.",candidate);
            }
            catch (Exception ex)
            {
                new SeriLogger().Error(ex.Message, ex);
                var errors = new List<string> { ex.Message };

                return this.ApiErrorResponse(HttpStatusCode.InternalServerError, errors, "Error", "Something went wrong. Please contact the administrator.");
            }
        }

    }
}
