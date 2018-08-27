using System;
using Domain;

namespace AppServices.Permutation
{
    public interface IPermutationService
    {
        Permutations GetPermutations(string input);
    }
}