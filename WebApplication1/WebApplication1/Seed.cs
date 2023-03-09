using billdataRestAPIMySQL;
using billdataRestAPIMySQL.Data;
using billdataRestAPIMySQL.Models;
using billdataRestAPIMySQL.Interfaces;
using billdataRestAPIMySQL.Repositories;


public class Seed
{
    private readonly DataContext dataContext;
    public Seed(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public void SeedDataContext()
    {
        if (!dataContext.billdata.Any())
        {
            List<billdata> items = new()
            {
                new billdata {Id=1, firstNames ="Laurie", lastNames = "McDaniel" , electricity=227.0,water=131.0 , gas=93.0 }
            };
            dataContext.billdata.AddRange(items);
            dataContext.SaveChanges();
        }
    }
}