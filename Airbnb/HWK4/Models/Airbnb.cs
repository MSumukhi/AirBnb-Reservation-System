namespace Airbnb.Models
{
    /// <summary>
    /// This class has the attributes declaration that are in the database
    /// </summary>
    public class Airbnb
    {
        public int Id { get; set; }
        public String name { get; set; }
        public String host_id { get; set; }
        public String host_name { get; set; }
        public String neighbourhood_group { get; set; }
        public String neighbourhood { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string roomtype { get; set; }
        public int price { get; set; }
        public int minimum_nights { get; set; }
        public int number_of_reviews { get; set; }
        public double reviews_per_month { get; set; }
        public string availability_365 { get; set; }
        public string reviews { get; set; } 


    }

    public class Airbnb_review
    {
        public int id { get; set; }
        public string review { get; set; }
    }
}
