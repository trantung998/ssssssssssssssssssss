using UnityEngine;

namespace Gameplay.Services
{
    public interface IInput
    {
        KeyCode KeyCode { get; set; }

        float VerticalValue { get; set; }

        float HorizontalValue { get; set; }
    }

    public class UnityInputService : IInput
    {
        public UnityInputService()
        {
            KeyCode = KeyCode.None;
            VerticalValue = 0;
            HorizontalValue = 0;
        }

        public KeyCode KeyCode { get; set; }
        public float VerticalValue { get; set; }
        public float HorizontalValue { get; set; }
    }
}