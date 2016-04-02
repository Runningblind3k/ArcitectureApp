using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArcitectureApp.Assembler
{
    abstract class Assembler
    {
        protected string AllLines;
        protected string[] lines;

        public List<byte> Instructionbuffer { get; private set; }


        public Assembler()
        {
            Instructionbuffer = new List<byte>();
        }

        public void GetCodeFromFile(string fileName)
        {
            using (TextReader tr = new StreamReader(fileName))
            {
                AllLines = tr.ReadToEnd();
            }
            lines = AllLines.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        public void Assemble()
        {
            int lineNumber = 0;
            foreach (string s in lines)
            {
                CreateBianary(s, lineNumber);
                lineNumber++;
            }
        }

        protected abstract void CreateBianary(string s, int lineNumber);

        
    }
}
