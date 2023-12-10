import java.util.*;

public class ReverseString {

    public static void reverseApproachOne(String s){
        //using a string variable
        String nstr = "";
        char ch;

        for(int i=0; i< s.length(); i++){
            ch = s.charAt(i);
            nstr=ch+nstr;
        }

        System.out.println(nstr);

    }

    public static void reverseApproachTwo(String s){
        //using reverse method in stringbuilder
       StringBuilder str = new StringBuilder(s);
       str.reverse();

        System.out.println(str);

    }

    public static void reverseApproachThree(String s){
        //converting the string to character array
        char[] arr = s.toCharArray();
        String str = "";

        for(int i=arr.length-1; i>=0; i--){
            str+=arr[i];
        }

        System.out.println(str);

    }

    public static void reverseApproachFour(String s){
        //using collections framework- array list
        char[] arr = s.toCharArray();
        List<Character> str = new ArrayList<>();
        for(char ch: arr){
            str.add(ch);
        }

        Collections.reverse(str);
        String yo = str.toString();

        System.out.println(yo);

        //or print like this
        ListIterator li = str.listIterator();
        while(li.hasNext()){
            System.out.print(li.next());
        }
        System.out.println();
    }

    public static void reverseApproachFive(String s){
        //using string buffer
        StringBuffer str = new StringBuffer(s);
        str.reverse();
        System.out.println(str);
    }

    public static void reverseApproachSix(String s){
        //using stack
        Stack<Character> stack = new Stack<>();
        String str="";
        for(int i=0; i<s.length(); i++){
            stack.push(s.charAt(i));
        }

        for(int i=0; i<s.length(); i++){
            str+=stack.pop();
        }
        System.out.println(str);
    }



    public static void main(String[] args) {
        reverseApproachOne("Diksha");
        reverseApproachTwo("Pathak");
        reverseApproachThree("Hello");
        reverseApproachFour("Yo Hello How are you?");
        reverseApproachFive("outside");
        reverseApproachSix("i am fun");
    }
}
