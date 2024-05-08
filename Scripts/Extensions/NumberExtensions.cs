using System;
using UnityEngine;
#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

namespace UnityUsefulUtils {
    public static class NumberExtensions {
        /// <summary>
        /// Calculates the percentage of the part value relative to the whole.
        /// </summary>
        public static float PercentageOf(this int part, int whole) {
            if (whole == 0) return 0; // Avoid division by zero
            return (float)part / whole * 100; // Ensure percentage is scaled by 100
        }
        
        /// <summary>
        /// Determines if an integer is odd.
        /// </summary>
        public static bool IsOdd(this int i) => i % 2 != 0;

        /// <summary>
        /// Determines if an integer is even.
        /// </summary>
        public static bool IsEven(this int i) => i % 2 == 0;

        /// <summary>
        /// Ensures that a value is at least a minimum value.
        /// </summary>
        public static int AtLeast(this int value, int min) => Math.Max(value, min);

        /// <summary>
        /// Ensures that a value does not exceed a maximum value.
        /// </summary>
        public static int AtMost(this int value, int max) => Math.Min(value, max);

#if ENABLED_UNITY_MATHEMATICS
        public static half AtLeast(this half value, half min) => math.max(value, min);
        public static half AtMost(this half value, half max) => math.min(value, max);
#endif

        /// <summary>
        /// Ensures that a value is at least a minimum value.
        /// </summary>
        public static float AtLeast(this float value, float min) => Math.Max(value, min);

        /// <summary>
        /// Ensures that a value does not exceed a maximum value.
        /// </summary>
        public static float AtMost(this float value, float max) => Math.Min(value, max);

        /// <summary>
        /// Ensures that a value is at least a minimum value.
        /// </summary>
        public static double AtLeast(this double value, double min) => Math.Max(value, min);

        /// <summary>
        /// Ensures that a value does not exceed a maximum value.
        /// </summary>
        public static double AtMost(this double value, double max) => Math.Min(value, max);
    }
}
