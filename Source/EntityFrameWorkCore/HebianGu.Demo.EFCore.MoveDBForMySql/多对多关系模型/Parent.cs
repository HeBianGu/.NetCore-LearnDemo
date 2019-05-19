using System;
using System.Collections.Generic;
using System.Text;


namespace HebianGu.Demo.EFCore.MoveDBForMySql
{

    //  Do：定义父母类型
    public class Parent
    {
        public Parent()
        {
            this.RelationShips =new List<RelationShip>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        //  Do：3、定义关系集合
        public List<RelationShip> RelationShips { get; set; }
    }


}
