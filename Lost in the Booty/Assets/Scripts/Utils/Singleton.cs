using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class Singleton<T> : MonoBehaviour
        where T : Singleton<T>
    {
        private static T instance;
        public static T Instance
        {
            get { return instance; }
        }

        public static bool isInitialized
        {
            get { return instance != null; }
        }

        protected virtual void Awake()
        {
            if (instance != null)
            {
                Debug.LogError(
                    $"[Singleton] Trying to instantiate a second instance of {GetType().Name} Singleton class."
                );
                Destroy(instance.gameObject);
                instance = (T)this;
            }
            else
            {
                instance = (T)this;
            }
        }

        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
    }
}
