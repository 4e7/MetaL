using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;

namespace MetaLLexems
{
    public class BinOper<T>:RegexLexema<BinOper<T>>where T:BinOper<T>, new()
    {
        protected override Lexema factory(string data)
        {
            if (data == null) return null;
            BinOper<T> lexema = new T();
            lexema.Data = data;
            return (Lexema)lexema;
        }
    }
}
