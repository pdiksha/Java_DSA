import java.util.LinkedList;
import java.util.Queue;

public class LearnQueue {

    public static void main(String[] args) {
        Queue<Integer> qu = new LinkedList<>();

        //add element
        qu.offer(12);
        qu.offer(13);
        qu.offer(14);
        qu.offer(15);
        System.out.println(qu);
        //remove element
        System.out.println(qu.poll());

        //top element
        System.out.println(qu.peek());

    }

}
