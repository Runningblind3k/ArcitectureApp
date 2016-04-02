using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcitectureApp.Assembler
{
    class AcumulatorAssembler : Assembler
    {

        protected override void CreateBianary(string s, int lineNumber)
        {
            char[] delimiterChars = {' '};
            string[] parts = s.Split(delimiterChars);
            byte[] instruction = { 0, 0, 0, 0};

            #region opcode

            switch (parts[0])
            {
                case "load":
                    {
                        instruction[0] |= 0x01;
                        break;
                    }
                case "loadi":
                    {
                        instruction[0] |= 0x02;
                        break;
                    }
                case "store":
                    {
                        instruction[0] |= 0x03;
                        break;
                    }
                case "storei":
                    {
                        instruction[0] |= 0x04;
                        break;
                    }
                case "add":
                    {
                        instruction[0] |= 0x05;
                        break;
                    }
                case "addi":
                    {
                        instruction[0] |= 0x06;
                        break;
                    }
                case "and":
                    {
                        instruction[0] |= 0x07;
                        break;
                    }
                case "or":
                    {
                        instruction[0] |= 0x08;
                        break;
                    }
                case "not":
                    {
                        instruction[0] |= 0x09;
                        break;
                    }
                case "xor":
                    {
                        instruction[0] |= 0x0A;
                        break;
                    }
                case "jump":
                    {
                        instruction[0] |= 0x0B;
                        break;
                    }
                case "bzero":
                    {
                        instruction[0] |= 0x0C;
                        break;
                    }
                case "seq":
                    {
                        instruction[0] |= 0x0D;
                        break;
                    }
                case "sne":
                    {
                        instruction[0] |= 0x0E;
                        break;
                    }
                case "sgt":
                    {
                        instruction[0] |= 0x0F;
                        break;
                    }
                case "slt":
                    {
                        instruction[0] |= 0x10;
                        break;
                    }
                case "sge":
                    {
                        instruction[0] |= 0x11;
                        break;
                    }
                case "sle":
                    {
                        instruction[0] |= 0x12;
                        break;
                    }
                case "push":
                    {
                        instruction[0] |= 0x13;
                        break;
                    }
                case "pop":
                    {
                        instruction[0] |= 0x14;
                        break;
                    }
                case "call":
                    {
                        instruction[0] |= 0x15;
                        break;
                    }
                case "ret":
                    {
                        instruction[0] |= 0x16;
                        break;
                    }
                case "exit":
                    {
                        instruction[0] |= 0x17;
                        break;
                    }
                default:
                    {
                        string t = "Invalid opcode spcified line " + lineNumber + ". Remember that this number does not account for empty lines.";
                        throw new Exception(t);                        
                    }
            }
            #endregion

            try
            {
                Int16 value = Convert.ToInt16(parts[1]);
                UInt16 addressOrConstant = (UInt16)value;

                instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);

                Instructionbuffer.Add(instruction[0]);
                Instructionbuffer.Add(instruction[1]);
                Instructionbuffer.Add(instruction[2]);
                Instructionbuffer.Add(instruction[3]);
            }
            catch
            {
                byte temp = 0;
                Instructionbuffer.Add(instruction[0]);
                Instructionbuffer.Add(temp);
                Instructionbuffer.Add(temp);
                Instructionbuffer.Add(temp);
            }
        }

        

    }
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
 * 0x17 - End program
 * 
 * */
