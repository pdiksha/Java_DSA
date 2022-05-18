import java.util.HashSet;
import java.util.LinkedHashSet;
import java.util.Set;
import java.util.TreeSet;

public class LearnHashSet {

    public static void main(String[] args) {

        //Set<Integer> set = new HashSet<>(); //all elements are unique in hashset - O(1)
        //Set<Integer> set = new LinkedHashSet<>(); //linked hash set
        //all the properties are same except now elements are added in an arranged manner

        Set<Integer> set = new TreeSet<>(); //-o(log n)
        set.add(20);
        set.add(3);
        set.add(50);
        set.add(44);
        set.add(19);
        set.add(50); //already added so it wont get added again

        System.out.println(set);

        set.remove(44);
        System.out.println(set);

        System.out.println(set.contains(100));

        System.out.println(set.isEmpty());

        System.out.println(set.size());

        set.clear();

        System.out.println(set);

    }
}
