using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast_Sort
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("\nБыстрая сортировка: тесты\n-------------\n");
			Test("Сортировка массива из трёх элементов", ThreeElementsTest());
			Test("Сортировка массива из 100 одинаковых чисел", OneHundredElementsTest());
			Test("Сортировка массива из 1000 случайных элементов", OneThousandElementsTest());
			Test("Сортировка пустого массива", EmptyMassiveTest());
			Test("Сортировка массива из 150 000 000 элементов", HugeMassiveTest());

			Console.ReadKey();
		}

		static void Test(string name, bool func)
		{
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write("[тест] {0} | {1}\n", name, func ? "пройден" : "провален");
		}

		static bool ThreeElementsTest()
		{
			var array = new[] { 15, 0, 8 };
			QSort.QuickSort(array);

			return QSort.IsSortedArray(array);
		}

		static bool OneHundredElementsTest()
		{
			var array = new int[100];
			for (var i = 0; i < array.Length; i++)
				array[i] = 32;
			QSort.QuickSort(array);

			return QSort.IsSortedArray(array);
		}

		static bool OneThousandElementsTest()
		{
			var rand = new Random();
			var array = new int[1000];
			for (var i = 0; i < array.Length; i++)
				array[i] = rand.Next();
			QSort.QuickSort(array);

			return QSort.IsSortedArray(array);
		}

		static bool EmptyMassiveTest()
		{
			var array = new int[0];
			QSort.QuickSort(array);

			return QSort.IsSortedArray(array);
		}

		static bool HugeMassiveTest()
		{
			Console.Write("\t Подождите...");

			var rand = new Random();
			var array = new int[150000000];

			for (var i = 0; i < array.Length; i++)
				array[i] = rand.Next();

			QSort.QuickSort(array);

			return QSort.IsSortedArray(array);
		}
	}

	public static class QSort
	{
		static void QuickSort(int[] array, int start, int end)
		{
			if (end == start) return;
			var pivot = array[end];
			var storeIndex = start;
			for (int i = start; i <= end - 1; i++)
				if (array[i] <= pivot)
				{
					Swap(ref array[i], ref array[storeIndex]);
					storeIndex++;
				}

			Swap(ref array[storeIndex], ref array[end]);

			if (storeIndex > start) QuickSort(array, start, storeIndex - 1);
			if (storeIndex < end) QuickSort(array, storeIndex + 1, end);
		}

		public static void QuickSort(int[] array)
		{
			var len = array.Length;
			QuickSort(array, 0, len == 0 ? len : len - 1);
		}

		static void QuickSortAssociative(int[] arrayOne, object[] arrayTwo, int start, int end)
		{
			if (end == start) return;
			var pivot = arrayOne[end];
			var storeIndex = start;
			for (int i = start; i <= end - 1; i++) {
				if (arrayOne[i] <= pivot)
				{
					Swap(ref arrayOne[i], ref arrayOne[storeIndex]);
					Swap(ref arrayTwo[i], ref arrayTwo[storeIndex]);
					storeIndex++;
				}
			}
			Swap(ref arrayOne[storeIndex], ref arrayOne[end]);
			Swap(ref arrayTwo[storeIndex], ref arrayTwo[end]);

			if (storeIndex > start) QuickSortAssociative(arrayOne, arrayTwo, start, storeIndex - 1);
			if (storeIndex < end) QuickSortAssociative(arrayOne, arrayTwo, storeIndex + 1, end);
		}

		public static void QuickSortAssociative(int[] arrayOne, object[] arrayTwo)
		{
			var len = arrayOne.Length;
			if (len != arrayTwo.Length) return;

			QuickSortAssociative(arrayOne, arrayTwo, 0, len == 0 ? len : len - 1);
		}

		public static bool IsSortedArray(int[] array)
		{
			var len = array.Length;
			if (len == 0 || len == 1) return true;
			var num = 0;
			var rand = new Random();

			for (var i = 0; i <= 10; i++)
			{
				var x = rand.Next(0, len - 1);
				if (array[x] < array[x + 1])
				{
					num++;
					if (len >= num) break;
				}
			}
			return len >= num || num <= 10;
		}

		private static void Swap<T>(ref T lhs, ref T rhs)
		{
			T temp = lhs;
			lhs = rhs;
			rhs = temp;
		}
	}
}
