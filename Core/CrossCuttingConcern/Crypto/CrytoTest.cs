using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcern.Crypto
{
    public class CrytoTest
    {
        public static string TestCryto(string value)
        {
            string test = value + DateTime.Now.Ticks.ToString().PadRight(20,'0').PadLeft(25,'1');
                                        //2^18
            string test1 = value + Guid.NewGuid().ToString().ToUpper().Split('1',15);
                                    //2^36

            return test;
        }
    }
}
