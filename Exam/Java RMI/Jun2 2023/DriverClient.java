import java.rmi.*;
import java.rmi.server.UnicastRemoteObject;

public class DriverClient {
    private Vehicle vehicle;
    private VehicleManager vm;
    private VehicleCallback cb;

    public DriverClient() {
        try {
            vm = (VehicleManager) Naming.lookup("rmi://localhost:1099/vm");
            vehicle = new Vehicle(1, null, true, 0);
            cb = new VehicleCallBackImpl();

            vm.addVehicle(vehicle, cb);

            System.out.println("Driver 1 active");
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }

    public class VehicleCallBackImpl extends UnicastRemoteObject implements VehicleCallback {

        protected VehicleCallBackImpl() throws RemoteException {
            super();
        }

        @Override
        public void notifyVehicle(String address) throws RemoteException {
            System.out.println("Your assigned address is " + address);
        }
    }

    public static void main(String args[]) {
        new DriverClient();
    }
}
