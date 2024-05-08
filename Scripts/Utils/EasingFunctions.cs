using System;
namespace UnityUsefulUtils
{

    public enum Ease
    {
        Linear,
        InQuad,
        OutQuad,
        InOutQuad,
        InCubic,
        OutCubic,
        InOutCubic,
        InQuart,
        OutQuart,
        InOutQuart,
        InQuint,
        OutQuint,
        InOutQuint,
        InSine,
        OutSine,
        InOutSine,
        InExpo,
        OutExpo,
        InOutExpo,
        InCirc,
        OutCirc,
        InOutCirc,
        InBack,
        OutBack,
        InOutBack,
        InElastic,
        OutElastic,
        InOutElastic

    }
    
    public enum LoopType
    {
        Restart,
        Yoyo,
        Incremental
    }


    public static class Easing
    {



        #region  Easing Functions

        static float EaseLinear(float t) => t;

        static float EaseInQuad(float t) => t * t;
        static float EaseOutQuad(float t) => t * (2 - t);
        static float EaseInOutQuad(float t) => t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
        static float EaseInCubic(float t) => t * t * t;
        static float EaseOutCubic(float t) => (t -= 1) * t * t + 1;
        static float EaseInOutCubic(float t) => t < 0.5f ? 4 * t * t * t : (t - 1) * (2 * t - 2) * (2 * t - 2) + 1;
        static float EaseInQuart(float t) => t * t * t * t;
        static float EaseOutQuart(float t) => 1 - (--t) * t * t * t;
        static float EaseInOutQuart(float t) => t < 0.5f ? 8 * t * t * t * t : 1 - 8 * (t - 1) * t * t * t;
        static float EaseInQuint(float t) => t * t * t * t * t;
        static float EaseOutQuint(float t) => 1 + (--t) * t * t * t * t;
        static float EaseInOutQuint(float t) => t < 0.5f ? 16 * t * t * t * t * t : 1 + 16 * (t - 1) * t * t * t * t;
        static float EaseInSine(float t) => (float)(1 - Math.Cos(t * Math.PI / 2));
        static float EaseOutSine(float t) => (float)(Math.Sin(t * Math.PI / 2));
        static float EaseInOutSine(float t) => (float)(-0.5f * (Math.Cos(Math.PI * t) - 1));
        static float EaseInExpo(float t) => (float)(t == 0 ? 0 : Math.Pow(2, 10 * t - 10));
        static float EaseOutExpo(float t) => (float)(t == 1 ? 1 : 1 - Math.Pow(2, -10 * t));
        static float EaseInOutExpo(float t) => (float)(t == 0 ? 0 : t == 1 ? 1 : t < 0.5f ? 0.5f * Math.Pow(2, 20 * t - 10) : 1 - 0.5f * Math.Pow(2, -20 * t + 10));
        static float EaseInCirc(float t) => (float)(1 - Math.Sqrt(1 - t * t));
        static float EaseOutCirc(float t) => (float)(Math.Sqrt(1 - (--t) * t));
        static float EaseInOutCirc(float t) => (float)(t < 0.5f ? 0.5f * (1 - Math.Sqrt(1 - 4 * t * t)) : 0.5f * (Math.Sqrt(-((2 * t - 3) * (2 * t - 1))) + 1));
        static float EaseInBack(float t) => t * t * (2.70158f * t - 1.70158f);
        static float EaseOutBack(float t) => 1 + (--t) * t * (2.70158f * t + 1.70158f);
        static float EaseInOutBack(float t) => t < 0.5f ? 0.5f * (2 * t * 2 * t * ((2.70158f + 1) * 2 * t - 2.70158f)) : 0.5f * ((2 * t - 2) * (2 * t - 2) * ((2.70158f + 1) * (2 * t - 2) + 2.70158f) + 2);
        static float EaseInElastic(float t) => (float)(Math.Sin(13 * Math.PI / 2 * t) * Math.Pow(2, 10 * (t - 1)));
        static float EaseOutElastic(float t) => (float)(Math.Sin(-13 * Math.PI / 2 * (t + 1)) * Math.Pow(2, -10 * t) + 1);
        static float EaseInOutElastic( float t) => (float)(t < 0.5f ? 0.5f * Math.Sin(13 * Math.PI / 2 * t) * Math.Pow(2, 10 * (2 * t - 1)) : 0.5f * Math.Sin(-13 * Math.PI / 2 * (2 * t - 1)) * Math.Pow(2, -10 * (2 * t - 1)) + 1);

        #endregion
        
        /// <summary>
        /// Evaluates the easing function based on the specified 'Ease' type and progress.
        /// </summary>
        public static float Evaluate(Ease ease, float t)
        {
            switch (ease)
            {
                case Ease.Linear: return EaseLinear(t);
                case Ease.InQuad: return EaseInQuad(t);
                case Ease.OutQuad: return EaseOutQuad(t);
                case Ease.InOutQuad: return EaseInOutQuad(t);
                case Ease.InCubic: return EaseInCubic(t);
                case Ease.OutCubic: return EaseOutCubic(t);
                case Ease.InOutCubic: return EaseInOutCubic(t);
                case Ease.InQuart: return EaseInQuart(t);
                case Ease.OutQuart: return EaseOutQuart(t);
                case Ease.InOutQuart: return EaseInOutQuart(t);
                case Ease.InQuint: return EaseInQuint(t);
                case Ease.OutQuint: return EaseOutQuint(t);
                case Ease.InOutQuint: return EaseInOutQuint(t);
                case Ease.InSine: return EaseInSine(t);
                case Ease.OutSine: return EaseOutSine(t);
                case Ease.InOutSine: return EaseInOutSine(t);
                case Ease.InExpo: return EaseInExpo(t);
                case Ease.OutExpo: return EaseOutExpo(t);
                case Ease.InOutExpo: return EaseInOutExpo(t);
                case Ease.InCirc: return EaseInCirc(t);
                case Ease.OutCirc: return EaseOutCirc(t);
                case Ease.InOutCirc: return EaseInOutCirc(t);
                case Ease.InBack: return EaseInBack(t);
                case Ease.OutBack: return EaseOutBack(t);
                case Ease.InOutBack: return EaseInOutBack(t);
                case Ease.InElastic: return EaseInElastic(t);
                case Ease.OutElastic: return EaseOutElastic(t);
                case Ease.InOutElastic: return EaseInOutElastic(t);
                default: return t;
            }
        }
        
        /// <summary>
        /// Applies tweening using an easing function, time progression, duration, and optionally loop type.
        /// </summary>
        public static float Tween(Ease ease, float time, float duration, LoopType loopType = default)
        {
            float normalizedTime = time / duration;
            switch (loopType)
            {
                case LoopType.Restart:
                    normalizedTime = Restart(time, duration) / duration;
                    break;
                case LoopType.Yoyo:
                    normalizedTime = PingPong(time, duration) / duration;
                    break;
                case LoopType.Incremental:
                    normalizedTime = (time % duration) / duration;
                    break;
                default:
                    Evaluate(ease, normalizedTime);
                    break;
            }
            return Evaluate(ease, normalizedTime);
        }
        static float PingPong(float t, float duration)
        {
            t = Restart(t, duration);
            return duration - Math.Abs(duration - 2 * t);
        }
        static float Restart(float t, float duration)
        {
            return (float)(Math.Clamp(t % duration, 0.0f, duration));
        }
        
    }
    
}