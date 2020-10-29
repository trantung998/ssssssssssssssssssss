using Svelto.ECS;

namespace ServerSide.Battle.ECS
{
    public class EntityGroups
    {
        public static ExclusiveGroup GlobalEntity = new ExclusiveGroup();
        public static ExclusiveGroup ActiveEntity = new ExclusiveGroup();
        public static ExclusiveGroup UnActiveEntity = new ExclusiveGroup();
    }
}