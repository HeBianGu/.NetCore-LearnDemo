using System.Collections.Generic;


namespace HebianGu.Demo.EFCore.MoveDBForMySql
{
    //  Do：定义子类型
    public class Child
    {
        public Child()
        {
            this.RelationShips=new List<RelationShip>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        //  Do：2、定义关系集合
        public List<RelationShip> RelationShips { get; set; }
    }


}
