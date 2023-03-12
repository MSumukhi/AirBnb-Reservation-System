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
    public class AirbnbRepository:IAirbnbRepository
    {
        private DataContext _context;

        public AirbnbRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This getItems method return all the items in the items list which contains the Grocery bill details.
        /// </summary>
        /// <returns>List of type Bill</returns>
        public ICollection<Airbnb> GetItems()
        {
            return _context.Airbnb.ToList();
        }

        /// <summary>
        /// GetItem function gets the id and returns the Bill details of that id. To get the bill details of that
        /// id, a foreach loop is used to check the id and the values of that id is stored in a variable and returned.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bill</returns>
        public Airbnb GetItem(int id)
        {
            return _context.Airbnb.Where(bill => bill.Id == id).FirstOrDefault();
        }

        public Airbnb EditItem(int id,Airbnb item)
        {
            _context.Update(item,id);
            return Save();
        }

        public bool AddItem(Airbnb item)
        {
            _context.Add(item);
            return Save();
        }

        public bool BillExists(int id)
        {
            return _context.Airbnb.Any(bill=>bill.Id == id);
        }

     
       

        /// <summary>
        /// getMean method is to get the mean value of the total bill amount.It returns the mean value.
        /// </summary>
        /// <returns>int</returns>
        public int getMean()
        {
            var total = _context.Airbnb.Sum(i => i.price);
           
            
            List<Airbnb> items = (List<Airbnb>)GetItems();
            
            int count = items.Count();
            System.Diagnostics.Debug.WriteLine(count);
            return total/count;

        }

        /// <summary>
        /// getMax method is to get item that costed the most in the bill items.
        /// </summary>
        /// <returns>int maximum value</returns>

        public int getMax()
        {
            int maxvalue = _context.Airbnb.Max(p => p.price);
            return maxvalue;
        }

        
        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved == 1;
        }

     
    }
}
