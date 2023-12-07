/*
        Using java Collections framework
 */
import java.util.*;
public class LinkedListTwo {

    public static void main(String[] args) {
        LinkedList<String> list = new LinkedList<>();

        list.addFirst("diksha");
        list.add("pathak");
        list.add(2,"full name");
        System.out.println(list);

        list.set(1,"sharma");
        list.addLast("yo");
        System.out.println(list);
        System.out.println(list.peek());
        System.out.println(list.peekFirst());
        System.out.println(list.peekLast());
        System.out.println(list.poll());
        System.out.println(list.pollFirst());
        System.out.println(list.pollLast());

        list.element();

        list.clear();
        System.out.println(list);





    }
}
