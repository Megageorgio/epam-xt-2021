using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Megageorgio.DynamicArrayLib
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {
        private T[] _array;
        private int _length;

        public DynamicArray() : this(8)
        {
        }

        public DynamicArray(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity", "Non-negative number required.");
            }

            _array = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> collection) => _array = collection.ToArray();

        public int Capacity
        {
            get => _array.Length;
            set
            {
                Array.Resize(ref _array, value);
                if (_array.Length < Length)
                {
                    Length = _array.Length;
                }
            }
        }

        public int Length
        {
            get => _length;
            private set
            {
                _length = value;
                if (_length > Capacity)
                {
                    var newCapacity = Capacity;

                    while (newCapacity < _length)
                    {
                        newCapacity *= 2;
                    }

                    Capacity = newCapacity;
                }
            }
        }

        public T this[int index]
        {
            get => GetArrayElement(index);
            set => GetArrayElement(index) = value;
        }

        public void Add(T item)
        {
            Length++;
            _array[Length - 1] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException("collection");
            }

            var index = Length;
            Length += collection.Count();
            collection.ToArray().CopyTo(_array, index);
        }

        public object Clone() => new DynamicArray<T>(_array);

        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Insert(T item, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            try
            {
                Length++;
                Array.Copy(_array, index, _array, index + 1, Length - index);
                _array[index] = item;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(T item)
        {
            try
            {
                int index = Array.IndexOf(_array, item, 0, Length);
                if (index == -1)
                {
                    return false;
                }

                Length--;
                Array.Copy(_array, index + 1, _array, index, Length - index);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T[] ToArray()
        {
            return _array.Take(Length).ToArray();
        }

        private ref T GetArrayElement(int index)
        {
            if ((index < -Length) || (index >= Length))
            {
                throw new ArgumentOutOfRangeException();
            }

            return ref _array[index + (index < 0 ? Length : 0)];
        }
    }
}