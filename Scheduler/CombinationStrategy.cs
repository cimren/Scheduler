using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Scheduler
{
    abstract class CombinationStrategy
    {
        public ArrayList combinations=new ArrayList();

        public abstract ArrayList getCombinations();

    }
}
