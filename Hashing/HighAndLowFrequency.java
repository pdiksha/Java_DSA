package Hashing;

import java.util.HashMap;
import java.util.Map;

//return the highest and lowest frequency
public class HighAndLowFrequency {

    public static void main(String[] args) {
        int[] arr = {1,2,1,3,2};
        int[] input = {5,1,4,2,3};
        int low,high =0;

        Map<Integer,Integer> hashMap = new HashMap<>();

        for(int i=0; i<arr.length; i++){
            if(!hashMap.containsKey(arr[i])){
                hashMap.put(arr[i],0);
            }
            hashMap.put(arr[i], hashMap.get(arr[i])+1);
        }

        System.out.println(hashMap);

    }
}
