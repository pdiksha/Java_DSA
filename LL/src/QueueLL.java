public class QueueLL {

    static class Node
    {
      static  int data;
      static  Node next;

        Node(int data)
        {
            this.data=data;
            next=null;
        }
    }
    static class llqueue{
      static Node head=null;
      static Node tail=null;

        public static boolean isEmpty()
        {
            return head==null && tail==null;
        }

        //add
        public static void add(int data)
        {
           Node newnode=new Node(data);
            //if empty
            if(tail==null)
            {
               tail=head=newnode;
               return;
            }
            tail.next=newnode;
            tail=newnode;

        }

        //delete an element
        public static int remove()
        {
            if(isEmpty())
            {
                System.out.println("Queue is empty");
                return -1;
            }

            int front=head.data;
            if(head==tail)
            {
                tail=null;
            }
            head=head.next;
            return front;
        }

        //peek
        public static int peek()
        {
            if(isEmpty())
            {
                System.out.println("Queue is empty");
                return -1;
            }

            return head.data;
        }



    }
    public static void main(String[] args) {

        llqueue q=new llqueue();
        q.add(1);
        q.add(2);
        q.add(3);
        q.add(4);
        q.add(5);
        System.out.println(q.remove());
        q.add(6);
        System.out.println(q.remove());
        q.add(7);

        while(!q.isEmpty())
        {
            System.out.println(q.peek());
            q.remove();
        }

    }

}
