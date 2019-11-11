using System;

namespace Hw2
{
    public class Administrator
    {
        public virtual void CheckIn(string name, string type) {}

        public virtual void CheckOut(int number) { }

        protected virtual bool CheckTypeWithType(string type)
        {
            return true;
        }

        protected virtual bool CheckTypeWithNumber(int number)
        {
            return true;
        }
    }
}