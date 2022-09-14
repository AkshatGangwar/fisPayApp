namespace fisPayApp.Models
{
    public class StoreList
    {
        public string vendorId { get; set; }
        public string storeId { get; set; }
        public string storeName { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string landmark { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zipcode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public double distan
        {
            get => dist();
        }
        public string distance
        {
            get => $"{dist()+"Km"}";
        }
        double dist()
        {
            Location boston = new Location(27.3637435, 79.6302954);
            Location sanFrancisco = new Location(double.Parse(latitude), double.Parse(longitude));
            return Math.Round(Location.CalculateDistance(boston, sanFrancisco, DistanceUnits.Kilometers), 2);
        }
        
    }
}
