using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using isGited;

namespace isGited {
    class queue {
        public bool makeBigger;
        public queue(bool _makeBigger) {
            makeBigger = _makeBigger;
        }

        aArray<string> aAr = new aArray<string>();

        static string[] array = new string[5];

        static int tail = 0;
        static int head = 0;

        public void Enqueue(string Wert) {
            if (Move(tail, array.Length) == head) {
                if (makeBigger == true) {
                    array = aAr.IncreaseSize(array, 10);
                    array[tail] = Wert;
                    tail = Move(tail, array.Length);
                    return;
                }
                Console.WriteLine("Voll");
                return;
            } else {
                array[tail] = Wert;
                tail = Move(tail, array.Length);
            }
        }

        public string Dequeue() {
            string answer = "";
            if (tail == head) {
                return "leer";
            }
            answer = array[head];
            head = Move(head, array.Length);
            return answer;
        }
        private int Move(int counter, int length) {
            if (counter > length - 1) {
                return 0;
            }
            return ++counter;
        }
    }
}