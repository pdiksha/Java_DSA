import FirstJavaProgram.com.company.QueueScratch;

public class CircularQueue {

    static class cqueue{
        static int[] arr;
        static int size;
        static int front=-1;
        static int rear=-1;

        cqueue(int size)
        {
            arr=new int[size];
            this.size=size;
        }

        public static boolean isEmpty()
        {
            return rear==-1 && front==-1;
        }

        public static boolean isFull()
        {
            return (rear+1)%size==front;
        }

        //add
        public static void add(int data)
        {
            if(isFull())
            {
                System.out.println("Queue is full");
                return;
            }
            //if empty
            if(front==-1)
            {
                front=0;
            }
            rear=(rear+1)%size;
            arr[rear]=data;

        }

        //delete an element
        public static int remove()
        {
            if(isEmpty())
            {
                System.out.println("Queue is empty");
                return -1;
            }

            int result=arr[front];

            if(rear==front)
            {
                rear=front=-1;
            }
            else
            {
                front=(front+1)%size;
            }

            return result;
        }

        //peek
        public static int peek()
        {
            if(isEmpty())
            {
                System.out.println("Queue is empty");
                return -1;
            }

            return arr[front];
        }



    }
    public static void main(String[] args) {

        cqueue q=new cqueue(5);
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
