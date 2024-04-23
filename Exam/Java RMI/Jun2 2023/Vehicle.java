import java.io.Serializable;
import java.rmi.*;

public class Vehicle implements Serializable {
    private int id;
    private String address;
    private boolean isFree;
    private int roundNum;

    public Vehicle(int id, String address, boolean isFree, int roundNum) throws RemoteException {
        super();
        this.id = id;
        this.address = address;
        this.isFree = isFree;
        this.roundNum = roundNum;
    }

    public int getId() throws RemoteException {
        return this.id;
    }

    public String getAddress() throws RemoteException {
        return this.address;
    }

    public boolean getIsFree() throws RemoteException {
        return this.isFree;
    }

    public int getRoundNum() throws RemoteException {
        return this.roundNum;
    }

    public void setAdress(String address) throws RemoteException {
        this.address = address;
    }

    public void setRoundNum(int roundNum) throws RemoteException {
        this.roundNum = roundNum;
    }
}