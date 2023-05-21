using System;


namespace WordSearch
{
    class Program
    {
        private const int UP = 0;  
        private const int UP_RIGHT = 1;
        private const int RIGHT = 2;   
        private const int DOWN_RIGHT = 3;
        private const int DOWN =  4;
        private const int DOWN_LEFT = 5;
        private const int LEFT = 6;
        private const int UP_LEFT = 7;
        static char[,] Grid = new char[,] {
            {'C', 'P', 'K', 'X', 'O', 'I', 'G', 'H', 'S', 'F', 'C', 'H'},
            {'Y', 'G', 'W', 'R', 'I', 'A', 'H', 'C', 'Q', 'R', 'X', 'K'},
            {'M', 'A', 'X', 'I', 'M', 'I', 'Z', 'A', 'T', 'I', 'O', 'N'},
            {'E', 'T', 'W', 'Z', 'N', 'L', 'W', 'G', 'E', 'D', 'Y', 'W'},
            {'M', 'C', 'L', 'E', 'L', 'D', 'N', 'V', 'L', 'G', 'P', 'T'},
            {'O', 'J', 'A', 'A', 'V', 'I', 'O', 'T', 'E', 'E', 'P', 'X'},
            {'C', 'D', 'B', 'P', 'H', 'I', 'A', 'W', 'V', 'X', 'U', 'I'},
            {'L', 'G', 'O', 'S', 'S', 'B', 'R', 'Q', 'I', 'A', 'P', 'K'},
            {'E', 'O', 'I', 'G', 'L', 'P', 'S', 'D', 'S', 'F', 'W', 'P'},
            {'W', 'F', 'K', 'E', 'G', 'O', 'L', 'F', 'I', 'F', 'R', 'S'},
            {'O', 'T', 'R', 'U', 'O', 'C', 'D', 'O', 'O', 'F', 'T', 'P'},
            {'C', 'A', 'R', 'P', 'E', 'T', 'R', 'W', 'N', 'G', 'V', 'Z'}
        };

        static string[] Words = new string[] 
        {
            "CARPET",
            "CHAIR",
            "DOG",
            "BALL",
            "DRIVEWAY",
            "FISHING",
            "FOODCOURT",
            "FRIDGE",
            "GOLF",
            "MAXIMIZATION",
            "PUPPY",
            "SPACE",
            "TABLE",
            "TELEVISION",
            "WELCOME",
            "WINDOW"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Word Search");

            for (int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    Console.Write(Grid[y, x]);
                    Console.Write(' ');
                }
                Console.WriteLine("");

            }

            Console.WriteLine("");
            Console.WriteLine("Found Words");
            Console.WriteLine("------------------------------");

            FindWords();

            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

        private static void FindWords()
        {
            //Find each of the words in the grid, outputting the start and end location of
            //each word, e.g.
            //PUPPY found at (10,7) to (10, 3)

            for (int i = 0; i < Words.Length; i++)
            {
                string word = Words[i];
                int wordLength = word.Length;

                
                for (int y = 0; y < 12; y++)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        // Checking the current cell has the staring letter of the word we are looking for
                        if (Grid[y, x] == word[0])
                        {
                            // Check for each direction 
                            for (int direction = 0; direction < 8; direction++)
                            {
                                int dx = GetDirectionX(direction);
                                int dy = GetDirectionY(direction);

                                bool found = true;
                                //Check for full word
                                for (int j = 1; j < wordLength; j++)
                                {
                                    int newX = x + dx * j;
                                    int newY = y + dy * j;

                                    if (newX < 0 || newX >= 12 || newY < 0 || newY >= 12 ||
                                        Grid[newY, newX] != word[j])
                                    {
                                        found = false;
                                        break;
                                    }
                                }

                                // If the word found, print its start and end locations
                                if (found)
                                {
                                    int startX = x + 1;
                                    int startY = y + 1;
                                    int endX = x + dx * (wordLength - 1) + 1;
                                    int endY = y + dy * (wordLength - 1) + 1;

                                    Console.WriteLine("{word} found at (" + startX + "," + startY + ") to (" + endX + "," + endY + ")");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        
        private static int GetDirectionX(int direction)
        {
            switch (direction)
            {
                case UP: return 0;  
                case UP_RIGHT: return 1; 
                case RIGHT: return 1;  
                case DOWN_RIGHT: return 1;   
                case DOWN: return 0;  
                case DOWN_LEFT: return -1; 
                case LEFT: return -1; 
                case UP_LEFT: return -1;  
                default: throw new ArgumentException("Invalid direction index");
            }
        }
        private static int GetDirectionY(int direction)
        {
            switch (direction)
            {
                case UP: return -1; 
                case UP_RIGHT: return -1;  
                case RIGHT: return 0;  
                case DOWN_RIGHT: return 1;  
                case DOWN: return 1;  
                case DOWN_LEFT: return 1;   
                case LEFT: return 0; 
                case UP_LEFT: return -1;  
                default: throw new ArgumentException("Invalid direction index");
            }
        }


    }
}
