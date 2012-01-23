using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;
using MetaLLexems;
namespace MetaLSyntaxAnalizator
{
    
   
    public class Analizator:SyntaxExpression
    {
        protected LexicalAnalizator m_lexicalAnalizator=new LexicalAnalizator();
        public string Programm;
        public List<string> errorMessages()
        {
            List<string> messages = new List<string>();
            foreach (LexemError error in m_lexicalAnalizator.errors)
            {
                messages.Add("Лексическая ошибка: неверная лексемма " + error.lexem + " в позиции " + error.position.ToString());
            }

            foreach (SyntaxError error in this.errors)
            {
                messages.Add("Синтаксическая ошибка:\n\t" + error.message() + " в позиции " + error.position.ToString());
            }
            return messages;
        }
        
        
        public Analizator():base(null)
        {
            this.m_ids = new HashSet<string>();
            m_lexicalAnalizator.registerLexem(new UnOperNot());
            //m_lexicalAnalizator.registerLexem(new MetaLLexems.Print());
            m_lexicalAnalizator.registerLexem(new OpenBracket());
            m_lexicalAnalizator.registerLexem(new CloseBracket());
            m_lexicalAnalizator.registerLexem(new BinOperAnd());
            m_lexicalAnalizator.registerLexem(new BinOperOr());
            m_lexicalAnalizator.registerLexem(new BinOperXor());
            m_lexicalAnalizator.registerLexem(new Const());
            m_lexicalAnalizator.registerLexem(new To());
            m_lexicalAnalizator.registerLexem(new For());
            m_lexicalAnalizator.registerLexem(new End());
            m_lexicalAnalizator.registerLexem(new Begin());
            m_lexicalAnalizator.registerLexem(new Var());
            m_lexicalAnalizator.registerLexem(new BinOperEqual());
            m_lexicalAnalizator.registerLexem(new Endl());
            m_lexicalAnalizator.registerLexem(new Comma());
            m_lexicalAnalizator.registerLexem(new MetaLLexems.Identifire());
        }

        public override string go()
        {

            errors.Clear();
            this.lexems=m_lexicalAnalizator.parse(Programm);
            if (m_lexicalAnalizator.errors.Count != 0)
            {
                return null;
            }
            string result = new Programm(this).go();
            
            return result;
            
        }
        public string parse(string text)
        {
            this.Programm = text;
            
            return go();
        }

    }
}
