using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    class VariableDefinitionMissedError : SyntaxError
    {
        public override string message()
        {
            return "Программа должна начинаться с обьявления переменных";
        }
    }
    class CalculationsMissedError : SyntaxError
    {
        public override string message()
        {
            return "Программа должна содержать инструкции";
        }
    }
   public class Programm:SyntaxExpression
    {
        public Programm(Analizator a):base(a)
        {
            
        }
        public override string go()
        {
            string s = null;
            SyntaxError error = null;
            s = new VariableDefinition(analizator).go();
            if (s == null)
            {
                error = new VariableDefinitionMissedError();
                error.position = 0;
                analizator.errors.Add(error);
                analizator.position++;
            }
            else
            {
                string calculations= new CalculationsDescription(analizator).go();
                if (calculations != null)
                {
                    s += calculations;
                }
                else
                {
                    error = new CalculationsMissedError();
                    error.position = analizator.position;
                    analizator.errors.Add(error);
                    s = null;
                    
                }
            }

            return s;
        }
    }
}
