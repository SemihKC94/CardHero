/*///////////////////////////////////////////////////////
//                                                     //
//        ╔═╗╦ ╦╔╗╔ ╦╦╔╦╗╔═╗╦ ╦  ╔═╗╔═╗╔╦╗╔═╗╔═╗       //
//        ╠╣ ║ ║║║║ ║║ ║ ╚═╗║ ║  ║ ╦╠═╣║║║║╣ ╚═╗       //
//        ╚  ╚═╝╝╚╝╚╝╩ ╩ ╚═╝╚═╝  ╚═╝╩ ╩╩ ╩╚═╝╚═╝       //
//                                                     //
///////////////////////////////////////////////////////*/
///
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Config SO")]
    [SerializeField] private FG_RunnerMechanic movementSO = null;

    [Space, Header("Animator")]
    [SerializeField] private Animator myAnimator = null;

    // Privates
    private float forwardSpeed;
    private float sideSpeed;
    private Vector2 xClamp;
    private Vector2 dir;
    private float xStart;

    private CamController myCam;

    #region Unity Methods
    private void Start()
    {
        xStart = transform.position.x;

        myCam = Camera.main.GetComponent<CamController>();

        myAnimator.SetTrigger(Constants.Animations.IDLE);
    }
    private void Update()
    {
        if (GameManager.GameState != GameState.Play) return;

        myCam.Assign(transform);

        dir = GUIController.Instance.GetJoystickDirection();

        float clamped = xStart + (dir.x * sideSpeed * Time.deltaTime); // TODO : Clamp
        Vector3 forwardDir = transform.forward * forwardSpeed * Time.deltaTime;

        transform.Translate(new Vector3(clamped, 0f, forwardDir.z));
        myAnimator.SetTrigger(Constants.Animations.RUN);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            FailMechanic();
            myAnimator.SetTrigger(Constants.Animations.LOSS);
        }

        if(other.gameObject.CompareTag("Finish"))
        {
            SuccessLevel();
            myAnimator.SetTrigger(Constants.Animations.VICTORY);
        }
    }

    #endregion

    #region Unique Methods
    public void Init()
    {
        forwardSpeed = movementSO.ForwardSpeed;
        sideSpeed = movementSO.SideSpeed;
        xClamp = movementSO.XClamp;
    }

    private void FailMechanic()
    {
        EventBroker.InvokeFail();
    }

    private void SuccessLevel()
    {
        EventBroker.InvokeLevelSuccess();
    }


    #endregion

}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */