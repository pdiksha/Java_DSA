import java.util.ArrayList;

public class RecursionAdvanced {


    //print total permutations for a given string
    public static void printPermutations(String str, String perm) //-O(n!)
    {
        if(str.length()==0)
        {
            System.out.println(perm);
            return;
        }
        for(int i=0; i<str.length(); i++)
        {
            char currChar=str.charAt(i);
            String newStr=str.substring(0,i) + str.substring(i+1);
            printPermutations(newStr,perm+currChar);
        }
    }

    //time complexity is too high for this approach and hence we use dynamic programming to solve this.
    //count total paths in a maze to reach from (0,0) to (n,m)
    public static int countPaths(int i,int j,int n, int m)
    {
        if(i==n || j==m)
        {
            return 0;

        }
        if((i==n-1) && (j==m-1))
        {
            return 1;

        }
        //move downwards
        int downPaths=countPaths(i+1,j,n,m);

        //move right
        int rightPaths=countPaths(i,j+1,n,m);

        return downPaths+rightPaths;
    }

    //place tiles of size 1*m in a floor of size n*m
    //solve using dynamic programming for less time complexity
    public static int placeTiles(int n,int m)
    {
        if(n==m)
        {
            return 2;
        }
        if(n<m)
        {
            return 1;
        }

        //vertically placements
        int vertPlacements=placeTiles(n-m,m);

        //Horizontally Placements
        int horizPlacements=placeTiles(n-1,m);

        return vertPlacements+horizPlacements;

    }

    //find the number of ways you can invite n guests to your party, single or in pairs
    public static int callGuests(int n)
    {
        if(n<=1)
        {
           return 1;
        }
        //single
        int ways1=callGuests(n-1);

        //in pairs
        int ways2=(n-1) * callGuests(n-2);

        return ways2+ways1;

    }

    //print subset
    public static void printSubset(ArrayList<Integer> set)
    {
        for(int i=0; i<set.size(); i++)
        {
            System.out.print(set.get(i) + " ");
        }
        System.out.println();
    }

    //print all the subsets of a set of n natural numbers
    public static void findSubsets(int n, ArrayList<Integer> set)
    {
        if(n==0)
        {
            printSubset(set);
            return;
        }
        //will get added
        set.add(n);
        findSubsets(n-1,set);

        //will not get added
        set.remove(set.size()-1);
        findSubsets(n-1,set);
    }


    public static void main(String[] args) {
        String str="abc";
        printPermutations(str,"");
        int n=6,m=6;
        int totalPaths=countPaths(0,0,n,m);
        System.out.println("Total Paths - " + totalPaths);
        int x=3,y=3;
        System.out.println("Ways of placing a tile " +placeTiles(x,y));
        System.out.println("Guests can come in " + callGuests(4) + " ways");

        int p=3;
        ArrayList<Integer> subset = new ArrayList<>();
        findSubsets(p,subset);


    }
}
