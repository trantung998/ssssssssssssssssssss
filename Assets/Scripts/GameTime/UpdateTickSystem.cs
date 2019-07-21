using Entitas;
using UnityEngine;

namespace GameTime
{
    public class UpdateTickSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;

        public UpdateTickSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
        }

        public void Execute()
        {
            _gameContext.ReplaceGameTimeTick(Time.deltaTime);
        }
    }
}