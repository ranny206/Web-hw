using Hotel;

namespace Hw2
{
    public class Double: Room
    {
        public bool SecondGuest;

        public Double(int number, bool isClean, bool isOccupied, string roomType, bool secondGuest) : 
            base(number, isClean, isOccupied, roomType)
        {
            SecondGuest = secondGuest;
        }
    }
}