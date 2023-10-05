using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility
{
    public class RandomValueGenerator
    {
        public static string UniqueFileName(string extension)
        {
            return Guid.NewGuid().ToString().Replace("-,", "") + extension;
        }
            
    }
}
