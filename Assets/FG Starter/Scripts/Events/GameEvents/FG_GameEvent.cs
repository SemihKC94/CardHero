/*///////////////////////////////////////////////////////
//                                                     //
//        ╔═╗╦ ╦╔╗╔ ╦╦╔╦╗╔═╗╦ ╦  ╔═╗╔═╗╔╦╗╔═╗╔═╗       //
//        ╠╣ ║ ║║║║ ║║ ║ ╚═╗║ ║  ║ ╦╠═╣║║║║╣ ╚═╗       //
//        ╚  ╚═╝╝╚╝╚╝╩ ╩ ╚═╝╚═╝  ╚═╝╩ ╩╩ ╩╚═╝╚═╝       //
//                                                     //
///////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New GameEvent",menuName ="Funjitsu/Event Data")]
public class FG_GameEvent : ScriptableObject
{
    List<FG_EventListener> eventListener = new List<FG_EventListener>();

    public void Raise()
    {
        for (int i = 0; i < eventListener.Count; i++)
        {
            eventListener[i].OnEventRaised();
        }
    }

    public void Register(FG_EventListener listener)
    {
        if(!eventListener.Contains(listener))
        {
            eventListener.Add(listener);
        }
    }

    public void DeRegister(FG_EventListener listener)
    {
        if(eventListener.Contains(listener))
        {
            eventListener.Remove(listener);
        }
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */