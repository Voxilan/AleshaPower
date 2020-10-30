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

        public static void GenLocal(string way)
        {
            var directions = new Dictionary<char, (int, int)>
            {
                { 'N', ( -1,  0) },
                { 'S', ( 1, 0) },
                { 'E', ( 0,  1) },
                { 'W', (0,  -1) }
            };
            

            var pos = (0, 0);
            var max_row = 0;
            var min_row = 0;
            var max_col = 0;
            var min_col = 0;
            foreach (var iw in way)
            {
                var row = pos.Item1 + directions[iw].Item1;
                if (row > max_row) max_row = row;
                if (row < min_row) min_row = row;
                var col = pos.Item2 + directions[iw].Item2;
                if (col > max_col) max_col = col;
                if (col < min_col) min_col = col;
                pos = (row, col);
            }
          
            var rows = max_row - min_row + 1;
            var cols = max_col - min_col + 1;        
            var start = (rows - max_row - 1, cols - max_col - 1);          
            int[,] local_gen = new int[rows, cols];
            Random rnd = new Random();
            int i = start.Item1, j = start.Item2;
            local_gen[i, j] = 1;
            foreach (var el in way)
            {
                i += directions[el].Item1;
                j += directions[el].Item2;
                local_gen[i, j] = 1;

            }
            To1DArray(local_gen);
        }
