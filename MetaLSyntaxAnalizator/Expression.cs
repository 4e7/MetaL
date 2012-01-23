using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
   public class Expression:SyntaxExpression
    {
       public Expression(SyntaxExpression a)
            : base(a)
        {
            
        }
       public string result="empty result";
       public string calculations = "";
       public override string go()
       {
           Lexems.Lexema l = getToken();
           string s = "";
           if (l == null) return "";
           if (l.GetType().Name != "UnOperNot")
           {

               this.lexems.Add(l);
           }
           else
           {
               s = "\tnot bx\n";
           }
           
           while ((l = getToken()) != null)
           {
               this.lexems.Add(l);
           }
           SubExpression e=new SubExpression(this);
           
           string result=e.go();
           calculations = e.calculations;
           string tmp = s;
           if(result !=null)
           {
               s = result ;
           }

            s += "\tmov bx,"+e.result+"\n"+tmp+"\n";
            this.result = "bx";
           
           return s;
       }
    }
}
