using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using isGited;

namespace isGited {
    class map<X, Y>
        where X : class
        where Y : class {

        Item<X, Y>[] Items = new Item<X, Y>[13];

        private int freeplace = 0;

        public bool Add(X key, Y value) {
            // checking key
            if (freeplace < Items.Length) {
                if (!CheckKey(key)) {
                    Item<X, Y> it = new Item<X, Y>();
                    it.Key = key;
                    it.Value = value;
                    Items[freeplace] = it;
                    freeplace++;
                    return true;
                }
            }
            return false;
        }

        public Item<X, Y> Get(X value) {
            for (int i = 0; i < freeplace; i++) {
                if (Items[i].Key == value) {
                    return Items[i];
                }
            }
            return null;
        }

        public Item<X, Y> GetByIndex(int index) {
            if (freeplace > 0) {
                try {
                    if (index >= 0 && index < freeplace) {
                        return Items[index];
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }

        private bool CheckKey(X key) {
            if (freeplace > 0) {
                for (int i = 0; i < freeplace; i++) {
                    if (Items[i].Key == key) {
                        //Console.WriteLine(Items[i].Key);
                        return true;
                    }
                }
            }
            return false;
        }
    }

    class Item<S, T> {

        public S Key { get; set; }
        public T Value { get; set; }
    }


}