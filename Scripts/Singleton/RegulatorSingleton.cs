using UnityEngine;

namespace UnityUsefulUtils {
    /// <summary>
    /// Persistent Regulator singleton, will destroy any other older components of the same type it finds on awake.
    /// </summary>
    public class RegulatorSingleton<T> : MonoBehaviour where T : Component {
        private static T instance;

        public static bool HasInstance => instance != null;

        public float InitializationTime { get; private set; }

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
                Debug.Log($"{typeof(T).Name} regulator instance destroyed.");
                instance = null;
            }
        }

        private static T FindOrCreateInstance() {
            T foundInstance = FindObjectOfType<T>();
            if (foundInstance != null) {
                return foundInstance;
            }

            var go = new GameObject($"{typeof(T).Name} Auto-Generated");
            go.hideFlags = HideFlags.HideAndDontSave;
            instance = go.AddComponent<T>();
            Debug.Log($"{typeof(T).Name} regulator instance created.");
            return instance;
        }

        protected void InitializeSingleton() {
            InitializationTime = Time.time;
            DontDestroyOnLoad(gameObject);

            T[] allInstances = FindObjectsOfType<T>();
            foreach (T old in allInstances) {
                var regulator = old.GetComponent<RegulatorSingleton<T>>();
                if (regulator && regulator.InitializationTime < InitializationTime) {
                    Debug.Log($"Destroying older instance of {typeof(T).Name} created at {regulator.InitializationTime}.");
                    Destroy(old.gameObject);
                }
            }

            if (instance == null) {
                instance = this as T;
            }
        }
    }
}
