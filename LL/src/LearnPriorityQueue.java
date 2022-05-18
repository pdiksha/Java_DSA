import java.util.Comparator;
import java.util.PriorityQueue;

public class LearnPriorityQueue {
    public static void main(String[] args) {
        //reversing the order
        //increasing order - min heap
        //decreasing order - max heap
        PriorityQueue<Integer> pq= new PriorityQueue<>(Comparator.reverseOrder());

        pq.offer(40);
        pq.offer(12);
        pq.offer(10);
        pq.offer(36);

        System.out.println(pq);

        pq.poll();
        System.out.println(pq);

        System.out.println(pq.peek());



    }

}
