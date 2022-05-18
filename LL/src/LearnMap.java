import com.sun.source.tree.Tree;

import java.util.*;

public class LearnMap {

    public static void main(String[] args) {
        //Map<String, Integer> numbers = new HashMap<>(); - O(1)
        Map<String, Integer> numbers = new TreeMap<>(); //-O(log n)
        numbers.put("one",1);
        numbers.put("two",2);
        numbers.put("three",3);
        numbers.put("four",4);


        System.out.println(numbers);

        if(!numbers.containsKey("three"))
        {
            numbers.put("three",33);
        }

        System.out.println(numbers.containsValue(3));
        System.out.println(numbers.isEmpty());

        numbers.putIfAbsent("five",5);

        System.out.println(numbers);

        //iterate through the map
        for(Map.Entry<String,Integer> e: numbers.entrySet())
        {
            System.out.println(e);
            System.out.println(e.getKey());
            System.out.println(e.getValue());

        }

        for (String key: numbers.keySet())
        {
            System.out.println(key);
        }

        for(Integer value: numbers.values())
        {
            System.out.println(value);
        }



    }
}
