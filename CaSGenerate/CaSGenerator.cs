using System;

namespace CaSGenerate
{
    class CaSGenerator
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public int Group { get; set; }
        public bool OneSideCheck { get; set; }

        private int[] _odd;
        private int[] _even;

        private void SetGroup() => Group = Column * Row;

        private void FillOddEvenArrays()
        {
            _odd = new int[Group];
            _even = new int[Group];
            int index = 0;

            for (int i = 1; i <= Group * 2; i++)
            {
                if (i % 2 != 0) _odd[index] = i;
                else if (i % 2 == 0) _even[index++] = i;
            }
        }

        private void FillOneSideArray()
        {
            _odd = new int[Group];
            for (int i = 0; i < Group; i++)
                _odd[i] = i + 1;
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
            SetGroup();
            string s;
            if (OneSideCheck)
            {
                FillOneSideArray();
                s = ArrayToString(_odd);
            }
            else
            {
                FillOddEvenArrays();
                EventReversArray();
                s = ArrayToString(_odd) + ArrayToString(_even);
            }
            return s;
        }

    }
}
