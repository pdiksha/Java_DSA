package Hashing;

import java.util.HashMap;
import java.util.Map;

//Map stores all the value in sorted order
//time complexity - O(log n) for storing and fetching
//unordered map - O(1) for best and average O(n) for worst
public class ProblemByHashMap {

    public static void main(String[] args) {

        int[] arr = {1,2,1,3,2};
        int[] input = {5,1,4,2,3};

        Map<Integer,Integer> hashMap = new HashMap<>();

        for(int i=0; i<arr.length; i++){
            if(!hashMap.containsKey(arr[i])){
                hashMap.put(arr[i],0);
            }
            hashMap.put(arr[i], hashMap.get(arr[i])+1);
        }

        for(int j=0; j<input.length; j++){
            System.out.println(hashMap.get(input[j]));
        }
    }
}
