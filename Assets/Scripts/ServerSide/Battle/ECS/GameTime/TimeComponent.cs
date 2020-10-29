using Svelto.ECS;

namespace ServerSide.Battle.ECS.GameTime
{
    public struct TimeComponent : IEntityComponent
    {
        public int fps;
        public float revFps;
        public long lastimeUpdate;
        public float deltaTime;
        public uint frame;
    }
}