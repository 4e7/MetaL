using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
   public class Operand:Expression
    {
       public Operand(SyntaxExpression a)
            : base(a)
        {
            
        }
       public override string go()
       {
           string s = "";
           Lexems.Lexema l = getToken();
           Lexems.Lexema op=l;
           if (l == null) return null;
           s = op.Data + "\n";
           while ((l = getToken()) != null )
           {
               lexems.Add(l);
           }
           if (lexems.Count>0)
           {
               calculations = new CalculationsDescription(this).go() + "\n";
           }
           
           
           
           return s;
       }
    }
}
