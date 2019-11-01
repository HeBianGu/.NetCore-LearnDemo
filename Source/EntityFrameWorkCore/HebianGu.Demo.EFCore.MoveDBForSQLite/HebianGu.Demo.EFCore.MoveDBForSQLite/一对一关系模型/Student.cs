namespace HebianGu.Demo.EFCore.MoveDBForSQLite
{
   public class Student
    {
        public int Id { get; set; }

        public  string Name { get; set; }

        public int DeskID { get; set; }

        public Desk Desk { get; set; }
    }
}
