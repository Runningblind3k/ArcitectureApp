using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcitectureApp.Testing
{
    class RegisterMemoryTest : Architecture.RegisterMemory
    {
        Random rnd;
        public int NumberOfTestsRun
        {
            get;
            private set;
        }
        public int NumberOfTestsFailed
        {
            get;
            private set;
        }

        public RegisterMemoryTest()
        {
            rnd = new Random();
            NumberOfTestsRun = 0;
            NumberOfTestsFailed = 0;
        }


        public void RunTestRegisters()
        {

            int randomNum;
            bool result;
            TestReport tr = TestReport.Instance;


            for (byte i = 1; i < 21; i++)
            {
                randomNum = rnd.Next();
                try
                {
                    NumberOfTestsRun++;
           
                    result = TestRegisters(i, randomNum);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed TestRegisters using register " + i + " and the value " + randomNum +"");
                        NumberOfTestsFailed++;
                    }
                }
                catch(Exception e)
                {
                    tr.AddLineToReport("Failed TestRegisters using register " + i + " and the value " + randomNum + "");
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }
            }

            for (byte i = 1; i < 21; i++)
            {
                randomNum = rnd.Next() * -1;
                try
                {
                    NumberOfTestsRun++;

                    result = TestRegisters(i, randomNum);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed TestRegisters using register " + i + " and the value " + randomNum + "");
                        NumberOfTestsFailed++;
                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed TestRegisters using register " + i + " and the value " + randomNum + "");
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }
            }
        }

        public void RunTestLoadStore()
        {
            int randomNum;
            UInt16 Memoryloc;
            byte reg1;
            byte reg2;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 500; i++)
            {
                randomNum = rnd.Next();
                Memoryloc = Convert.ToUInt16(rnd.Next(0, 18000));
                reg1 = Convert.ToByte(rnd.Next(1, 20)); 
                reg2 = Convert.ToByte(rnd.Next(1, 20));
                NumberOfTestsRun++;

                try
                {

                    result = RmTestLoadStore(reg1, reg2, Memoryloc, randomNum);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmLoadStore using registers " + reg1 +", " + reg2 + " and the value " + randomNum + "");
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmLoadStore using registers " + reg1 + ", " + reg2 + " and the value " + randomNum + "");
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

            }

        }

        public void RunTestIndLoad()
        {
            int randomNum;
            UInt16 Memoryloc1;
            UInt16 Memoryloc2;
            byte reg1;
            byte reg2;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 500; i++)
            {
                randomNum = rnd.Next();
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                Memoryloc2 = Convert.ToUInt16(rnd.Next(0, 18000));
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                reg2 = Convert.ToByte(rnd.Next(1, 20));
                NumberOfTestsRun++;

                try
                {

                    result = RmTestIndLoad(reg1, reg2, Memoryloc1, Memoryloc2, randomNum);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestIndLoad using registers " + reg1 + ", " + reg2 + " and the value " + randomNum + "");
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestIndLoad using registers " + reg1 + ", " + reg2 + " and the value " + randomNum + "");
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

            }
        }

        public void RunTestIndStore()
        {
            int randomNum;
            UInt16 Memoryloc1;
            UInt16 Memoryloc2;
            byte reg1;
            byte reg2;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 500; i++)
            {
                randomNum = rnd.Next();
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                Memoryloc2 = Convert.ToUInt16(rnd.Next(0, 18000));
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                reg2 = Convert.ToByte(rnd.Next(1, 20));
                NumberOfTestsRun++;

                try
                {

                    result = RmTestIndStore(reg1, reg2, Memoryloc1, Memoryloc2, randomNum);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestIndStore using registers " + reg1 + ", " + reg2 + " and the value " + randomNum + "");
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestIndStore using registers " + reg1 + ", " + reg2 + " and the value " + randomNum + "");
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

            }
        }

        public void RunTestAdd()
        {
            int randomNum1;
            int randomNum2;
            UInt16 Memoryloc1;
            byte reg1;
            bool result;
            TestReport tr = TestReport.Instance;
            for (int i = 0; i < 500; i++)
            {
                randomNum1 = rnd.Next();
                randomNum2 = rnd.Next();
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                NumberOfTestsRun++;

                try
                {

                    result = RmTestAdd(reg1, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestIndStore using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestIndStore using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

                NumberOfTestsRun++;
                randomNum1 *= -1;

                try
                {

                    result = RmTestAdd(reg1, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestIndStore using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestIndStore using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

                NumberOfTestsRun++;
                randomNum2 *= -1;

                try
                {

                    result = RmTestAdd(reg1, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestIndStore using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestIndStore using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }
            }

        }

        public void RunTestAddImm()
        {
            int randomNum1;
            UInt16 ranImmidiate;
            UInt16 Memoryloc1;
            byte reg1;
            bool result;
            bool invert;

            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 1000; i++)
            {
                randomNum1 = rnd.Next();
                ranImmidiate = Convert.ToUInt16(rnd.Next(0, Int16.MaxValue));
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                invert = Convert.ToBoolean(rnd.Next(0, 1));

                if (invert)
                {
                    randomNum1 *= -1;
                }

                NumberOfTestsRun++;

                try
                {

                    result = RmTestAddImm(reg1, ranImmidiate, randomNum1);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestAddImm using registers " + reg1  + " and the value " + randomNum1 + ", " + ranImmidiate + "");
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestAddImm using registers " + reg1 + " and the value " + randomNum1 + ", " + ranImmidiate + "");
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }
            }
        }

        public void RunTestAnd()
        {
            int randomNum1;
            int randomNum2;
            UInt16 Memoryloc1;
            byte reg1;
            bool result;
            TestReport tr = TestReport.Instance;
            for (int i = 0; i < 500; i++)
            {
                randomNum1 = rnd.Next();
                randomNum2 = rnd.Next();
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                NumberOfTestsRun++;

                try
                {

                    result = RmTestAnd(reg1, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestAnd using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestAnd using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

                NumberOfTestsRun++;
                randomNum1 *= -1;

                try
                {

                    result = RmTestAnd(reg1, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestAnd using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestAnd using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

                NumberOfTestsRun++;
                randomNum2 *= -1;

                try
                {

                    result = RmTestAnd(reg1, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestAnd using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestAnd using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }
            }
        }

        public void RunTestOr()
        {
            int randomNum1;
            int randomNum2;
            UInt16 Memoryloc1;
            byte reg1;
            bool result;
            TestReport tr = TestReport.Instance;
            for (int i = 0; i < 500; i++)
            {
                randomNum1 = rnd.Next();
                randomNum2 = rnd.Next();
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                NumberOfTestsRun++;

                try
                {

                    result = RmTestOr(reg1, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestOr using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestOr using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

                NumberOfTestsRun++;
                randomNum1 *= -1;

                try
                {

                    result = RmTestOr(reg1, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestOr using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestOr using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

                NumberOfTestsRun++;
                randomNum2 *= -1;

                try
                {

                    result = RmTestOr(reg1, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestOr using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestOr using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }
            }
        }

        public void RunTestNot()
        {
            int randomNum2;
            byte reg1;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 500; i++)
            {
                randomNum2 = rnd.Next();

                if ((i % 2) == 1)
                {
                    randomNum2 *= -1;
                }

                reg1 = Convert.ToByte(rnd.Next(1, 20));
                NumberOfTestsRun++;

                try
                {

                    result = RmTestNot(reg1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestNot using registers " + reg1 + ",  and the value "  + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestNot using registers " + reg1 + ",  and the value " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

            }
        }

        public void RunTestXor()
        {
            int randomNum1;
            int randomNum2;
            UInt16 Memoryloc1;
            byte reg1;
            bool result;
            TestReport tr = TestReport.Instance;
            for (int i = 0; i < 500; i++)
            {
                randomNum1 = rnd.Next();
                randomNum2 = rnd.Next();
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                NumberOfTestsRun++;

                try
                {

                    result = RmTestXor(reg1, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestXor using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestXor using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

                NumberOfTestsRun++;
                randomNum1 *= -1;

                try
                {

                    result = RmTestXor(reg1, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestXor using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestXor using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

                NumberOfTestsRun++;
                randomNum2 *= -1;

                try
                {

                    result = RmTestXor(reg1, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestXor using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestXor using registers " + reg1 + ", the Memloc " + Memoryloc1 + " and the value " + randomNum1 + ", " + randomNum2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }
            }
        }

        public void RunTestMove()
        {
            int randomNum1;
            byte reg1;
            byte reg2;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 500; i++)
            {
                NumberOfTestsRun++;
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                reg2 = Convert.ToByte(rnd.Next(1, 20));
                randomNum1 = rnd.Next();
                if ((i % 2) == 1)
                {
                    randomNum1 *= -1;
                }
                try
                {

                    result = RmTestMove(reg1, reg2, randomNum1);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestMove using registers " + reg1 + ", " + reg2 + " and the value " + randomNum1);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestMove using registers " + reg1 + ", " + reg2 + " and the value " + randomNum1);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }
            }
        }

        public void RunTestjump()
        {
            UInt16 Memoryloc1;
            UInt16 Memoryloc2;
            TestReport tr = TestReport.Instance;
            bool result;

            for (int i = 0; i < 500; i++)
            {
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                Memoryloc2 = Convert.ToUInt16(rnd.Next(0, 18000));


                NumberOfTestsRun++;

                try
                {

                    result = RmTestJump(Memoryloc1, Memoryloc2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestJump using memory locations " + Memoryloc1 + " and " + Memoryloc2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestJump using memory locations " + Memoryloc1 + " and " + Memoryloc2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }
            }

        }

        public void RunTestBranchOnZero()
        {
            byte reg1;
            UInt16 Memoryloc1;
            UInt16 Memoryloc2;
            int value;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 500; i++)
            {
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                Memoryloc2 = Convert.ToUInt16(rnd.Next(0, 18000));
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                NumberOfTestsRun++;
                if ((i % 100) == 0)
                {
                    value = 0;
                }
                else
                {
                    value = rnd.Next();
                    if ((i % 2) == 0)
                    {
                        value = value *= -1;
                    }
                }

                NumberOfTestsRun++;

                try
                {

                    result = RmTestBranchOnZero(reg1, Memoryloc1, value, Memoryloc2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestBranchOnZero using register " + reg1 +  " the value " + value + " and the meory locations " + Memoryloc1 + ", and " + Memoryloc2 +"");
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestBranchOnZero using register " + reg1 + " the value " + value + " and the meory locations " + Memoryloc1 + ", and " + Memoryloc2 + "");
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }


            }

        }

        public void RunTestSetOnEqual()
        {
            int randomNum1;
            int randomNum2;
            byte reg1;
            byte reg2;
            UInt16 Memoryloc1;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 700; i++)
            {
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                reg2 = Convert.ToByte(rnd.Next(1, 20));
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                randomNum1 = rnd.Next();
                NumberOfTestsRun++;
                if ((i % 2) == 1)
                {
                    randomNum1 *= -1;
                }

                if (rnd.Next(0, 10) == 0)
                {
                    randomNum2 = randomNum1;
                }
                else
                {
                    randomNum2 = rnd.Next();
                    if (rnd.Next(0, 7) == 3)
                    {
                        randomNum2 *= -1;
                    }
                }

                try
                {

                    result = RmTestSetOnEqual(reg1, reg2, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestSetOnEqual using registers " + reg1 + ", " + reg2 + " and the values " + randomNum1 + ", " + randomNum2 + " and the memory location " + Memoryloc1);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestSetOnEqual using registers " + reg1 + ", " + reg2 + " and the values " + randomNum1 + ", " + randomNum2 + " and the memory location " + Memoryloc1);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }


            }

        }

        public void RunTestSetNotEqual()
        {
            int randomNum1;
            int randomNum2;
            byte reg1;
            byte reg2;
            UInt16 Memoryloc1;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 700; i++)
            {
                NumberOfTestsRun++;
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                reg2 = Convert.ToByte(rnd.Next(1, 20));
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                randomNum1 = rnd.Next();
                if ((i % 2) == 1)
                {
                    randomNum1 *= -1;
                }

                if (rnd.Next(0, 10) == 0)
                {
                    randomNum2 = randomNum1;
                }
                else
                {
                    randomNum2 = rnd.Next();
                    if (rnd.Next(0, 7) == 3)
                    {
                        randomNum2 *= -1;
                    }
                }

                try
                {

                    result = RmTestSetNotEqual(reg1, reg2, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestSetNotEqual using registers " + reg1 + ", " + reg2 + " and the values " + randomNum1 + ", " + randomNum2 + " and the memory location " + Memoryloc1);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestSetNotEqual using registers " + reg1 + ", " + reg2 + " and the values " + randomNum1 + ", " + randomNum2 + " and the memory location " + Memoryloc1);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }


            }
        }

        public void RunTestSetOnGreaterThan()
        {
            int randomNum1;
            int randomNum2;
            byte reg1;
            byte reg2;
            UInt16 Memoryloc1;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 700; i++)
            {
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                reg2 = Convert.ToByte(rnd.Next(1, 20));
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                randomNum1 = rnd.Next();
                NumberOfTestsRun++;
                if ((i % 2) == 1)
                {
                    randomNum1 *= -1;
                }

                if (rnd.Next(0, 10) == 0)
                {
                    randomNum2 = randomNum1;
                }
                else
                {
                    randomNum2 = rnd.Next();
                    if (rnd.Next(0, 7) == 3)
                    {
                        randomNum2 *= -1;
                    }
                }

                try
                {

                    result = RmTestSetOnGreaterThan(reg1, reg2, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestSetOnGreaterThan using registers " + reg1 + ", " + reg2 + " and the values " + randomNum1 + ", " + randomNum2 + " and the memory location " + Memoryloc1);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestSetOnGreaterThan using registers " + reg1 + ", " + reg2 + " and the values " + randomNum1 + ", " + randomNum2 + " and the memory location " + Memoryloc1);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }


            }
        }

        public void RunTestSetOnLessThan()
        {
            int randomNum1;
            int randomNum2;
            byte reg1;
            byte reg2;
            UInt16 Memoryloc1;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 700; i++)
            {
                NumberOfTestsRun++;
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                reg2 = Convert.ToByte(rnd.Next(1, 20));
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                randomNum1 = rnd.Next();
                if ((i % 2) == 1)
                {
                    randomNum1 *= -1;
                }

                if (rnd.Next(0, 10) == 0)
                {
                    randomNum2 = randomNum1;
                }
                else
                {
                    randomNum2 = rnd.Next();
                    if (rnd.Next(0, 7) == 3)
                    {
                        randomNum2 *= -1;
                    }
                }

                try
                {

                    result = RmTestSetOnLessThan(reg1, reg2, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestSetOnLessThan using registers " + reg1 + ", " + reg2 + " and the values " + randomNum1 + ", " + randomNum2 + " and the memory location " + Memoryloc1);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestSetOnLessThan using registers " + reg1 + ", " + reg2 + " and the values " + randomNum1 + ", " + randomNum2 + " and the memory location " + Memoryloc1);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }


            }
        }

        public void RunTestSetOnGreaterThanOrEqual()
        {
            int randomNum1;
            int randomNum2;
            byte reg1;
            byte reg2;
            UInt16 Memoryloc1;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 700; i++)
            {
                NumberOfTestsRun++;
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                reg2 = Convert.ToByte(rnd.Next(1, 20));
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                randomNum1 = rnd.Next();
                if ((i % 2) == 1)
                {
                    randomNum1 *= -1;
                }

                if (rnd.Next(0, 10) == 0)
                {
                    randomNum2 = randomNum1;
                }
                else
                {
                    randomNum2 = rnd.Next();
                    if (rnd.Next(0, 7) == 3)
                    {
                        randomNum2 *= -1;
                    }
                }

                try
                {

                    result = RmTestSetOnGreaterThanOrEqual(reg1, reg2, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestSetOnGreaterThanOrEqual using registers " + reg1 + ", " + reg2 + " and the values " + randomNum1 + ", " + randomNum2 + " and the memory location " + Memoryloc1);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestSetOnGreaterThanOrEqual using registers " + reg1 + ", " + reg2 + " and the values " + randomNum1 + ", " + randomNum2 + " and the memory location " + Memoryloc1);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }


            }
        }

        public void RunTestSetOnLessThanOrEqual()
        {
            int randomNum1;
            int randomNum2;
            byte reg1;
            byte reg2;
            UInt16 Memoryloc1;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 700; i++)
            {
                NumberOfTestsRun++;
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                reg2 = Convert.ToByte(rnd.Next(1, 20));
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                randomNum1 = rnd.Next();
                if ((i % 2) == 1)
                {
                    randomNum1 *= -1;
                }

                if (rnd.Next(0, 10) == 0)
                {
                    randomNum2 = randomNum1;
                }
                else
                {
                    randomNum2 = rnd.Next();
                    if (rnd.Next(0, 7) == 3)
                    {
                        randomNum2 *= -1;
                    }
                }

                try
                {

                    result = RmTestSetOnLessThanOrEqual(reg1, reg2, Memoryloc1, randomNum1, randomNum2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestSetOnLessThanOrEqual using registers " + reg1 + ", " + reg2 + " and the values " + randomNum1 + ", " + randomNum2 + " and the memory location " + Memoryloc1);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestSetOnLessThanOrEqual using registers " + reg1 + ", " + reg2 + " and the values " + randomNum1 + ", " + randomNum2 + " and the memory location " + Memoryloc1);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }


            }
        }

        public void RunTestPushPop()
        {
            int randomNum1;
            byte reg1;
            byte reg2;
            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 500; i++)
            {
                NumberOfTestsRun++;
                reg1 = Convert.ToByte(rnd.Next(1, 20));
                reg2 = Convert.ToByte(rnd.Next(1, 20));
                randomNum1 = rnd.Next();
                if ((i % 2) == 1)
                {
                    randomNum1 *= -1;
                }

                try
                {

                    result = RmTestPushPop(reg1, reg2, randomNum1);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestPushPop using registers " + reg1 + ", " + reg2 + " and the value " + randomNum1);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestPushPop using registers " + reg1 + ", " + reg2 + " and the value " + randomNum1);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

            }
        }

        public void RunTestCall()
        {

            byte reg1;
            UInt16 Memoryloc1;
            UInt16 Memoryloc2;
            UInt16 Memoryloc3;

            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 500; i++)
            {
                NumberOfTestsRun++;
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                Memoryloc2 = Convert.ToUInt16(rnd.Next(0, 18000));
                Memoryloc3 = Convert.ToUInt16(rnd.Next(0, 18000));
                reg1 = Convert.ToByte(rnd.Next(1, 20));

                try
                {

                    result = RmTestCall(Memoryloc1, Memoryloc2, Memoryloc3, reg1);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestCall using register " + reg1 + " and the meory locations " + Memoryloc1 + "," + Memoryloc2 + ", and " + Memoryloc3);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestCall using register " + reg1 + " and the meory locations " + Memoryloc1 + "," + Memoryloc2 + ", and " + Memoryloc3);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }

            }
        }

        public void RunTestReturn()
        {
            UInt16 Memoryloc1;
            UInt16 Memoryloc2;

            bool result;
            TestReport tr = TestReport.Instance;

            for (int i = 0; i < 500; i++)
            {
                NumberOfTestsRun++;
                Memoryloc1 = Convert.ToUInt16(rnd.Next(0, 18000));
                Memoryloc2 = Convert.ToUInt16(rnd.Next(0, 18000));

                try
                {

                    result = RmTestReturn(Memoryloc1, Memoryloc2);
                    if (result == false)
                    {
                        tr.AddLineToReport("Failed RmTestReturn using the meory locations " + Memoryloc1 + ", and " + Memoryloc2);
                        NumberOfTestsFailed++;

                    }
                }
                catch (Exception e)
                {
                    tr.AddLineToReport("Failed RmTestReturn using the meory locations " + Memoryloc1 + ", and " + Memoryloc2);
                    NumberOfTestsFailed++;
                    tr.AddLineToReport("{0} Exception caught." + e);
                }
            }
        }

        private bool TestRegisters(byte register, int value)
        {

            uint v = (uint)value;

            SetRegister(register, v);
            v = GetRegister(register);

            if ((int)v == value)
            {
                return true;
            }

            return false;
        }

        private bool RmTestLoadStore(byte register1, byte register2, UInt16 Address, int value)
        {

            SetRegister(register1, (uint)value);

            RmStore(register1, Address);
            RmLoad(register2, Address);

            int v = (int)GetRegister(register2);

            if (v == value)
            {
                return true;
            }

            return false;
        }

        private bool RmTestIndLoad(byte reg1, byte reg2, UInt16 addi, UInt16 addv, int value)
        {

            SetRegister(reg1, (uint)addv);

            RmStore(reg1, addi);
            SetRegister(reg1, (uint)value);
            RmStore(reg1, addv);

            RmLoadIndirect(reg2, addi);

            int v = (int)GetRegister(reg2);

            if (v == value)
            {
                return true;
            }

            return false;
        }

        private bool RmTestIndStore(byte reg1, byte reg2, UInt16 addi, UInt16 addv, int value)
        {
            SetRegister(reg1, (uint)addv);

            RmStore(reg1, addi);
            SetRegister(reg1, (uint)value);

            RmStoreIndirect(reg1, addi);
            RmLoad(reg2, addv);

            int v = (int)GetRegister(reg2);

            if (v == value)
            {
                return true;
            }

            return false;
        }

        private bool RmTestAdd(byte reg1, UInt16 Addr, int value1, int value2)
        {
            int answer = value1 + value2;

            SetRegister(reg1, (uint)value2);
            RmStore(reg1, Addr);
            SetRegister(reg1, (uint)value1);
            RmAdd(reg1, Addr);

            int v = (int)GetRegister(reg1);

            if (v == answer)
            {
                return true;
            }
            
            return false;
        }

        private bool RmTestAddImm(byte reg, UInt16 imm, int value)
        {
            int answer = (int)imm + value;

            SetRegister(reg, (uint)value);
            RmAddImmediate(reg, imm);

            int v = (int)GetRegister(reg);

            if (v == answer)
            {
                return true;
            }

            return false;
        }

        private bool RmTestAnd(byte reg, UInt16 addr, int value1, int value2)
        {
            uint v1 = (uint)value1;
            uint v2 = (uint)value2;

            uint answer = v1 & v2;

            SetRegister(reg, (uint)value1);
            RmStore(reg, addr);
            SetRegister(reg, (uint)value2);
            RmAnd(reg, addr);

            uint v = GetRegister(reg);

            if (v == answer)
            {
                return true;
            }

            return false;
        }

        private bool RmTestOr(byte reg, UInt16 addr, int value1, int value2)
        {
            uint v1 = (uint)value1;
            uint v2 = (uint)value2;

            uint answer = v1 | v2;

            SetRegister(reg, (uint)value1);
            RmStore(reg, addr);
            SetRegister(reg, (uint)value2);
            RmOr(reg, addr);

            uint v = GetRegister(reg);

            if (v == answer)
            {
                return true;
            }

            return false;
        }

        private bool RmTestNot(byte reg, int value)
        {
            uint val = (uint)value;

            uint answer = ~val;

            SetRegister(reg, val);
            RmNot(reg);
            uint v = GetRegister(reg);

            if (v == answer)
            {
                return true;
            }

            return false;
        }

        private bool RmTestXor(byte reg, UInt16 addr, int value1, int value2)
        {
            uint v1 = (uint)value1;
            uint v2 = (uint)value2;

            uint answer = v1 ^ v2;

            SetRegister(reg, (uint)value1);
            RmStore(reg, addr);
            SetRegister(reg, (uint)value2);
            RmXor(reg, addr);

            uint v = GetRegister(reg);

            if (v == answer)
            {
                return true;
            }

            return false;
        }

        private bool RmTestMove(byte reg1, byte reg2, int value)
        {

            SetRegister(reg1, (uint) value);
            RmMove(reg2, (UInt16)reg1);
            int v = (int)GetRegister(reg2);

            if (v == value)
            {
                return true;
            }

            return false;
        }

        private bool RmTestJump(int oldPc, int newPc)
        {
            pc = (uint) oldPc;

            RmJump((UInt16)newPc);

            if (pc == ((UInt16)newPc))
            {
                return true;
            }

            return false;
        }

        private bool RmTestBranchOnZero(byte reg, int jAddr, int value1, int oldPc)
        {
            pc = (uint)oldPc;
            uint answer = pc;

            if (value1 == 0)
            {
                answer = (uint)jAddr;
            }

            SetRegister(reg, (uint)value1);
            RmBranchOnZero(reg, (UInt16)jAddr);

            if (pc == answer)
            {
                return true;
            }

            return false;
        }

        private bool RmTestSetOnEqual(byte reg1, byte reg2, int Addr, int value1, int value2)
        {
            uint answer;

            if (reg1 == reg2)
            {
                reg2 = 100;
            }

            if (value1 == value2)
            {
                answer = 1;
            }
            else
            {
                answer = 0;
            }

            SetRegister(reg2, (uint)value2);
            SetRegister(reg1, (uint)value1);
            RmStore(reg2, (UInt16)Addr);
            RmSetOnEqual(reg1, (UInt16)Addr);

            uint v = GetRegister(reg1);

            if (v == answer)
            {
                return true;
            }

            return false;
        }

        private bool RmTestSetNotEqual(byte reg1, byte reg2, int Addr, int value1, int value2)
        {
            uint answer;

            if (reg1 == reg2)
            {
                reg2 = 100;
            }

            if (value1 != value2)
            {
                answer = 1;
            }
            else
            {
                answer = 0;
            }

            SetRegister(reg2, (uint)value2);
            SetRegister(reg1, (uint)value1);
            RmStore(reg2, (UInt16)Addr);
            RmSetNotEqual(reg1, (UInt16)Addr);

            uint v = GetRegister(reg1);

            if (v == answer)
            {
                return true;
            }

            return false;
        }

        private bool RmTestSetOnGreaterThan(byte reg1, byte reg2, int Addr, int value1, int value2)
        {
            uint answer;

            if (reg1 == reg2)
            {
                reg2 = 100;
            }

            if (value1 > value2)
            {
                answer = 1;
            }
            else
            {
                answer = 0;
            }

            SetRegister(reg2, (uint)value2);
            SetRegister(reg1, (uint)value1);
            RmStore(reg2, (UInt16)Addr);
            RmSetOnGreaterThan(reg1, (UInt16)Addr);

            uint v = GetRegister(reg1);

            if (v == answer)
            {
                return true;
            }

            return false;
        }

        private bool RmTestSetOnGreaterThanOrEqual(byte reg1, byte reg2, int Addr, int value1, int value2)
        {
            uint answer;

            if (reg1 == reg2)
            {
                reg2 = 100;
            }

            if (value1 >= value2)
            {
                answer = 1;
            }
            else
            {
                answer = 0;
            }

            SetRegister(reg2, (uint)value2);
            SetRegister(reg1, (uint)value1);
            RmStore(reg2, (UInt16)Addr);
            RmSetOnGreaterThanOrEqual(reg1, (UInt16)Addr);

            uint v = GetRegister(reg1);

            if (v == answer)
            {
                return true;
            }

            return false;
        }

        private bool RmTestSetOnLessThan(byte reg1, byte reg2, int Addr, int value1, int value2)
        {
            uint answer;

            if (reg1 == reg2)
            {
                reg2 = 100;
            }

            if (value1 < value2)
            {
                answer = 1;
            }
            else
            {
                answer = 0;
            }

            SetRegister(reg2, (uint)value2);
            SetRegister(reg1, (uint)value1);
            RmStore(reg2, (UInt16)Addr);
            RmSetOnLessThan(reg1, (UInt16)Addr);

            uint v = GetRegister(reg1);

            if (v == answer)
            {
                return true;
            }

            return false;
        }

        private bool RmTestSetOnLessThanOrEqual(byte reg1, byte reg2, int Addr, int value1, int value2)
        {
            uint answer;

            if (value1 <= value2)
            {
                answer = 1;
            }
            else
            {
                answer = 0;
            }

            if (reg1 == reg2)
            {
                reg2 = 100;
            }

            SetRegister(reg2, (uint)value2);
            SetRegister(reg1, (uint)value1);
            RmStore(reg2, (UInt16)Addr);
            RmSetOnLessThanOrEqual(reg1, (UInt16)Addr);

            uint v = GetRegister(reg1);

            if (v == answer)
            {
                return true;
            }

            return false;
        }

        private bool RmTestPushPop(byte reg1, byte reg2, int value)
        {
            SetRegister(reg1, (uint)value);
            RmPush(reg1);
            RmPop(reg2);

            int v = (int)GetRegister(reg2);

            if (v == value)
            {
                return true;
            }

            return false;
        }

        private bool RmTestCall(UInt16 oldPc, UInt16 newPc, UInt16 Addr, byte reg)
        {
            pc = oldPc;

            RmCall((UInt16)Addr);
            RmPop(reg);

            UInt16 v = (UInt16)GetRegister(reg);

            int PcPlusFour = oldPc + 4;

            if((pc == newPc) && (PcPlusFour == v))
            {
                return true;
            }

            return false;
        }

        private bool RmTestReturn(int oldPc, int newPc)
        {
            pc = (uint)oldPc;

            SetRegister(1, (uint)newPc);
            RmPush(1);
            RmReturn();

            if (pc == (uint)newPc)
            {
                return true;
            }

            return false;
        }
    }
}
