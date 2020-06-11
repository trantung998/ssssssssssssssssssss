using System;
using Entitas;
using Sirenix.OdinInspector;
using UnityEngine;

public class CollierController : MonoBehaviour
{
    [SerializeField] private Collider2D _collider2D;
    private IEntity _entity;
    private Action<IEntity> _actionWhenCollided;
    private CollisionData _collisionData;

    [Button]
    private void GetReference()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    public virtual void Init(IEntity entity, Action<IEntity> action)
    {
        this._entity = entity;
        this._actionWhenCollided = action;
        SetUpCollider();
    }

    public virtual void SetUpCollider()
    {
    }

    public virtual void SetOffset(Vector2 offset)
    {
        if (_collider2D != null)
        {
            _collider2D.offset = offset;
        }
    }

    public void SetActive(bool isActive)
    {
        if (_collider2D != null) _collider2D.enabled = isActive;
    }

    public IEntity GetEntity()
    {
        return _entity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D ");
        if (_actionWhenCollided != null) _actionWhenCollided(other.GetComponent<CollierController>().GetEntity());
    }
}