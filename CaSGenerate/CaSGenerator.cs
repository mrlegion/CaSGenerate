using System;

namespace CaSGenerate
{
    class CaSGenerator
    {
        /// <summary>
        /// Количество колонок
        /// </summary>
        public int Column { get; set; }
        /// <summary>
        /// Количество строк
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// Общее количество групп
        /// </summary>
        public int Group { get; set; }
        /// <summary>
        /// Проверка на одностороннюю печать
        /// </summary>
        public bool OneSideCheck { get; set; }

        /// <summary>
        /// Массив нечетных чисел
        /// </summary>
        private int[] _odd;
        /// <summary>
        /// Массив четных чисел
        /// </summary>
        private int[] _even;

        /// <summary>
        /// Установка количества групп
        /// </summary>
        private void SetGroup() => Group = Column * Row;

        /// <summary>
        /// Заполнение массивов _odd и _even
        /// </summary>
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

        /// <summary>
        /// Заполнение массива при одностороннем просчете
        /// </summary>
        private void FillOneSideArray()
        {
            _odd = new int[Group];
            for (int i = 0; i < Group; i++)
                _odd[i] = i + 1;
        }

        /// <summary>
        /// Настройки массива _even
        /// </summary>
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

        /// <summary>
        /// Перевод массива в строку подходящего вида
        /// </summary>
        /// <param name="array">Массив, который следует перевести в строку</param>
        /// <returns>Строка из значений массива</returns>
        private string ArrayToString(int[] array)
        {
            string s = "";
            foreach (int i in array) s += $"{i} ";
            return s;
        }

        /// <summary>
        /// Запуск прочета групп и основной логики класса
        /// </summary>
        /// <returns>Строку вычисленного значения</returns>
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
