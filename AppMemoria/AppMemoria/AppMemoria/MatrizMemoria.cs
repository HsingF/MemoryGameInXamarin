using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMemoria
{
    class MatrizMemoria
    {
        private string[,] matriz;
        public const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static Random random;

        public MatrizMemoria()
        {
            matriz = new string[5,5];
            random = new Random();
        }

        public static Random GetRandom()
        {
            return random;
        }

        public static string RandomString()
        {
            int index = GetRandom().Next(alphabet.Length);
            return alphabet[index] + "";
        }

        public string GetByPosition(int i, int j)
        {
            return matriz[i,j];
        }

        public string GetAnswer()
        {
            string result="";
            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    result += GetByPosition(i,j) + "\t\t";
                }
                result += "\r\n";
            }
            return result;
        }

        public void GenerarMatriz()
        {
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    matriz[i,j] = RandomString();
                }
            }
        }
    }
}
