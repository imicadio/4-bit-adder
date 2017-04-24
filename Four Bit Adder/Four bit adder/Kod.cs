using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four_bit_adder
{
    class Kod
    {
        int K = 0;

        public bool IsBin(string s)
        {
            foreach (var c in s)
                if (c != '0' && c != '1')
                    return false;
            return true;
        }
        public void Oblicz(int[] tablica1, int[] tablica2, int[]S, int[] A, int[] B, int[] D, int[] arra)
        {
            for (int i = 3; i >= 0; i--)
            {                 
                S[i] = tablica1[i] ^ tablica2[i] ^ K;

                A[i] = tablica1[i] * tablica2[i];
                B[i] = tablica1[i] ^ tablica2[i];
                D[i] = K * B[i];
                K = A[i] + D[i];
                arra[i] = K;
            }
            K = 0;
        }

        public string Informacja(int[] C, int[] S)
        {
            return C[0] + string.Join("", S);
        }

        //Console.WriteLine("{0}" + string.Join("", S), C);
        //    if (C == 1)
        //        sumka = 16;


        //    for (int i = 0; i<S.Length; i++)
        //    {
        //        if (S[i] == 1)
        //            sumka += array1[i];
        //    }
    }
}
