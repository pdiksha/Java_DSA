/*
This is a from scratch implementation of linkedlist to add an element, delete, print the list, get the size of the list, reverse the linkedlist
reverse LL using recursion
 */
public class LL {
    Node head;
    private int size;

    LL(){
        this.size=0;
    }
    public static class Node{
        int data;
        Node next;

        Node(int data) {
            this.data = data;
            this.next = null;
        }
    }

    //add - first
    public void addFirst(int data){
        Node newNode = new Node(data);
        size++;
        if (head==null){
            head=newNode;
            return;
        }

        newNode.next=head;
        head=newNode;
    }

    //add-last
    public void addLast(int data){
        Node newNode = new Node(data);
        size++;
        if(head==null){
            head=newNode;
            return;
        }
        Node temp = head;
        while(temp.next!=null){
            temp=temp.next;
        }
        temp.next=newNode;

    }

    //delete- first
    public void deleteFirst(){
        if(head==null){
            System.out.println("List is empty already!");
            return;
        }
        size--;
        head=head.next;
    }

    //delete- last
    public void deleteLast(){
        if(head==null){
            System.out.println("List is empty already!");
            return;
        }
        size--;
        Node temp=head;
        while(temp.next.next!=null){
            temp=temp.next;
        }
        temp.next=null;
    }

    public void reverselist()
    {
      if(head==null){
          System.out.println("list is empty, can't be reversed");
          return;
      }
      Node prev = head;
      Node curr = head.next;

      while(curr!=null){
          Node nextNode = curr.next;
          curr.next=prev;

          prev=curr;
          curr=nextNode;
      }

      head.next=null;
      head=prev;

    }

    public Node recursiveReverseList(Node head){

        if(head==null || head.next==null){
            return head;
        }

        Node newNode = recursiveReverseList(head.next);

        head.next.next=head;
        head.next=null;

        return newNode;
    }

    public void printlist()
    {
        if(head==null)
        {
            System.out.println("List is empty");
            return;
        }
        Node temp = head;
        while(temp!=null)
        {
            System.out.print(temp.data + " -> ");
            temp=temp.next;
        }
        System.out.print("null");
        System.out.println();
    }

    public static void main(String[] args) {
        LL list = new LL();
        list.addFirst(1);
        list.addLast(2);
        list.addFirst(3);
        list.addLast(4);
        list.printlist();
        System.out.println(list.size);

        list.deleteFirst();
        list.printlist();
        list.deleteLast();
        list.printlist();
        System.out.println(list.size);

        list.reverselist();
        list.printlist();

        list.printlist();


    }

}
