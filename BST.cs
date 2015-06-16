public class node_in_sbt 
{
    public int data_value;
    public node_in_sbt left, right;
    public node_in_sbt(int a) 
    {
        this.data_value = a;
        left = null;
        right = null;
    }
}
public class Tree
{
    public node_in_sbt root_of_the_tree;
    public Tree()
    {
        root_of_the_tree = null;
    }
    public Tree(int[] input) 
    {
        root_of_the_tree = null;
        for (int i = 0; i < input.Length; i++) 
        {
            this.insert(this.root_of_the_tree, this.addNode(input[i]));
        }
    }
    public node_in_sbt addNode(int int_data)
    {
        node_in_sbt temp = new node_in_sbt(int_data);
        if (root_of_the_tree == null) root_of_the_tree = temp;
        return temp;
    }
    public void insert(node_in_sbt root, node_in_sbt newNode)
    {
        while (root != null)
        {
            if (newNode.data_value > root.data_value)
            {
                if (root.right == null)
                {
                    root.right = newNode;
                    MessageBox.Show(root.right.data_value.ToString(), "Right");
                    break;
                }
                root = root.right;
                MessageBox.Show(root.data_value.ToString(), "new root right");
            }
            else
            {
                if (root.left == null)
                {
                    root.left = newNode;
                    MessageBox.Show(newNode.data_value.ToString(), "Left");
                    break;

                }
                root = root.left;
                MessageBox.Show(root.data_value.ToString(), "new root left");
            }
        }
    }
    public void ordered(node_in_sbt root)
    {
        string str_return;
        if (root != null)
        {
           ordered(root.left);
           str_return = root.data_value.ToString() + " ";
           MessageBox.Show(str_return, "Queued");
           ordered(root.right);
        }
    }
    public int count_elements(node_in_sbt root)
    {
        int count = 1;
        if (root != null)
        {
            if (root.left != null) count += count_elements(root.left);
            if (root.right != null) count += count_elements(root.right);
        }
        return count;
    }
    public int tree_height_or_depth(node_in_sbt root) 
    {
        int height = 1;
        int left = 1;
        int right = 1;
        if (root != null) 
        {
            if (root.left != null) left += tree_height_or_depth(root.left);
            if (root.right != null) right += tree_height_or_depth(root.right);
        }
        height = Math.Max(left, right);
        return height;
    }
    public void FindItem(node_in_sbt root, int item_node) 
    {
        node_in_sbt temp = new node_in_sbt(-1);
        if (root != null) 
        {
            if (item_node < root.data_value) 
            {
                temp.data_value = root.data_value;
                FindItem(root.left, item_node);
            }
            else if (item_node > root.data_value)   
            {
                temp.data_value = root.data_value;
                FindItem(root.right, item_node);
            }
            else 
            { 
                MessageBox.Show("Found",root.data_value.ToString()); 
            }
        }
    }

    public node_in_sbt GetSuccessor(node_in_sbt delNode)
    {
        node_in_sbt successorParent = delNode;
        node_in_sbt successor = delNode;
        node_in_sbt current = delNode.right;  

        while (current != null)
        {
            successorParent = current;
            successor = current;
            current = current.left;    
        }
        if (successor != delNode.right )  
        {
            successorParent.left = successor.right;  
            successor.right = delNode.right;   
        }
        return successor;
    }
    public bool delete_node(int value_to_delete)
    {
        node_in_sbt current = root_of_the_tree;
        node_in_sbt parent = root_of_the_tree;
        bool isLeftChild = true;
        while (current.data_value != value_to_delete) 
        {
            parent = current;
            if (value_to_delete < current.data_value) 
            {
                isLeftChild = true;
                current = current.left; 
            }
            else
            {
                isLeftChild = false;
                current = current.right; 
            }
            if (current == null)
            {
                return false;
            }
        }
        if ( current.left == null && current.right == null  )  
        {
            if ( current == root_of_the_tree  ) 
            {
                root_of_the_tree = null;   
            }
            else if (isLeftChild)
            {
                parent.left = null; 
            }
            else
            {
                parent.right = null;   
            }
        }
        else if ( current.right == null )  
        {
            if ( current == root_of_the_tree )  
            {
                root_of_the_tree = current.left; 
            }
            else if (isLeftChild)
            {
                parent.left = current.left;   
            }
            else
            {
                parent.right = current.right;  
            }
        }
        else if (current.left == null)   
        {
            if (current == root_of_the_tree) 
            {
                root_of_the_tree = current.right;  
            }
            else if (isLeftChild)
            {
                parent.left = parent.right;  
            }
            else
            {
                parent.right = current.right;  
            }
        }
        else
        {
            node_in_sbt successor = GetSuccessor(current);
            if (current == root_of_the_tree) 
            {
                root_of_the_tree = successor; 
            }
            else if (isLeftChild)
            {
                parent.left = successor;  
            }
            else
            {
                parent.right = successor;  
            }
            successor.left = current.left; 
        }
        return true;
    }

}
 private void cmdRun_Click(object sender, EventArgs e)
 {
    
    //int[] input = { 53, 21, 17, 81, 14, 12, 51, 51, 3, 101, 47 };
    //int[] input = { 53 };
    int[] input = { 53, 14, 7, 17, 12, 1, 72 }; // { 53, 72, 14, 7, 17, 12, 1};
    int no_to_delete = 104;
    Tree bst = new Tree(input);
    bst.ordered(bst.root_of_the_tree);
    int int_how_manu = bst.count_elements(bst.root_of_the_tree);
    label1.Text = int_how_manu.ToString();
    int int_height = bst.tree_height_or_depth(bst.root_of_the_tree);
    label4.Text = int_height.ToString();
    // bst.FindItem(bst.root_of_the_tree, 72);

    // bst.deleteNode(72, bst.root_of_the_tree);
    // bst.ordered(bst.root_of_the_tree);
    //  *******************************************
    if (bst.delete_node(no_to_delete))
    {
        MessageBox.Show("After deletion, bst looks as follows:");
        bst.ordered(bst.root_of_the_tree);
    }
    else 
    {
        MessageBox.Show("There is no nuber " + no_to_delete.ToString() + " in the bst to delete");
    }

  }
}
