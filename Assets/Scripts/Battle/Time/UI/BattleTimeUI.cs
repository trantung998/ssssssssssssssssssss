using System;
using TMPro;
using UnityEngine;

public class BattleTimeUI : MonoBehaviour, IAnyUpdateBattleTimeListener
{
    [SerializeField] private TextMeshProUGUI _battleTimeText;

    private void Start()
    {
        Contexts.sharedInstance.game.updateBattleTimeEntity.AddAnyUpdateBattleTimeListener(this);
    }

    public void OnAnyUpdateBattleTime(GameEntity entity, float timeValue)
    {
        if (_battleTimeText != null)
        {
            _battleTimeText.text = TimeHelper.StringTimeFormated(TimeFormatType.MinuteNSecond, (int) timeValue);
        }
    }
}