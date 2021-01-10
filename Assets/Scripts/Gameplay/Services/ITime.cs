namespace Gameplay.Services
{
    public interface ITime
    {
        float deltaTime { get; }
    }

    // Unity
    public class UnityTimeService : ITime
    {
        public float deltaTime
        {
            get { return UnityEngine.Time.deltaTime; }
        }
    }
}