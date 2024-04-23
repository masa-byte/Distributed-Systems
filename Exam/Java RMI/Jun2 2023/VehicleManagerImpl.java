import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.HashMap;

public class VehicleManagerImpl extends UnicastRemoteObject implements VehicleManager {
    private HashMap<Vehicle, VehicleCallback> vehicles;
    private ArrayList<String> waitingQueue;
    private int waitingQueueSize;

    public VehicleManagerImpl() throws RemoteException {
        super();
        this.vehicles = new HashMap<>();
        this.waitingQueue = new ArrayList<>();
        this.waitingQueueSize = 20;
    }

    @Override
    public synchronized void addVehicle(Vehicle v, VehicleCallback cb) throws RemoteException {
        this.vehicles.put(v, cb);
    }

    @Override
    public synchronized void removeVehicle(Vehicle v) throws RemoteException {
        this.vehicles.remove(v);
    }

    @Override
    public synchronized boolean requestVehicle(String address) throws RemoteException {
        // finding minimum round number
        int minRoundNumber = Integer.MAX_VALUE;
        for (Vehicle v : vehicles.keySet()) {
            if (v.getIsFree() && (v.getRoundNum() < minRoundNumber)) {
                minRoundNumber = v.getRoundNum();
            }
        }
        // if minRoundNumber is still MAX_VALUE -> no vehicle is free
        // we assume the waiting queue has room
        if (minRoundNumber == Integer.MAX_VALUE && this.getQueueSize() < waitingQueueSize) {
            this.addToQueue(address);
            return true;
        } else if (this.getQueueSize() == waitingQueueSize) {
            return false;
        }

        // finding all with the same minimum value
        ArrayList<Vehicle> minRoundNumberVehicles = new ArrayList<>();
        for (Vehicle v : vehicles.keySet()) {
            if (v.getRoundNum() == minRoundNumber) {
                minRoundNumberVehicles.add(v);
            }
        }
        // taking the one with biggest id
        int maxId = Integer.MIN_VALUE;
        Vehicle maxIdVehicle = minRoundNumberVehicles.get(0);
        for (Vehicle v : minRoundNumberVehicles) {
            if (v.getId() > maxId) {
                maxId = v.getId();
                maxIdVehicle = v;
            }
        }

        maxIdVehicle.setAdress(address);
        maxIdVehicle.setRoundNum(minRoundNumber + 1);
        vehicles.get(maxIdVehicle).notifyVehicle(address);
        return true;
    }

    private void addToQueue(String address) {
        this.waitingQueue.add(address);
    }

    private int getQueueSize() {
        return this.waitingQueue.size();
    }
}
