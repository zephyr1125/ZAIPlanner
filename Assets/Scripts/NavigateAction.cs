using AI.Planner.Domains;
using Unity.AI.Planner.Agent;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using UnityEngine;

public class NavigateAction : IOperationalAction<CharAgent, StateData, ActionKey>
{
    public void BeginExecution(StateData state, ActionKey action, CharAgent agent)
    {
        Debug.Log("Navigate character");
        
        // Update Character position (real-world)
        var destinationLocation = state.GetTraitOnObjectAtIndex<Location>(action[1]);
        agent.transform.position = destinationLocation.Position;
    }

    public void ContinueExecution(StateData state, ActionKey action, CharAgent agent)
    {
    }

    public void EndExecution(StateData state, ActionKey action, CharAgent agent)
    {
        // Update Character position (Planner simulation)
        var destinationLocation = state.GetTraitOnObjectAtIndex<Location>(action[1]);
        var characterLocation = state.GetTraitOnObjectAtIndex<Location>(action[0]);
        
        characterLocation.Position = destinationLocation.Position;
        state.SetTraitOnObjectAtIndex(characterLocation, action[0]);
    }

    public OperationalActionStatus Status(StateData state, ActionKey action, CharAgent agent)
    {
        return OperationalActionStatus.Completed;
    }
}