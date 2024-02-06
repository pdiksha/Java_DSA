
//https://www.geeksforgeeks.org/create-immutable-class-java/

//for a normal class we use a constructor to instantiate an object while for a singleton class we use a
//getinstance() method
//i can also use singleton() instead of getinstance() by keeping everything same
class singleton{
    private static singleton single_instance = null;
    public String s;
    private singleton()
    {
        s="hello, I am a part of a singleton class";
    }

    public static singleton getInstance()
    {
        if(single_instance==null)
        {
            single_instance = new singleton();
        }
        return single_instance;
    }


}

public class SingletonClass {

    public static void main(String[] args) {

        singleton x = singleton.getInstance();
        singleton y = singleton.getInstance();
        singleton z = singleton.getInstance();
        x.s="hello";

        System.out.println("Hash code of x : " + x.hashCode());
        System.out.println("Hash code of y : " + y.hashCode());
        System.out.println("Hash code of z : " + z.hashCode());
        System.out.println(x.s);
        y.s="pathak";
        System.out.println(x.s);

        if(x==y && y==z)
        {
            System.out.println("All objects point to the same memory location");
        }
        else
        {
            System.out.println("All objects don't point to the same memory location");
        }
    }
}
