using UnityEngine;
using UnityEditor;
using AstroTurffx.AstroUtils.Runtime;


namespace AstroTurffx.AstroUtils.Editor
{
    internal class AstroUtilsMenuItems
    {

#if UNITY_EDITOR
        [MenuItem("GameObject/Astro Utils/Basic Player Controller", false, 1)]
        static void CreateBasicPlayerController(MenuCommand menuCommand)
        {
            // --- Create Game Object ---
            GameObject bpc = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            GameObject groundCheck = new GameObject("Ground Check");
            GameObject camHolder = new GameObject("Camera Holder");

            // --- Set BPC Settings ---
            bpc.name = "Basic Player Controller";
            bpc.transform.position += Vector3.up;

            BasicPlayerController controller = bpc.AddComponent<BasicPlayerController>();

            bpc.GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            controller.cameraHolder = camHolder.transform;

            // --- Set Ground Check Settings ---
            PlayerGroundCheck pgc = groundCheck.AddComponent<PlayerGroundCheck>();

            pgc.player = controller;
            controller.groundCheck = pgc;

            BoxCollider collider = groundCheck.AddComponent<BoxCollider>();
            collider.center = Vector3.down;
            collider.size = new Vector3(0.9f, 0.1f, 0.9f);
            collider.isTrigger = true;

            // --- Set Camera Settings ---
            Camera cam = Camera.main;
            if (cam == null)
            {
                GameObject camGo = new GameObject("Main Camera");
                camGo.tag = "MainCamera";
                cam = camGo.AddComponent<Camera>();
            }

            // --- Set Parents ---
            camHolder.transform.parent = bpc.transform;
            groundCheck.transform.parent = bpc.transform;
            cam.transform.parent = camHolder.transform;

            // --- Set Positions ---
            groundCheck.transform.localPosition = new Vector3(0, 0, 0);
            camHolder.transform.localPosition = new Vector3(0, 0.5f, 0);
            cam.transform.localPosition = Vector3.zero;

            // --- Set Editor Settings ---
            GameObjectUtility.SetParentAndAlign(bpc, (GameObject) menuCommand.context);
            Undo.RegisterCreatedObjectUndo(bpc, "Create " + bpc.name);
            Selection.activeObject = bpc;
        }
#endif
    }
}