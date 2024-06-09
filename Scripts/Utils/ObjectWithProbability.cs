using System;
using System.Collections.Generic;

namespace UnityUsefulUtils
{
    public static class ObjectWithProbability
    {
                /// <summary>
        /// Converts a list of objects to a list of objects with associated probabilities.
        /// </summary>
        /// <typeparam name="T">The type of objects in the list.</typeparam>
        /// <param name="list">The list of objects to convert.</param>
        /// <param name="prob">The list of probabilities corresponding to each object.</param>
        /// <returns>A list of objects each wrapped with a probability.</returns>
        public static List<ObjectWithProbability<T>> ObjectListToProbabilityList<T>(this IList<T> list, IList<int> prob)
        {
            if (list == null || prob == null) throw new ArgumentNullException("List or probability list cannot be null.");
            if (list.Count != prob.Count) throw new ArgumentException("Object list and probability list must have the same number of elements.");

            List<ObjectWithProbability<T>> result = new List<ObjectWithProbability<T>>();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(new ObjectWithProbability<T>(list[i], prob[i]));
            }
            return result;
        }

        /// <summary>
        /// Return a random item with probability from the list.
        /// Sampling with replacement.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T SelectObjectWithProbability<T>(this IList<ObjectWithProbability<T>> list)
        {

            int poolSize = 0;
            for (int i = 0; i < list.Count; i++)
            {
                poolSize += list[i].Probability;
            }


            int randomNumber = UnityEngine.Random.Range(0, poolSize);


            int accumulatedProbability = 0;
            for (int i = 0; i < list.Count; i++)
            {
                accumulatedProbability += list[i].Probability;
                if (randomNumber <= accumulatedProbability)
                    return list[i].GenericObject;
            }

            throw new System.IndexOutOfRangeException("Cannot select a random item");
        }

    }

    [Serializable]
    public struct ObjectWithProbability<T>
    {
        public T GenericObject;
        public int Probability;

        public ObjectWithProbability(T obj, int probability)
        {
            GenericObject = obj;
            Probability = probability;
        }
    }
}
