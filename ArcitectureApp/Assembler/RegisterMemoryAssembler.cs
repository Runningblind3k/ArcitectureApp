using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcitectureApp.Assembler
{
    class RegisterMemoryAssembler : Assembler
    {


        protected override void CreateBianary(string s, int lineNumber)
        {
            char[] delimiterChars = { ' ', ',' };
            string[] p = s.Split(delimiterChars);
            string[] parts = new string[3];
            byte[] instruction = { 0, 0, 0, 0 };

            UInt16 addressOrConstant;
            

            int i = 0;
            foreach (string tmp in p)
            {
                parts[i] = tmp.Trim();
                i++;
            }

            #region opcode

            switch (parts[0])
            {
                case "load":
                    {
                        instruction[0] |= 0x01;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "loadi":
                    {
                        instruction[0] |= 0x02;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "store":
                    {
                        instruction[0] |= 0x03;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "storei":
                    {
                        instruction[0] |= 0x04;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "add":
                    {
                        instruction[0] |= 0x05;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "addi":
                    {
                        instruction[0] |= 0x06;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "and":
                    {
                        instruction[0] |= 0x07;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "or":
                    {
                        instruction[0] |= 0x08;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "not":
                    {
                        instruction[0] |= 0x09;
                        instruction[1] = Convert.ToByte(parts[1]);
                        break;
                    }
                case "xor":
                    {
                        instruction[0] |= 0x0A;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "move":
                    {
                        instruction[0] |= 0x0B;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "jump":
                    {
                        instruction[0] |= 0x0C;
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "bzero":
                    {
                        instruction[0] |= 0x0D;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "seq":
                    {
                        instruction[0] |= 0x0E;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "sne":
                    {
                        instruction[0] |= 0x0F;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "sgt":
                    {
                        instruction[0] |= 0x10;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "slt":
                    {
                        instruction[0] |= 0x11;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "sge":
                    {
                        instruction[0] |= 0x12;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "sle":
                    {
                        instruction[0] |= 0x13;
                        instruction[1] = Convert.ToByte(parts[1]);
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "push":
                    {
                        instruction[0] |= 0x14;
                        instruction[1] = Convert.ToByte(parts[1]);
                        break;
                    }
                case "pop":
                    {
                        instruction[0] |= 0x15;
                        instruction[1] = Convert.ToByte(parts[1]);
                        break;
                    }
                case "call":
                    {
                        instruction[0] |= 0x16;
                        addressOrConstant = Convert.ToUInt16(parts[2]);
                        instruction[3] = Convert.ToByte(addressOrConstant & 0xFF);
                        addressOrConstant = Convert.ToUInt16(addressOrConstant >> 8);
                        instruction[2] = Convert.ToByte(addressOrConstant & 0xFF);
                        break;
                    }
                case "ret":
                    {
                        instruction[0] |= 0x17;
                        break;
                    }
                case "exit":
                    {
                        instruction[0] |= 0x18;
                        break;
                    }
                default:
                    {
                        string t = "Invalid opcode spcified line " + lineNumber + ". Remember that this number does not account for empty lines.";
                        throw new Exception(t);
                    }
            }
            #endregion

            Instructionbuffer.Add(instruction[0]);
            Instructionbuffer.Add(instruction[1]);
            Instructionbuffer.Add(instruction[2]);
            Instructionbuffer.Add(instruction[3]);

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
 * 0x5 - Add
 * 0x6 - Add Imediate
 * 0x7 - AND 
 * 0x8 - OR
 * 0x9 - NOT
 * 0xA - Exclusive OR
 * 0xB - Move
 * 0xC - Jump
 * 0xD - Branch on Zero
 * 0xE - Set on Equal
 * 0xF - Set Not Equal
 * 0x10 - Set on Greater Than
 * 0x11 - Set on Less Than
 * 0x12 - Set on Greater Than or Equal
 * 0x13 - Set on Less than or Equal
 * 0x14 - Push
 * 0x15 - Pop
 * 0x16 - Call
 * 0x17 - Return
 * 0x18 - End program
 * 
 * */
