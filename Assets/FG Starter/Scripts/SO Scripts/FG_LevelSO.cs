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

[CreateAssetMenu(fileName = "New Level Data", menuName = "Funjitsu/Gameplay/Level Data")]
public class FG_LevelSO : ScriptableObject
{
    [Header("Level Prefab Object")]
    [SerializeField] private GameObject levelPrefab = null;

    [Header("Unique Setting")]
    [SerializeField] private Material uniqueSkyBox = null;

    public GameObject GetLevelPrefab()
    {
        return levelPrefab;
    }

    public Material GetSkyBox()
    {
        return uniqueSkyBox;
    }
}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */