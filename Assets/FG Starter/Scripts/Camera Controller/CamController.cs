/*///////////////////////////////////////////////////////
//                                                     //
//        ╔═╗╦ ╦╔╗╔ ╦╦╔╦╗╔═╗╦ ╦  ╔═╗╔═╗╔╦╗╔═╗╔═╗       //
//        ╠╣ ║ ║║║║ ║║ ║ ╚═╗║ ║  ║ ╦╠═╣║║║║╣ ╚═╗       //
//        ╚  ╚═╝╝╚╝╚╝╩ ╩ ╚═╝╚═╝  ╚═╝╩ ╩╩ ╩╚═╝╚═╝       //
//                                                     //
///////////////////////////////////////////////////////*/

using System.Collections;
using System;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [Header("Camera Config")]
    [SerializeField] private Vector3 camOffset = Vector3.zero;
    [SerializeField] private float smoothSpeed = .2f;
    [SerializeField] private bool lerpOrDamp = false;
    [SerializeField] private bool LookAtTarget = false;

    // Privates
    private Transform _followingTarget;
    private Transform _lookingTarget;

    // Temp
    private Vector3 desiredPos, smoothedPos, velocity;

    private void LateUpdate()
    {
        if (GameManager.GameState == GameState.Play)
        {
            if (_followingTarget != null)
            {
                desiredPos = _followingTarget.position + camOffset;

                if (lerpOrDamp)
                {
                    smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
                    transform.position = smoothedPos;
                }
                else
                {
                    smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothSpeed);
                    transform.position = smoothedPos;
                }

                if (LookAtTarget) transform.LookAt(_lookingTarget);
            }
        }
    }

    public void Assign(Transform newTarget)
    {
        _followingTarget = newTarget;
        _lookingTarget = newTarget;

        transform.position = _followingTarget.position + camOffset;
        if (LookAtTarget) transform.LookAt(_lookingTarget);
    }

    public void Assign(Transform followingTarget, Transform lookingTarget)
    {
        _followingTarget = followingTarget;
        _lookingTarget = lookingTarget;

        transform.position = _followingTarget.position + camOffset;
        if (LookAtTarget) transform.LookAt(_lookingTarget);
    }

    public void ResetCamera()
    {
        transform.position = camOffset;
    }

}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */