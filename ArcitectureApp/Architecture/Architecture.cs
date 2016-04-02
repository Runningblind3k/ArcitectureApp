using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcitectureApp.Architecture
{
    abstract class Architecture
    {
        public int instructionCount = 0;
        public int memoryAccessCount = 0;
        protected uint pc = 0; // program counter
        protected uint stackPointer = 7000;
        protected byte[] Memory = new byte[20000];    // change if longer program desired

        public void LoadPreloadedData()
        {
            Utility.PreloadData data = new Utility.PreloadData();

            int mp = 12000;

            foreach (int i in data.set1)
            {
                byte[] t = BitConverter.GetBytes(i);
                Array.Reverse(t);                     // This may be neccisary
                Memory[mp] = t[0];
                mp++;
                Memory[mp] = t[1];
                mp++;
                Memory[mp] = t[2];
                mp++;
                Memory[mp] = t[3];
                mp++;
            }

            mp = 12500;

            foreach (int i in data.set2)
            {
                byte[] t = BitConverter.GetBytes(i);
                Array.Reverse(t);                     // This may be neccisary
                Memory[mp] = t[0];
                mp++;
                Memory[mp] = t[1];
                mp++;
                Memory[mp] = t[2];
                mp++;
                Memory[mp] = t[3];
                mp++;
            }

            mp = 13000;

            foreach (int i in data.set3)
            {
                byte[] t = BitConverter.GetBytes(i);
                Array.Reverse(t);                     // This may be neccisary
                Memory[mp] = t[0];
                mp++;
                Memory[mp] = t[1];
                mp++;
                Memory[mp] = t[2];
                mp++;
                Memory[mp] = t[3];
                mp++;
            }

            mp = 13500;

            foreach (int i in data.set4)
            {
                byte[] t = BitConverter.GetBytes(i);
                Array.Reverse(t);                     // This may be neccisary
                Memory[mp] = t[0];
                mp++;
                Memory[mp] = t[1];
                mp++;
                Memory[mp] = t[2];
                mp++;
                Memory[mp] = t[3];
                mp++;
            }

            mp = 14000;

            foreach (int i in data.set5)
            {
                byte[] t = BitConverter.GetBytes(i);
                Array.Reverse(t);                     // This may be neccisary
                Memory[mp] = t[0];
                mp++;
                Memory[mp] = t[1];
                mp++;
                Memory[mp] = t[2];
                mp++;
                Memory[mp] = t[3];
                mp++;
            }

            mp = 15000;
            Memory[mp] = 0;
            Memory[mp + 1] = 0;
            Memory[mp + 2] = 0;
            Memory[mp + 3] = 0;
        }

        abstract public void parse(string fileName);

        public void GetPartOfMemory(int[] section, int length, int mp)
        {

            uint p1;
            uint p2;
            uint p3;
            uint p4;

            uint data;

            for (int i = 0; i < length; i++)
            {
                p1 = Memory[mp];
                p2 = Memory[mp + 1];
                p3 = Memory[mp + 2];
                p4 = Memory[mp + 3];

                mp += 4;

                p1 = p1 << 24;
                p2 = p2 << 16;
                p3 = p3 << 8;

                data = 0;

                data |= p1;
                data |= p2;
                data |= p3;
                data |= p4;

                section[i] = (int)data;
            }
        }

        public void Execute()
        {

            bool ProgramNotFinished = true;
            instructionCount = 0;

            while (ProgramNotFinished)
            {
                byte[] instruction = fetch();
                pc += 4;
                ProgramNotFinished = DecodeInstruction(instruction);
                instructionCount++;
            }
            return;

        }

        protected abstract bool DecodeInstruction(byte[] instruction);

        protected byte[] fetch()
        {
            byte[] instruction = { 0, 0, 0, 0 };

            instruction[0] = Memory[pc];
            instruction[1] = Memory[pc + 1];
            instruction[2] = Memory[pc + 2];
            instruction[3] = Memory[pc + 3];

            return instruction;
        }
    }
}
