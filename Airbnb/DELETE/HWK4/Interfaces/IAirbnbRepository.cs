using HWK4.Models;

namespace HWK4.Interfaces
{
    /// <summary>
    /// This interface has the declarations for the methods used.
    /// </summary>
    public interface IAirbnbRepository
    {
        ICollection<Airbnb> GetItems();

        Airbnb GetItem(int id);

        Airbnb EditItem(int id);

        bool AddItem(Airbnb item);

        bool BillExists(int id);
        

        int getMean();

        int getMax();
        bool Save();
    }
}
