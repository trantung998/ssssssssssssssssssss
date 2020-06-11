using Entitas;

public interface IBTController
{
    void Init(Contexts contexts, IEntity entity);
    void CreateTree();
    void UpdateTree(float dt);
}

[Game]
public class BTComponent : IComponent
{
    public IBTController treeController;
}