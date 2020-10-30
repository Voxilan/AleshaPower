public static int[] To1DArray(int[,] input)
         {              
                int[] result = new int[input.Length];                
                int count = 0;
                for (int i = 0; i <= input.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= input.GetUpperBound(1); j++)
                    {                      
                        result[count++] = input[i, j];
                    Console.Write(input[i, j] + " ");
                    }
                Console.WriteLine();
                }
                return result;
         }
        
        public static void Check(int[,] global, int[,] local)
        {
            var _1dGlobal = To1DArray(global);
            Console.WriteLine();
            var _1dLocal = To1DArray(local);
            int shift = global.GetUpperBound(1) - local.GetUpperBound(1); 
            var elems = _1dLocal.Where(x => x != 0).Count();         
            int count = 0;
            for (int i = 0; i <= _1dGlobal.Length - (local.Length + shift * local.GetUpperBound(0)); i++)
            {
                count = 0;
                for (int j = 0; j < _1dLocal.Length; j++)
                {
                    if (_1dLocal[j] == 0) continue;
                    if (_1dLocal[j] == _1dGlobal[i + j + (j / (local.GetUpperBound(1) + 1)) * shift]) count++;
                    else break;
                }
                if (count == elems)
                {
                    Console.WriteLine();
                    Console.WriteLine($"({ i / (global.GetUpperBound(1) + 1)}, { i % (global.GetUpperBound(1) + 1)}) ");
                    break;
                }
            }
        }
