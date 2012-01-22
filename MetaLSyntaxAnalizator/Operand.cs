using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
   public class Operand:SyntaxExpression
    {
       public Operand(Analizator a)
            : base(a)
        {
            
        }
       public override string go()
       {
           string s = null;
           return s;
       }
    }
}
