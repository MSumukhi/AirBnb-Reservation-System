using HWK4.Data;
using HWK4.Interfaces;
using HWK4.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Xml.Linq;

///<summary>
///This Repository class contains the function defintions for getItems,getItem,deteleItem,editItem,addItem,getMean and getHighestValue
///</summary>

namespace HWK4.Repositories
{
    public class AirbnbRepository : IAirbnbRepository
    {
        private DataContext _context;

        public AirbnbRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all the items of the Airbnb dataset
        /// </summary>
        /// <returns>List of Airbnb</returns>
        public ICollection<Airbnb> GetItems()
        {
            return _context.Airbnb.ToList();
        }

        /// <summary>
        /// GetItem function gets the id and returns the Airbnb record details of that id. To get the details of that
        /// id, a foreach loop is used to check the id and the values of that id is stored in a variable and returned.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bill</returns>
        public Airbnb GetItem(int id)
        {
            return _context.Airbnb.Where(bill => bill.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// The createItem method adds a new record to the dataset
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public bool CreateItem(Airbnb bill)
        {
            _context.Add(bill);
            return Save();
        }

        public bool BillExists(int id)
        {
            return _context.Airbnb.Any(bill => bill.Id == id);
        }

        /// <summary>
        /// editItem method is used to update the record values.This method returns boolean value to indicate if the values are successfully updated or not.
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="updated"></param>
        /// <returns>bool</returns>

        public bool editItem(Airbnb bill)
        {

            _context.Update(bill);
            return Save();
        }

        /// <summary>
        /// deleteItem method is used to delete the item value of the id given. This method returns a boolean to let know if the item is deleted or not.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>

        public bool deleteItem(int Id)
        {
            var customer = _context.Airbnb.First(c => c.Id == Id);

            _context.Remove(customer);

            return Save();
        }


        /// <summary>
        /// getMean method returns the average price of airbnb records
        /// </summary>
        /// <returns>int</returns>
        public int getMean()
        {
            var total = _context.Airbnb.Sum(i => i.price);


            List<Airbnb> items = (List<Airbnb>)GetItems();

            int count = items.Count();
            System.Diagnostics.Debug.WriteLine(count);
            return total / count;

        }

        /// <summary>
        /// getMax method returns the highest price value of airbnb record
        /// </summary>
        /// <returns>int maximum value</returns>

        public int getMax()
        {
            int maxvalue = _context.Airbnb.Max(p => p.price);
            return maxvalue;
        }
        
        /// <summary>
        /// Availability method returns the records of airbnb which are available 365 days.
        /// </summary>
        /// <returns></returns>
        public ICollection<Airbnb> Availability()
        {
            return _context.Airbnb.Where(bill => bill.availability_365=="365").ToList();
           // return _context.Airbnb.ToList();
        }

        /// <summary>
        /// Filter Max function is to filter the data based the number of members that can be accommodated in the house.
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public ICollection<Airbnb> FilterMax(int max)
        {

            return _context.Airbnb.Where(bill => bill.max_people >= max).ToList();

        }

        /// <summary>
        /// Childsafety function is to provide the details of the airbnb houses that has children amenities.
        /// </summary>
        /// <returns></returns>

        public ICollection<Airbnb> IsChildsafety()
        {
            return _context.Airbnb.Where(bill => bill.children_amenities == "yes").ToList();
        }

        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved == 1;
        }
    }
}
