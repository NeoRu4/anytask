using System;

namespace ConsoleApplication
{
	class Program
	{
		public static int BinarySearch(int[] array, int value)
		{
			int middle;
			int low = 0;
			int high = array.Length - 1;
			while (low <= high)
			{
				middle = (low + high) / 2;
				if (value < array[middle])
					high = middle - 1;
				else if (value > array[middle])
					low = middle + 1;
				else
					return middle;
			}
			return -1;
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Бинарный поиск: тесты\n-------------\n");
			TestStandartMassive();
			TestNegativeNumbers();
			TestNonExistentElement();
			TestDublicatedElement();
			TestEmptyMassive();
			TestHugeMassive();

			Console.ReadKey();
		}

		private static void TestStandartMassive()
		{
			int[] negativeNumbers = new[] { -5, -4, -3, -2, 5 };

			if (BinarySearch(negativeNumbers, 5) != 4)
				Console.WriteLine("(!) Поиск не нашёл 5 среди {-5, -4, -3, -2 , 5}");
			else
				Console.WriteLine("Тест: поиск в массиве из 5 элементов - пройден");
		}

		private static void TestNegativeNumbers()
		{
			int[] negativeNumbers = new[] { -5, -4, -3, -2 };

			if (BinarySearch(negativeNumbers, -3) != 2)
				Console.WriteLine("(!) Поиск не нашёл -3 среди {-5, -4, -3, -2}");
			else
				Console.WriteLine("Тест: поиск отрицательного числа - пройден");
		}

		private static void TestNonExistentElement()
		{
			int[] negativeNumbers = new[] { -5, -4, -3, -2 };

			if (BinarySearch(negativeNumbers, -1) >= 0)
				Console.WriteLine("(!) Поиск нашёл -1 среди {-5, -4, -3, -2}");
			else
				Console.WriteLine("Тест: поиск отсутствующего элемента - пройден");
		}

		private static void TestDublicatedElement()
		{
			int[] numbers = new[] { 1, 2, 3, 3, 4 };

			if (BinarySearch(numbers, 3) != 2)
				Console.WriteLine("(!) Поиск не нашёл 3 среди {1, 2, 3, 3, 4}");
			else
				Console.WriteLine("Тест: поиск повторяющегося элемента - пройден");
		}

		private static void TestEmptyMassive()
		{
			int[] numbers = new int[0];

			if (BinarySearch(numbers, 6) != -1)
				Console.WriteLine("(!) Поиск не нашёл 0 в пустом массиве");
			else
				Console.WriteLine("Тест: поиск в пустом массиве - пройден");
		}
		private static void TestHugeMassive()
		{
			int[] numbers = new int[100001];
			for (var i = 0; i < 100001; i++)
				numbers[i] = i;
			if (BinarySearch(numbers, 5560) != 5560)
				Console.WriteLine("(!) Поиск не нашёл 5560 в new int[100001]");
			else
				Console.WriteLine("Тест: поиск в new int[100001] - пройден");
		}
	}
}