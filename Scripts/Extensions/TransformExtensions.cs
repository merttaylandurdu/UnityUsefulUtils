using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UnityUsefulUtils {
    public static class TransformExtensions {

        /// <summary>
        /// Check if the transform is within a certain distance and optionally within a certain angle from the target transform.
        /// </summary>
        /// <param name="source">The source transform.</param>
        /// <param name="target">The target transform to compare against.</param>
        /// <param name="maxDistance">The maximum distance allowed between the two transforms.</param>
        /// <param name="maxAngle">The maximum allowed angle in degrees.</param>
        /// <param name="ignoreY">Whether to ignore the Y component when calculating the direction and distance.</param>
        /// <returns>True if within the specified range and angle, false otherwise.</returns>
        public static bool InRangeOf(this Transform source, Transform target, float maxDistance, float maxAngle = 360f, bool ignoreY = true) {
            Vector3 directionToTarget = ignoreY ? (target.position - source.position).With(y: 0) : target.position - source.position;
            float distance = Vector3.Distance(source.position, target.position);
            return distance <= maxDistance && Vector3.Angle(source.forward, directionToTarget) <= maxAngle / 2;
        }

        /// <summary>
        /// Retrieves all the children of a given Transform.
        /// </summary>
        /// <param name="parent">The Transform from which to retrieve children.</param>
        /// <returns>An IEnumerable containing all the child Transforms of the parent.</returns>
        public static IEnumerable<Transform> Children(this Transform parent) {
            foreach (Transform child in parent) {
                yield return child;
            }
        }

        /// <summary>
        /// Resets the transform's position, scale, and rotation to default.
        /// </summary>
        /// <param name="transform">The Transform to reset.</param>
        public static void Reset(this Transform transform) {
            transform.position = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Destroys all child game objects of the specified transform.
        /// </summary>
        /// <param name="parent">The Transform whose children will be destroyed.</param>
        public static void DestroyChildren(this Transform parent) {
            parent.ForEveryChild(child => Object.Destroy(child.gameObject));
        }

        /// <summary>
        /// Immediately destroys all child game objects of the specified transform.
        /// </summary>
        /// <param name="parent">The Transform whose children will be immediately destroyed.</param>
        public static void DestroyChildrenImmediate(this Transform parent) {
            parent.ForEveryChild(child => Object.DestroyImmediate(child.gameObject));
        }

        /// <summary>
        /// Enables all child game objects of the specified transform.
        /// </summary>
        /// <param name="parent">The Transform whose children will be enabled.</param>
        public static void EnableChildren(this Transform parent) {
            parent.ForEveryChild(child => child.gameObject.SetActive(true));
        }

        /// <summary>
        /// Disables all child game objects of the specified transform.
        /// </summary>
        /// <param name="parent">The Transform whose children will be disabled.</param>
        public static void DisableChildren(this Transform parent) {
            parent.ForEveryChild(child => child.gameObject.SetActive(false));
        }

        /// <summary>
        /// Executes a specified action on each child of a transform.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
        /// <param name="action">The action to perform on each child.</param>
        public static void ForEveryChild(this Transform parent, Action<Transform> action) {
            for (int i = parent.childCount - 1; i >= 0; i--) {
                action(parent.GetChild(i));
            }
        }

        [Obsolete("Renamed to ForEveryChild to better reflect functionality")]
        static void PerformActionOnChildren(this Transform parent, Action<Transform> action) {
            parent.ForEveryChild(action);
        }
    }
}
