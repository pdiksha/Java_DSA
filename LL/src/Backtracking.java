import java.util.ArrayList;
import java.util.List;

public class Backtracking {

    public static void printPermutations(String str, String per) //-O(n*n!)
    {
        if(str.length()<=0)
        {
            System.out.println(per);
            return;
        }
        for(int i=0; i<str.length(); i++)
        {
            char currChar = str.charAt(i);
            String newString = str.substring(0,i) + str.substring(i+1);
            printPermutations(str,per+currChar);
        }

    }


    public static void main(String[] args) {
        String str="ABC";
        printPermutations(str,"");

    }
}
