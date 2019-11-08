using Hotel;

namespace Hw2
{
    public class Lux: Room
    {
        public bool IsServed;
        public bool Baggage;

        public Lux(int number, bool isClean, bool isOccupied, string roomType, bool isServed, bool baggage) :
            base(number, isClean, isOccupied, roomType)
        {
            IsServed = isServed;
            Baggage = baggage;
        }
    }
}