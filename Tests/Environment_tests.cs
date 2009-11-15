using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Environment_tests
    {
        GenePool TheEnvironment;

        [SetUp]
        public void Context()
        {
            TheEnvironment = new GenePool(100);

        }
    }

    public class GenePool
    {
        public GenePool(int populationCount)
        {
            throw new NotImplementedException();
        }
    }
}
