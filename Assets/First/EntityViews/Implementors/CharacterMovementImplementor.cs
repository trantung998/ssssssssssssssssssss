using System;
using First.EntityViews.Components;
using Svelto.ECS.Hybrid;
using UnityEngine;

namespace First.EntityViews.Implementors
{
    public class CharacterMovementImplementor : MonoBehaviour, IImplementor, ITransformComponent
    {
        Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public Vector3 position
        {
            get { return _transform.position; }
            set { _transform.position = value; }
        }

        public Quaternion rotation
        {
            set { }
        }

        public Vector3 localScale
        {
            get { return _transform.localScale; }
            set { _transform.localScale = value; }
        }
    }
}