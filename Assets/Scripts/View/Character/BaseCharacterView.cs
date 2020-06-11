using Entitas;
using Sirenix.OdinInspector;
using UnityEngine;
using View;
using View.Indicators;

public class BaseCharacterView : UnityViewController, IEffectDataChangedListener, ICharacterStateListener
{
    [SerializeField] private Transform effectTransformParent;
    [SerializeField] private BaseAnimationService _animationService;

    private EffectViewsManager _effectViewsManager;
    private BaseCharacterAnimationController _animationController;

    [Button]
    protected virtual void InitView()
    {
        _animationService = GetComponentInChildren<BaseAnimationService>();
    }

    public override void InitializeView(Contexts contexts, IEntity entity)
    {
        base.InitializeView(contexts, entity);

        _entity.AddEffectDataChangedListener(this);
        _entity.AddCharacterStateListener(this);

        _effectViewsManager = new EffectViewsManager();
        _effectViewsManager.Init(_entity, effectTransformParent);
    }

    protected virtual BaseCharacterAnimationController CreateAnimationController()
    {
        return new BaseCharacterAnimationController(_animationService);
    }

    public override void OnEntityDestroyed()
    {
        _entity.RemoveEffectDataChangedListener(this);
        base.OnEntityDestroyed();
    }

    public override void OnUpdate(float dt)
    {
        base.OnUpdate(dt);

        _effectViewsManager.CheckEffectsView();
        _effectViewsManager.UpdateViews(dt);
    }

    public void OnEffectDataChanged(GameEntity entity)
    {
    }

    public void OnCharacterState(GameEntity entity, CharacterStateData value)
    {
        Debug.Log(string.Format("Character State Change from {0} to {1}", value.prevState, value.currentState));
    }
}