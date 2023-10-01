namespace DesafioTDD.Services
{
    public class Calculator
    {
        public int Sum(int value1, int value2)
        {
            int result = value1 + value2;
            return result;
        }

        public int Subtract(int value1, int value2)
        {
            int result = value1 - value2;
            return result;
        }

        public int Multiply(int value1, int value2)
        {
            return -1;
        }

        public int Divide(int value1, int value2)
        {
            return -1;
        }

        public List<string> GetHistory()
        {
            return null!;
        }
    }
}
