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

namespace FG
{

    public class FG_Assets : MonoBehaviour
    {

        // Internal instance reference
        private static FG_Assets _i;

        // Instance reference
        public static FG_Assets i
        {
            get
            {
                if (_i == null) _i = Instantiate(Resources.Load<FG_Assets>("FGAssets"));
                return _i;
            }
        }


        // All references

        public Sprite s_White;
        public Material m_White;

    }

}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */