using AVLTreeImplementation;

namespace AVLTree;

internal class Program
{
    static void Main(string[] args)
    {
        AVL aVLTree = new();
        int[] arr = { 1, 2, 3, 5 };
        for (int i = 0 ; i < arr.Length ; i++)
            aVLTree.Insert(arr[i]);
        aVLTree.InOrder();
        Console.WriteLine();
        Console.WriteLine(aVLTree.Search(2));
    }
}