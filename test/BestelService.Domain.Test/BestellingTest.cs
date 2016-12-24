using BestelService.Domain.Events;
using BestelService.Domain.Exceptions;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BestelService.Domain.Test
{
    [TestClass]
    public class BestellingTest
    {
        [TestMethod]
        public void BestellingKanGeplaatstWorden()
        {
            // Arrange
            Guid klantId = Guid.Parse("e69a3385-3916-4f24-9520-71068cc9f0c5");
            Orderregel[] artikelen = {
                new Orderregel(artikelNummer: 12345, aantal: 2),
                new Orderregel(artikelNummer: 67890, aantal: 1),
            };

            // Act
            Bestelling bestelling = Bestelling.Plaats(klantId, artikelen);

            // Assert
            IEnumerable<DomainEvent> changes = bestelling.GetUncommittedChanges();
            Assert.AreEqual(1, changes.Count());
            Assert.IsInstanceOfType(changes.First(), typeof(BestellingGeplaatst));
        }

        [TestMethod]
        public void BestellingMoetArtikelenHebben()
        {
            // Arrange
            Guid klantId = Guid.Parse("e69a3385-3916-4f24-9520-71068cc9f0c5");
            Orderregel[] orderregels = { }; // Geen artikelen

            // Act
            Action action = () => Bestelling.Plaats(klantId, orderregels);

            // Assert
            Assert.ThrowsException<LegeBestellingException>(action);
        }
    }
}
