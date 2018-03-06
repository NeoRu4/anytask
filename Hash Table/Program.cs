using System;
using System.Collections.Generic;

using Binary_Search;
using Fast_Sort;

namespace Hash_Table
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("\nХэш-таблицы: тесты\n-------------\n");
			Test("Добавление трёх элементов, поиск трёх элементов", ThreeElementsTest());
			Test("Добавление одного и того же ключа дважды с разными значениями", SimilarKeysTest());
			Test("Добавление 10000 элементов и поиск одного из них", HugeAndOneFindTest());
			Test("Добавление 10000 элементов и поиск 1000 недобавленных ключей", HugeAndFadedFindTest());

			Console.ReadKey();
		}

		static void Test(string name, object func)
		{
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write("[тест] {0} | {1}\n", name, (bool)func ? "пройден" : "провален");
		}

		static object ThreeElementsTest()
		{
			var tbl = new HashTable(3);
			tbl.PutPair("abc", 13424);
			tbl.PutPair("dfsfgsdg", 59498);
			tbl.PutPair("12", 59498);

			return (int)tbl.GetValueByKey("dfsfgsdg") == 59498;
		}

		static object SimilarKeysTest()
		{
			var tbl = new HashTable(1);
			tbl.PutPair("abc", 575287);
			tbl.PutPair("abc", 123);

			return (int)tbl.GetValueByKey("abc") == 123;
		}

		static object HugeAndOneFindTest()
		{
			Console.Write("\t загрузка...");
			var tbl = new HashTable(10000);
			for (var i = 1; i <= tbl.Length; i++)
				tbl.PutPair(i, i*2);

			return (int)tbl.GetValueByKey(5) == 10;
		}

		static object HugeAndFadedFindTest()
		{
			Console.Write("\t загрузка...");
			var tbl = new HashTable(10000);
			for (var i = 1; i <= tbl.Length; i++)
				tbl.PutPair(i, i * 2);

			for (var i = tbl.Length+1; i <=(tbl.Length * 1.1); i++)
				if ((object)tbl.GetValueByKey(i) != null)
					return false;

			return true;
		}


	}

	class HashTable
	{
		private int[] keys;
		private object[] values;
		private int num;
		public readonly int Length;

		public HashTable(int size)
		{
			Length = size;
			keys = new int[size];
			values = new object[size];
			num = 0;
		}

		public void PutPair(object key, object value)
		{
			var hashdKey = key.GetHashCode(); //Console.WriteLine("k: {0} {1}", key, hashdKey);
			int id;
			if ((id = BSearch.BinarySearch(keys, hashdKey)) != -1)
			{
				values[id] = value;
			}
			else if (num != Length)
			{
				keys[num] = hashdKey;
				values[num] = value;
				num++;
			}
			else
			{
				Console.WriteLine("(!) Переполнение таблицы");
				return;
			}

			if (!QSort.IsSortedArray(keys))
				QSort.QuickSortAssociative(keys, values);
		}

		public object GetValueByKey(object key)
		{
			var hashdKey = key.GetHashCode();
			var id = BSearch.BinarySearch(keys, hashdKey);

			return id != -1 ? values[id] : null;
		}

	}
}
