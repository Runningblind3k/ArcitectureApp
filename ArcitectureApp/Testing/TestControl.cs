using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcitectureApp.Testing
{
    class TestControl
    {
        RegisterMemoryTest RmTest;
        AccumulatorTest AcTest;


        public TestControl()
        {
            RmTest = new RegisterMemoryTest();
            AcTest = new AccumulatorTest();

            TestReport tr = TestReport.Instance;

            RmTest.RunTestAdd();
            RmTest.RunTestAddImm();
            RmTest.RunTestIndLoad();
            RmTest.RunTestIndStore();
            RmTest.RunTestLoadStore();
            RmTest.RunTestRegisters();
            RmTest.RunTestjump();
            RmTest.RunTestMove();
            RmTest.RunTestNot();
            RmTest.RunTestOr();
            RmTest.RunTestXor();
            RmTest.RunTestMove();
            RmTest.RunTestBranchOnZero();
            RmTest.RunTestSetNotEqual();
            RmTest.RunTestSetOnEqual();
            RmTest.RunTestSetOnGreaterThan();
            RmTest.RunTestSetOnGreaterThanOrEqual();
            RmTest.RunTestSetOnLessThanOrEqual();
            RmTest.RunTestSetOnLessThan();
            RmTest.RunTestPushPop();
            RmTest.RunTestCall();
            RmTest.RunTestReturn();


            tr.AddLineToReport("Ran " + RmTest.NumberOfTestsRun + "tests, failed " + RmTest.NumberOfTestsFailed + ".");
            tr.WriteReport();
            
        }



    }
}
