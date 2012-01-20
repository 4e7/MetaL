using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;
using MetaLLexems;
namespace consoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LexicalAnalizator lm= new LexicalAnalizator();

            lm.registerLexem(new UnOperNot());
            lm.registerLexem(new BinOperAnd());
            lm.registerLexem(new BinOperOr());
            lm.registerLexem(new BinOperXor());
            lm.registerLexem(new Const());
            lm.registerLexem(new To());
            lm.registerLexem(new For());
            lm.registerLexem(new End());
            lm.registerLexem(new Begin());
            lm.registerLexem(new Var());
            lm.registerLexem(new Identifire());
            lm.registerLexem(new BinOperEqual());
            Console.WriteLine("Введите всякий хлам :");
            string s =Console.ReadLine();
            List<Lexema> lexems = lm.parse(s);
            if (lexems == null)
            {
                return;
            }
            Console.WriteLine("Хлам в строке :");
            foreach (Lexema l in lexems)
            {
                Console.WriteLine("\t"+l.Data+" Тип :"+l.GetType().Name);
            }
        }
    }
}
