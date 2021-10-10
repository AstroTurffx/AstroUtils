using System.Collections;
using System.Collections.Generic;
using AstroTurffx.AstroUtils.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AstroTurffx.AstroUtils.UI
{

    public class LoadingScreen : Singleton<LoadingScreen>
    {
        public GameObject loadingScreen;
        public Slider progressSlider;

        private bool loading = false;
        private AsyncOperation loadSceneOperation;

        void Update()
        {
            loadingScreen.SetActive(loading);

            if (loadSceneOperation != null)
            {
                LoadUpdate(Mathf.InverseLerp(0f, 0.9f, loadSceneOperation.progress));
            }
        }

        public void StartLoadingScreen(AsyncOperation operation)
        {
            loading = true;
            loadSceneOperation = operation;

            LoadStart();

            loadSceneOperation.completed += (op) =>
            {
                loading = false;
                loadSceneOperation = null;
                LoadEnd();
            };
        }

        protected virtual void LoadStart() { }
        protected virtual void LoadUpdate(float progress)
        {
            if (progressSlider)
            {
                progressSlider.value = progress;
            }
        }
        protected virtual void LoadEnd() { }
    }
}