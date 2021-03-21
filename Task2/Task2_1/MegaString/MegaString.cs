using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Megageorgio.MegaStringLib
{
    public class MegaString : IEnumerable<char>
    {
        private char[] array;
        public static readonly MegaString Empty = "";
        public int Length => array.Length;

        public MegaString(char[] array)
        {
            this.array = new char[array.Length];
            Array.Copy(array, this.array, array.Length);
        }

        public MegaString(string s)
        {
            this.array = s.ToCharArray();
        }

        public char[] ToCharArray() => array;

        public int IndexOf(char value) => Array.FindIndex(array, c => c == value);

        public int LastIndexOf(char value) => Array.FindLastIndex(array, c => c == value);

        public MegaString Capitalize()
        {
            var result = MegaString.Empty;
            result.array = new char[Length];
            var nextUpper = true;

            for (int i = 0; i < array.Length; i++)
            {
                if (nextUpper && char.IsLetter(array[i]))
                {
                    result.array[i] = char.ToUpper(array[i]);
                    nextUpper = false;
                }
                else
                {
                    result.array[i] = char.ToLower(array[i]);
                }

                if (array[i] == '.' || array[i] == '?' || array[i] == '!')
                {
                    nextUpper = true;
                }
            }

            return result;
        }

        public MegaString RemoveDoubles()
        {
            var result = MegaString.Empty;
            result.array = new char[this.Length];
            var i = 0;
            var last = (char) 0;

            foreach (var c in array)
            {
                if (c != last)
                {
                    last = result.array[i] = c;
                    i++;
                }
            }

            Array.Resize(ref result.array, i);
            return result;
        }

        public char this[int i]
        {
            get => array[i];
            set => array[i] = value;
        }

        public static MegaString operator +(MegaString a, MegaString b)
        {
            var result = new char[a.Length + b.Length];
            a.array.CopyTo(result, 0);
            b.array.CopyTo(result, a.Length);
            return new MegaString(result);
        }

        public static implicit operator MegaString(string s) => new MegaString(s);

        public static implicit operator string(MegaString s) => s.ToString();

        public static bool operator ==(MegaString a, object b) => a.Equals(b);
        public static bool operator !=(MegaString a, object b) => !a.Equals(b);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var array = (obj as MegaString)?.array ?? (obj as string)?.ToCharArray();
            return this.array.SequenceEqual(array);
        }

        public override int GetHashCode() => HashCode.Combine(array);

        public override string ToString() => string.Concat(array);

        public IEnumerator<char> GetEnumerator()
        {
            foreach (var c in array) yield return c;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}