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
            Operater operater = new OperaterImpl();
            for (int i = 0; i < 10; i++) {
                String broj = "061521384" + i;
                int minuti = Math.round((float) Math.random() * 100);
                int poruke = Math.round((float) Math.random() * 100);
                int internet = Math.round((float) Math.random() * 100);

                int minutiTarifa = Math.round((float) Math.random() * 10);
                int porukeTarifa = Math.round((float) Math.random() * 2);
                int internetTarifa = Math.round((float) Math.random() * 100);

                operater.dodajKorisnika(broj, minuti, poruke, internet, minutiTarifa, porukeTarifa, internetTarifa);
            }

            Naming.rebind("rmi://localhost:1099/" + objectName, operater);
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
