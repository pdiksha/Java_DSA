package Hashing;

import java.util.Arrays;

//Hashing is precomputing the results and fetching when required
//Time complexity - O(n)
public class IntegerArray {

    public static void main(String[] args) {

        int[] arr = {1,2,1,3,2};
        int[] input = {5,1,4,2,3};

        int[] hashingArray = new int[12];
        //by default int arrays are initialized to 0 if we still want to initialize with a value then we can use Arrays.fill()
        Arrays.fill(hashingArray,0);

        //pre-compute
        for(int i=0; i<arr.length; i++){
            hashingArray[arr[i]]++;
        }

        //fetching
        for(int j=0; j<input.length; j++){
            System.out.println(hashingArray[input[j]]);
        }

    }
}
