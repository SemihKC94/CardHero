/*///////////////////////////////////////////////////////
//                                                     //
//        ╔═╗╦ ╦╔╗╔ ╦╦╔╦╗╔═╗╦ ╦  ╔═╗╔═╗╔╦╗╔═╗╔═╗       //
//        ╠╣ ║ ║║║║ ║║ ║ ╚═╗║ ║  ║ ╦╠═╣║║║║╣ ╚═╗       //
//        ╚  ╚═╝╝╚╝╚╝╩ ╩ ╚═╝╚═╝  ╚═╝╩ ╩╩ ╩╚═╝╚═╝       //
//                                                     //
///////////////////////////////////////////////////////*/
using System;
using UnityEngine;
using FG.Utils;

namespace FG
{

    /*
     * Debug Class with various helper functions to quickly create buttons, text, etc
     * */
    public static class FG_Debug
    {

        // Creates a Button in the World
        public static World_Sprite Button(Transform parent, Vector3 localPosition, Quaternion rot,string text, System.Action ClickFunc, int fontSize = 30, float paddingX = 5, float paddingY = 5)
        {
            return World_Sprite.CreateDebugButton(parent, localPosition, rot,text, ClickFunc, fontSize, paddingX, paddingY);
        }

        // Creates a Button in the UI
        public static UI_Sprite ButtonUI(Vector2 anchoredPosition, string text, Action ClickFunc)
        {
            return UI_Sprite.CreateDebugButton(anchoredPosition, text, ClickFunc);
        }

        // Creates a World Text object at the world position
        public static void Text(string text, Vector3 localPosition = default(Vector3),Quaternion rot = default(Quaternion) ,Transform parent = null, int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = FG_Utils.sortingOrderDefault)
        {
            FG_Utils.CreateWorldText(text, parent, localPosition, rot,fontSize, color, textAnchor, textAlignment, sortingOrder);
        }

        // World text pop up at mouse position
        public static void TextPopupMouse(string text,Color col,Quaternion rot,float time)
        {
            FG_Utils.CreateWorldTextPopup(text, FG_Utils.GetMouseWorldPosition(),rot,40,col,time);
        }

        // Creates a Text pop up at the world position
        public static void TextPopup(string text, Vector3 position,Quaternion rot,int size,Color col,float time)
        {
            FG_Utils.CreateWorldTextPopup(text, position,rot,size,col , time);
        }

        // Text Updater in World, (parent == null) = world position
        public static FG_FunctionUpdater TextUpdater(Func<string> GetTextFunc, Vector3 localPosition, Transform parent = null)
        {
            return FG_Utils.CreateWorldTextUpdater(GetTextFunc, localPosition, parent);
        }

        // Text Updater in UI
        public static FG_FunctionUpdater TextUpdaterUI(Func<string> GetTextFunc, Vector2 anchoredPosition)
        {
            return FG_Utils.CreateUITextUpdater(GetTextFunc, anchoredPosition);
        }

        // Text Updater always following mouse
        public static void MouseTextUpdater(Func<string> GetTextFunc, Vector3 positionOffset = default(Vector3))
        {
            GameObject gameObject = new GameObject();
            FG_FunctionUpdater.Create(() => {
                gameObject.transform.position = FG_Utils.GetMouseWorldPosition() + positionOffset;
                return false;
            });
            TextUpdater(GetTextFunc, Vector3.zero, gameObject.transform);
        }

        // Trigger Action on Key
        public static FG_FunctionUpdater KeyCodeAction(KeyCode keyCode, Action onKeyDown)
        {
            return FG_Utils.CreateKeyCodeAction(keyCode, onKeyDown);
        }



        // Debug DrawLine to draw a projectile, turn Gizmos On
        public static void DebugProjectile(Vector3 from, Vector3 to, float speed, float projectileSize)
        {
            Vector3 dir = (to - from).normalized;
            Vector3 pos = from;
            FG_FunctionUpdater.Create(() => {
                Debug.DrawLine(pos, pos + dir * projectileSize);
                float distanceBefore = Vector3.Distance(pos, to);
                pos += dir * speed * Time.deltaTime;
                float distanceAfter = Vector3.Distance(pos, to);
                if (distanceBefore < distanceAfter)
                {
                    return true;
                }
                return false;
            });
        }


    }

}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */