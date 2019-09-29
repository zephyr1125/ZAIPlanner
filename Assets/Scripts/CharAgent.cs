using AI.Planner.Actions.Character;
using AI.Planner.Domains;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using UnityEngine.AI.Planner.DomainLanguage.TraitBased;

public class CharAgent : BaseAgent<CharAgent, DomainObject, StateEntityKey, StateData,
    StateDataContext, ActionScheduler, Heuristic, TerminationEvaluator, StateManager, ActionKey>
{
}
