//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class ServiceComponentsLookup {

    public const int GameplayServicesInputInputService = 0;
    public const int RandomService = 1;
    public const int ViewViewService = 2;

    public const int TotalComponents = 3;

    public static readonly string[] componentNames = {
        "GameplayServicesInputInputService",
        "RandomService",
        "ViewViewService"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(GameplayServices.Input.InputServiceComponent),
        typeof(RandomServiceComponent),
        typeof(View.ViewServiceComponent)
    };
}