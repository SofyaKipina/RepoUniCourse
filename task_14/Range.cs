using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeStruct
{
    public struct Range
    {
        const int MaxValue = int.MaxValue;

        public int Value { get; set; }

        int leftRange;
        public int LeftRange
        {
            get => leftRange;
            set
            {
                if (value > MaxValue)
                    throw new ArgumentException("Значение должно быть меньше максимального значения целого числа");
                leftRange = value;
            }
        }

        int rightRange;
        public int RightRange
        {
            get => rightRange;
            set
            {
                if ((value > MaxValue && value > leftRange))
                    throw new ArgumentException("Значение должно быть меньше максимального значения целого числа и больше левой границы");
                rightRange = value;
            }
        }


        public Range(int leftRange, int rightRange) : this()
        {
            LeftRange = leftRange;
            RightRange = rightRange;
        }

        public int Count
        {
            get => Math.Abs(RightRange - LeftRange);
        }

        public bool IsContains(int number)
        {
            if (number >= leftRange && number < rightRange)
                return true;
            else return false;
        }

        public override string ToString() => $"[{LeftRange};{RightRange})";


        public override bool Equals(object obj)
        {
            if (obj is Range)
                return Count == ((Range)obj).Count;
            throw new ArgumentException("Объект для сравнения не является диапазоном");
        }

        public override int GetHashCode() => Count.GetHashCode();

        public static Range operator &(Range x, Range y)
        {
            int newLeft = Math.Max(x.LeftRange, y.LeftRange);
            int newRight = Math.Min(x.RightRange, y.RightRange);

            Range z = new Range(newLeft, newRight);

            if (z.leftRange >= z.rightRange)
                throw new ArgumentException("У диапазонов нет пересечения");
            else
                return z;
        }

        public static Range operator |(Range x, Range y)
        {
            int newLeft = Math.Min(x.LeftRange, y.LeftRange);
            int newRight = Math.Max(x.RightRange, y.RightRange);

            return new Range(newLeft, newRight);
        }
    }
}
