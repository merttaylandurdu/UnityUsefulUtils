using UnityEngine;

namespace UnityUsefulUtils {
    public static class RendererExtensions {
        /// <summary>
        /// Enables ZWrite for materials in this Renderer. This will allow the materials 
        /// to write to the Z buffer, which can help ensure correct layering of transparent objects.
        /// </summary>
        /// <param name="renderer">The Renderer whose materials will be modified.</param>
        public static void EnableZWrite(this Renderer renderer) {
            if (renderer == null) {
                Debug.LogError("Renderer is null.");
                return;
            }

            var materials = renderer.materials;
            if (materials == null) {
                Debug.LogError("Materials array is null.");
                return;
            }

            foreach (Material material in materials) {
                if (material != null && material.HasProperty("_ZWrite")) {
                    material.SetInt("_ZWrite", 1);
                    material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                }
            }
        }

        /// <summary>
        /// Disables ZWrite for materials in this Renderer. This can prevent subsequent 
        /// rendering from being occluded, like in rendering of semi-transparent or layered objects.
        /// </summary>
        /// <param name="renderer">The Renderer whose materials will be modified.</param>
        public static void DisableZWrite(this Renderer renderer) {
            if (renderer == null) {
                Debug.LogError("Renderer is null.");
                return;
            }

            var materials = renderer.materials;
            if (materials == null) {
                Debug.LogError("Materials array is null.");
                return;
            }

            foreach (Material material in materials) {
                if (material != null && material.HasProperty("_ZWrite")) {
                    material.SetInt("_ZWrite", 0);
                    material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent + 100;
                }
            }
        }
    }
}
