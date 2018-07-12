using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Calculator;

namespace UnitTestProject1
{
    [TestClass]
    public class RekenmachineTest
    {
        [TestMethod]
        public void OptellenTest()
        {
            // Hier gaan we testen of 2+2 ook echt 4 is
            var machine = new Rekenmachine();

            int antwoord = machine.Optellen(2, 2);

            Assert.AreEqual(4, antwoord);
        }

        [TestMethod]
        public void OptellenTest2()
        {
            // Hier gaan we testen of 2+2 ook echt 4 is
            var machine = new Rekenmachine();
            Assert.AreEqual(5, machine.Optellen(1, 4));
        }

        [TestMethod]
        public void AftrekkenTest()
        {
            var machine = new Rekenmachine();
            Assert.AreEqual(10, machine.Aftrekken(80, 70));
        }

        [TestMethod]
        public void VermenigvuldigenTest()
        {
            var machine = new Rekenmachine();
            Assert.AreEqual(56, machine.Vermenigvuldigen(8, 7));
        }

        [TestMethod]
        public void DelenTest()
        {
            var machine = new Rekenmachine();
            Assert.AreEqual(50, machine.Delen(200, 4));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DelenTest2()
        {
            var machine = new Rekenmachine();
            machine.Delen(200, 0);
            // Het slagen of falen van de test wordt afgevangen
            // door het attribuut ExpectedException
        }

        [TestMethod]
        public void KwadraatAsyncTest()
        {
            var machine = new Rekenmachine();
            // De async call moet worden getest op 
            // synchrone manier door de Result op te vragen
            // Het opvragen van Result is een blocking call!
            int antwoord = machine.KwadraatAsync(4).Result;
            Assert.AreEqual(16, antwoord);
        }


        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void VermenigvuldigenTest2()
        {
            var r = new Rekenmachine();

            Assert.AreEqual(80000000000, r.Vermenigvuldigen(100000, 800000));
        }


        [ExpectedException(typeof(OverflowException))]
        [TestMethod]
        public void OptellenTest3()
        {
            var r = new Rekenmachine();

            int a = int.MaxValue;
            int b = r.Optellen(a, 1);
        }

    }
}
