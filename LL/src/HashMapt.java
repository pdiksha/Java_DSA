import java.util.Scanner;

class HashMapt{

    public static void printMyName(String s){
        System.out.println("My name is : " + s);
        return;
    }

    public static void main(String[] args) {
        Scanner sc=new Scanner(System.in);
        String s = sc.nextLine();
        printMyName(s);
    }
}
