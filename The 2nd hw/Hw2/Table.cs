using System.Collections.Generic;

namespace Hw2
{
    public class Table
    {
        public int Number;
        public List<bool> IsReserved = new List<bool>(24);
        public string TableType;

        public Table(int number, string tableType)
        {
            Number = number;
            TableType = tableType;
            for (var i = 0; i < 24; i++)
            {
                IsReserved.Add(false);
            }
        }
    }
}