using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    class CloseBracketMissed : SyntaxError
    {
        public override string message()
        {
            return "Пропущенна закрывающая скобка";
        }
    }
   public class SubExpression:Expression
    {
       public SubExpression(SyntaxExpression a)
            : base(a)
        {
            
        }
       
       public override string go()
       {
           Lexems.Lexema l = getToken();
           string s="";
           if (l == null) return null;
           string type = l.GetType().Name;
           switch (type)
           {
               case "OpenBracket":
                   {
                       Lexems.Lexema local=null;
                       while((local=getToken())!=null&&local.GetType().Name!="CloseBracket")
                       {
                           this.lexems.Add(local);
                       }
                       if(local==null)
                       {
                           addError(new CloseBracketMissed(),0);
                       }
                       Expression e=new Expression(this);
                       string res= e.go();
                       calculations = e.calculations;
                       this.result="cx";
                       
                       if (res != null)
                       {
                           s = res + "\tmov cx," + e.result+"\n";
                       }
                       
                   }
                   break;
               
               default:
                   {
                       do
                       {
                           this.lexems.Add(l);
                       }
                       while ((l = getToken()) != null);
                       BinaryOperator op=new BinaryOperator(this);
                       s = op.go();
                       calculations = op.calculations;
                       this.result = "cx";
                       s += "\tmov cx," + op.result+"\n";
                   }
                   break;
           }
           
           return s;
       }
    }
}
 