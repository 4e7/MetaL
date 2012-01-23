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
            Lexems.Lexema l = null;
            while ((l = getToken()) != null)
            {
                lexems.Add(l);
            }
            s = new VariableDefinition(this).go();
            if (s == null)
            {
                error = new VariableDefinitionMissedError();
                error.position = 0;
                
            }
            else
            {
                s += "CODE SEGMENT\nASSUME CS:CODE, DS:SEG1\nSTART:\n\tmov AX,SEG1\n\tmov DS,AX\n";
                CalculationsDescription cd = new CalculationsDescription(this);
                string calculations= cd.go();
                if (calculations != null)
                {
                    s += calculations;
                }
                else
                {
                   addError ( new CalculationsMissedError(),0);
                    
                }
                s += "CODE ENDS\nEND START\n";
            }

            return s;
        }
    }
}
