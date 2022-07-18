﻿/*///////////////////////////////////////////////////////
//                                                     //
//        ╔═╗╦ ╦╔╗╔ ╦╦╔╦╗╔═╗╦ ╦  ╔═╗╔═╗╔╦╗╔═╗╔═╗       //
//        ╠╣ ║ ║║║║ ║║ ║ ╚═╗║ ║  ║ ╦╠═╣║║║║╣ ╚═╗       //
//        ╚  ╚═╝╝╚╝╚╝╩ ╩ ╚═╝╚═╝  ╚═╝╩ ╩╩ ╩╚═╝╚═╝       //
//                                                     //
///////////////////////////////////////////////////////*/
using System.Collections.Generic;
using UnityEngine;

namespace FG.MonoBehaviours
{

    /*
     * Easy set up for CameraFollow, it will follow the transform with zoom
     * */
    public class FG_CameraFollowSetup : MonoBehaviour
    {

        [SerializeField] private FG_CameraFollow cameraFollow;
        [SerializeField] private Transform followTransform;
        [SerializeField] private float zoom;

        public Transform FollowTransform { get => followTransform; set => followTransform = value; }
        public float Zoom { get => zoom; set => zoom = value; }
        public FG_CameraFollow CameraFollow { get => cameraFollow; set => cameraFollow = value; }

        private void Start()
        {
            if (FollowTransform == null)
            {
                Debug.LogError("followTransform is null! Intended?");
                CameraFollow.Setup(() => Vector3.zero, () => Zoom);
            }
            else
            {
                CameraFollow.Setup(() => FollowTransform.position, () => Zoom);
            }
        }
    }

}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */