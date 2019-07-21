using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace View
{
    public interface IViewService
    {
        void CreateView(
            Contexts contexts,
            IEntity entity);
    }

    [Service, Unique]
    public class ViewServiceComponent : IComponent
    {
        public IViewService instance;
    }
}