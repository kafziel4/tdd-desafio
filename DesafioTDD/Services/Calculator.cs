namespace DesafioTDD.Services
{
    public class Calculator
    {
        private readonly List<string> _history;

        public Calculator()
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
            if (_history.Count >= 3)
                _history.RemoveRange(2, _history.Count - 2);

            _history.Insert(0, $"Result: {result}");
        }
    }
}
