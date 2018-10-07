using System;
using Xunit;

namespace DbDataReaderExtension.Test
{
    public class SumTest
    {
        [Fact]
        public void ThreeMoreFourEqualSeven()
        {
            Assert.Equal(7, new Sum(3, 4).Result);
        }
    }
}
