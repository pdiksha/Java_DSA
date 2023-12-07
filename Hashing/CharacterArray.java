package Hashing;


import java.util.Arrays;

public class CharacterArray {

    public static void main(String[] args) {

        String s = "abcdabehf";
        char[] input = {'a','g','h','b','c'};
        int[] hashingArray = new int[26];

        //precompute
        for(int i=0; i<s.length(); i++){
            hashingArray[s.charAt(i)-'a']++;
        }

        System.out.println(Arrays.toString(hashingArray));

        //fetch
        for(int i=0; i<input.length; i++){
            System.out.println(hashingArray[input[i]-'a']);
        }

    }
}
