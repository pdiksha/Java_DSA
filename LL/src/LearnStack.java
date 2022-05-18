import java.util.Stack;

public class LearnStack {

    public static void main(String[] args) {
        Stack<String> animals=new Stack<>();
        animals.push("Lion");
        animals.push("dog");
        animals.push("horse");
        animals.push("cat");
        System.out.println(animals);

        //top of the stack
        System.out.println(animals.peek());

        //pop from stack
        animals.pop();
        System.out.println(animals.peek());
    }
}
