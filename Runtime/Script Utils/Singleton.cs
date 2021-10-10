using UnityEngine;

namespace AstroTurffx.AstroUtils.Utils
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        public virtual void Awake()
        {
            T t = GetComponent<T>();
            if (Instance == null)
            {
                Instance = t;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != t)
            {
                Debug.LogWarning($"There are multiple {typeof(T).Name} in the scene!");
                Destroy(gameObject);
            }
        }
    }
}
