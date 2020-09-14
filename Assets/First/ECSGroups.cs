using Svelto.ECS;

namespace First
{
    /// <summary>
    ///     Create the Exclusive Groups use to build Entities in separate groups.
    ///     you don't need to put all the ExclusiveGroup inside a single class
    ///     you can decide to use them as you wish and create them wherever you want
    /// </summary>
    static class ECSGroups
    {
        /// <summary>
        ///     Reserving 3 exclusive groups, one for each enemy type
        /// </summary>
        public static readonly ExclusiveGroup CharacterToRecycleGroups = new ExclusiveGroup(1);

        public static readonly ExclusiveGroup DeadCharacterGroups = new ExclusiveGroup();

        /// <summary>
        ///     while the active enemies share the same group to optimize the memory layout
        /// </summary>
        public static readonly ExclusiveGroup ActiveCharacter = new ExclusiveGroup();
        public static readonly ExclusiveGroup PlayerInput = new ExclusiveGroup();
    }
}