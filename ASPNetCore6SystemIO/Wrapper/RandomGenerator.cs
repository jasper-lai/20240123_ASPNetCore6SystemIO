namespace ASPNetCore6SystemIO.Wrapper
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random _random = new();

        public int Next() => _random.Next();
        public int Next(int maxValue) => _random.Next(maxValue);
        public int Next(int minValue, int maxValue) => _random.Next(minValue, maxValue);
        public double NextDouble() => _random.NextDouble();
    }
}
