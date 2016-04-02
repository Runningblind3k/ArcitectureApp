using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 
 * This Architecture uses the first 16 bits for the opcode and the second 16 bits for the memory address. This makes things simpler. 
 * This could be modified if larger memory addressing was desired. 
 * 
 * */

namespace ArcitectureApp.Architecture
{
    class Accumulator : Architecture
    {
        #region private varriables

        private uint acumulator;


        #endregion





        #region Methods

       
        public override void parse(string fileName)
        {
            Assembler.AcumulatorAssembler Assembler = new Assembler.AcumulatorAssembler();
            Assembler.GetCodeFromFile(fileName);
            Assembler.Assemble();
            int i = 0;
            foreach (byte b in Assembler.Instructionbuffer)
            {
                Memory[i] = b;
                i++;
            }
            return;
        }

        protected override bool DecodeInstruction(byte[] instruction)
        {
            uint t1 = 0;
            t1 = t1 | instruction[2];
            t1 = t1 << 8;
            uint t2 = 0;
            t2 = t2 | instruction[3];

            UInt16 p1 = Convert.ToUInt16(t1);
            UInt16 p2 = Convert.ToUInt16(t2);

            UInt16 AddOrImm = 0;

            AddOrImm |= p1;
            AddOrImm |= p2;


            switch (instruction[0])
            {
                case 0x01:
                    {
                        AccuLoad(AddOrImm);
                        break;
                    }
                case 0x02:
                    {
                        AccuLoadIndirect(AddOrImm);
                        break;
                    }
                case 0x03:
                    {
                        AccuStore(AddOrImm);
                        break;
                    }
                case 0x04:
                    {
                        AccuStoreIndirect(AddOrImm);
                        break;
                    }
                case 0x05:
                    {
                        AccuAddition(AddOrImm);
                        break;
                    }
                case 0x06:
                    {
                        AccuAddImediate(AddOrImm);
                        break;
                    }
                case 0x07:
                    {
                        AccuAND(AddOrImm);
                        break;
                    }
                case 0x08:
                    {
                        AccuOR(AddOrImm);
                        break;
                    }
                case 0x09:
                    {
                        AccuNOT();
                        break;
                    }
                case 0x0A:
                    {
                        AccuXOR(AddOrImm);
                        break;
                    }
                case 0x0B:
                    {
                        AccuJump(AddOrImm);
                        break;
                    }
                case 0x0C:
                    {
                        AccuBranchOnZero(AddOrImm);
                        break;
                    }
                case 0x0D:
                    {
                        AccuSetOnEqual(AddOrImm);
                        break;
                    }
                case 0x0E:
                    {
                        AccuSetOnNotEqual(AddOrImm);
                        break;
                    }
                case 0x0F:
                    {
                        AccuSetOnGreaterThan(AddOrImm);
                        break;
                    }
                case 0x10:
                    {
                        AccuSetOnLessThan(AddOrImm);
                        break;
                    }
                case 0x11:
                    {
                        AccuSetOnGreaterThanOrEqual(AddOrImm);
                        break;
                    }
                case 0x12:
                    {
                        AccuSetOnLessThanOrEqual(AddOrImm);
                        break;
                    }
                case 0x13:
                    {
                        AccuPush();
                        break;
                    }
                case 0x14:
                    {
                        AccuPop();
                        break;
                    }
                case 0x15:
                    {
                        AccuCall(AddOrImm);
                        break;
                    }
                case 0x16:
                    {
                        AccuReturn();
                        break;
                    }
                case 0x17:
                    {
                        return false;
                    }
                default:
                    {
                        string ex = "Invalid instruction opocode in assembler acumulator architecture.";
                        throw new Exception(ex);
                    }
            }
            return true;
        }


        #endregion

        #region Instructions

        private void AccuLoad(UInt16 Address)
        {
            memoryAccessCount++;
            uint p1 = Memory[Address];
            uint p2 = Memory[Address + 1];
            uint p3 = Memory[Address + 2];
            uint p4 = Memory[Address + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            acumulator = 0;

            acumulator |= p1;
            acumulator |= p2;
            acumulator |= p3;
            acumulator |= p4;
        }

        private void AccuLoadIndirect(UInt16 Address)
        {
            memoryAccessCount++;
            uint p1 = Memory[Address];
            uint p2 = Memory[Address + 1];
            uint p3 = Memory[Address + 2];
            uint p4 = Memory[Address + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            uint tmp = 0;

            tmp |= p1;
            tmp |= p2;
            tmp |= p3;
            tmp |= p4;

            
            p1 = Memory[tmp];
            p2 = Memory[tmp + 1];
            p3 = Memory[tmp + 2];
            p4 = Memory[tmp + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            acumulator = 0;

            acumulator |= p1;
            acumulator |= p2;
            acumulator |= p3;
            acumulator |= p4;
        }

        private void AccuStore(UInt16 Address)
        {
            memoryAccessCount++;
            //Memory[Address] = acumulator;
            uint t1 = acumulator;
            uint t2 = acumulator;
            uint t3 = acumulator;
            uint t4 = acumulator;

            t1 = t1 >> 24;
            Memory[Address] = Convert.ToByte(t1);

            t2 = t2 << 8;
            t2 = t2 >> 24;

            Memory[Address + 1] = Convert.ToByte(t2);

            t3 = t3 << 16;
            t3 = t3 >> 24;

            Memory[Address + 2] = Convert.ToByte(t3);

            t4 = t4 << 24;
            t4 = t4 >> 24;

            Memory[Address + 3] = Convert.ToByte(t4);
        }

        private void AccuStoreIndirect(UInt16 Address)
        {
            memoryAccessCount++;
            uint p1 = Memory[Address];
            uint p2 = Memory[Address + 1];
            uint p3 = Memory[Address + 2];
            uint p4 = Memory[Address + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            uint add = 0;

            add |= p1;
            add |= p2;
            add |= p3;
            add |= p4;

            uint t1 = acumulator;
            uint t2 = acumulator;
            uint t3 = acumulator;
            uint t4 = acumulator;

            t1 = t1 >> 24;
            Memory[add] = Convert.ToByte(t1);

            t2 = t2 << 8;
            t2 = t2 >> 24;

            Memory[add + 1] = Convert.ToByte(t2);

            t3 = t3 << 16;
            t3 = t3 >> 24;

            Memory[add + 2] = Convert.ToByte(t3);

            t4 = t4 << 24;
            t4 = t4 >> 24;

            Memory[add + 3] = Convert.ToByte(t4);
        }

        private void AccuAddition(UInt16 Address)
        {
            memoryAccessCount++;
            uint temp = acumulator;
            AccuLoad(Address);

            int t1 = (int)acumulator;
            int t2 = (int)temp;
            t1 = t1 + t2;

            acumulator = (uint)t1;
        }

        private void AccuAddImediate(UInt16 immediate)
        {

            int t1 = (int)acumulator;
            int t2 = (Int16)immediate;
            t1 = t1 + t2;

            acumulator = (uint)t1;
            

        }

        private void AccuAND(UInt16 Address)
        {
            uint temp = acumulator;
            AccuLoad(Address);
            acumulator = acumulator & temp;
        }

        private void AccuOR(UInt16 Address)
        {
            uint temp = acumulator;
            AccuLoad(Address);
            acumulator = acumulator | temp;
        }

        private void AccuNOT()
        {
            acumulator = ~acumulator;
        }

        private void AccuXOR(UInt16 Address)
        {
            uint temp = acumulator;
            AccuLoad(Address);
            acumulator = acumulator ^ temp;
        }

        private void AccuJump(UInt16 Address)
        {
            memoryAccessCount++;
            pc = Address;
        }

        private void AccuBranchOnZero(UInt16 Address)
        {
            memoryAccessCount++;
            if (acumulator == 0)
            {
                AccuJump(Address);
            }
        }

        private void AccuSetOnEqual(UInt16 Address)
        {
            memoryAccessCount++;
            uint p1 = Memory[Address];
            uint p2 = Memory[Address + 1];
            uint p3 = Memory[Address + 2];
            uint p4 = Memory[Address + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            uint value = 0;

            value |= p1;
            value |= p2;
            value |= p3;
            value |= p4;

            int v = (int)value;
            int accuSigned = (int)acumulator;
          

            if (v == accuSigned)
            {
                acumulator = 1;
            }
            else
            {
                acumulator = 0;
            }

        }

        private void AccuSetOnNotEqual(UInt16 Address)
        {
            memoryAccessCount++;
            uint p1 = Memory[Address];
            uint p2 = Memory[Address + 1];
            uint p3 = Memory[Address + 2];
            uint p4 = Memory[Address + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            uint value = 0;

            value |= p1;
            value |= p2;
            value |= p3;
            value |= p4;

            int v = (int)value;
            int accuSigned = (int)acumulator;

            if (v == accuSigned)
            {
                acumulator = 0;
            }
            else
            {
                acumulator = 1;
            }
        }

        private void AccuSetOnGreaterThan(UInt16 Address)
        {
            memoryAccessCount++;
            uint p1 = Memory[Address];
            uint p2 = Memory[Address + 1];
            uint p3 = Memory[Address + 2];
            uint p4 = Memory[Address + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            uint value = 0;

            value |= p1;
            value |= p2;
            value |= p3;
            value |= p4;

            int v = (int)value;
            int accuSigned = (int)acumulator;

            if (accuSigned > v)
            {
                acumulator = 1;
            }
            else
            {
                acumulator = 0;
            }
        }

        private void AccuSetOnLessThan(UInt16 Address)
        {
            memoryAccessCount++;
            uint p1 = Memory[Address];
            uint p2 = Memory[Address + 1];
            uint p3 = Memory[Address + 2];
            uint p4 = Memory[Address + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            uint value = 0;

            value |= p1;
            value |= p2;
            value |= p3;
            value |= p4;

            int v = (int)value;
            int accuSigned = (int)acumulator;

            if (accuSigned < v)
            {
                acumulator = 1;
            }
            else
            {
                acumulator = 0;
            }
        }

        private void AccuSetOnGreaterThanOrEqual(UInt16 Address)
        {
            memoryAccessCount++;
            uint p1 = Memory[Address];
            uint p2 = Memory[Address + 1];
            uint p3 = Memory[Address + 2];
            uint p4 = Memory[Address + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            uint value = 0;

            value |= p1;
            value |= p2;
            value |= p3;
            value |= p4;

            int v = (int)value;
            int accuSigned = (int)acumulator;

            if (accuSigned >= v)
            {
                acumulator = 1;
            }
            else
            {
                acumulator = 0;
            }
        }

        private void AccuSetOnLessThanOrEqual(UInt16 Address)
        {
            memoryAccessCount++;
            uint p1 = Memory[Address];
            uint p2 = Memory[Address + 1];
            uint p3 = Memory[Address + 2];
            uint p4 = Memory[Address + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            uint value = 0;

            value |= p1;
            value |= p2;
            value |= p3;
            value |= p4;

            int v = (int)value;
            int accuSigned = (int)acumulator;

            if (accuSigned <= v)
            {
                acumulator = 1;
            }
            else
            {
                acumulator = 0;
            }
        }

        private void AccuPush()
        {
            memoryAccessCount++;
            uint add = stackPointer;

            uint t1 = acumulator;
            uint t2 = acumulator;
            uint t3 = acumulator;
            uint t4 = acumulator;

            t1 = t1 >> 24;
            Memory[add] = Convert.ToByte(t1);

            t2 = t2 << 8;
            t2 = t2 >> 24;

            Memory[add + 1] = Convert.ToByte(t2);

            t3 = t3 << 16;
            t3 = t3 >> 24;

            Memory[add + 2] = Convert.ToByte(t3);

            t4 = t4 << 24;
            t4 = t4 >> 24;

            Memory[add + 3] = Convert.ToByte(t4);

            stackPointer += 4;
        }

        private void AccuPop()
        {
            memoryAccessCount++;
            stackPointer -= 4;

            uint Address = stackPointer;

            uint p1 = Memory[Address];
            uint p2 = Memory[Address + 1];
            uint p3 = Memory[Address + 2];
            uint p4 = Memory[Address + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            acumulator = 0;

            acumulator |= p1;
            acumulator |= p2;
            acumulator |= p3;
            acumulator |= p4;
        }

        private void AccuCall(UInt16 Address)
        {
            memoryAccessCount++;
            uint temp = acumulator;
            acumulator = pc + 4;
            AccuPush();
            acumulator = temp;

            uint p1 = Memory[Address];
            uint p2 = Memory[Address + 1];
            uint p3 = Memory[Address + 2];
            uint p4 = Memory[Address + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            pc = 0;

            pc |= p1;
            pc |= p2;
            pc |= p3;
            pc |= p4;
        }

        private void AccuReturn()
        {
            uint temp = acumulator;
            AccuPop();
            pc = acumulator;
            acumulator = temp;
        }

        #endregion

    }

    /*
     * Instruction opcodes
     * 
     * 0x0 - Nothing
     * 0x1 - Load
     * 0x2 - Load Indirect
     * 0x3 - Store
     * 0x4 - Store Indirect
     * 0x5 - Addition
     * 0x6 - Add Imediate
     * 0x7 - AND 
     * 0x8 - OR
     * 0x9 - NOT
     * 0xA - Exclusive OR
     * 0xB - Jump
     * 0xC - Branch on Zero
     * 0xD - Set on Equal
     * 0xE - Set on Not Euqal
     * 0xF - Set on Greater Than
     * 0x10 - Set on Less Than
     * 0x11 - Set on Greater Than or Equal
     * 0x12 - Set on Less than or Equal
     * 0x13 - Push
     * 0x14 - Pop
     * 0x15 - Call
     * 0x16 - Return
     * 0x17 - Ends the program
     * 
     * */
}
