import java.rmi.*;

public interface VehicleManager extends Remote {
    boolean requestVehicle(String address) throws RemoteException;

    void addVehicle(Vehicle v, VehicleCallback cb) throws RemoteException;

    void removeVehicle(Vehicle v) throws RemoteException;
}
