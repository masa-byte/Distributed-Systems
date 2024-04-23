import java.rmi.*;
import java.rmi.registry.*;

public class Server {

    private VehicleManager vehicleManager;

    public Server() {
        try {
            LocateRegistry.createRegistry(1099);
            vehicleManager = new VehicleManagerImpl();
            Naming.rebind("rmi://localhost:1099/vm", vehicleManager);

            System.out.println("Server active");
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }

    public static void main(String args[]) {
        new Server();
    }
}
