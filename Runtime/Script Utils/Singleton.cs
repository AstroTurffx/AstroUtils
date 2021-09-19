using UnityEngine;

namespace AstroUtils
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        public virtual void Awake()
        {
            T t = GetComponent<T>();
            if (Instance == null) Instance = t;
            else if (Instance != t)
            {
                Debug.LogError($"There are mutliple {typeof(T).Name} in the scene!");
                Destroy(gameObject);
            }
        }
    }
}
