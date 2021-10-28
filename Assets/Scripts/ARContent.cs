using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public abstract class ARContent : MonoBehaviour
{
    [SerializeField] protected List<ARState> statesSequence = null;
    [SerializeField] protected List<string> actNamesSequence = null;

    private ARState currentState = ARState.Default;

    public enum ARState
    {
        Default,
        Idle,
        Dummy, //Специальное состояние. Когда передаётся в метод getMessage - AR Content не меняет состояние 
        State1,
        State2,
        State3,
        State4,
        State5,
        State6,
        State7,
        State8,
        State9,
        State10,
        State11,
        State12,
        State13,
        Finish
    }

    public void TakeActsData()
    {
        if (statesSequence == null)
            statesSequence = new List<ARState>();

        if (actNamesSequence == null)
            actNamesSequence = new List<string>();


        if (!(actNamesSequence.Count() == SceneEventNotificator.instance.actNames.Count()
            && !actNamesSequence.Except(SceneEventNotificator.instance.actNames).Any()))
        {
            actNamesSequence.Clear();
            actNamesSequence.AddRange(SceneEventNotificator.instance.actNames);
        }
    }

    public void GetMessage(string actName, float timeElapsed)
    {
        ARState nextState = statesSequence[actNamesSequence.IndexOf(actName)];
        if (nextState != ARState.Dummy)
            SetState(nextState, 0.0f/*timeElapsed*/);
    }

    protected virtual void SetState(ARState state, float timeElapsed)
    {

    }
}
