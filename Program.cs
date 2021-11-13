using System;
using System.Collections.Generic;
using System.Linq;

namespace maineconsole
{
    delegate void InformResultDelegate(string result);
    class Program
    {
        static void Main(string[] args)
        {
            // var result = SelectionSort(new List<int> { 5, 3, 6, 2, 10 });
            // CountDown(10);
            // Console.WriteLine(Fact(3));
            // Console.WriteLine(Sum(new List<int> { 5, 3, 6, 2, 10 }));
            // Console.WriteLine(Count(new List<int> { 5, 3, 6, 2, 10, 5, 3, 6, 2, 10, 5, 3, 6, 2, 10, 1, 1, 1 }));
            // Console.WriteLine(Max(new List<int> { 1, 11, 2, 3, 22, 4 }));
            // var result = QuickSort(new int[] { 10, 5, 2, 6, 9, 3, 7, 4, 8, 1 });
            // foreach (var r in result)
            // {
            //     Console.WriteLine(r);
            // }
            BreadthFirstSearch("you");
            Console.ReadLine();
        }
        static void Main2(string[] args)
        {
            InformResultDelegate informResultDelegate = new InformResultDelegate(Console.WriteLine);
            var intArray = new int[] { 1, 3, 5, 7, 9 };

        ReadAgain:

            var inputStr = Console.ReadLine();
            int.TryParse(inputStr, out int input);
            var result = BinarySearch(intArray, input);
            informResultDelegate(result.ToString());

            goto ReadAgain;
        }

        static int? BinarySearch(int[] array, int item)
        {
            int low = 0;
            int high = array.Length - 1;
            int mid = 0;
            int guess = 0;

            while (low <= high)
            {
                mid = (low + high) / 2;
                guess = array[mid];

                if (guess == item) return mid;
                else if (guess > item) high = mid - 1;
                else low = mid + 1;
            }

            return null;
        }

        static List<int> SelectionSort(List<int> input)
        {
            int length = input.Count;
            var newList = new List<int>(length);
            for (int i = 0; i < length; i++)
            {
                var smallestIndex = FindSmallestIndex(input);
                newList.Add(input[smallestIndex]);
                input.RemoveAt(smallestIndex);
            }

            return newList;
        }

        static int FindSmallestIndex(List<int> input)
        {
            int smallest = input[0];
            int smallestIndex = 0;

            for (int i = 1; i < input.Count; i++)
            {
                if (input[i] < smallest)
                {
                    smallest = input[i];
                    smallestIndex = i;
                }
            }

            return smallestIndex;
        }

        static void CountDown(int count)
        {
            Console.WriteLine(count);
            //base case
            if (count <= 0) return;
            //recursive case
            else CountDown(count - 1);
        }

        static int Fact(int x)
        {
            if (x == 1) return 1;
            else return x * Fact(x - 1);
        }

        static int Sum(List<int> list)
        {
            if (list.Count == 1)
            {
                return list[0];
            }
            else
            {
                var firstValue = list[0];
                list.RemoveAt(0);
                return firstValue + Sum(list);
            }
        }

        static int Count(List<int> list)
        {
            if (list.Count == 1)
            {
                return 1;
            }
            else
            {
                list.RemoveAt(0);
                return 1 + Count(list);
            }
        }

        static int Max(List<int> list)
        {
            if (list.Count == 2)
            {
                return list[0] > list[1] ? list[0] : list[1];
            }
            else
            {
                var firstValue = list[0];
                list.RemoveAt(0);
                var subMax = Max(list);
                return firstValue > subMax ? firstValue : subMax;
            }
        }

        static int[] QuickSort(int[] inputArray)
        {
            if (inputArray.Length < 2)
            {
                return inputArray;
            }
            else
            {

                var pivot = inputArray[0];

                var arrayWithoutPivot = inputArray.Skip(1).ToArray();

                var less = GetLess(arrayWithoutPivot, pivot);
                var greather = GetGreather(arrayWithoutPivot, pivot);

                return QuickSort(less.ToArray())
                .Append(pivot)
                .Concat(QuickSort(greather.ToArray())).ToArray();
            }
        }

        static IEnumerable<int> GetLess(int[] inputArray, int pivot)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] <= pivot) yield return inputArray[i];
            }
        }

        static IEnumerable<int> GetGreather(int[] inputArray, int pivot)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] > pivot) yield return inputArray[i];
            }
        }

        static bool BreadthFirstSearch(string name)
        {
            var graph = new Dictionary<string, string[]>();
            graph.Add("you", new string[] { "alice", "bob", "claire" });
            graph.Add("bob", new string[] { "anuj", "peggy" });
            graph.Add("alice", new string[] { "peggy" });
            graph.Add("claire", new string[] { "thom", "jonny" });
            graph.Add("anuj", new string[] { });
            graph.Add("peggy", new string[] { });
            graph.Add("thom", new string[] { });
            graph.Add("jonny", new string[] { });

            var queue = new Queue<string>();
            EnqueueItems(queue, graph[name]);

            var searched = new List<string>();

            while (queue.Count() > 0)
            {
                var item = queue.Dequeue();
                if (!searched.Contains(item))
                {

                    if (item[item.Length - 1] == 'm')
                    {
                        return true;
                    }
                    else
                    {
                        EnqueueItems(queue, graph[item]);
                        searched.Add(item);
                    }
                }

            }
            return false;
        }

        public static void EnqueueItems(Queue<string> queue, string[] nodes)
        {
            foreach (var node in nodes)
            {
                queue.Enqueue(node);
            }
        }

        public static void DijkstraSearch()
        {
            var graph = new Dictionary<string, Dictionary<string, int>>();

            var node = new Dictionary<string, int>();
            node.Add("A", 6);
            node.Add("B", 2);

            graph.Add("START", node);

            var node2 = new Dictionary<string, int>();
            node2.Add("FIN", 1);

            graph.Add("A", node2);

            var node3 = new Dictionary<string, int>();
            node3.Add("A", 3);
            node3.Add("FIN", 5);

            graph.Add("B", node3);

            graph.Add("FIN", null);

            var costs = new Dictionary<string, int>();
            costs.Add("A", 6);
            costs.Add("B", 2);
            costs.Add("FIN", int.MaxValue);

            var parents = new Dictionary<string, string>();
            parents.Add("A", "START");
            parents.Add("B", "START");
            parents.Add("FIN", null);

            var processed = new List<string>();
            
        }
    }
}
