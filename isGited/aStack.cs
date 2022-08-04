using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using isGited;

namespace isGited {
    class aStack
    {
        public bool makeBigger;
        public aStack(bool _makeBigger)
        {
            makeBigger = _makeBigger;
        }

        aArray<string> aAr = new aArray<string>();

        static string[] stack = new string[5];
        static int top = 0;

        public void push(string Wert)
        {
            if (top >= stack.Length)
            {
                if(makeBigger == true)
                { 
                    stack = aAr.IncreaseSize(stack, 10);
                    stack[top] = Wert;
                    top++;
                    return ;
                }

                throw new Exception("Stack ist voll");
            }
            stack[top] = Wert;
            top++;
            
        }

        public string pop()
        {
            if (top <= 0) {
                throw new Exception("Stack ist leer");
                //return "leer";
            }
            else {
                top = top - 1;
            }
            return stack[top];
        }
    }
}
