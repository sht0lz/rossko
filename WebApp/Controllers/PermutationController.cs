using AppServices.Permutation;
using Microsoft.AspNetCore.Mvc;
using WebApp.Model;

namespace WebApp.Controllers
{
    public class PermutationController : Controller
    {
        private readonly IPermutationService _permutation;

        public PermutationController()
        {
            _permutation = new PermutationService();
        }
        
        [HttpPost("permutations")]
        public PermutationsModel Permutations(string input)
        {
            var permutations = _permutation.GetPermutations(input);
            return PermutationsModel.FromObject(permutations);
        }
    }
}