// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] arr = new int[4] { 7,4,6,5};

for (int i = 0; i < arr.Length; i++)
{
    for (int j= 1; j<arr.Length;j++)
    {
        int temp;

        if (arr[j] != arr.Count())
        {
            if (arr[j] > arr[j + 1])
            {
                temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
                arr[i + 1] = arr[j];

            }
            // arr[i + 1] = arr[j];
        }
    }
    if (arr[i] < arr[i+1])
    {
        int temp;
        temp = arr[i];
        arr[i] = arr[i + 1];
        arr[i + 1] = temp;
    }
    Console.WriteLine(arr[i]);

}

