using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Scheduler
{
    class CombinationContext
    {
        CombinationStrategy cmbStrategy;

        public void setCombinationStrategy(CombinationStrategy _cmbStrategy)
        {
            cmbStrategy = _cmbStrategy;
        }

        public ArrayList getCombinations()
        {
            return cmbStrategy.getCombinations();
        }

    }
}
