using billdataRestAPIMySQL.Models;
namespace billdataRestAPIMySQL.Interfaces
{
    public interface IbilldataRepository
    {   /// <summary>
        /// Interface Repository for declaring all the methods called in Repository
        /// </summary>
        /// <returns> called function</returns>
        ICollection<billdata> getItems();
        billdata getItem(int id);
        bool addItem(billdata item);

        bool editItem(billdata item);

        bool deleteItem(int id);

        billdata MaxElec();

        billdata MinGas();


    }
}