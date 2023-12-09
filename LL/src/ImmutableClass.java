import java.util.Date;

final class Stud{
    private final int rollno;
    private final String name;
    private final Date dob;

    Stud(int rollno, String name, Date dob) {
        this.rollno = rollno;
        this.name = name;
        this.dob = new Date(dob.getTime());
    }
    public String getName()
    {
        return this.name;
    }
    public int getRollno()
    {
        return this.rollno;
    }
    public Date getDob() { return new Date(dob.getTime()); }
}


public class ImmutableClass {
    public static void main(String[] args) {
        Stud s = new Stud(1, "Diksha", new Date());
        System.out.println(s.getName());
        System.out.println(s.getRollno());
        System.out.println(s.getDob());

        //class should be final
        //since there will be no setter methods we will not be setting any value
        //we also cannot directly access data members because they are private
        //cannot change their values because they are final
        //https://www.geeksforgeeks.org/create-immutable-class-java/
    }
}
