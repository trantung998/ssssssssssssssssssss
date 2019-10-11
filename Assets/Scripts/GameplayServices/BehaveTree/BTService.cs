using System.Collections.Generic;
using NPBehave;
using UnityEngine;

public class BTService : IBTService
{
    private Clock clock;
    private Dictionary<string, Blackboard> blackboards = new Dictionary<string, Blackboard>();

    public BTService()
    {
        clock = new Clock();
    }

    public void Update(float dt)
    {
        clock.Update(Time.deltaTime);
    }

    public Blackboard GetSharedBlackboard(string key)
    {
        if (!blackboards.ContainsKey(key))
        {
            blackboards.Add(key, new Blackboard(clock));
        }

        return blackboards[key];
    }

    public Clock GetClock()
    {
        return clock;
    }
}