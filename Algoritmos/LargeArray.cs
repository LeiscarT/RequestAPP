using System;
 
class Largest {
     
    static int []arr = {49, 371, 45, 90, 9808,92};
     
  
    static int largest()
    {
        int i;
    
        int max = arr[0];
     
        for (i = 1; i < arr.Length; i++)
            if (arr[i] > max)
                max = arr[i];
     
        return max;
    }
     
    public static void Main()
    {
        Console.WriteLine(largest());
    }
}