using Svelto.ECS;

namespace ServerSide.Battle.ECS.GameTime
{
    public interface IGameEngine : IEngine
    {
        void Update();
    }
}