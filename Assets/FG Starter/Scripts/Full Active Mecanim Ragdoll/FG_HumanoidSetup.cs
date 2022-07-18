/*///////////////////////////////////////////////////////
//                                                     //
//        ╔═╗╦ ╦╔╗╔ ╦╦╔╦╗╔═╗╦ ╦  ╔═╗╔═╗╔╦╗╔═╗╔═╗       //
//        ╠╣ ║ ║║║║ ║║ ║ ╚═╗║ ║  ║ ╦╠═╣║║║║╣ ╚═╗       //
//        ╚  ╚═╝╝╚╝╚╝╩ ╩ ╚═╝╚═╝  ╚═╝╩ ╩╩ ╩╚═╝╚═╝       //
//                                                     //
///////////////////////////////////////////////////////*/
using UnityEngine;
using System;


public class FG_HumanoidSetup : MonoBehaviour
{

    #region Assignable vars
    [Tooltip("Static animator hips.")]
    public Transform masterRoot;
    [Tooltip("Ragdoll hips.")]
    public Transform slaveRoot;
    [Tooltip("Camera following the character.")]
    public Camera characterCamera;
    [Tooltip("Ragdoll looses strength when colliding with other objects except for objects with layers contained in this mask.")]
    public LayerMask dontLooseStrengthLayerMask;

    #endregion


    #region NonSerialized Accesable var
    [NonSerialized]
    public FG_MasterController masterController;
    [NonSerialized]
    public FG_SlaveController slaveController;
    [NonSerialized]
    public FG_AnimationFollowing animFollow;
    [NonSerialized]
    public Animator anim;

    #endregion
    void Awake()
    {
        if (masterRoot == null) Debug.LogError("masterRoot not assigned.");
        if (slaveRoot == null) Debug.LogError("slaveRoot not assigned.");
        if (characterCamera == null) Debug.LogError("characterCamera not assigned.");

        masterController = this.GetComponentInChildren<FG_MasterController>();
        if (masterController == null) Debug.LogError("MasterControler not found.");

        slaveController = this.GetComponentInChildren<FG_SlaveController>();
        if (slaveController == null) Debug.LogError("SlaveController not found.");

        animFollow = this.GetComponentInChildren<FG_AnimationFollowing>();
        if (animFollow == null) Debug.LogError("AnimationFollowing not found.");

        anim = this.GetComponentInChildren<Animator>();
        if (anim == null) Debug.LogError("Animator not found.");
    }

}
