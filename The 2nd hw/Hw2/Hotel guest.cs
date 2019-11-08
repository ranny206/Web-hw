namespace Hw2
{
    public class HotelGuest: Guest
    {
        public int Room;

        public HotelGuest(string name) : base(name)
        {
            this.Room = 0;
        }
    }
}