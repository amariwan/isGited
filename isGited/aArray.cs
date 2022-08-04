using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isGited {
    class aArray<T>
    {

        public T[] IncreaseSize(T[] array, int amount)
        {
            T[] newarray = new T[array.Length + amount];
            Copy(array, newarray);
            return newarray;
        }
        public void Copy(T[] array, T[] newarray)
        {
            for (int y = 0; y < array.Length; y++)
            {
                newarray[y] = array[y];
            }
            
        }
    }
}
