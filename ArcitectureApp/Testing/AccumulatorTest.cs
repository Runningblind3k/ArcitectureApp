using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcitectureApp.Testing
{
    class AccumulatorTest : Architecture.Accumulator
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


    }
}
