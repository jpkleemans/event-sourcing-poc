using BestelService.Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BestelService.Domain.Test
{
    [TestClass]
    public class OrderregelTest
    {
        [TestMethod]
        public void AantalMagNietNulZijn()
        {
            // Arrange
            long artikelNummer = 12345;
            int aantal = 0;

            // Act
            Action action = () => new Orderregel(artikelNummer, aantal);

            // Assert
            Assert.ThrowsException<OngeldigAantalException>(action);
        }
    }
}
