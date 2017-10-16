using System;

namespace CaSGenerate
{
    class CaSGenerator
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public int Group { get; set; }

        private int[] _odd;
        private int[] _even;

        private void SetGroup() => Group = Column * Row;

        private void FillOddEvenArrays()
        {
            SetGroup();

            _odd = new int[Group];
            _even = new int[Group];
            int index = 0;

            for (int i = 1; i <= Group * 2; i++)
            {
                if (i % 2 != 0) _odd[index] = i;
                else if (i % 2 == 0) _even[index++] = i;
            }
        }

        private void EventReversArray()
        {
            int[] temp = new int[Column];
            for (int i = 0; i < Row; i++)
            {
                Array.ConstrainedCopy(_even, i * Column, temp, 0, Column);
                Array.Reverse(temp);
                Array.ConstrainedCopy(temp, 0, _even, i * Column, Column);
            }
        }

        private string ArrayToString(int[] array)
        {
            string s = "";
            foreach (int i in array) s += $"{i} ";
            return s;
        }

        public string GetGenerateNumber()
        {
            FillOddEvenArrays();
            EventReversArray();
            return ArrayToString(_odd) + ArrayToString(_even);
        }

    }
}
