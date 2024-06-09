import java.rmi.Naming;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;

public class Server {
    private TagManager tagManager;

    public Server(String objname) {
        try {
            LocateRegistry.createRegistry(1099);
        } catch (RemoteException e) {
            e.printStackTrace();
        }

        try {
            tagManager = new TagManagerImpl();

            Naming.rebind("rmi://localhost:1099/" + objname, tagManager);
        } catch (Exception e) {

            e.printStackTrace();
        }
    }

    public static void main(String[] args) {
        new Server("tag");
    }
}
