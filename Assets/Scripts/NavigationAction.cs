using AI.Planner.Domains;
using Unity.AI.Planner.Agent;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using UnityEngine;

public class NavigationAction : IOperationalAction<CharAgent, StateData, ActionKey>
{
    private const float WalkSpeed = 0.3f;
    private Vector3 _targetPosition;
    private Transform _agentTransform;
    private bool _arrived;

    public void BeginExecution(StateData state, ActionKey action, CharAgent agent)
    {
        _targetPosition = state.GetTraitOnObjectAtIndex<Location>(action[1]).Position;
        _agentTransform = agent.transform;

        _agentTransform.LookAt(_targetPosition);

        _arrived = false;
    }

    public void ContinueExecution(StateData state, ActionKey action, CharAgent agent)
    {
        _agentTransform.LookAt(_targetPosition);

        var position = _agentTransform.position;
        var newPosition = position + _agentTransform.forward * WalkSpeed;
        _agentTransform.position = newPosition;

        _arrived = Vector3.Distance(newPosition, _targetPosition) <= 0.1;
    }

    public void EndExecution(StateData state, ActionKey action, CharAgent agent)
    {
        var destLoc = state.GetTraitOnObjectAtIndex<Location>(action[1]);
        var location = state.GetTraitOnObjectAtIndex<Location>(action[0]);
        location.Position = destLoc.Position;
        state.SetTraitOnObjectAtIndex(location, action[0]);
    }

    public OperationalActionStatus Status(StateData state, ActionKey action, CharAgent agent)
    {
        return _arrived
            ? OperationalActionStatus.Completed
            : OperationalActionStatus.InProgress;
    }
}