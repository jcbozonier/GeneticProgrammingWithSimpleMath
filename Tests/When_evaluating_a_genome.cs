using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvolvingPythagoreansTheorem.GenomeEvaluation;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class When_evaluating_a_pythagorean_formula
    {
        string AGenome;
        IEvaluatable Ast;
        GenomeConverter Converter;
        double Result;

        [Test]
        public void Should_compute_correct_result()
        {
            Assert.That(Result, Is.EqualTo(5));
        }

        [SetUp]
        public void Context()
        {
            AGenome = "r+**xxyy";
            Converter = new GenomeConverter();
            Ast = Converter.Convert(AGenome);

            Because();
        }

        void Because()
        {
            Result = Ast.Evaluate(new Dictionary<string, double> { { "x", 3.0 }, { "y", 4.0 } });
        }
    }

    [TestFixture]
    public class When_evaluating_a_sqrt_x_genome
    {
        string AGenome;
        IEvaluatable Ast;
        GenomeConverter Converter;
        double Result;

        [Test]
        public void Should_compute_correct_result()
        {
            Assert.That(Result, Is.EqualTo(9));
        }

        [SetUp]
        public void Context()
        {
            AGenome = "rx";
            Converter = new GenomeConverter();
            Ast = Converter.Convert(AGenome);

            Because();
        }

        void Because()
        {
            Result = Ast.Evaluate(new Dictionary<string, double> { { "x", 81.0 } });
        }
    }

    [TestFixture]
    public class When_evaluating_a_divide_x_y_genome
    {
        string AGenome;
        IEvaluatable Ast;
        GenomeConverter Converter;
        double Result;

        [Test]
        public void Should_compute_correct_result()
        {
            Assert.That(Result, Is.EqualTo(.5));
        }

        [SetUp]
        public void Context()
        {
            AGenome = "/xy";
            Converter = new GenomeConverter();
            Ast = Converter.Convert(AGenome);

            Because();
        }

        void Because()
        {
            Result = Ast.Evaluate(new Dictionary<string, double> { { "x", 2.0 }, { "y", 4.0 } });
        }
    }

    [TestFixture]
    public class When_evaluating_a_multiply_x_y_genome
    {
        string AGenome;
        IEvaluatable Ast;
        GenomeConverter Converter;
        double Result;

        [Test]
        public void Should_compute_correct_result()
        {
            Assert.That(Result, Is.EqualTo(6.0));
        }

        [SetUp]
        public void Context()
        {
            AGenome = "*xy";
            Converter = new GenomeConverter();
            Ast = Converter.Convert(AGenome);

            Because();
        }

        void Because()
        {
            Result = Ast.Evaluate(new Dictionary<string, double> { { "x", 2.0 }, { "y", 3.0 } });
        }
    }

    [TestFixture]
    public class When_evaluating_a_minus_x_y_genome
    {
        string AGenome;
        IEvaluatable Ast;
        GenomeConverter Converter;
        double Result;

        [Test]
        public void Should_compute_correct_result()
        {
            Assert.That(Result, Is.EqualTo(-1.0));
        }

        [SetUp]
        public void Context()
        {
            AGenome = "-xy";
            Converter = new GenomeConverter();
            Ast = Converter.Convert(AGenome);

            Because();
        }

        void Because()
        {
            Result = Ast.Evaluate(new Dictionary<string, double> { { "x", 2.0 }, { "y", 3.0 } });
        }
    }

    [TestFixture]
    public class When_evaluating_a_plus_x_y_genome
    {
        string AGenome;
        IEvaluatable Ast;
        GenomeConverter Converter;
        double Result;

        [Test]
        public void Should_compute_correct_result()
        {
            Assert.That(Result, Is.EqualTo(5.0));
        }

        [SetUp]
        public void Context()
        {
            AGenome = "+xy";
            Converter = new GenomeConverter();
            Ast = Converter.Convert(AGenome);

            Because();
        }

        void Because()
        {
            Result = Ast.Evaluate(new Dictionary<string, double> { { "x", 2.0 }, { "y", 3.0 } });
        }
    }
}
