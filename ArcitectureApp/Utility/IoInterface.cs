using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArcitectureApp.Utility
{
    class IoInterface
    {
        public int x { get; private set; }
        public string fileName { get; private set; }
        private bool testing = false;

        public IoInterface()
        {

            while ((x != 1) && (x != 2) && (x != 3))
            {
                Console.WriteLine("Enter 1 for accumulator, 2 for register-memory, or 3 for testing");
                //string t = Console.Read();
                x = Convert.ToInt32(Console.ReadLine());
                if (x == 1)
                {
                    Console.WriteLine("Accumulator Architecture selected.");
                }
                else if (x == 2)
                {
                    Console.WriteLine("Register-memory Architecture selected.");
                }
                else if (x == 3)
                {
                    Console.WriteLine("Testing system selected.");
                    testing = true;
                }
                else
                {
                    Console.WriteLine("Invalid input entered. Try again.");
                }
            }

            if (!testing)
            {
                bool validFile = false;

                while (!validFile)
                {
                    Console.WriteLine("Please enter the name of your assemply file including the extension. ");
                    Console.WriteLine("Place the file in the same directory as this executable.");
                    fileName = Console.ReadLine();
                    string test;
                    try
                    {
                        using (TextReader tr = new StreamReader(fileName))
                        {
                            //Console.WriteLine(tr.ReadToEnd());
                            test = tr.ReadToEnd();
                        }
                        validFile = true;
                    }
                    catch
                    {
                        validFile = false;
                        Console.WriteLine("The filename is invalid.");
                    }
                }
            }

            

        }

        public void DisplayException(Exception e, int i)
        {
            Console.WriteLine("An exception occured while executing the program.");
            Console.WriteLine(e);
            Console.WriteLine("There were " + i + " instructions executed before the exception occured.");
        }

        public void PrintNumberOfInstructions(int i)
        {
            Console.WriteLine("");
            Console.WriteLine("There were " + i +" instructions executed.");
        }

        public void PrintMemorySection(int[] section)
        {
            Console.WriteLine("");
            Console.WriteLine("Printing a section of memory.");
            for (int i = 0; i < section.Length; i++)
            {
                Console.Write(section[i] + ", ");
            }
        }

        public void PrintNumberOfMemoryAccesses(int number)
        {
            Console.WriteLine("");
            Console.WriteLine("There were " + number + " of memory accesses during the execution of the program. ");
        }

    }
}
