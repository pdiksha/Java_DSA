import java.util.HashSet;
import java.util.Objects;
import java.util.Set;

public class Student {
    int rollno;
    String name;

    public Student(String name, int rollno)
    {
        this.name = name;
        this.rollno=rollno;
    }

    @Override
    public String toString() {
        return "Student{" +
                "rollno=" + rollno +
                ", name='" + name + '\'' +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Student student = (Student) o;
        return rollno == student.rollno;
    }

    @Override
    public int hashCode() {
        return Objects.hash(rollno);
    }

    public static void main(String[] args) {
        Set<Student> set= new HashSet<>();
        set.add(new Student("diksha", 10));
        set.add(new Student("pathak", 11));
        set.add(new Student("hello", 12));
        set.add(new Student("world", 13));
        set.add(new Student("kamal", 14));

        System.out.println(set);

    }
}
