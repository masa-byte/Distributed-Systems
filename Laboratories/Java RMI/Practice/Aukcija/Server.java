import java.io.IOException;
import java.net.MalformedURLException;
import java.rmi.*;
import java.rmi.registry.*;

public class Server {

    public Server(String objectName) {
        try {
            LocateRegistry.createRegistry(1099);
            System.out.println("Java RMI registry created.");
        } catch (RemoteException e) {
            System.out.println("Java RMI registry already exists.");
        }

        try {
            EAukcijaImpl obj = new EAukcijaImpl();
            obj.dodajEksponat(new EksponatImpl("1", "Eksponat 1", 100));
            obj.dodajEksponat(new EksponatImpl("2", "Eksponat 2", 200));
            obj.dodajEksponat(new EksponatImpl("3", "Eksponat 3", 300));
            obj.dodajEksponat(new EksponatImpl("4", "Eksponat 4", 400));
            obj.dodajEksponat(new EksponatImpl("5", "Eksponat 5", 500));

            Naming.rebind("rmi://localhost:1099/" + objectName, obj);
        } catch (RemoteException e) {
            System.out.println("Failure during RMI object creation: " + e);
        } catch (MalformedURLException e) {
            System.out.println("Failure during Name registration: " + e);
        }
    }

    public static void main(String[] args) {
        String objectName = args[0];

        new Server(objectName);
        System.out.println("Server started.");

        try {
            System.in.read();
        } catch (IOException e) {

        }
    }
}
