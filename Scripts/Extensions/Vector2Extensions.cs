using UnityEngine;

namespace UnityUsefulUtils {
    public static class Vector2Extensions {
        /// <summary>
        /// Adds specified amounts to the x and y components of a Vector2.
        /// </summary>
        /// <param name="vector2">The original Vector2 to modify.</param>
        /// <param name="x">Amount to add to the x component.</param>
        /// <param name="y">Amount to add to the y component.</param>
        /// <returns>A new Vector2 with the added values.</returns>
        public static Vector2 Add(this Vector2 vector2, float x = 0, float y = 0) {
            return new Vector2(vector2.x + x, vector2.y + y);
        }

        /// <summary>
        /// Sets the specified components of a Vector2 to new values.
        /// </summary>
        /// <param name="vector2">The original Vector2 to modify.</param>
        /// <param name="x">New value for the x component, or null to leave unchanged.</param>
        /// <param name="y">New value for the y component, or null to leave unchanged.</param>
        /// <returns>A new Vector2 with the specified components set to new values.</returns>
        public static Vector2 With(this Vector2 vector2, float? x = null, float? y = null) {
            return new Vector2(x ?? vector2.x, y ?? vector2.y);
        }

        /// <summary>
        /// Determines whether the current Vector2 is within a specified range of another Vector2.
        /// </summary>
        /// <param name="current">The Vector2 to check.</param>
        /// <param name="target">The target Vector2 to compare against.</param>
        /// <param name="range">The maximum allowable distance between the two vectors.</param>
        /// <returns>True if the distance between the vectors is less than or equal to the specified range, otherwise false.</returns>
        public static bool InRangeOf(this Vector2 current, Vector2 target, float range) {
            return (current - target).sqrMagnitude <= range * range;
        }

        /// <summary>
        /// Normalizes the Vector2 to have a magnitude of 1, maintaining direction.
        /// </summary>
        /// <param name="vector2">The Vector2 to normalize.</param>
        /// <returns>A normalized Vector2 with the same direction.</returns>
        public static Vector2 Normalize(this Vector2 vector2) {
            return vector2.normalized;
        }

        /// <summary>
        /// Rotates the Vector2 by a specified angle in degrees.
        /// </summary>
        /// <param name="vector2">The Vector2 to rotate.</param>
        /// <param name="degrees">The angle in degrees to rotate the vector.</param>
        /// <returns>The rotated Vector2.</returns>
        public static Vector2 Rotate(this Vector2 vector2, float degrees) {
            float radians = degrees * Mathf.Deg2Rad;
            float sin = Mathf.Sin(radians);
            float cos = Mathf.Cos(radians);
            float tx = vector2.x;
            float ty = vector2.y;
            return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
        }
    }
}
