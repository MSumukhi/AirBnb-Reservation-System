using HWK4.Data;
using HWK4.Models;
using System.ComponentModel;

namespace HWK4
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext dataContext) 
        {
            this.dataContext=dataContext;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Airbnb.Any())
            {
                List<Airbnb> bills = new()
                {
                    new Airbnb{Id=1, name="West avenue",host_id= "2788",host_name="shruthy",neighbourhood_group="brooklyn", neighbourhood="brook",latitude=76, longitude=56,roomtype="deluxe",price=150,minimum_nights=1,number_of_reviews=3,reviews_per_month=5,availability_365="yes",max_people=5,children_amenities="yes"}        
                };

                dataContext.Airbnb.AddRange(bills);
                dataContext.SaveChanges();
            }
        }
    }
}
