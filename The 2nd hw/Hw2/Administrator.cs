using System;

namespace Hw2
{
    public class Administrator
    {
        public virtual void CheckIn(string name, string type) {}

        public virtual void CheckOut(int number) { }

        public virtual bool CheckTypeWithType(string type)
        {
            return true;
        }

        public virtual bool CheckTypeWithNumber(int number)
        {
            return true;
        }
    }
}