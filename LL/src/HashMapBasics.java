import java.util.*;
public class HashMapBasics {

    /*
    hashmaps are unordered maps - they will be printed in any random order
     */
    public static void main(String[] args) {

        HashMap<String,Integer> map = new HashMap<>();

        //Insertion
        map.put("India",120);
        map.put("US",30);
        map.put("China",150);

        System.out.println(map);

        //if key exists it updates the value, if key does not exists it adds a new pair
        map.put("China",180);

        //Search
        if(map.containsKey("Indonesia")){
            System.out.println("key present in the map");
        } else {
            System.out.println("key is not present in the map");
        }

        //gives the value of key if exists
        System.out.println(map.get("China"));
        //gives null if key doesn't exists
        System.out.println(map.get("Indo"));

        //Iteration
        for(Map.Entry<String,Integer> e: map.entrySet()){
            System.out.println(e.getKey() + " -> " + e.getValue());
        }



    }
}
