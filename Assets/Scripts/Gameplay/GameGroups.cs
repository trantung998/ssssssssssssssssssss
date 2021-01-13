using Svelto.ECS;

namespace Gameplay
{
    public static class GameGroups
    {
        public class UserInput : GroupTag<UserInput>
        {
        }

        public abstract class Dynamic : GroupTag<Dynamic>
        {
        }

        public class UserInputGroup : GroupCompound<UserInput, Dynamic>
        {
        }
    }
}