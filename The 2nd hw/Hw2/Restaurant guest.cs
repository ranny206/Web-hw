namespace Hw2
{
    public class RestaurantGuest: Guest
    {
        public readonly int Table;

        public RestaurantGuest(string name, int table) : base(name)
        {
            Table = table;
        }
    }
}