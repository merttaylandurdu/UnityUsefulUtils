using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityUsefulUtils
{


    public static class CollectionsExtensions
    {
        private static Random rng = new Random();

        /// <summary>
        /// Performs an action on each element in the sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence to iterate over.</param>
        /// <param name="action">The action to perform on each element.</param>
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence), "The sequence cannot be null.");
            if (action == null) throw new ArgumentNullException(nameof(action), "Action cannot be null.");
            foreach (var item in sequence)
            {
                action(item);
            }
        }

        /// <summary>
        /// Return a random item from the list. Sampling with replacement.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to sample from.</param>
        /// <returns>A random item from the list.</returns>
        public static T GetRandomItem<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0) throw new InvalidOperationException("Cannot select a random item from an empty or null list.");
            return list[rng.Next(list.Count)];
        }

        /// <summary>
        /// Removes a random item from the list, returning that item. Sampling without replacement.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list from which to remove an item.</param>
        /// <returns>The removed item.</returns>
        public static T RemoveRandom<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0) throw new InvalidOperationException("Cannot remove a random item from an empty or null list.");
            int index = rng.Next(list.Count);
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }

        /// <summary>
        /// Shuffle the list in place using the Fisher-Yates method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to shuffle.</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list), "List cannot be null.");
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Batches the elements of a sequence into smaller sized collections.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The sequence to partition into smaller batches.</param>
        /// <param name="size">The maximum size of each batch.</param>
        /// <returns>An IEnumerable of IEnumerable containing the batched items.</returns>
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
        {
            List<T> batch = new List<T>(size);
            foreach (var item in source)
            {
                batch.Add(item);
                if (batch.Count == size)
                {
                    yield return batch;
                    batch = new List<T>(size);
                }
            }
            if (batch.Any())
            {
                yield return batch;
            }
        }

        /// <summary>
        /// Produces a distinct set from a sequence by using a specified key selector to compare values.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by the key selector.</typeparam>
        /// <param name="source">The sequence to remove duplicates from.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <returns>An IEnumerable containing distinct elements from the source sequence.</returns>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (T element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the ICollection.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <param name="collection">The collection to add items to.</param>
        /// <param name="items">The items to add to the collection.</param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Determines whether the collection is empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to check for emptiness.</param>
        /// <returns>True if the collection is empty; otherwise, false.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        /// <summary>
        /// Finds the indices of all items in a list that match the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to search within.</param>
        /// <param name="predicate">The predicate to match items against.</param>
        /// <returns>An IEnumerable of integers representing the indices of matching items.</returns>
        public static IEnumerable<int> FindIndices<T>(this IList<T> list, Func<T, bool> predicate)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (predicate(list[i]))
                {
                    yield return i;
                }
            }
        }

        /// <summary>
        /// Removes all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list from which to remove elements.</param>
        /// <param name="match">The predicate that defines the conditions of the elements to remove.</param>
        public static void RemoveAll<T>(this IList<T> list, Predicate<T> match)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (match(list[i]))
                {
                    list.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Resizes a two-dimensional array to the specified dimensions.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="original">The original array to resize.</param>
        /// <param name="newCoNum">New number of columns.</param>
        /// <param name="newRoNum">New number of rows.</param>
        /// <returns>A new array with resized dimensions.</returns>
        public static T[,] ResizeArray<T>(this T[,] original, int newCoNum, int newRoNum)
        {
            var newArray = new T[newCoNum, newRoNum];
            int minRows = Math.Min(original.GetLength(0), newRoNum);
            int minCols = Math.Min(original.GetLength(1), newCoNum);
            for (int i = 0; i < minRows; i++)
            {
                for (int j = 0; j < minCols; j++)
                {
                    newArray[i, j] = original[i, j];
                }
            }
            return newArray;
        }

        /// <summary>
        /// Retrieves the maximum element of a sequence according to a specified key selector.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">The sequence to return an element from.</param>
        /// <param name="keySelector">A function to extract the key from an element.</param>
        /// <returns>The element in the sequence that has the maximum value in the key selected by keySelector.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the source sequence is empty.</exception>
        public static T MaxBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
        {
            if (source == null) throw new ArgumentNullException(nameof(source), "Source cannot be null.");
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector), "Key selector cannot be null.");
            if (!source.Any()) throw new InvalidOperationException("Cannot perform MaxBy on an empty sequence.");

            T maxElement = source.First();
            TKey maxKey = keySelector(maxElement);
            foreach (var element in source.Skip(1))
            {
                TKey currentKey = keySelector(element);
                if (currentKey.CompareTo(maxKey) > 0)
                {
                    maxKey = currentKey;
                    maxElement = element;
                }
            }
            return maxElement;
        }


        /// <summary>
        /// Retrieves the minimum element of a sequence according to a specified key selector.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">The sequence to return an element from.</param>
        /// <param name="keySelector">A function to extract the key from an element.</param>
        /// <returns>The element in the sequence that has the minimum value in the key selected by keySelector.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the source sequence is empty.</exception>
        public static T MinBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
        {
            if (source == null) throw new ArgumentNullException(nameof(source), "Source cannot be null.");
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector), "Key selector cannot be null.");
            if (!source.Any()) throw new InvalidOperationException("Cannot perform MinBy on an empty sequence.");

            T minElement = source.First();
            TKey minKey = keySelector(minElement);
            foreach (var element in source.Skip(1))
            {
                TKey currentKey = keySelector(element);
                if (currentKey.CompareTo(minKey) < 0)
                {
                    minKey = currentKey;
                    minElement = element;
                }
            }
            return minElement;
        }

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
        public T GenericObject { get; set; }
        public int Probability { get; set; }

        public ObjectWithProbability(T obj, int probability)
        {
            GenericObject = obj;
            Probability = probability;
        }
    }
}