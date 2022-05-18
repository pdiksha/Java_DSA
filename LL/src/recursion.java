import java.util.HashSet;

public class recursion {

  public static  int sum=0;
  public static  int fact=1;
  public static int res=1;
  public static int first=-1;
  public static int last = -1;
  public static boolean[] map=new boolean[26];


    public static void printsum(int i, int n, int sum)
    {
        if(i==n)
        {
            sum+=i;
            System.out.println(sum);
            return;
        }
       sum+=i;
       printsum(i+1,n,sum);
    }

    public static int factorial(int n)
    {

        if(n==0)
        {
            return fact;
        }
        fact*=n;
        return factorial(n-1);
    }

    public static void fibonacci(int a, int b, int n)
    {
        if(n==0)
            return;
      int c=a+b;
        System.out.print(" " +c);
        fibonacci(b,c,n-1);
    }

    public static int pow(int x, int n) //- O(n) stack height
    {
        if(n==0)
            return res;
        res=x*pow(x,n-1);
        return res;
    }

    public static int pow1(int x, int n) //- O(log n) stack height
    {
        if(n==0)
            return 1;
        if(x==0)
            return 0;
        if(n%2==0)
        {
            return pow1(x,n/2) * pow1(x,n/2);
        }
        else
        {
            return pow1(x,n/2) * pow1(x,n/2) * x;
        }

    }

    public static void towerOfHanoi(int n, String src, String helper, String dest)
    {
        if(n==1)
        {
            System.out.println("Transferring disk " + n + " from " + src + " to " + dest);
            return;
        }
        towerOfHanoi(n-1,src,dest,helper);
        System.out.println("Transferring disk " + n + " from " + src + " to " + dest);
        towerOfHanoi(n-1,helper,src,dest);

    }

    public static void stringreverse(String str, int index)
    {
        if(index<0)
        {
            return;
        }
        System.out.print(str.charAt(index));
        stringreverse(str,index-1);
    }

    public static void findOccurance(String str, int index,char element) //-O(n)
    {
        if(index==str.length())
        {
            System.out.println();
            System.out.println("first occurence " + first);
            System.out.println("last occurence "+ last);
            return;
        }
        char currChar=str.charAt(index);
        if(currChar==element)
        {
            if(first==-1)
            {
                first=index;
            }
            else
            {
                last=index;
            }
        }
        findOccurance(str,index+1, element);
    }

    public static boolean isStrictlySorted(int[] arr, int index)
    {
        if(index== arr.length-1)
        {
            return true;
        }
        if(arr[index]<arr[index+1])
        {
            return isStrictlySorted(arr,index+1);
        }
        else
        {
            return false;
        }
    }

    public static void moveAllx(String str,int index,int count, String newStr)
    {
        if(index==str.length())
        {
            for(int i=0; i<count; i++)
            {
                newStr+='x';
            }
            System.out.println(newStr);
            return;
        }
        char currChar = str.charAt(index);
        if(currChar=='x')
        {
            count++;
            moveAllx(str,index+1,count,newStr);
        }
        else
        {
            newStr+=currChar;
            moveAllx(str,index+1,count,newStr);
        }
    }

    public static void removeDuplicates(String str,int index, String newStr)
    {
        if(index==str.length())
        {
            System.out.println(newStr);
            return;
        }
        char currChar=str.charAt(index);
        if(map[currChar-'a']==true)
        {
            removeDuplicates(str,index+1,newStr);
        }
        else
        {
            newStr+=currChar;
            map[currChar-'a']=true;
            removeDuplicates(str,index+1,newStr);
        }
    }

    public static void subsequences(String str, int index, String newStr) //-O(2^n)
    {
        if(index==str.length())
        {
            System.out.println(newStr);
            return;
        }
        char currChar=str.charAt(index);
        // to be
        subsequences(str,index+1, newStr+currChar);

        //or not to be
        subsequences(str,index+1,newStr);
    }

    public static void subsequences1(String str, int index, String newStr,HashSet<String> set) //-O(2^n)
    {
        if(index==str.length())
        {
            if(set.contains(newStr))
            {
                return;
            }
            else
            {
                System.out.println(newStr);
                set.add(newStr);
                return;
            }
        }
        char currChar=str.charAt(index);
        // to be
        subsequences1(str,index+1, newStr+currChar,set);

        //or not to be
        subsequences1(str,index+1,newStr,set);
    }
     public static String[] keypad={ ".","abc","def","ghi","jkl","mno","pqrs","tu","vwx","yz"};

    public static void printCombinations(String str, int index, String comb)
    {
        if(index==str.length())
        {
            System.out.println(comb);
            return;
        }
        char currChar=str.charAt(index);
        String mapping=keypad[currChar-'0'];
        for(int i=0; i<mapping.length(); i++)
        {
            printCombinations(str,index+1,comb+mapping.charAt(i));
        }
    }

    public static void main(String[] args) {
     printsum(1,5,0);
     System.out.println(factorial(5));
        System.out.print("0" + " 1");
        fibonacci(0,1,5);
        System.out.println();
        int res=pow(2,8);
        System.out.println(res);

        int n=3;
        towerOfHanoi(n,"S","H","D");
        stringreverse("diksha pathak","diksha pathak".length()-1);
        findOccurance("abaacdaefaah", 0, 'a');

        int arr[]={1,2,3,4,5};
        boolean res1=isStrictlySorted(arr,0);
        System.out.println(res1);

        moveAllx("axbxcdxx",0,0,"");
        removeDuplicates("aabcddeff",0,"");
        subsequences("abc",0,"");

        //subsequence example with all same character "aaa"
        HashSet<String> set=new HashSet<>();
        subsequences1("aaa",0,"",set);
        printCombinations("23",0,"");

    }
}
