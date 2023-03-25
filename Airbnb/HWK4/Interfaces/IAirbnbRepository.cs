using Airbnb.Models;

namespace Airbnb.Interfaces
{
    using Airbnb.Models;
    using Airbnb_review.Models;
    /// <summary>
    /// The interface provides the declarations for the methods used
    /// </summary>
    public interface IAirbnbRepository
    {
        ICollection<Airbnb> GetItems();

        Airbnb GetItem(int id);

        bool CreateItem(Airbnb bill);

        bool BillExists(int id);

        bool editItem(Airbnb bill);
        bool deleteItem(int id);
        int getMean();

        int getMax();
        ICollection<Airbnb> Availability();

        ICollection<Airbnb_review> GetReviews();

        bool AddReview(Airbnb_review review);

        ICollection<Airbnb> Availability();
        ICollection<Airbnb> FilterMax(int max);

        ICollection<Airbnb> IsChildsafety();

        bool Save();
    }
}
