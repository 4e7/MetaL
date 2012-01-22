using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    class KeyWordBeginMissed : SyntaxError
    {
        public override string message()
        {
            return "Пропущенно ключевое слово Begin";
        }
    }
    class KeyWordEndMissed : SyntaxError
    {
        public override string message()
        {
            return "Пропущенно ключевое слово End";
        }
    }
    public class CalculationsDescription:SyntaxExpression
    {
        public CalculationsDescription(Analizator a)
            : base(a)
        {
            
        }
        public override string go()
        {
            
            string s = null;
            Lexems.Lexema l = analizator.getToken();
            if (l.GetType().Name == "Begin")
            {
                s = "CODE SEGMENT\nASSUME CS:CODE, DS:SEG1\nSTART:\n\tmov AX,SEG1\n\tmov DS,AX\n";
                string assignmentsList = new AssignmentList(analizator).go();

                if (assignmentsList != null)
                {
                    s += assignmentsList;
                }
                    l = analizator.getToken();
                    if (l != null && l.GetType().Name == "End")
                    {
                        s += "CODE ENDS\nEND START\n";
                    }
                    else
                    {
                        SyntaxError error = new KeyWordEndMissed();
                        error.position = analizator.position;
                        analizator.errors.Add(error);
                        s = null;
                    }
                
            }
            else
            {
                SyntaxError error = new KeyWordBeginMissed();
                error.position = analizator.position;
                analizator.errors.Add(error);
                s = null;
 
            }
            return s;
        }
    }
}
