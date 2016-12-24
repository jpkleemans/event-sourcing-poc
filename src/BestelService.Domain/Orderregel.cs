using BestelService.Domain.Exceptions;

namespace BestelService.Domain
{
    // Value Object
    public class Orderregel
    {
        public long ArtikelNummer { get; private set; }
        public int Aantal { get; private set; }

        public Orderregel(long artikelNummer, int aantal)
        {
            if (aantal <= 0) throw new OngeldigAantalException();

            ArtikelNummer = artikelNummer;
            Aantal = aantal;
        }
    }
}
