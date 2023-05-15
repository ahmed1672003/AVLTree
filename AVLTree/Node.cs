namespace AVLTreeImplementation
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Data { get; set; }
        public int Height { get; set; }
        public Node(int data)
        {
            Height = 1;
            Data = data;
        }
    }
}