using System;

namespace DbDataReaderExtension
{
    public class Sum
    {
        private readonly int _a;
        private readonly int _b;

        public Sum(int a, int b)
        {
            _a = a;
            _b = b;
        }

        public int Result => _a + _b;
    }
}
