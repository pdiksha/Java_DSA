import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Scanner;

public class Graphs {

//    storing a graph
//    1.adjacency list - array of array list - why this is optimized because in graph finding neighbors is a frequent operation
//    2. adjacency matrix
//    3. edge list
//    4. 2d matrix (implicit graph) - space is used more , finding neighbour takes more time because it goes through every node

    //for creating MST (minimum spanning tree) from edge list
    static class Edge{
        int src;
        int dest;
        int wt;
        public Edge(int s, int d, int w){
            this.src=s;
            this.dest=d;
            this.wt=w;
        }
    }

    public static void createGraph(ArrayList<Edge> graph[]){
        //this is imp, create an empty arraylist on every index
        for(int i=0; i<graph.length; i++){
            graph[i]=new ArrayList<Edge>();
        }

        graph[0].add(new Edge(0,2,2));
        graph[1].add(new Edge(1,2,10));
        graph[1].add(new Edge(1,3,0));
        graph[2].add(new Edge(2,0,2));
        graph[2].add(new Edge(2,1,10));
        graph[2].add(new Edge(2,3,-1));
        graph[3].add(new Edge(3,1,-1));
        graph[3].add(new Edge(3,2,0));

    }

    public static void bfs(ArrayList<Edge> graph[], int v, boolean vis[], int start){
        Queue<Integer> q = new LinkedList<>();

        q.add(start);
        while(!q.isEmpty()){
            int curr=q.remove();
            if(vis[curr]==false){
                System.out.print(curr+ " ");
                vis[curr]=true;
                for(int i=0; i<graph[curr].size(); i++){
                    Edge e=graph[curr].get(i);

                    q.add(e.dest);
                }
            }
        }
    }

    public static void dfs(ArrayList<Edge> graph[], int curr, boolean vis[]){
        System.out.print(curr+ " ");
        vis[curr]=true;

        for(int i=0; i<graph[curr].size(); i++){
            Edge e=graph[curr].get(i);
            if(vis[e.dest]==false)
                dfs(graph,e.dest,vis);
        }
    }

    public static void main(String[] args) {
        int v = 4;
        ArrayList<Edge> graph[] = new ArrayList[v];
        createGraph(graph);

        //print 2's neighbours
        for(int i=0; i<graph[2].size(); i++){
            Edge e = graph[2].get(i);
            System.out.print(e.dest + " " + e.wt);
            System.out.println();
        }

        //this bfs approach works for disconnected components also
        boolean vis[] = new boolean[v];
        for(int i=0; i<v; i++){
            if(vis[i]==false){
                bfs(graph,v,vis,i);
            }
        }
        System.out.println();

        boolean vis1[] = new boolean[v];
        for(int i=0; i<v; i++){
            if(vis1[i]==false){
                dfs(graph,0,vis1);
            }
        }






    }

}
