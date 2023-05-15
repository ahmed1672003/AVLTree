namespace AVLTreeImplementation
{
    public class AVL
    {
        public Node Root { get; private set; }
        public void Insert(int data) =>
            Root = InsertHelper(this.Root, data);
        private Node InsertHelper(Node current, int data)
        {
            if (current is null)
                return new Node(data);

            if (data > current.Data)
                current.Right = InsertHelper(current.Right, data);
            else if (data < current.Data)
                current.Left = InsertHelper(current.Left, data);
            else
                return current;


            current.Height = 1 + Math.Max(GetHeight(current.Left), GetHeight(current.Right));

            int balance = GetBalance(current);

            if (balance > 1)
            {
                if (data < current.Left.Data)
                    return RotateRight(current);

                else
                {
                    current.Left = RotateLeft(current.Left);
                    return RotateRight(current);
                }
            }
            else if (balance < -1)
            {
                if (data > current.Right.Data)
                    return RotateLeft(current);
                else
                {
                    current.Right = RotateRight(current.Right);
                    return RotateLeft(current);
                }
            }
            return current;
        }
        private int GetHeight(Node current)
        {
            if (current is null)
                return 0;
            else
                return current.Height;
        }
        private int GetBalance(Node current)
        {
            if (current is null)
                return 0;
            return GetHeight(current.Left) - GetHeight(current.Right);
        }
        private Node RotateRight(Node current)
        {
            Node newRoot = current.Left;
            Node temp = newRoot.Right;

            newRoot.Right = current;
            current.Left = temp;

            current.Height = 1 + Math.Max(GetHeight(current.Left), GetHeight(current.Right));
            newRoot.Height = 1 + Math.Max(GetHeight(newRoot.Left), GetHeight(newRoot.Right));
            return newRoot;
        }
        private Node RotateLeft(Node current)
        {
            Node newRoot = current.Right;
            Node temp = newRoot.Left;

            newRoot.Left = current;
            current.Right = temp;

            newRoot.Height = 1 + Math.Max(GetHeight(newRoot.Right), GetHeight(newRoot.Left));
            current.Height = 1 + Math.Max(GetHeight(current.Right), GetHeight(current.Left));

            return newRoot;
        }
        public bool Search(int data) => Search(this.Root, data);
        private bool Search(Node current, int data)
        {
            if (IsEmpty() || current is null)
                return false;
            else if (data.Equals(current.Data))
                return true;
            else if (data > current.Data)
                return Search(current.Right, data);
            else
                return Search(current.Left, data);
        }
        public void Delete(int data) => DeleteHelper(this.Root, data);
        private Node DeleteHelper(Node current, int data)
        {
            if (current is null)
                return null;

            if (data > current.Data)
                return DeleteHelper(current.Right, data);

            else if (data < current.Data)
                return DeleteHelper(current.Left, data);
            else
            {
                if (current.Left is null || current.Right is null)
                {
                    Node temp = current.Left ?? current.Right;
                    // current has one child
                    if (temp is null)
                    {
                        temp = current;
                        current = null;
                    }
                    else
                    {
                        // current has no child
                        current = temp;
                    }
                }
                else
                {
                    // current has two childs
                    Node temp = GetMinNode(current.Right);
                    current.Data = temp.Data;
                    current.Right = DeleteHelper(current.Right, temp.Data);
                }
            }

            if (current is null)
                return null;
            current.Height = 1 + Math.Max(GetHeight(current.Right), GetHeight(current.Left));

            int balance = GetBalance(current);

            // left left
            if (balance > 1 && GetBalance(current.Left) >= 0)
                return RotateRight(current);
            // right right
            else if (balance < -1 && GetBalance(current.Right) <= 0)
                return RotateLeft(current);
            // left right
            else if (balance > 1 && GetBalance(current.Left) < 0)
            {
                current.Left = RotateLeft(current.Left);
                return RotateRight(current);
            }
            // Right Left
            else if (balance < -1 && GetBalance(current.Right) > 0)
            {
                current.Right = RotateRight(current.Right);
                return RotateLeft(current);
            }

            return current;
        }
        private Node GetMinNode(Node current)
        {
            if (current.Left is not null)
                current.Left = GetMinNode(current.Left);
            return current;
        }
        public bool IsEmpty() => this.Root is null;

        #region InOrderTraversal
        public void InOrder() => InOrderTraversal(this.Root);
        private void InOrderTraversal(Node current)
        {
            if (current is not null)
            {
                if (current.Left is not null)
                    InOrderTraversal(current.Left);
                Console.Write(current.Data + " ");
                if (current.Right is not null)
                    InOrderTraversal(current.Right);
            }
        }
        #endregion

        #region PostOrderTraversal 
        public void PostOrder() => PostOrderTraversal(this.Root);
        private void PostOrderTraversal(Node current)
        {
            if (current is not null)
            {
                if (current.Left is not null)
                    PostOrderTraversal(current.Left);
                if (current.Right is not null)
                    PostOrderTraversal(current.Right);
                Console.Write(current.Data + " ");
            }
        }
        #endregion

        #region PreOrderTraversal
        public void PreOrder() => PreOrderTraversal(this.Root);
        private void PreOrderTraversal(Node current)
        {
            if (current is not null)
            {
                Console.Write(current.Data + " ");
                if (current.Left is not null)
                    PreOrderTraversal(current.Left);
                if (current.Right is not null)
                    PreOrderTraversal(current.Right);
            }
        }
        #endregion
    }
}