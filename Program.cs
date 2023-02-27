using System;

namespace Pathfinding
{
    class Vector2
    {
        public int x, y;

        public Vector2(int posx, int posy)
        {
            x = posx;
            y = posy;
        }
    }

    class Range2D
    {
        public int x1, x2, y1, y2;

        public Range2D(int posx1, int posx2, int posy1, int posy2)
        {
            x1 = posx1;
            x2 = posx2;
            y1 = posy1;
            y2 = posy2;
        }
    }

    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            // Settings
            Vector2 size = new Vector2(30, 10);
            Range2D startrange = new Range2D(0, size.x / 2, 0, size.y / 2);
            Range2D endrange = new Range2D(size.x / 2, size.x, size.y / 2, size.y);
            // Template: [<wall>, <empty>, <start>, <end>]
            string[] symbols = new string[] {"#", ".", "1", "0"};

            // Generate map and display
            printarray(generate_map(size, startrange, endrange, symbols));
        }

        static void printarray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }



        static string[] generate_map(Vector2 size, Range2D startrange, Range2D endrange, string[] symbols)
        {
            // Variables
            string[] map = new string[size.y];
            string[] line = new string[size.x];
            Vector2 start = new Vector2(rnd.Next(startrange.x1, startrange.x2), rnd.Next(startrange.y1, startrange.y2));
            Vector2 end = new Vector2(rnd.Next(endrange.x1, endrange.x2), rnd.Next(endrange.y1, endrange.y2));

            for (int i = 0; i < size.y; i++)
            {
                Array.Clear(line, 0, line.Length);
                for (int j = 0; j < size.x; j++)
                {
                    if (start.x == j && start.y == i) // If at start position
                    {
                        line[j] = symbols[2];
                    }
                    else if (end.x == j && end.y == i) // If at end position
                    {
                        line[j] = symbols[3];
                    }
                    else if (rnd.Next(1, 8) == 1) // If wall
                    {
                        line[j] = symbols[0];
                    }
                    else // Else empty
                    {
                        line[j] = symbols[1];
                    }
                }
                map[i] = string.Join("", line);
            }

            return map;
        }
    }
}