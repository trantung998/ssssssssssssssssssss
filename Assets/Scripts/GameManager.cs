using System.Collections;
using System.Collections.Generic;
using ServerSide.Battle.ECS;
using ServerSide.Battle.Logger;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static BattleContext _battleContext;

    // Start is called before the first frame update
    void Start()
    {
        _battleContext = new BattleContext(new UnityLog());
    }

    // Update is called once per frame
    void Update()
    {
        _battleContext.OnUpdate();
    }
}