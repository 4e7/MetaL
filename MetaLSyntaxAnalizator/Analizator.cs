using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;
using MetaLLexems;
namespace MetaLSyntaxAnalizator
{
    
   
    public class Analizator
    {
        protected LexicalAnalizator m_lexicalAnalizator=new LexicalAnalizator();
        protected List<Lexema> m_lexems=new List<Lexema>();
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
        public List<SyntaxError> errors=new List<SyntaxError>();
        public HashSet<string> ids=new HashSet<string>();
        int m_tokenPosition = 0;
        class FakeLexema : Lexema
        {
            public override Lexema parse(ref string s)
            {
                return null;
            }
        }
        public Lexema getToken()
        {
            
            Lexema l = new FakeLexema();
            if (m_tokenPosition < m_lexems.Count)
            {
                l = m_lexems[m_tokenPosition];
                m_tokenPosition++;
            }
            
            return l;
        }
        public void backToken()
        {
            m_tokenPosition--;
        }
        public int position=0;
        public Analizator()
        {
            m_lexicalAnalizator.registerLexem(new UnOperNot());
            m_lexicalAnalizator.registerLexem(new OpenBracket());
            m_lexicalAnalizator.registerLexem(new CloseBracket());
            m_lexicalAnalizator.registerLexem(new BinOperAnd());
            m_lexicalAnalizator.registerLexem(new BinOperOr());
            m_lexicalAnalizator.registerLexem(new BinOperXor());
            m_lexicalAnalizator.registerLexem(new Const());
           // m_lexicalAnalizator.registerLexem(new To());
            //m_lexicalAnalizator.registerLexem(new For());
            m_lexicalAnalizator.registerLexem(new End());
            m_lexicalAnalizator.registerLexem(new Begin());
            m_lexicalAnalizator.registerLexem(new Var());
            m_lexicalAnalizator.registerLexem(new BinOperEqual());
            m_lexicalAnalizator.registerLexem(new Endl());
            m_lexicalAnalizator.registerLexem(new Comma());
            m_lexicalAnalizator.registerLexem(new MetaLLexems.Identifire());
        }
        public string parse(string text)
        {
            m_tokenPosition = 0;
            position = 0;
            errors.Clear();
            m_lexems.Clear();
            string result = null;
            m_lexems=m_lexicalAnalizator.parse(text);
            result = new Programm(this).go();
            if (m_lexicalAnalizator.errors.Count != 0)
            {
                result = null;
            }
            return result;
        }

    }
}
