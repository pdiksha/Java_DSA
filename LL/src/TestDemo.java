import java.util.ArrayList;
import java.util.Date;
import java.util.List;

 class singletons {

  public String s = null;
  private static singletons single_instance=null;

  private singletons(){ this.s = "singleton class";}

  public static singletons getInstance(){
      if(single_instance==null){
          single_instance = new singletons();
      }
      return single_instance;
  }

}


public class TestDemo {
    public static void main(String[] args) {

    singletons x = singletons.getInstance();

    }
}
