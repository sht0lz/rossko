using AppServices.Permutation;
using Microsoft.AspNetCore.Mvc;
using WebApp.Model;

namespace WebApp.Controllers
{
    public class PermutationController : Controller
    {
        private readonly IPermutationsService _permutationsService;

        public PermutationController(IPermutationsService permutationsService)
        {
            _permutationsService = permutationsService;
        }
        
        [HttpPost("permutations")]
        public PermutationsModel Permutations(string input)
        {
            var permutations = _permutationsService.GetPermutations(input);
            return PermutationsModel.FromObject(permutations);
        }
    }
}