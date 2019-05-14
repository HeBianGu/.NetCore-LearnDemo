namespace HebianGu.Demo.EFCore.MoveDBForMySql
{
   public class Desk
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student Student { get; set; }
    }
}
