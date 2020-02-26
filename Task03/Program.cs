using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Задача: реализовать метод Filter, который должен возвращать входной массив, в котором удалены элементы, которые встречаются более одного раза.
//   * Значения в массиве должны следовать в том порядке, в котором они следуют в оригинальном массиве.
//   * Если в массиве встречаются повторяющиеся значения, то они ВСЕ значения должны быть удалены.
//   * Метод должен выбрасывать исключение ArgumentNullException в случае, если в метод передали null.
//   * В решении разрешается использовать только конструкции языка. Использовать LINQ запрещено.

namespace Task03
{
    class Program
    {
        public static int[] Filter(int[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("NULL!");
            }
            if(source.Length == 0 || source.Length == 1)
            {
                return source;
            }
            return createNewArray(source); // массив, в который будут записаны неповторяющиеся значения
        }

        public static int[] createNewArray(int[] source) // метод, который будет записывать в новый массив неповторяющиеся значения из текущего массива
        {
            int[] newArray = new int[0]; // массив, в который будут записаны неповторяющиеся значения
            int newArrayElementIndex = 0;
            for (int i = 0; i < source.Length; i++)
            {
                int countOfElements = 0;
                for (int j = 0; j < source.Length; j++)
                {
                    if (source[i] == source[j])
                    {
                        countOfElements++;
                        continue;
                    }
                }
                if (countOfElements == 1)
                {
                    Array.Resize(ref newArray, newArray.Length + 1);
                    newArray[newArrayElementIndex++] = source[i];
                }
            }
            return newArray;
        }

        // ----- ЗАПРЕЩЕНО ИЗМЕНЯТЬ КОД МЕТОДОВ, КОТОРЫЕ НАХОДЯТСЯ НИЖЕ -----
        static void Main(string[] args)
        {
            Console.WriteLine("Task is done when all test cases are correct:");

            int testCaseNumber = 1;

            TestReturnedValues(testCaseNumber++, new int[] { }, new int[] { });
            TestReturnedValues(testCaseNumber++, new int[] { 0 }, new int[] { 0 });
            TestReturnedValues(testCaseNumber++, new int[] { 0, 1 }, new int[] { 0, 1 });
            TestReturnedValues(testCaseNumber++, new int[] { 0, 0 }, new int[] { });
            TestReturnedValues(testCaseNumber++, new int[] { 0, 1, 0 }, new int[] { 1 });
            TestReturnedValues(testCaseNumber++, new int[] { 0, 1, 0, 1 }, new int[] { });
            TestReturnedValues(testCaseNumber++, new int[] { 0, 1, 2, 2, 5, 4, 4, 5, 1, 8, 4, 9, 1, 3, 4, 5, 7 }, new int[] { 0, 8, 9, 3, 7 });
            TestException<ArgumentNullException>(testCaseNumber++, null);

            if (correctTestCaseAmount == testCaseNumber - 1)
            {
                Console.WriteLine("Task is done.");
            }
            else
            {
                Console.WriteLine("TASK IS NOT DONE.");
            }
            Console.ReadKey();
        }
        private static void TestReturnedValues(int testCaseNumber, int[] array, int[] expectedResult)
        {
            try
            {
                var result = Filter(array);

                if (result.SequenceEqual(expectedResult))
                {
                    Console.WriteLine(correctCaseTemplate, testCaseNumber);
                    correctTestCaseAmount++;
                }
                else
                {
                    Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
            }
        }

        private static void TestException<T>(int testCaseNumber, int[] array) where T : Exception
        {
            try
            {
                Filter(array);
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
            catch (T)
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
                correctTestCaseAmount++;
            }
            catch (Exception)
            {
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
        }

        private static string correctCaseTemplate = "Case #{0} is correct.";
        private static string incorrectCaseTemplate = "Case #{0} IS NOT CORRECT";
        private static int correctTestCaseAmount = 0;
    }
}

