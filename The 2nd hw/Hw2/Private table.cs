namespace Hw2
{
    public class PrivateTable: Table
    {
        public bool Music;

        public PrivateTable(int number, string tableType, bool music) : base(number, tableType)
        {
            Music = music;
        }
    }
}