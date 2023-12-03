/******************************************************************************
 * @author Jake Brockbank
 * Dec 2nd, 2023 (Revitalized)
 * This is a simple binary tree inversion program.
******************************************************************************/
namespace BinaryTreeInversion
{
    /******************************************************************************
     * Class: BinaryTree: 
     * 
     * - This class is a binary tree that can be inverted.
     *
     * Input: None.
     *
     * Output: Inverted binary tree.
     *
    ******************************************************************************/
    class BinaryTree
    {
        private TreeNode? root;

        /******************************************************************************
         * Class: TreeNode: 
         * 
         * - This class is a node for the binary tree.
         *
         * Input: int data.
         *
         * Output: None.
         *
        ******************************************************************************/
        public class TreeNode(int value)
        {
            public int Value = value;
            public TreeNode? Left;
            public TreeNode? Right;
        }

        /******************************************************************************
         * Method: Insert: 
         * 
         * - This method inserts a node into the binary tree.
         *
         * Input: int value.
         *
         * Output: None.
         *
        ******************************************************************************/
        public void Insert(int value)
        {
            root = InsertRecursive(root, value);
        }

        /******************************************************************************
         * Method: InsertRecursive: 
         * 
         * - Base Case (Empty Node): If the current node is null, a new TreeNode 
         * containing the value is created and returned. This case is the base 
         * condition for the recursion, handling the situation where either the tree 
         * is empty or a leaf node has been reached.
         * Recursive Insertion: If the value to be inserted is less than the value of 
         * the current node, the method calls itself recursively to insert the value 
         * in the left subtree (current.Left). If the value is greater, the method 
         * calls itself recursively to insert the value in the right subtree 
         * (current.Right).
         * Returning the Current Node: After handling the above two cases, the 
         * method returns the current node. This return is crucial for maintaining
         * the links between nodes, especially when the recursion unwinds and 
         * reconstructs the tree structure with the new value inserted.
         *
         * Input: TreeNode? current, int value.
         *
         * Output: TreeNode.
         *
        ******************************************************************************/
        private static TreeNode? InsertRecursive(TreeNode? current, int value)
        {
            if (current == null)
            {
                return new TreeNode(value);
            }

            if (value < current.Value)
            {
                current.Left = InsertRecursive(current.Left, value);
            }
            else if (value > current.Value)
            {
                current.Right = InsertRecursive(current.Right, value);
            }

            return current;
        }

        /******************************************************************************
         * Method: InvertTree: 
         * 
         * - Base Case: If the node is null, the method returns null. This case 
         * handles empty trees or leaf nodes.
         * Swapping Children: The method swaps the left and right children of the 
         * current node. It does this by:
         *   - Temporarily storing the left child in temp.
         *   - Setting the left child to be the result of inverting the right 
         *     child (InvertTree(node.Right)).
         *   - Setting the right child to be the result of inverting the originally 
         *     stored left child (InvertTree(temp)).
         * - Recursive Inversion: The inverting of the children is done recursively, 
         * meaning the method is called on each child node.
         * Returning the Node: After the children are swapped for the current node and 
         * its subtrees, the method returns the current node.
         *
         * Input: TreeNode? node.
         *
         * Output: TreeNode.
         *
        ******************************************************************************/
        public static TreeNode? InvertTree(TreeNode? node)
        {
            if (node == null)
            {
                return null;
            }

            TreeNode? temp = node.Left;
            node.Left = InvertTree(node.Right);
            node.Right = InvertTree(temp);

            return node;
        }

        /******************************************************************************
         * Method: InOrderTraversal: 
         * 
         * - This method traverses the binary tree in in-order traversal.
         *
         * Input: None.
         *
         * Output: None.
         *
        ******************************************************************************/
        public void InOrderTraversal()
        {
            InOrderTraversal(root);
        }

        /******************************************************************************
         * Method: InOrderTraversal: 
         * 
         * - This method traverses the binary tree in in-order traversal.
         *
         * Input: TreeNode? node.
         *
         * Output: None.
         *
        ******************************************************************************/
        private static void InOrderTraversal(TreeNode? node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.WriteLine(node.Value);
                InOrderTraversal(node.Right);
            }
        }

        /******************************************************************************
         * Method: Main: 
         * 
         * - This method is the main method.
         *
         * Input: None.
         *
         * Output: Results from insertion and non-insertion traversal.
         *
        ******************************************************************************/
        public static void Main()
        {
            BinaryTree tree = new();

            // Insert nodes
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(9);

            // Display the tree in in-order traversal before inversion
            Console.WriteLine("In-order traversal before inversion:");
            tree.InOrderTraversal();

            // Invert the tree
            InvertTree(tree.root);

            // Display the tree in in-order traversal after inversion
            Console.WriteLine("\nIn-order traversal after inversion:");
            tree.InOrderTraversal();
        }
    }
}