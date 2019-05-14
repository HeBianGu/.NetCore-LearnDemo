namespace HebianGu.Demo.EFCore.MoveDBForMySql
{
    /// <summary>
    /// 1、多对多关系模型
    /// </summary>
    public class RelationShip
    {
        public int ChildID { get; set; }

        public  Child Child { get; set; }

        public int ParentID { get; set; }

        public  Parent Parent { get; set; }
    }


}
