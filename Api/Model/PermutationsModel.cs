using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Model
{
    public class PermutationsModel
    {
        private static readonly string elapsedStringFormat = @"s\.fffff"; 
        public int PermutationNumber { get; set; }
        public string Elapsed { get; set; }

        public static PermutationsModel FromObject(Permutations obj)
        {
            return new PermutationsModel 
            {
                PermutationNumber = obj.PermutationNumber, 
                Elapsed = obj.Elapsed.ToString(elapsedStringFormat)
            };
        }
    }
}