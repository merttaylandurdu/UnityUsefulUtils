using UnityEngine;

namespace UnityUsefulUtils {
    public class Singleton<T> : MonoBehaviour where T : Component {
        private static T instance;

        public static bool HasInstance => instance != null;

        public static T Instance {
            get {
                if (instance == null) {
                    instance = FindOrCreateInstance();
                }
                return instance;
            }
        }

        protected virtual void Awake() {
            if (!Application.isPlaying) {
                return;
            }
            InitializeSingleton();
        }

        private void OnDestroy() {
            if (instance == this) {
                Debug.Log($"{typeof(T).Name} singleton instance destroyed.");
                instance = null;
            }
        }

        private static T FindOrCreateInstance() {
            T foundInstance = FindObjectOfType<T>();
            if (foundInstance != null) {
                return foundInstance;
            }

            var go = new GameObject($"{typeof(T).Name} Auto-Generated");
            instance = go.AddComponent<T>();
            Debug.Log($"{typeof(T).Name} singleton instance created.");
            return instance;
        }

        protected void InitializeSingleton() {
            if (instance == null) {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            } else {
                Debug.Log($"Another instance of {typeof(T).Name} was detected and will be destroyed.");
                Destroy(gameObject);
            }
        }
    }
}