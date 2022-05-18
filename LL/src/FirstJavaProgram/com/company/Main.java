package FirstJavaProgram.com.company;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        ArrayList<String> list = new ArrayList<>();
        ArrayList<String> list2 = new ArrayList<>();

        list.add("hello");
        list.add("my");
        list.add("world");
        list.add("love");
        list.add("you");

        list2.addAll(list);
        System.out.println(list);
        System.out.println(list2);

        System.out.println(list.get(1));

        list.remove(0);
        System.out.println(list);

        list.remove(String.valueOf("world")); //remove which element to delete
        System.out.println(list);

        list2.clear();
        System.out.println(list2);

        list.set(0,"hello");
        System.out.println(list);

        System.out.println(list.contains("love")); //check if the element is present

        for (int i = 0; i < list.size(); i++) {
            System.out.println(list.get(i));
        }

        //foreach loop
        for(String str:list)
        {
            System.out.println(str);
        }

        //iterator of type string
        Iterator<String> it=list.iterator();
        while(it.hasNext())
        {
            System.out.println(it.next());
        }
    }

    }


