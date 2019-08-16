using UnityEngine;

public class UnityTimeService : ITimeService
{
    public float DeltaTime
    {
        get { return Time.deltaTime; }
    }

    public float TimeFromStart
    {
        get { return Time.realtimeSinceStartup; }
    }

    public float TimeScale
    {
        get { return Time.timeScale; }
        set { Time.timeScale = value; }
    }
}