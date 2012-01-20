using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;

namespace MetaLLexems
{
    public class UnOper<T>:RegexLexema<UnOper<T>>where T:UnOper<T>, new()
    {
        protected override Lexema factory(string data)
        {
            if (data == null) return null;
            UnOper<T> lexema = new T();
            lexema.Data = data;
            return (Lexema)lexema;
        }
    }
}
