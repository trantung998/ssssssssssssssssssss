using UnityEngine;

namespace Gameplay.Services
{
    public interface IInput
    {
        bool IsSpawnCharacter { get; set; }

        float VerticalValue { get; set; }

        float HorizontalValue { get; set; }
    }

    public class UnityInputService : IInput
    {
        public UnityInputService()
        {
            IsSpawnCharacter = false;
            VerticalValue = 0;
            HorizontalValue = 0;
        }

        public bool IsSpawnCharacter
        {
            get => Input.GetKeyDown(KeyCode.A);
            set { }
        }

        public float VerticalValue
        {
            get => Input.GetAxis("Horizontal");
            set { }
        }

        public float HorizontalValue
        {
            get => Input.GetAxis("Vertical");
            set { }
        }
    }
}