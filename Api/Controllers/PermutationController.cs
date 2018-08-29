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
        private readonly int maxLength = 8;

        public PermutationController(IPermutationsService permutationsService)
        {
            _permutationsService = permutationsService;
        }

        [HttpPost("permutations")]
        public IActionResult Permutations(string input)
        {
            IActionResult result = Validate(input);
            if (result != null)
            {
                return result;
            }
            
            var permutations = _permutationsService.GetPermutations(input);
            return Ok(PermutationsModel.FromObject(permutations));
        }

        private IActionResult Validate(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return BadRequest("Строка должна содержать символы");
            }

            if (!input.IsLatinAndNumberString())
            {
                return BadRequest("Допускаются только цифры латинские буквы");
            }
            
            if (input.Length > maxLength)
            {
                return BadRequest("Максимальная длинна последовательности не должна быть больше 8 символов");
            }

            return null;
        }
    }
}