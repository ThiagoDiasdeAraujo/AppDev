using WebApp.Data;

namespace WebApp.Repositories
{
    public class ReservatieRepository
    {
        private static List<Reservatie> _reservaties = new List<Reservatie>();

        //methode voor het toevoegen van nieuwe reservaties. Deze methode stelt tevens de waarde van het ID-attribuut in op de waarde van het grootste ID in de lijst, verhoogd met1. Indien er nog geen reservaties in de lijst zitten, stel je de waarde van het ID in op 1.
        public static int Add(Reservatie reservatie)
        {
            int id = _reservaties.Count() > 0 ? _reservaties.Max(x => x.ReservatieID) + 1 : 1;
            reservatie.ReservatieID = id;

            _reservaties.Add(reservatie);

            return id;
        }

        public static IEnumerable<Reservatie> GetAll()
        {
            return _reservaties.ToList();
        }

        public static Reservatie GetById(int id)
        {
            return _reservaties.Find(x => x.ReservatieID == id);
        }

        public static void Update(Reservatie reservatie)
        {
            Reservatie existing = _reservaties.Find(x => x.ReservatieID == reservatie.ReservatieID);
            _reservaties.Remove(existing);
            _reservaties.Add(reservatie);
        }

        public static bool Delete(Reservatie reservatie)
        {
            return _reservaties.Remove(reservatie);
        }
    }
}
