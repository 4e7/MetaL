using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    class Indetifire:SyntaxExpression
    {
        public Indetifire(SyntaxExpression a)
            : base(a)
        {
            
        }
       public override string go()
       {
           
           SyntaxError error = null;
           string s = null;
           Lexems.Lexema l = getToken();
           if (l.GetType().Name == "Identifire")
           {
               s = "Undefinded";
               
               if (hasId(l.Data))
               {
                   error = new IndetifireRedefinitionError(l.Data);
               }
               else
               {
                   s += "\t" +l.Data + " dw ?\n";
               }
               addId(l.Data);
           }
           else
           {
               error = new IndetifierMissedError();
               
           }
           return s;
       }
    }
}
