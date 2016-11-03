using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 



 
namespace KDay1
{
    class ProgramOld
    {
        static void Min1()
        {
            const int arrayDimentions = 2;
            int[,] array = initArray();
            int size = array.GetLength(arrayDimentions-1);
          
            int cordY = 0, cordX = 0;
            const string nameOfFirstCord = "x";
            const string nameOfSecondCord = "y";
            Console.Write("Now enter the coordinates. The center of the coordianate system is the upper left corner (0,0).\nThe axis are (" + nameOfFirstCord + ", "+ nameOfSecondCord + ")");
            validateCord(out cordX, size, nameOfFirstCord);
            validateCord(out cordY, size, nameOfSecondCord);

            //fill the array, increment and print 
            int counter = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //fill
                    array[i,j] = counter;
                    if (cordX == i && cordY == j)
                    {
                        //increment
                        array[i, j]++;
                     }
                    counter++;
                    //print
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.Write("\nEnter exit and press Enter to close the program!");
            Console.ReadLine();
         }

        static int[,] initArray()
        {
            const string message = "Enter the matrix size=";
            Console.Write(message);
            int size = 0;
            Int32.TryParse(Console.ReadLine(), out size);
            while (!validateValue(size, int.MaxValue))
            {
                Console.Write("\n Not valid size (1," + (int.MaxValue) + ") !\n");
                Console.Write(message);
                Int32.TryParse(Console.ReadLine(), out size);
            }
            int[,] array = new int[size, size];
            return array;

        }
        static void validateCord(out int cord, int maxSize, string nameOfCord)
        {
            String message = "Enter the coordinate " + nameOfCord + "=";
            Console.Write(message);
            Int32.TryParse(Console.ReadLine(), out cord);
            while (!validateValue(cord, maxSize))
            {
                Console.Write("\n Not valid coordinated (0," + (maxSize - 1) + ") !\n");
                Console.Write(message);
                Int32.TryParse(Console.ReadLine(), out cord);
            }
        }

        static bool validateValue(int cord, int maxSize)
        {
            bool isValid = false;
            if (cord > 0 && cord < maxSize)
            {
                isValid = true;
            }
            return isValid;
        }
                     
    }

    
}
