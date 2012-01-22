using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
   public abstract class SyntaxError
    {
       public  int position=-1;
       public abstract string message();
    }
}
