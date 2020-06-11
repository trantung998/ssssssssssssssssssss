using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace View
{
    public class UnityViewController : MonoBehaviour, IViewController, ICharacterPositionListener
    {
        protected Contexts _contexts;
        protected GameEntity _entity;

        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public Vector3 Scale
        {
            get { return transform.localScale; }
            set { transform.localScale = value; }
        }

        public Quaternion Rotation
        {
            get { return transform.rotation; }
            set { transform.rotation = value; }
        }

        public IEntity GetEntity { get; set; }

        IEntity IViewController.GetEntity()
        {
            return _entity;
        }

        public bool Active
        {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }

        public virtual void InitializeView(Contexts contexts, IEntity entity)
        {
            this._contexts = contexts;
            this._entity = (GameEntity) entity;
            this._entity.AddCharacterPositionListener(this);
            Link();
        }

        public virtual void OnEntityDestroyed()
        {
            this._entity.RemoveCharacterPositionListener(this);
            UnLink();
        }

        public virtual void OnUpdate(float dt)
        {
        }

        public void Link()
        {
            if (gameObject.GetEntityLink() == null || gameObject.GetEntityLink().entity == null)
                gameObject.Link(_entity);
        }

        public void UnLink()
        {
            if (gameObject != null && gameObject.GetEntityLink() != null && gameObject.GetEntityLink().entity != null)
                gameObject.Unlink();
        }

        public void OnCharacterPosition(GameEntity entity, Vector3 value)
        {
            Position = value;
        }
    }
}