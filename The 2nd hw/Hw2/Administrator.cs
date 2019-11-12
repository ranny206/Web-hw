using System;

namespace Hw2
{
    public class Administrator
    {
        public virtual void CheckIn(string name, string type) {}

        public virtual void CheckOut(int number) { }

        public virtual int CheckTypeWithType(string type)
        {
            return 1;
        }

        public virtual int CheckTypeWithNumber(int number)
        {
            return 1;
        }
    }
}