using System;
using System.Text;

namespace AppServices.Permutation
{
    public class PermutationsCalculator: IPermutationsCalculator
    {
        public Int32 NumberOfPermutations(string input)
        {
            StringBuilder sb = new StringBuilder(input);
            Int32 i = 0; 
            Int32 j; 
            Int32 k;
            Int32 m = 3;
            
            Int32 length = input.Length;
            Int32 toSwapIndex = 0;
            Int32 groupEnd = 0; 

            Int32 multiplicationFactorials = 1;
            Int32 factorialOfNumber = 1*2*3;
            
            while (i < length)
            {
                
                j = i + 1;
                k = 1;
                toSwapIndex = j;
                while (j < length)
                {
                    if (sb[i] == sb[j])
                    {
                        if (j > toSwapIndex)
                        {
                            Swap(sb,toSwapIndex, j);
                        }
                        toSwapIndex++;
                        
                        k++;
                        multiplicationFactorials *= k;
                        
                        m++;
                        factorialOfNumber *= m;
                    }
                    j++;
                }
                i = toSwapIndex;
            }
            return factorialOfNumber / multiplicationFactorials;
        }
        
        private void Swap(StringBuilder str, Int32 idx1, Int32 idx2)
        {
            var tmp = str[idx1];
            str[idx1] = str[idx2];
            str[idx2] = tmp;
        }
    }
}