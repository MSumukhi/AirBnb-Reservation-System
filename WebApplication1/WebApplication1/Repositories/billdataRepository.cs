using billdataRestAPIMySQL.Models;
using billdataRestAPIMySQL.Data;
using billdataRestAPIMySQL.Interfaces;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Routing.Constraints;

namespace billdataRestAPIMySQL.Repositories
{
    public class billdataRepository : IbilldataRepository
    {
        private DataContext _context;

        public billdataRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieving all the items of file billdata
        /// </summary>
        /// <returns> All items </returns>
        public ICollection<billdata> getItems()
        {
            return _context.billdata.ToList();
        }

        /// <summary>
        /// Retrieving the item with a specific Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>item</returns>
        public billdata getItem(int id)
        {
            return _context.billdata.Where(billdata => billdata.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Adding new item 
        /// </summary>
        /// <param name="data"></param>
        /// <returns> bool </returns>
        public bool addItem(billdata item)
        {
            _context.Add(item);
            return Save();
        }

        /// <summary>
        /// Updating the item values
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updated"></param>
        /// <returns>bool</returns>
        public bool editItem(billdata item)
        {
            _context.Update(item);
            return Save();
        }

        /// <summary>
        /// Deleting an item with specific Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> bool </returns>
        public bool deleteItem(int id)
        {
            var items = _context.billdata.Where(item => item.Id == id);
            foreach (var item in items)
            {
                _context.Remove(item);
            }
            return Save();
        }
        /// <summary>
        /// Getting the item with maximum electricity
        /// </summary>
        /// <returns> item</returns>
        public billdata MaxElec()
        {
            billdata data = null;
            double max = 0.0;
            foreach (billdata item in _context.billdata)
            {
                if (item.electricity >= max)
                {
                    data = item;
                    max = item.electricity;
                }
            }
            return data;
        }

        /// <summary>
        /// Getting the item with minimum gasbill
        /// </summary>
        /// <returns> item </returns>
        public billdata MinGas()
        {
            billdata data = null;
            double min = 1000.0;
            foreach (billdata item in _context.billdata)
            {
                if (item.gas <= min)
                {
                    data = item;
                    min = item.electricity;
                }
            }
            return data;
        }
        /// <summary>
        /// Saving the changes accordingly when the methods are called
        /// </summary>
        /// <returns> changes saved </returns>
        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved == 1;
        }

    }
}