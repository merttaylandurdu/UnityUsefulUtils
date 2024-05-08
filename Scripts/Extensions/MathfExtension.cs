using System;
#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

namespace UnityUsefulUtils {
    public static class MathfExtension {
        #region Min Methods

#if ENABLED_UNITY_MATHEMATICS
        public static half Min(half a, half b) => a < b ? a : b;

        public static half Min(params half[] values) {
            if (values.Length == 0) {
                throw new InvalidOperationException("Cannot perform Min on an empty array.");
            }

            half min = values[0];
            for (int i = 1; i < values.Length; i++) {
                if (values[i] < min) {
                    min = values[i];
                }
            }
            return min;
        }
#endif

        public static double Min(double a, double b) => a < b ? a : b;

        public static double Min(params double[] values) {
            if (values.Length == 0) {
                throw new InvalidOperationException("Cannot perform Min on an empty array.");
            }

            double min = values[0];
            for (int i = 1; i < values.Length; i++) {
                if (values[i] < min) {
                    min = values[i];
                }
            }
            return min;
        }

        #endregion

        #region Max Methods

#if ENABLED_UNITY_MATHEMATICS
        public static half Max(half a, half b) => a > b ? a : b;

        public static half Max(params half[] values) {
            if (values.Length == 0) {
                throw new InvalidOperationException("Cannot perform Max on an empty array.");
            }

            half max = values[0];
            for (int i = 1; i < values.Length; i++) {
                if (values[i] > max) {
                    max = values[i];
                }
            }
            return max;
        }
#endif

        public static double Max(double a, double b) => a > b ? a : b;

        public static double Max(params double[] values) {
            if (values.Length == 0) {
                throw new InvalidOperationException("Cannot perform Max on an empty array.");
            }

            double max = values[0];
            for (int i = 1; i < values.Length; i++) {
                if (values[i] > max) {
                    max = values[i];
                }
            }
            return max;
        }

        #endregion
    }
}
