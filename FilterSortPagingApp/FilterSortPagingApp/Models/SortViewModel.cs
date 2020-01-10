namespace FilterSortPagingApp.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; } // значение для сортировки по имени
        public SortState AgeSort { get; private set; }    // значение для сортировки по возрасту
        public SortState RoomSort { get; private set; }   // значение для сортировки по компании
        public SortState Current { get; private set; }     // текущее значение сортировки
 
        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            AgeSort = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
            RoomSort = sortOrder == SortState.RoomAsc ? SortState.RoomDesc : SortState.RoomAsc;
            Current = sortOrder;
        }
    }
}