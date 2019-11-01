namespace HebianGu.Demo.EFCore.MoveDBForSQLite
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public  int SchoolID { get; set; }
        public School School { get; set; }
    }
}
