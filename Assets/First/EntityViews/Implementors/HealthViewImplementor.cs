using First.EntityViews.Components;
using Svelto.ECS.Hybrid;
using UnityEngine;

namespace First.EntityViews.Implementors
{
    public class HealthViewImplementor : MonoBehaviour, IHealthComponent, IImplementor
    {
        [SerializeField] private SpriteRenderer _healthSpriteRenderer;
        private Transform _transform;
        private Vector3 _scaleValue;

        private void Awake()
        {
            _transform = _healthSpriteRenderer.transform;
            _scaleValue = Vector3.one;
            _scaleValue.y = 0.12f;
        }

        public float value
        {
            set
            {
                _scaleValue.x = value;
                _transform.localScale = _scaleValue;
            }
        }
    }
}