using System.Collections;
using System.Collections.Generic;
using AstroTurffx.AstroUtils.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AstroTurffx.AstroUtils.SceneLoadingSystem
{
    public class LoadSceneTrigger : MonoBehaviour
    {
        public LoadTrigger loadTrigger = LoadTrigger.Enter;
        public LayerMask layerMask;
        public string scene = "Load Scene Name";

        private bool loading = false;

        private void OnTriggerEnter(Collider other)
        {
            if (loadTrigger == LoadTrigger.Enter)
                OnTrigger(other);
        }

        private void OnTriggerExit(Collider other)
        {
            if (loadTrigger == LoadTrigger.Exit)
                OnTrigger(other);
        }

        private void OnTrigger(Collider other)
        {
            if (!loading && layerMask == (layerMask | 1 << other.gameObject.layer))
                Load();
            
        }

        public void Load()
        {
            if (SceneLoadingManager.Instance == null)
                new GameObject("Scene Loading Manager").AddComponent<SceneLoadingManager>();

            if (SceneLoadingManager.Instance.canLoadScene)
            {
                loading = true;
                SceneLoadingManager.Instance.Load(scene, (op) => loading = false);
            }
        }
    }

    public enum LoadTrigger { Enter, Exit }
}