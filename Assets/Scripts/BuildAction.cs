using AI.Planner.Domains;
using Unity.AI.Planner.Agent;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using UnityEngine;

public class BuildAction : IOperationalAction<CharAgent, StateData, ActionKey>
{
    public void BeginExecution(StateData state, ActionKey action, CharAgent agent)
    {
        Debug.Log("Begin BuildAction");
    }

    public void ContinueExecution(StateData state, ActionKey action, CharAgent agent)
    {
        
    }

    public void EndExecution(StateData state, ActionKey action, CharAgent agent)
    {
        
    }

    public OperationalActionStatus Status(StateData state, ActionKey action, CharAgent agent)
    {
        return OperationalActionStatus.Completed;
    }
}