using BestelService.Domain.Events;
using BestelService.Domain.Exceptions;
using Common;
using System;

namespace BestelService.Domain
{
    public class Bestelling : AggregateRoot
    {
        public static Bestelling Plaats(Guid klantId, Orderregel[] orderregels)
        {
            if (orderregels.Length == 0) throw new LegeBestellingException();

            var id = Guid.NewGuid();

            var bestelling = new Bestelling();
            bestelling.ApplyChange(new BestellingGeplaatst(id, klantId, orderregels));

            return bestelling;
        }

        private Bestelling()
        {
        }
    }
}
