import java.util.ArrayList;

public class BinarySearchTree {

    /*
    used for fast lookup - logN is the time complexity of searching
    max time/worst case - O(height) if the key is leaf node
    it is a binary tree; left subtree nodes <root and right subtree nodes > root
    LST & RST are also BST with no duplicates
    by default there are no duplicates but always ask if duplicates are present
    inorder traversal of BST gives a sorted sequence ascending order
    BST makes search efficient
    Strategy -  most problems will be solved using recursion
    */

    static class Node {
        int data;
        Node left;
        Node right;

        Node(int val){
            this.data=val;
        }
    }

    public static Node insert(Node root, int val){
        if(root==null){
            root = new Node(val);
            return root;
        }

        if(root.data > val){
            //left subtree
            root.left = insert(root.left, val);
        } else {
            root.right = insert(root.right, val);
        }
        return root;
    }

    public static void inorder(Node root){

        if(root==null)
            return;
        inorder(root.left);
        System.out.print(root.data + " ");
        inorder(root.right);
    }

    public static boolean search(Node root, int key){

        if(root==null){
            return false;
        }

        if(root.data > key){
            return search(root.left, key);
        } else if( root.data < key){
            return search(root.right, key);
        } else {
            return true;
        }
    }

    /*
    DELETE A NODE
    1) no child (leaf node)
    2) one child - replace with the child
    3) two children - replace with inorder successor,
    inorder successor always have either one child or 0 child
    */

    public static Node delete(Node root, int val){

        if(root.data > val){
          root.left = delete(root.left, val);
        } else if(root.data < val){
            root.right = delete(root.right, val);
        } else {
            //root.data == val

            //case 1 no child
            if(root.left==null && root.right==null){
                return null;
            }

            //case 2 one child
            if(root.left == null){
                return root.right;
            } else if(root.right == null) {
                return root.left;
            }

            //case 3 two children
            Node is = inorderSuccessor(root.right);
            root.data= is.data;
            root.right = delete(root.right, is.data);


        }
        return root;
    }

    public static Node inorderSuccessor(Node root) {

        //return root ka leftmost child
        while(root.left!= null){
            root = root.left;
        }
        return root;
    }

    //print in range
    public static void printInRange(Node root, int x, int y){

        if(root==null){
            return;
        }

        if(root.data >= x && root.data <= y){
            printInRange(root.left,x,y);
            System.out.println(root.data+" ");
            printInRange(root.right, x, y);
        } else if(root.data>=y){
            printInRange(root.left,x,y);
        } else {
            printInRange(root.right,x,y);
        }
    }

    //root to leaf paths
    //print path on reaching the leaf node
    //we'll keep deleting the nodes from which we're backtracking

    public static void printRoot2Leaf(Node root, ArrayList<Integer> path){
        if(root==null){
            return;
        }
        path.add(root.data);

        if(root.left==null && root.right ==null){
            printPath(path);
        } else {
            //non leaf
            printRoot2Leaf(root.left, path);
            printRoot2Leaf(root.right,path);
        }
        path.remove(path.size()-1);

    }

    public static void printPath(ArrayList<Integer> path){
        for(int i=0; i<path.size(); i++){
            System.out.print(path.get(i) + "->");
        }
        System.out.println();
    }

    public static void main(String[] args) {
        int[] values = {8,5,3,1,4,6,10,11,14};
        Node root = null;

        for(int i=0; i<values.length; i++){
            root = insert(root,values[i]);
        }

        inorder(root);
        System.out.println();

        System.out.println(search(root,10));
        inorder(root);

        printInRange(root,3,10);

        printRoot2Leaf(root, new ArrayList<>());

    }



}
