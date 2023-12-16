import java.util.ArrayList;
import java.util.List;

public class TestDemo {

    public static void main(String[] args) {
        List<List<Integer>> list1 = new ArrayList<>();

        List<Integer> list = new ArrayList<>();
        List<Integer> list2 = new ArrayList<>();

        list.add(1);
        list.add(2);
        list1.add(list);

        list2.add(3);
        list2.add(4);
        list1.add(list2);
        System.out.println(list1);

    }
}
