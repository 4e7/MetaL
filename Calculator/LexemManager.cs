using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LexemList = System.Collections.Generic.List<Lexems.Lexema>;
namespace Lexems
{
    using LexemErrors = List<LexemError>;
   public class LexicalAnalizator
    {

       public LexemErrors errors=new LexemErrors();
       public LexicalAnalizator() { m_lexems = new LexemList(); }
       protected LexemList m_lexems;
        

        public void registerLexem(Lexema lexem)
        {
            m_lexems.Add(lexem);
        }

        protected static LexemErrors optimiseErros(LexemErrors errors)
        {
            LexemErrors optimised = new LexemErrors();
            if (errors.Count < 2) return errors;
            int searchIndex = 0;
            int searchOffset=1;
            for (int i = 0; i < errors.Count-1; i++)
            {
                if (errors[searchIndex].position == errors[searchIndex+searchOffset].position + searchOffset)
                {
                    errors[searchIndex].lexem += errors[searchIndex+searchOffset].lexem;
                    searchOffset++;
                    
                }
                else
                {
                    optimised.Add(errors[searchIndex]);
                    searchIndex = i;
                    searchOffset = 1;
                }
               
            }
            return optimised;
        }
       
        protected LexemList recursiveParse(ref string s,int errorOffset)
        {
            LexemList lexems = new LexemList();
            
            int beginLength = s.Length;
            int startPosition = -1;
            
            
            while (s.Length > 0)
            {
                Lexema l = null;
                foreach (Lexema t in m_lexems)
                {
                    l = t.parse(ref s);
                    if (l == null)
                    {
                        continue;
                    }
                    
                    lexems.Add(l);
                    break;
                }
                if (l == null)
                {
                    startPosition = beginLength - s.Length;
                    LexemError error = new LexemError();
                    error.position = startPosition + errorOffset;
                    error.lexem = s[0].ToString();
                    errors.Add(error);
                    s=s.Remove(0, 1);
                    if (lexems.Count > 0)
                    {
                        errorOffset += startPosition;
                    }
                    
                    lexems.AddRange(recursiveParse(ref s, errorOffset+1));
                    break;
                }
            }
            return lexems;
        }
        public LexemList parse(string s) 
        {
            errors.Clear();
            s.Replace('\n',' ');
            LexemList lexems = recursiveParse(ref s, 0);
            return lexems;
        }
    }
}
