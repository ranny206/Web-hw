namespace Hotel_App.Models
{
    public class ReseptionAdministrator: Administrator
    {
        public override void CheckIn()
        {
            base.CheckIn();
            
        }

        public override void MoveOut()
        {
            base.MoveOut();
        }
    }
}