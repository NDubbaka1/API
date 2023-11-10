// See https://aka.ms/new-console-template for more information

int[] arr = new int[5] { -11, 12, -42, 0, 90 };
int temp;
foreach(var item in arr)
{

    Console.WriteLine("unsorted:" +""+ item);

}

for (int i=0; i< arr.Length-1; i++)
{
    for (int j =i+1; j< arr.Length; j++)
    {
        if (arr[i]> arr[j])
        {
            temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}

foreach (var item in arr)
{

    Console.WriteLine("sorted:" + "" + item);

}




