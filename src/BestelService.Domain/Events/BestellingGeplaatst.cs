using Common;
using System;

namespace BestelService.Domain.Events
{
    public class BestellingGeplaatst : DomainEvent
    {
        public Guid BestellingId { get; private set; }
        public Guid KlantId { get; private set; }
        public Orderregel[] Orderregels { get; private set; }

        public BestellingGeplaatst(Guid bestellingId, Guid klantId, Orderregel[] orderregels)
        {
            BestellingId = bestellingId;
            KlantId = klantId;
            Orderregels = orderregels;
        }
    }
}
