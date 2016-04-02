using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcitectureApp.Testing
{
    public sealed class TestReport
    {
        private static volatile TestReport instance;
        List<string> report;
        string fileName;

        private TestReport()
        {
            Console.WriteLine("Please enter the name of the file you want to use in your report. Include the extension. ");
            Console.WriteLine("Place the file in the same directory as this executable.");
            fileName = Console.ReadLine();
            report = new List<string>();
        }

        public static TestReport Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestReport();
                }
                return instance;
            }
        }

        public void WriteReport()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                foreach (string line in report)
                {
                    file.WriteLine(line);
                }
            }
        }

        public void AddLineToReport(string line)
        {
            report.Add(line);
        }

        public void EmptyReport()
        {
            report = new List<string>();
        }
    }
}
