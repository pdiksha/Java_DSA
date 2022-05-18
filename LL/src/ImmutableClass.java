
final class Stud{
    private final int rollno;
    private final String name;

    Stud(int rollno, String name) {
        this.rollno = rollno;
        this.name = name;
    }
    public String getName()
    {
        return this.name;
    }
    public int getRollno()
    {
        return this.rollno;
    }
}


public class ImmutableClass {
    public static void main(String[] args) {
        Stud s = new Stud(1, "Diksha");
        System.out.println(s.getName());
        System.out.println(s.getRollno());

        //class should be final
        //since there will be no setter methods we will not be setting any value
        //we also cannot directly access data members becase they are private
        //cannot change their values because they are final
        //https://www.geeksforgeeks.org/create-immutable-class-java/
    }
}
