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
       public VariableDefinition(Analizator a)
            : base(a)
        {
            
        }
       public override string go()
       {
           SyntaxError error = null;
           string s = null;
           Lexema l = analizator.getToken();
           if (l.GetType().Name == "Var")
           {
               s = new VariableList(analizator).go();
               if (s == null)
               {
                   error = new VariableListMissedError();
                   error.position = analizator.position;
                   analizator.errors.Add(error);
               }
               
            }

           

           return s;
       }
    }
}
