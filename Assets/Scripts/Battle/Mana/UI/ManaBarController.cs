using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarController : MonoBehaviour
{
    [SerializeField] private Image manaValueBarImage;
    private ManaComponent _manaComponent;

    private void Start()
    {
        _manaComponent = Contexts.sharedInstance.game.mana;
    }

    private void Update()
    {
        if (_manaComponent != null)
        {
            SetManaValue(_manaComponent.GetManaPercent(0));
        }
    }

    [Button]
    private void SetManaValue(float value)
    {
        if (value < 0) value = 0;
        if (value > 1) value = 1;

        manaValueBarImage.transform.localScale = new Vector3(value, 1, 1);
    }
}