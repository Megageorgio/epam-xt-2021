using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Megageorgio.DynamicArrayLib;

namespace DynamicArrayLib
{
    public class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray() : base()
        {
        }

        public CycledDynamicArray(int capacity) : base(capacity)
        {
        }

        public CycledDynamicArray(IEnumerable<T> collection) : base(collection)
        {
        }

        public override IEnumerator<T> GetEnumerator()
        {
            var i = 0;
            while (true)
            {
                yield return this[i];

                if (++i == Length)
                {
                    i = 0;
                }
            }
        }
    }
}