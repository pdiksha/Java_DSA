
import java.util.*;
import java.util.function.Function;
import java.util.stream.Collectors;

public class test {

    public static void main(String[] args) {
        List<Integer> list = new ArrayList<>();
        list = Arrays.asList(10,15,8,49,25,98,98,32,15);
        Set<Integer> set = new HashSet<>();

        List<Integer> finalList = list;

        // 1) collections.frequency
//        set = list.stream().filter(i -> Collections.frequency(finalList,i) > 1).collect(Collectors.toSet());

        // 2) Use a map to store key and value as occurences and get them in a set
        set = list.stream().collect(Collectors.groupingBy(Function.identity(),Collectors.counting())).entrySet().
                stream().filter(m-> m.getValue() > 1).map(Map.Entry:: getKey).collect(Collectors.toSet());

        Set<Integer> set2 = list.stream().map(x->x*x).collect(Collectors.toSet());

        System.out.println(set);
        System.out.println(set2);

        List<String> stringList = Arrays.asList("Diksha","Doll","Pathak","Hello");
        List<String> tempList = stringList.stream().filter(s-> s.startsWith("D")).collect(Collectors.toList());


        System.out.println(tempList);
        System.out.println(stringList.stream().sorted().collect(Collectors.toList()));



    }
}
