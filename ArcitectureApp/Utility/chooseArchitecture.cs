using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcitectureApp.Utility
{
    class chooseArchitecture
    {
        public Architecture.Architecture chosenArchitecture {get; private set; }

        public chooseArchitecture(int x)
        {
            if (x == 1)
                chosenArchitecture = new Architecture.Accumulator();
            else if (x == 2)
                chosenArchitecture = new Architecture.RegisterMemory();
            else
                throw new Exception("Invalide argument to choose Architecture");
        }
    }
}
