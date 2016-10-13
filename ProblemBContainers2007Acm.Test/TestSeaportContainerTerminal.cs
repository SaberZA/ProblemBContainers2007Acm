using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProblemBContainers2007Acm.Test
{
    [TestFixture]
    public class TestSeaportContainerTerminal
    {
        private Terminal _terminal;

        [SetUp]
        public void Setup()
        {
            _terminal = CreateTerminal();
        }

        [Test]
        public void Construct_GivenTerminal_ShouldReturnTerminal()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            
            //---------------Test Result -----------------------
            Assert.IsNotNull(_terminal);
        }

        [Test]
        public void Construct_GivenTerminal_ShouldReturnEmptyEntities()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(0, _terminal.Containers);
            Assert.AreEqual(0, _terminal.Ships);
            Assert.AreEqual(0, _terminal.Stacks);
        }
        
        [Test]
        public void LoadContainers_GivenZeroContainers_ShouldReturnZeroStacks()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            _terminal.LoadContainers("");
            //---------------Test Result -----------------------
            Assert.AreEqual(0, _terminal.Stacks);
        }

        [Test]
        public void ReceiveContainers_GivenZeroContainers_ShouldReturnZeroContainers()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            _terminal.ReceiveContainers("");
            //---------------Test Result -----------------------
            Assert.AreEqual(0, _terminal.Containers);
        }

        [Test]
        public void ReceiveContainers_GivenOneContainerA_ShouldReturnOneContainer()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            _terminal.ReceiveContainers("A");
            //---------------Test Result -----------------------
            Assert.AreEqual(1, _terminal.Containers);
        }
        
        [Test]
        public void ReceiveContainers_GivenTwoContainers_ShouldReturnTwoContainers()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            _terminal.ReceiveContainers("AB");
            //---------------Test Result -----------------------
            Assert.AreEqual(2, _terminal.Containers);
        }

        [Test]
        public void ReceiveContainers_GivenThreeSameContainers_ShouldReturnThreeContainers()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            _terminal.ReceiveContainers("AAA");
            //---------------Test Result -----------------------
            Assert.AreEqual(3, _terminal.Containers);
        }

        [Test]
        public void ReceiveContainers_GivenOneContainer_ShouldReturnOneShipToBeLoaded()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            _terminal.ReceiveContainers("A");
            //---------------Test Result -----------------------
            Assert.AreEqual(1, _terminal.Ships);
        }

        [Test]
        public void ReceiveContainers_GivenTwoDifferentContainers_ShouldReturnTwoShipsToBeLoaded()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            _terminal.ReceiveContainers("AB");
            //---------------Test Result -----------------------
            Assert.AreEqual(2, _terminal.Ships);
        }

        [Test]
        public void ReceiveContainers_GivenTwoSameContainers_ShouldReturnOneShipToBeLoaded()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            _terminal.ReceiveContainers("AA");
            //---------------Test Result -----------------------
            Assert.AreEqual(1, _terminal.Ships);
        }

        [Test]
        public void ReceiveContainers_GivenFiveContainersThreeSameWithTwoDifferent_ShouldReturnThreeShipsToBeLoaded()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            _terminal.ReceiveContainers("BBBCA");
            //---------------Test Result -----------------------
            Assert.AreEqual(3, _terminal.Ships);
        }

        [Test]
        public void MaximumStacks_GivenSixContainersAllSame_ShouldReturnOneContainerToBeLoaded()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            _terminal.ReceiveContainers("AAAAAA");
            //---------------Test Result -----------------------
            Assert.AreEqual(1, _terminal.MaximumStacks);
        }

        [Test]
        public void ReceiveContainers_GivenNumberedContainer_ShouldThrowNumberNotAcceptedException()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var exception = Assert.Throws<NumberNotAcceptedException>(() => _terminal.ReceiveContainers("1"));
            //---------------Test Result -----------------------
            Assert.AreEqual(exception.Message, NumberNotAcceptedException.DisplayMessage);
        }

        [Test]
        public void ReceiveContainers_GivenSpecialCharacterContainer_ShouldThrowSpecialCharacterNotAcceptedException()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var exception = Assert.Throws<SpecialCharacterNotAcceptedException>(() => _terminal.ReceiveContainers("$"));
            //---------------Test Result -----------------------
            Assert.AreEqual(exception.Message, SpecialCharacterNotAcceptedException.DisplayMessage);
        }
		[TestCase("A", 1)]
		[TestCase("AA", 1)]
		[TestCase("AB", 2)]
		[TestCase("ABC", 3)]
		[TestCase("ACB", 2)]
		[TestCase("ACBA", 2)]
		[TestCase("CBACBACBACBACBA", 3)]
		[TestCase("ACMICPC", 4)]
		[TestCase("CCCCBBBBAAAA", 1)]
		public void ReceiveContainers_GivenContainers_ShouldReturnExpectedStacks(string containers, int expectedStacks)
		{
			//---------------Set up test pack-------------------

			//---------------Assert Precondition----------------

			//---------------Execute Test ----------------------
			_terminal.ReceiveContainers(containers);
			//---------------Test Result -----------------------
			Assert.AreEqual(expectedStacks, _terminal.Stacks);
		}

		private Terminal CreateTerminal()
        {
            var terminal = new Terminal();
            return terminal;
        }

    }
}
