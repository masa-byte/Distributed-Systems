import java.rmi.Remote;
import java.rmi.RemoteException;

public interface VehicleCallback extends Remote {
    void notifyVehicle(String address) throws RemoteException;
}
