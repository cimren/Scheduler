using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Scheduler
{
    class StringCombination : CombinationStrategy
    {
        public StringCombination(List<Array> list)
        {
            foreach (string x in foo(0, list))
            {
                string[] arr = x.Split(' ');
                int[] combArray = new int[list.Count];

                for (int i = 0; i < list.Count; i++)
                {
                    int a = Int32.Parse(arr[i]);
                    combArray[i] = a;

                }
                Combination combination = new Combination(combArray);
                combinations.Add(combination);
            }
        }

        public override ArrayList getCombinations()
        {
            return combinations;
        }


        static List<string> foo(int a, List<Array> x)
        {
            List<string> retval = new List<string>();
            if (a == x.Count)
            {
                retval.Add("");
                return retval;
            }
            foreach (Object y in x[a])
            {
                foreach (string x2 in foo(a + 1, x))
                {
                    retval.Add(y.ToString() + " " + x2.ToString());
                }

            }
            return retval;
        }
    }
}
