using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{


    class UnexpectedIndefier : SyntaxError
    {
 string id = "";
 public UnexpectedIndefier(string id)
        {
            this.id = id;
        }
        public override string message()
        {
            return "Неожиданный интендификатор " + id;
        }
    }
    class UndefindedIndefier : SyntaxError
    {
        string id = "";
        public UndefindedIndefier(string id)
        {
            this.id = id;
        }
        public override string message()
        {
            return "Не распознанный интендификатор " + id;
        }
    }
    class OperatorEqualInWrongPosition:SyntaxError
    {
        public override string message()
        {
            return "Неверное положение оператора = , либо лишний оператор =";
        }
    }
    
    
    public class Assignment:SyntaxExpression
    {
        bool wasIndetifier = false;
        bool wasFirst = true;
        public Lexems.Lexema indetifier = new MetaLLexems.Identifire();
        public Assignment(SyntaxExpression a):base(a)
        {
            indetifier.Data = "";
        }
        public override string go()
        {

            string s = "";
            Lexems.Lexema l = getToken();
            string type = "";
            if (l != null)
            {
                type = l.GetType().Name;
            }
            else
            {
                return null;
            }
            switch (type)
            {
                case "Identifire":
                    {
                        wasIndetifier = true;
                        if (hasId(l.Data))
                        {
                            indetifier.Data = l.Data;
                        }
                        else
                        {
                            addError(new UndefindedIndefier(l.Data), 0); ;
                        }
                        Lexems.Lexema lt = null;
                        while ((lt = getToken()) != null && lt.GetType().Name != "Endl")
                        {
                            this.lexems.Add(lt);
                        }
                        if (lt == null)
                        {
                            addError(new EndlMissedError(), 0);
                        }
                        Assignment a=new Assignment(this);
                        a.indetifier = this.indetifier;
                        a.wasIndetifier = true;
                        string ass = a.go();
                        if (ass != null)
                        {
                            s += ass;
                        }
                        
                    }
                    break;
                case "BinOperEqual":
                    {
                        if (wasIndetifier)
                        {
                            s += "\tmov " + indetifier.Data + ",ax";
                        }
                        else
                        {
                            addError(new IndetifierMissedError(), 0);
                        }
                        Lexems.Lexema lt = null;
                        while ((lt = getToken()) != null && lt.GetType().Name != "Endl")
                        {
                            this.lexems.Add(lt);
                        }
                        if (lt == null&&!wasIndetifier)
                        {
                            addError(new EndlMissedError(), 0);
                        }
                        Expression e=new Expression(this);
                        string result = e.go();
                        if (result != null)
                        {
                            s = result + "\tmov ax," + e.result + "\n" + s;
                        }
                    }
                    break;
                case "For":
                    
                        if (wasIndetifier)
                        {
                            addError(new UnexpectedIndefier(this.indetifier.Data), 0);
                        }
                       
                    
                    return new ForTo(this.parent).go();
               /* case "Print":
                    
                        if (wasIndetifier)
                        {
                            addError(new UnexpectedIndefier(this.indetifier.Data), 0);
                        }

                        return new Print(this.parent).go();
                 */   
                default:
                    {
                        if (wasIndetifier)
                        {
                            this.lexems.Insert(0, indetifier);
                        }
                        Lexems.Lexema lt = null;
                        while ((lt = getToken()) != null && lt.GetType().Name != "Endl")
                        {
                            this.lexems.Add(lt);
                        }
                        if (lt == null)
                        {
                            addError(new EndlMissedError(), 0);
                        }
                        
                        Expression e = new Expression(this);
                        string result = e.go();
                        if (result != null)
                        {
                            s = result;
                        }
                    }
                    break;

            }

            return s;
        }
    }
}
