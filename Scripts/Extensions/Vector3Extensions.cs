using System.Collections.Generic;
using UnityEngine;

namespace UnityUsefulUtils {
    public static class Vector3Extensions {

        //Original repo https://github.com/adammyhre/Unity-Utils
        /// <summary>
        /// Sets the specified components of a Vector3 to new values.
        /// </summary>
        /// <param name="vector">The original Vector3 to modify.</param>
        /// <param name="x">New value for the x component, or null to leave unchanged.</param>
        /// <param name="y">New value for the y component, or null to leave unchanged.</param>
        /// <param name="z">New value for the z component, or null to leave unchanged.</param>
        /// <returns>A new Vector3 with the specified components set to new values.</returns>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) {
            return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }

        /// <summary>
        /// Adds specified amounts to the x, y, and z components of a Vector3.
        /// </summary>
        /// <param name="vector">The original Vector3 to modify.</param>
        /// <param name="x">Amount to add to the x component.</param>
        /// <param name="y">Amount to add to the y component.</param>
        /// <param name="z">Amount to add to the z component.</param>
        /// <returns>A new Vector3 with the added values.</returns>
        public static Vector3 Add(this Vector3 vector, float x = 0, float y = 0, float z = 0) {
            return new Vector3(vector.x + x, vector.y + y, vector.z + z);
        }

        /// <summary>
        /// Adds another Vector3 to the current Vector3.
        /// </summary>
        /// <param name="vector">The original Vector3 to modify.</param>
        /// <param name="addition">The Vector3 to add.</param>
        /// <returns>A new Vector3 with the added values.</returns>
        public static Vector3 Add(this Vector3 vector, Vector3 addition) {
            return vector + addition;
        }

        /// <summary>
        /// Determines whether the current Vector3 is within a specified range of another Vector3.
        /// </summary>
        /// <param name="current">The Vector3 to check.</param>
        /// <param name="target">The target Vector3 to compare against.</param>
        /// <param name="range">The maximum allowable distance between the two vectors.</param>
        /// <returns>True if the distance between the vectors is less than or equal to the specified range, otherwise false.</returns>
        public static bool InRangeOf(this Vector3 current, Vector3 target, float range) {
            return (current - target).sqrMagnitude <= range * range;
        }

        /// <summary>
        /// Divides each component of the first Vector3 by the corresponding component of the second Vector3, unless the divisor is zero, in which case the original component value is retained.
        /// </summary>
        /// <param name="v0">The Vector3 to be divided.</param>
        /// <param name="v1">The Vector3 by which to divide.</param>
        /// <returns>A new Vector3 after component-wise division.</returns>
        public static Vector3 ComponentDivide(this Vector3 v0, Vector3 v1){
            return new Vector3(
                v1.x != 0 ? v0.x / v1.x : v0.x,
                v1.y != 0 ? v0.y / v1.y : v0.y,
                v1.z != 0 ? v0.z / v1.z : v0.z);  
        }

        /// <summary>
        /// Finds the position closest to a given position from a list of positions.
        /// </summary>
        /// <param name="position">The reference position to compare against.</param>
        /// <param name="otherPositions">A collection of positions to evaluate.</param>
        /// <returns>The position from the list that is closest to the given reference position.</returns>
        public static Vector3 GetClosest(this Vector3 position, IEnumerable<Vector3> otherPositions) {
            var closest = Vector3.zero;
            var shortestDistance = Mathf.Infinity;

            foreach (var otherPosition in otherPositions) {
                var distance = (position - otherPosition).sqrMagnitude;

                if (distance < shortestDistance) {
                    closest = otherPosition;
                    shortestDistance = distance;
                }
            }

            return closest;
        }
    }
}
