using System;
using Api.Model;
using AppServices.Permutation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class PermutationController : Controller
    {
        private readonly IPermutationsService _permutationsService;

        public PermutationController(IPermutationsService permutationsService)
        {
            _permutationsService = permutationsService;
        }

        [HttpPost("permutations")]
        public IActionResult Permutations(string input)
        {
            try
            {
                var permutations = _permutationsService.GetPermutations(input);
                return Ok(PermutationsModel.FromObject(permutations));
            }
            catch (Exception e)
            {
                return BadRequest(e);
                throw;
            }
        }
    }
}