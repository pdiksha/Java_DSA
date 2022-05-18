package FirstJavaProgram.com.company;

public class QueueScratch {
 static class queues{
     static int[] arr;
     static int size;
     static int rear=-1;

     queues(int size)
     {
         arr=new int[size];
         this.size=size;
     }

     public static boolean isEmpty()
     {
         return rear==-1;
     }

     //add function
     public static void add(int data)
     {
         if(rear==size-1)
         {
             System.out.println("Queue is full");
             return;
         }
         rear++;
         arr[rear]=data;
     }

     //delete function - O(n)
     public static int remove()
     {
         if(isEmpty())
         {
             System.out.println("Queue is empty");
             return -1;
         }

         int front=arr[0];

         for(int i=0; i<rear; i++)
         {
             arr[i]=arr[i+1];
         }
         rear=rear-1;
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

         return arr[0];
     }


 }

    public static void main(String[] args) {

     queues q=new queues(10);
     q.add(1);
        q.add(2);
        q.add(3);
        q.add(4);

        while(!q.isEmpty())
        {
            System.out.println(q.peek());
            q.remove();
        }


    }

}
