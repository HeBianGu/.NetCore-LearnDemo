using System.Collections.Generic;

namespace HebianGu.Demo.EFCore.MoveDBForMySql
{
    public class School
   {
       public int Id { get; set; }
       public string Name { get; set; }
       public List<Teacher> Teachers { get; set; }
    }
}
