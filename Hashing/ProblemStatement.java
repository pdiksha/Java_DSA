package Hashing;

//Given an array

//Time Complexity - O(q*n)
public class ProblemStatement {

    public static void main(String[] args) {

        int[] arr = {1,2,1,3,2};
        int[] input = {5,1,4,2,3};
        int count;
        for(int i =0; i<input.length; i++){
            count=0;
            for(int j=0; j< arr.length; j++){
                if(input[i]==arr[j]){
                    count++;
                }
            }
            System.out.println(count);
        }

    }
}
