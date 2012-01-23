using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;
namespace MetaLSyntaxAnalizator
{

    class VariableListMissedError : SyntaxError
    {
        public override string message()
        {
            return "Пропущен список переменных";
        }
    }
    class EndlMissedError : SyntaxError
    {
        public override string message()
        {
            return "Требуется ;";
        }
    }
   public  class VariableDefinition:SyntaxExpression
    {
       public VariableDefinition(SyntaxExpression a)
            : base(a)
        {
            
        }
       public override string go()
       {
           SyntaxError error = null;
           string s = null;
           Lexema l = getToken();
           if (l.GetType().Name == "Var")
           {
               while ((l=getToken())!=null&&l.GetType().Name!="Endl")
               {
                   string type=l.GetType().Name;
                   if (type == "Begin")
                   {
                       addError(new EndlMissedError(), 0);
                       break;
                   }
                   lexems.Add(l);
               }
               if (l==null)
               {
                   addError(new EndlMissedError(), 0);
               }
               string result = "SEG1 SEGMENT\n";
               s = new VariableList(this).go();
               if (s == null)
               {
                   error = new VariableListMissedError();

               }
               else
               {
                   result += s+"\n";
                   result += "SEG1 ENDS\n";
                   s = result;
               }
               
            }

           
           return s;
       }
    }
}
