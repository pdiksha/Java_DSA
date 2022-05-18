import java.util.*;

public class LearnCollectionsClass {

    public static void main(String[] args) {
        List<Integer> list=new ArrayList<>();

        list.add(10);
        list.add(20);
        list.add(30);
        list.add(40);
        list.add(50);
        list.add(60);
        list.add(20);
        list.add(20);

        System.out.println("Minimum element of the arraylist is : " + Collections.min(list));
        System.out.println("Maximum element of the arraylist is : " + Collections.max(list));
        System.out.println(Collections.frequency(list,20));
        
       // Collections.sort(list, Comparator.reverseOrder());
        Collections.sort(list);
        System.out.println(list);

    }

}
