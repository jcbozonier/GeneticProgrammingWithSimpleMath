using System;
using System.Collections.Generic;
using EvolvingPythagoreansTheorem.GenomeEvaluation;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DirectGenomeEvaluator_Tests5
    {
        DirectGenomeEvaluator Evaluator;
        Dictionary<string, double> Parameters;
        double Result;

        [Test]
        public void It_should_return_the_right_answer()
        {
            Assert.That(Result, Is.EqualTo(double.NaN));
        }

        [SetUp]
        public void Context()
        {
            Evaluator = new DirectGenomeEvaluator("--b");
            Parameters = new Dictionary<string, double>
                         {
                                 {"a", 2.0},
                                 {"b", 3.0}
                         };
            Because();
        }

        void Because()
        {
            Result = Evaluator.Evaluate(Parameters);
        }
    }

    [TestFixture]
    public class DirectGenomeEvaluator_Tests4
    {
        DirectGenomeEvaluator Evaluator;
        Dictionary<string, double> Parameters;
        double Result;

        [Test]
        public void It_should_return_the_right_answer()
        {
            Assert.That(Result, Is.EqualTo(15));
        }

        [SetUp]
        public void Context()
        {
            Evaluator = new DirectGenomeEvaluator("+*b*aba*ab");
            Parameters = new Dictionary<string, double>
                         {
                                 {"a", 2.0},
                                 {"b", 3.0}
                         };
            Because();
        }

        void Because()
        {
            Result = Evaluator.Evaluate(Parameters);
        }
    }

    [TestFixture]
    public class DirectGenomeEvaluator_Tests3
    {
        DirectGenomeEvaluator Evaluator;
        Dictionary<string, double> Parameters;
        double Result;

        [Test]
        public void It_should_return_the_right_answer()
        {
            Assert.That(Result, Is.EqualTo(15));
        }

        [SetUp]
        public void Context()
        {
            Evaluator = new DirectGenomeEvaluator("+*b*aba");
            Parameters = new Dictionary<string, double>
                         {
                                 {"a", 2.0},
                                 {"b", 3.0}
                         };
            Because();
        }

        void Because()
        {
            Result = Evaluator.Evaluate(Parameters);
        }
    }

    [TestFixture]
    public class DirectGenomeEvaluator_Tests2
    {
        DirectGenomeEvaluator Evaluator;
        Dictionary<string, double> Parameters;
        double Result;

        [Test]
        public void It_should_return_the_right_answer()
        {
            Assert.That(Result, Is.EqualTo(Math.Sqrt(2.0)));
        }

        [SetUp]
        public void Context()
        {
            Evaluator = new DirectGenomeEvaluator("r+**aabb");
            Parameters = new Dictionary<string, double>
                         {
                                 {"a", 1.0},
                                 {"b", 1.0}
                         };
            Because();
        }

        void Because()
        {
            Result = Evaluator.Evaluate(Parameters);
        }
    }

    [TestFixture]
    public class DirectGenomeEvaluator_Tests
    {
        DirectGenomeEvaluator Evaluator;
        Dictionary<string, double> Parameters;
        double Result;

        [Test]
        public void It_should_return_the_right_answer()
        {
            Assert.That(Result, Is.EqualTo(5));
        }

        [SetUp]
        public void Context()
        {
            Evaluator = new DirectGenomeEvaluator("r+**aabb");
            Parameters = new Dictionary<string, double>
                         {
                                 {"a", 3.0},
                                 {"b", 4.0}
                         };
            Because();
        }

        void Because()
        {
            Result = Evaluator.Evaluate(Parameters);
        }
    }
}
