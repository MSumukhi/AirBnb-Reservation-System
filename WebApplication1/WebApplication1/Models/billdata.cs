namespace billdataRestAPIMySQL.Models
{
    public class billdata
    {   /// <summary>
        /// Structure of the Data. It takes the following parameters
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="electricityBill"></param>
        /// <param name="waterBill"></param>
        /// <param name="gasBill"></param>

        public int Id { get; set; }

        public string firstNames { get; set; }

        public string lastNames { get; set; }

        public double electricity { get; set; }

        public double water { get; set; }

        public double gas { get; set; }

        // {get;set;} method is an automatic property provided by c#.
        // The get methid is used to return the value of variable
        // The set method is used to set value to the variable

    }
}