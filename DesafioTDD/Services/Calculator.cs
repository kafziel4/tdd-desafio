namespace DesafioTDD.Services
{
    public class Calculator
    {
        private const int MaxHistoryEntries = 3;

        private readonly List<string> _history;

        public Calculator(string date)
        {
            _history = new();
        }

        public int Sum(int value1, int value2)
        {
            int result = value1 + value2;
            AddHistory(result);
            return result;
        }

        public int Subtract(int value1, int value2)
        {
            int result = value1 - value2;
            AddHistory(result);
            return result;
        }

        public int Multiply(int value1, int value2)
        {
            int result = value1 * value2;
            AddHistory(result);
            return result;
        }

        public int Divide(int value1, int value2)
        {
            int result = value1 / value2;
            AddHistory(result);
            return result;
        }

        public List<string> GetHistory()
        {
            return _history;
        }

        private void AddHistory(int result)
        {
            if (_history.Count >= MaxHistoryEntries)
            {
                int index = MaxHistoryEntries - 1;
                _history.RemoveRange(index, _history.Count - index);
            }

            _history.Insert(0, $"Result: {result}");
        }
    }
}
