/*///////////////////////////////////////////////////////
//                                                     //
//        ╔═╗╦ ╦╔╗╔ ╦╦╔╦╗╔═╗╦ ╦  ╔═╗╔═╗╔╦╗╔═╗╔═╗       //
//        ╠╣ ║ ║║║║ ║║ ║ ╚═╗║ ║  ║ ╦╠═╣║║║║╣ ╚═╗       //
//        ╚  ╚═╝╝╚╝╚╝╩ ╩ ╚═╝╚═╝  ╚═╝╩ ╩╩ ╩╚═╝╚═╝       //
//                                                     //
///////////////////////////////////////////////////////*/

using UnityEngine;


public class FG_CollisionDetector : MonoBehaviour
{
    #region Private Vars
    private FG_SlaveController slaveController;
    private LayerMask layerMask;
    #endregion


    void Start()
    {
        FG_HumanoidSetup setUp = this.GetComponentInParent<FG_HumanoidSetup>();
        slaveController = setUp.slaveController;
        layerMask = setUp.dontLooseStrengthLayerMask;
    }

    private bool CheckIfLayerIsInLayerMask(int layer)
    {
        return layerMask == (layerMask | (1 << layer));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!CheckIfLayerIsInLayerMask(collision.gameObject.layer))
        {
            slaveController.currentNumberOfCollisions++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!CheckIfLayerIsInLayerMask(collision.gameObject.layer))
        {
            slaveController.currentNumberOfCollisions--;
        }
    }

}
