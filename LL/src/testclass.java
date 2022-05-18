import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.Map;

public class testclass{

   public static Node head;
    public static class Node{
        int data;
        Node next;

        Node(int data) {
            this.data = data;
            this.next = null;
        }
    }

    public static void add(int data)
    {
        Node newnode=new Node(data);
        if(head==null)
        {
            head=newnode;
            return;
        }

        Node temp = head;
        while(temp.next!=null)
        {
            temp=temp.next;
        }
        temp.next=newnode;
    }

    public static void reverselist()
    {
        Node prev=head;
        Node curr=head.next;

        while(curr!=null)
        {
            Node nextn=curr.next;
            curr.next=prev;

            prev=curr;
            curr=nextn;

        }
        head.next=null;
        head=prev;

    }

    public static void printlist()
    {
        if(head==null)
        {
            System.out.println("List is empty");
            return;
        }
        Node temp = head;
        while(temp!=null)
        {
            System.out.println(temp.data + " ->");
            temp=temp.next;
        }
    }



    public static void main(String[] args) {
     //  Node newnode=new Node(1);


        add(1);
        add(2);
        add(3);
        add(4);
        reverselist();
        printlist();




    }




    //{1,1,2,3,4,5,6,7} sum=7

}
