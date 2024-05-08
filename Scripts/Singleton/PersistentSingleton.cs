using UnityEngine;

namespace UnityUsefulUtils {
    public class PersistentSingleton<T> : MonoBehaviour where T : Component {
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
            } else if (instance != this) {
                Debug.Log($"Another instance of {typeof(T).Name} was found, which will be destroyed.");
                Destroy(gameObject);
            }

            if (autoUnparentOnAwake) {
                transform.SetParent(null);
            }
        }

        [SerializeField]
        private bool autoUnparentOnAwake = true;

        public bool AutoUnparentOnAwake {
            get => autoUnparentOnAwake;
            set => autoUnparentOnAwake = value;
        }
    }
}