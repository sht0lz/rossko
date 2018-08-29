using System;
using Api.Extensions;
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
            if (String.IsNullOrEmpty(input))
            {
                return BadRequest("Строка должна содержать символы");
            }

            if (!input.IsLatinAndNumberString())
            {
                return BadRequest("Допускаются только цифры латинские буквы");
            }
            
            var permutations = _permutationsService.GetPermutations(input);
            return Ok(PermutationsModel.FromObject(permutations));
        }
    }
}