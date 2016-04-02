using System;
using System.Collections.Generic;
using System.Text;


namespace ArcitectureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility.IoInterface io = new Utility.IoInterface();

            if ((io.x == 1) || (io.x == 2))
            {

                Utility.chooseArchitecture choose = new Utility.chooseArchitecture(io.x);

                Architecture.Architecture Arch = choose.chosenArchitecture;

                int[] data = new int[100];
                int[] data2 = new int[100];
                int[] data3 = new int[100];
                int[] data4 = new int[100];
                int[] data5 = new int[100];


            



                    try
                    {
                        Arch.parse(io.fileName);
                        Arch.LoadPreloadedData();
                        Arch.GetPartOfMemory(data, 100, 12000);
                        Arch.GetPartOfMemory(data2, 100, 12500);
                        Arch.GetPartOfMemory(data3, 100, 13000);
                        Arch.GetPartOfMemory(data4, 100, 13500);
                        Arch.GetPartOfMemory(data5, 100, 14000);
                        io.PrintMemorySection(data);
                        io.PrintMemorySection(data2);
                        io.PrintMemorySection(data3);
                        io.PrintMemorySection(data4);
                        io.PrintMemorySection(data5);
                        Arch.Execute();
                        Arch.GetPartOfMemory(data, 100, 12000);
                        Arch.GetPartOfMemory(data2, 100, 12500);
                        Arch.GetPartOfMemory(data3, 100, 13000);
                        Arch.GetPartOfMemory(data4, 100, 13500);
                        Arch.GetPartOfMemory(data5, 100, 14000);
                        io.PrintMemorySection(data);
                        io.PrintMemorySection(data2);
                        io.PrintMemorySection(data3);
                        io.PrintMemorySection(data4);
                        io.PrintMemorySection(data5);
                        io.PrintNumberOfInstructions(Arch.instructionCount);
                        io.PrintNumberOfMemoryAccesses(Arch.memoryAccessCount);
                    }
                    catch(Exception e)
                    {
                        io.DisplayException(e, Arch.instructionCount);
                    }

              }

            if (io.x == 3)
            {
                Testing.TestControl tc = new Testing.TestControl();
            }
        }

        
    }
}
