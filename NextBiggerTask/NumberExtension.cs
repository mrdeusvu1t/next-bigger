using System;

namespace NextBiggerTask
{
    public static class NumberExtension
    {
        public static int? NextBiggerThan(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("error");
            }

            if (number < 10)
            {
                return null;
            }

            if (number >= int.MaxValue)
            {
                return null;
            }

            char[] numbers = number.ToString().ToCharArray();

            string n = "";

            var len = numbers.Length - 1;
            var count = 0;
            var x = 1;

            for (int i = len; i > 0; i--)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    var temp = numbers[i];
                    numbers[i] = numbers[i - 1];
                    numbers[i - 1] = temp;
                    count = i;
                    break;
                }

                x++;
            }

            if (x == numbers.Length)
            {
                return null;
            }

            for (int i = count; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        var temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            foreach (char num in numbers)
            {
                n += num;
            }

            return Convert.ToInt32(n);

        }
    }
}
