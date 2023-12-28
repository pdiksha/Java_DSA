import java.util.HashSet;
import java.util.Iterator;

public class Hashing {

    /*
    -- Hashset --
    insert/add - O(1)
    search/contains - O(1)
    delete/removal - O(1)
     */

    public static void main(String[] args) {

        //Creating
        HashSet<Integer> set = new HashSet<>();

        //Insert
        set.add(1);
        set.add(2);
        set.add(3);
        set.add(1); //this will not get stored because only unique elements get stored.

        //size
        System.out.println(set.size());

        //print all elements
        System.out.println(set);

        //Search - contains
        if(set.contains(1)){
            System.out.println("Set contains 1");
        }
        if(!set.contains(6)){
            System.out.println("does not contain");
        }

        //delete
        set.remove(1);
        if(!set.contains(1)){
            System.out.println("does not contain 1");
        }

        //Iterator
        Iterator it = set.iterator();
        while(it.hasNext()){
            System.out.println(it.hasNext());
        }

    }
}
