import java.util.Arrays;

public class LearnArrayClass {

    public static void main(String[] args) {
        Integer[] nums={1,2,3,4,5,6,7,8,9,10};

        int index= Arrays.binarySearch(nums,10);
        System.out.println("Element found at : " + index);

        //if array is not sorted
        Arrays.sort(nums); //implement quick sort

        //there is a parallel sort also when your array has many numbers

        Arrays.fill(nums,9);
       for(int i:nums) {
           System.out.println(nums[i]);
       }

    }
}
