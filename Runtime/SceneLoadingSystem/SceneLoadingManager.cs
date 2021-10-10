using System;
using System.Collections;
using System.Collections.Generic;
using AstroTurffx.AstroUtils.UI;
using AstroTurffx.AstroUtils.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AstroTurffx.AstroUtils.SceneLoadingSystem{
    public class SceneLoadingManager : Singleton<SceneLoadingManager>
    {
        public bool canLoadScene = true;
        public void Load(string sceneName, Action<AsyncOperation> onCompleted)
        {
            canLoadScene = false;
            Debug.Log($"Loading Scene \"{sceneName}\".");
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);

            op.completed += (op) => Invoke("ResetLoadScene", 2f);
            op.completed += onCompleted;

            if(LoadingScreen.Instance) LoadingScreen.Instance.StartLoadingScreen(op);
        }

        void ResetLoadScene() => canLoadScene = true;
    }
}