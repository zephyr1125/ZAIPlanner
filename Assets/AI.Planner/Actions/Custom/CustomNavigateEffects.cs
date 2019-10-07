#if PLANNER_DOMAIN_GENERATED
using AI.Planner.Domains;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using UnityEngine;

namespace AI.Planner.Actions.Custom
{
    public class CustomNavigateEffects : ICustomActionEffect<StateData>
    {
        private const int AgentIndex = 0;
        private const int ToIndex = 1;
        private const int TimeIndex = 2;

        
        public void ApplyCustomActionEffectsToState(StateData originalState, ActionKey action, StateData newState)
        {
            var domainObjBuffer = originalState.DomainObjects;
            var agentObject = domainObjBuffer[action[AgentIndex]];
            var toObject = domainObjBuffer[action[ToIndex]];
            var locationBuffer = originalState.LocationBuffer;
            var agentLocation = locationBuffer[agentObject.LocationIndex];
            var destLocation = locationBuffer[toObject.LocationIndex];

            var time = originalState.TimeBuffer[action[TimeIndex]];
            var distance = Vector3.Distance(agentLocation.Position, destLocation.Position);
            var deltaTime = Mathf.FloorToInt(distance / Const.WalkingSpeed + 1);
            time.Value += deltaTime;
            newState.TimeBuffer[action[TimeIndex]] = time;
        }
    }
}
#endif