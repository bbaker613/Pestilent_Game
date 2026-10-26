using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionSystem : Singleton<ActionSystem>
{
    private List<GameAction> reactions = null;
    public bool isPerforming { get; private set; } = false;
    private static Dictionary<Type, List<Action<GameAction>>> preSubs = new();
    private static Dictionary<Type, List<Action<GameAction>>> postSubs = new();
    private static Dictionary<Type, List<Action<GameAction>>> performers = new();

    public void Perform(GameAction action, System.Action OnPerformFinished = null)
    {

    }

    public void AddReaction(GameAction gameAction)
    {
        reactions?.Add(gameAction);
    }

    /*
    private IEnumerator PerformReactions()
    {
        foreach (var reaction in reactions)
        {
            yield return Flow(reaction);
        }
    }
    */

    public static void AttachPerformers<T>(Func<T, IEnumerator> performer) where T : GameAction 
    {
        Type type = typeof(T);
        IEnumerator wrappedPerformer(GameAction action) => performer((T)action);
        if (performers.ContainsKey(type))
        {
            //performers[type] = wrappedPerformer;
        }
        else
        {
            //performers.Add(type, wrappedPerformer);
        }
    }
    public static void DetachPerformer<T>() where T : GameAction 
    { 

    }
    public static void SubscribeReaction<T>(Action<T> reaction, ReactionTiming timing) where T : GameAction 
    {

    }
    public static void UnsubscribeReaction<T>(Action<T> reaction, ReactionTiming timing) where T : GameAction 
    {

    }

}