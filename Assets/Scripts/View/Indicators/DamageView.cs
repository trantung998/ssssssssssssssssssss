using DG.Tweening;
using Entitas;
using Indicator;
using TMPro;
using UnityEngine;

namespace View.Indicators
{
    public class DamageView : UnityViewController
    {
        [SerializeField] private TextMeshPro valueText;

        private DamageIndicatorData _damageIndicatorData;

        public override void InitializeView(Contexts contexts, IEntity entity)
        {
            base.InitializeView(contexts, entity);
            _damageIndicatorData = this._entity.indicatorIndicator.value as DamageIndicatorData;
            valueText.transform.position = Vector3.zero;
            if (_damageIndicatorData != null)
            {
                valueText.text = "" + _damageIndicatorData.value;
                if (_damageIndicatorData.isCriticalHit)
                {
                    valueText.transform.localScale = Vector3.one;
                    valueText.transform.DOScale(new Vector3(1.5f, 1.5f, 1), 0.3f).SetEase(Ease.InBounce);
                }
                else
                {
                    valueText.transform.localScale = Vector3.one;
                }
            }

            valueText.transform.DOMoveY(transform.position.y + 0.5f, 0.3f)
                .OnComplete(() => { this._entity.isEntityDestroyed = true; });
        }

        public override void OnEntityDestroyed()
        {
            base.OnEntityDestroyed();
            gameObject.Recycle();
        }
    }
}