using Domain;

namespace AppServices.Permutation
{
    public interface IPermutationsService
    {
        Permutations GetPermutations(string input);
    }
}