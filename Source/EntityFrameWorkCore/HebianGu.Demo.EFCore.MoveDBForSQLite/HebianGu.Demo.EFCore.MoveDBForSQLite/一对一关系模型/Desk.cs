namespace HebianGu.Demo.EFCore.MoveDBForSQLite
{
   public class Desk
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student Student { get; set; }
    }
}
