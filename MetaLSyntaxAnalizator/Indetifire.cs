using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    class Indetifire:SyntaxExpression
    {
        public Indetifire(Analizator a)
            : base(a)
        {
            
        }
       public override string go()
       {
           
           SyntaxError error = null;
           string s = null;
           Lexems.Lexema l = analizator.getToken();
           if (l.GetType().Name == "Identifire")
           {
               s = "";
               if (analizator.ids.Contains(l.Data))
               {
                   error = new IndetifireRedefinitionError(l.Data);
               }
               else
               {
                   s += "\t" +l.Data + " dw ?\n";
               }

               analizator.ids.Add(l.Data);
           }
           else
           {
               error = new IndetifierMissedError();
               error.position = analizator.position;
               analizator.errors.Add(error);
           }
           return s;
       }
    }
}
