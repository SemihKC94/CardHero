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

[CreateAssetMenu(fileName ="New Runner Mechanic", menuName ="Funjitsu/Gameplay/Mechanic/Runner Mechanic Data")]
public class FG_RunnerMechanic : ScriptableObject
{
    [Header("Movement Config")]
    [SerializeField] float _forwardSpeed = 10f;
    [SerializeField] float _sideSpeed = 5f;
    [SerializeField] Vector2 _xClamp = Vector2.one;

    public float ForwardSpeed => _forwardSpeed;
    public float SideSpeed => _sideSpeed;
    public Vector2 XClamp => _xClamp;

}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */