using System;

namespace HebianGu.Demo.EFCore.MoveDBForMySql
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public int Count { get; set; }
        public DateTime CDate { get; set; }
    }
}
