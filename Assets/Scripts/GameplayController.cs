using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;

public class GameplayController : MonoBehaviour
{
    private Contexts _contexts;
    private RootSystems _rootSystems;

    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;
        _contexts = Contexts.sharedInstance;

        var gamplayServices = new GameplayServices(new UnityViewService());
        var regService = new ServiceRegistrationSystems(_contexts, gamplayServices);
        regService.Initialize();

        _rootSystems = new RootSystems(_contexts);
        _rootSystems.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _rootSystems.Execute();
        _rootSystems.Cleanup();
    }

    private void OnDestroy()
    {
        _rootSystems.TearDown();
        _rootSystems.DeactivateReactiveSystems();
        _rootSystems.ClearReactiveSystems();

        _contexts.Reset();
    }
}