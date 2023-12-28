import java.util.ArrayList;
import java.util.Collections;

public class ArrayListt {

    /*
    arrays are fixed size and continuous, can store primitive data types & objects
    arraylist are non-contiguous and variable size, can store only objects
    basically as you are inserting the size also increases
    array lists are created in heap memory

    why cant we store primitive in array list? because we need to allocate memory beforehand which we dont do here
     */
    public static void main(String[] args) {

        ArrayList<Integer> list = new ArrayList<>();
        ArrayList<String> list2 = new ArrayList<>();

        //add elements
        list.add(0);
        list.add(2);
        list.add(3);

        System.out.println(list);

        //get elements
        int element = list.get(0);
        System.out.println(element);

        //add elements in between
        list.add(1,1);

        System.out.println(list);

        //set element
        list.set(0,5);
        System.out.println(list);

        //delete element
        list.remove(3);
        System.out.println(list);

        //size
        int size = list.size();
        System.out.println(size);

        //loops
        for (int i=0; i<list.size(); i++){
            System.out.print(list.get(i));
        }
        System.out.println();

        //sorting
        Collections.sort(list);
        System.out.println(list);

    }
}
