using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;
namespace MetaLLexems
{
    public class KeyWord<T>:RegexLexema<KeyWord<T>> where T:KeyWord<T>, new()
    {
        protected override Lexema factory(string data)
        {
            if (data == null) return null;
            KeyWord<T> lexema = new T();
            lexema.Data = data;
            return (Lexema)lexema;
        }
    }
}