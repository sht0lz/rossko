﻿using System;
using System.Diagnostics;
using System.Text;
using Domain;
using Domain.Interfaces;

namespace AppServices.Permutation
{
    public class PermutationsService:IPermutationsService
    {
        private readonly IPermutationsCalculator _calculator;
        private readonly IPermutationsCache _cache;

        public PermutationsService(IPermutationsCalculator calculator, IPermutationsCache cache)
        {
            _calculator = calculator;
            _cache = cache;
        }
        
        public Permutations GetPermutations(string input)
        {

            var cachedPermutation = _cache.Get(input);
            if (cachedPermutation != null)
            {
                return cachedPermutation;
            }
            
            var sw = new Stopwatch();
            sw.Start();
            var number = _calculator.NumberOfPermutations(input);
            sw.Stop();
            var result = new Permutations(){PermutationNumber = number, Elapsed = sw.Elapsed}; 
            _cache.Set(input, result);
            return result;
        }
    }
}