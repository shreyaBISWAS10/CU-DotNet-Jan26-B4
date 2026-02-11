using System;

namespace Spiltwise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr ={ 200,600,600,200};
            int sum = 0;
            int[] res = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = arr[i];
                sum += arr[i];

            }
            int avg = sum / arr.Length;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < avg)
                {
                    for (int j = 0; j <arr.Length; j++)
                    {
                        if (res[j] > avg)
                        {
                            Console.WriteLine($"{i + 1} person needs to pay {j + 1} person {res[j]-avg}.");
                            arr[i] = res[i] + (res[j] - avg);
                            res[j] = res[j] - arr[i];
                            if (arr[i] == avg)
                            {
                                break;
                            }
                            
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{i + 1} person doesnt need to pay anything.");
                }
            }

        }
    }
}
