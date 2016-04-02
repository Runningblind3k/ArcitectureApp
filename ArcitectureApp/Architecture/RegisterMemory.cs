using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcitectureApp.Architecture
{
    class RegisterMemory : Architecture
    {

        #region private varriables

        private uint register1;
        private uint register2;
        private uint register3;
        private uint register4;
        private uint register5;
        private uint register6;
        private uint register7;
        private uint register8;
        private uint register9;
        private uint register10;
        private uint register11;
        private uint register12;
        private uint register13;
        private uint register14;
        private uint register15;
        private uint register16;
        private uint register17;
        private uint register18;
        private uint register19;
        private uint register20;
        private uint internalReserved100;
        

        #endregion 

        public override void parse(string fileName)
        {
            Assembler.RegisterMemoryAssembler Assembler = new Assembler.RegisterMemoryAssembler();
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

            UInt16 Constant = 0;

            Constant |= p1;
            Constant |= p2;

            byte Register = instruction[1];


            switch (instruction[0])
            {
                case 0x01:
                    {
                        RmLoad(instruction[1], Constant);
                        break;
                    }
                case 0x02:
                    {
                        RmLoadIndirect(instruction[1], Constant);
                        break;
                    }
                case 0x03:
                    {
                        RmStore(instruction[1], Constant);
                        break;
                    }
                case 0x04:
                    {
                        RmStoreIndirect(instruction[1], Constant);
                        break;
                    }
                case 0x05:
                    {
                        RmAdd(instruction[1], Constant);
                        break;
                    }
                case 0x06:
                    {
                        RmAddImmediate(instruction[1], Constant);
                        break;
                    }
                case 0x07:
                    {
                        RmAnd(instruction[1], Constant);
                        break;
                    }
                case 0x08:
                    {
                        RmOr(instruction[1], Constant);
                        break;
                    }
                case 0x09:
                    {
                        RmNot(instruction[1]);
                        break;
                    }
                case 0x0A:
                    {
                        RmXor(instruction[1], Constant);
                        break;
                    }
                case 0x0B:
                    {
                        RmMove(instruction[1], Constant);
                        break;
                    }
                case 0x0C:
                    {
                        RmJump(Constant);
                        break;
                    }
                case 0x0D:
                    {
                        RmBranchOnZero(instruction[1], Constant);
                        break;
                    }
                case 0x0E:
                    {
                        RmSetOnEqual(instruction[1], Constant);
                        break;
                    }
                case 0x0F:
                    {
                        RmSetNotEqual(instruction[1], Constant);
                        break;
                    }
                case 0x10:
                    {
                        RmSetOnGreaterThan(instruction[1], Constant);
                        break;
                    }
                case 0x11:
                    {
                        RmSetOnLessThan(instruction[1], Constant);
                        break;
                    }
                case 0x12:
                    {
                        RmSetOnGreaterThanOrEqual(instruction[1], Constant);   
                        break;
                    }
                case 0x13:
                    {
                        RmSetOnLessThanOrEqual(instruction[1], Constant);
                        break;
                    }
                case 0x14:
                    {
                        RmPush(instruction[1]);
                        break;
                    }
                case 0x15:
                    {
                        RmPop(instruction[1]);
                        break;
                    }
                case 0x16:
                    {
                        RmCall(Constant);
                        break;
                    }
                case 0x17:
                    {
                        RmReturn();
                        break;
                    }
                case 0x18:
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

        #region Instructions

        protected void RmLoad(byte register, UInt16 Address)
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

            SetRegister(register, value);
        }

        protected void RmLoadIndirect(byte register, UInt16 Address)
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


            p1 = Memory[add];
            p2 = Memory[add + 1];
            p3 = Memory[add + 2];
            p4 = Memory[add + 3];

            p1 = p1 << 24;
            p2 = p2 << 16;
            p3 = p3 << 8;

            uint value = 0;

            value |= p1;
            value |= p2;
            value |= p3;
            value |= p4;

            SetRegister(register, value);
        }

        protected void RmStore(byte register, UInt16 Address)
        {
            memoryAccessCount++;
            uint value = GetRegister(register);

            uint t1 = value;
            uint t2 = value;
            uint t3 = value;
            uint t4 = value;

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

        protected void RmStoreIndirect(byte register, UInt16 Address)
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

            uint value = GetRegister(register);

            uint t1 = value;
            uint t2 = value;
            uint t3 = value;
            uint t4 = value;

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

        protected void RmAdd(byte register, UInt16 Address)
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

            uint rVal = GetRegister(register);

            int t1 = (int)value;
            int t2 = (int)rVal;

            t1 = t1 + t2;

            value = (uint)t1;

            SetRegister(register, value);

        }

        protected void RmAddImmediate(byte register, UInt16 Constant)
        {

            uint value = GetRegister(register);

            int t1 = (int)value;
            int t2 = (int)Constant;

            t1 = t1 + t2;

            value = (uint)t1;

            SetRegister(register, value);
        }

        protected void RmAnd(byte register, UInt16 Address)
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

            uint rval = GetRegister(register);

            value = rval & value;

            SetRegister(register, value);
        }

        protected void RmOr(byte register, UInt16 Address)
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

            uint rval = GetRegister(register);

            value = rval | value;

            SetRegister(register, value);
        }

        protected void RmNot(byte register)
        {
            uint rval = GetRegister(register);
            rval = ~rval;
            SetRegister(register, rval);
        }

        protected void RmXor(byte register, UInt16 Address)
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

            uint rval = GetRegister(register);

            value = rval ^ value;

            SetRegister(register, value);
        }

        protected void RmMove(byte reg1, UInt16 reg2)
        {
            SetRegister(reg1, GetRegister(Convert.ToByte(reg2)));
            
        }

        protected void RmJump(UInt16 Address)
        {
            pc = Address;
        }

        protected void RmBranchOnZero(byte register, UInt16 Address)
        {

            uint value = GetRegister(register);

            if (value == 0)
            {
                RmJump(Address);
            }
        }

        protected void RmSetOnEqual(byte register, UInt16 Address)
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

            uint rval = GetRegister(register);

            if (rval == value)
            {
                SetRegister(register, 1);
            }
            else
            {
                SetRegister(register, 0);
            }
        }

        protected void RmSetNotEqual(byte register, UInt16 Address)
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

            uint rval = GetRegister(register);

            if (rval == value)
            {
                SetRegister(register, 0);
            }
            else
            {
                SetRegister(register, 1);
            }
        }

        protected void RmSetOnGreaterThan(byte register, UInt16 Address)
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

            uint rval = GetRegister(register);

            int valueSigned = (int)value;
            int rvalSigned = (int)rval;

            if (rvalSigned > valueSigned)
            {
                SetRegister(register, 1);
            }
            else
            {
                SetRegister(register, 0);
            }
        }

        protected void RmSetOnLessThan(byte register, UInt16 Address)
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

            uint rval = GetRegister(register);

            int valueSigned = (int)value;
            int rvalSigned = (int)rval;

            if (rvalSigned < valueSigned)
            {
                SetRegister(register, 1);
            }
            else
            {
                SetRegister(register, 0);
            }
        }

        protected void RmSetOnGreaterThanOrEqual(byte register, UInt16 Address)
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

            uint rval = GetRegister(register);

            int valueSigned = (int)value;
            int rvalSigned = (int)rval;

            if (rvalSigned >= valueSigned)
            {
                SetRegister(register, 1);
            }
            else
            {
                SetRegister(register, 0);
            }
        }

        protected void RmSetOnLessThanOrEqual(byte register, UInt16 Address)
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

            uint rval = GetRegister(register);

            int valueSigned = (int)value;
            int rvalSigned = (int)rval;

            if (rvalSigned <= valueSigned)
            {
                SetRegister(register, 1);
            }
            else
            {
                SetRegister(register, 0);
            }
        }

        protected void RmPush(byte register)
        {
            memoryAccessCount++;
            uint add = stackPointer;
            uint rval = GetRegister(register);

            uint t1 = rval;
            uint t2 = rval;
            uint t3 = rval;
            uint t4 = rval;

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

        protected void RmPop(byte register)
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

            uint value = 0;

            value |= p1;
            value |= p2;
            value |= p3;
            value |= p4;

            SetRegister(register, value);
        }

        protected void RmCall(UInt16 Address)
        {
            SetRegister(100, pc + 4);
            RmPush(100);
            RmJump(Address);
        }

        protected void RmReturn()
        {
            RmPop(100);
            pc = GetRegister(100);

        }

        #endregion

        protected uint GetRegister(byte register)
        {
            switch (register)
            {
                case 1:
                    {
                        return register1;
                    }
                case 2:
                    {
                        return register2;
                    }
                case 3:
                    {
                        return register3;
                    }
                case 4:
                    {
                        return register4;
                    }
                case 5:
                    {
                        return register5;
                    }
                case 6:
                    {
                        return register6;
                    }
                case 7:
                    {
                        return register7;
                    }
                case 8:
                    {
                        return register8;
                    }
                case 9:
                    {
                        return register9;
                    }
                case 10:
                    {
                        return register10;
                    }
                case 11:
                    {
                        return register11;
                    }
                case 12:
                    {
                        return register12;
                    }
                case 13:
                    {
                        return register13;
                    }
                case 14:
                    {
                        return register14;
                    }
                case 15:
                    {
                        return register15;
                    }
                case 16:
                    {
                        return register16;
                    }
                case 17:
                    {
                        return register17;
                    }
                case 18:
                    {
                        return register18;
                    }
                case 19:
                    {
                        return register19;
                    }
                case 20:
                    {
                        return register20;
                    }
                case 100:
                    {
                        return internalReserved100;
                    }
                default:
                    {
                        throw new Exception("Invalid Register Opcode attempted.");
                    }
            }
        }

        protected void SetRegister(byte register, uint value)
        {
            switch (register)
            {
                case 1:
                    {
                        register1 = value;
                        break;
                    }
                case 2:
                    {
                        register2 = value;
                        break;
                    }
                case 3:
                    {
                        register3 = value;
                        break;
                    }
                case 4:
                    {
                        register4 = value;
                        break;
                    }
                case 5:
                    {
                        register5 = value;
                        break;
                    }
                case 6:
                    {
                        register6 = value;
                        break;
                    }
                case 7:
                    {
                        register7 = value;
                        break;
                    }
                case 8:
                    {
                        register8 = value;
                        break;
                    }
                case 9:
                    {
                        register9 = value;
                        break;
                    }
                case 10:
                    {
                        register10 = value;
                        break;
                    }
                case 11:
                    {
                        register11 = value;
                        break;
                    }
                case 12:
                    {
                        register12 = value;
                        break;
                    }
                case 13:
                    {
                        register13 = value;
                        break;
                    }
                case 14:
                    {
                        register14 = value;
                        break;
                    }
                case 15:
                    {
                        register15 = value;
                        break;
                    }
                case 16:
                    {
                        register16 = value;
                        break;
                    }
                case 17:
                    {
                        register17 = value;
                        break;
                    }
                case 18:
                    {
                        register18 = value;
                        break;
                    }
                case 19:
                    {
                        register19 = value;
                        break;
                    }
                case 20:
                    {
                        register20 = value;
                        break;
                    }
                case 100:
                    {
                        internalReserved100 = value;
                        break;
                    }
                default:
                    {
                        throw new Exception("Invalid Register Opcode attempted.");
                    }
            }
        }

    }
}
