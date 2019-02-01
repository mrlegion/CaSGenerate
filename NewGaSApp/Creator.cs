using System.Text;

namespace NewGaSApp
{
    public interface ICreator
    {
        string Generate(int cols, int rows, int groups, bool isOneSide);
    }

    public class Creator : ICreator
    {
        private int[] _odd;
        private int[] _even;
        
        private void FillArrays(int groups)
        {
            int index = 0;
            for (int i = 1; i <= groups; i++)
                if (i % 2 != 0) _odd[index] = i;
                else if (i % 2 == 0) _even[index] = i;
        }

        private string OneSideArray(int groups)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= groups; ++i)
                sb.Append($"{i} ");
            return sb.ToString().TrimEnd(' ');
        }

        public string Generate(int cols, int rows, int groups, bool isOneSide)
        {
            if (isOneSide) return OneSideArray(groups);

            int g = groups / 2;
            _odd = new int[g];
            _even = new int[g];
            FillArrays(g);

            return "";
        }
    }
}