using UnityEngine.Analytics;

namespace Combat
{
    public enum EffectId
    {
        None,
        Stun,
        Slow,
    }

    //stack(cộng dồn hiệu ứng): làm mới lại thời gian tác dụng, lấy giá trị cao hơn thay vào giá trị hiện tại
    public class BaseEffectData
    {
        private EffectId _effectId;
        private float remainTime;
        public bool stackable;

        public BaseEffectData(float duration)
        {
            remainTime = duration;
        }

        public virtual void SetEffectState(ref int state, bool isSet = true)
        {
            if (isSet) state |= (1 << (int) _effectId);
            else state &= ~(1 << (int) _effectId);
        }

        public bool IsEffectActive(int status)
        {
            return 1 >> (status & (1 << (int) _effectId)) == 1;
        }

        public EffectId EffectId
        {
            get => _effectId;
            set => _effectId = value;
        }

        public float RemainTime
        {
            get => remainTime;
            set => remainTime = value;
        }

        public bool Stackable
        {
            get => stackable;
            set => stackable = value;
        }
    }
}