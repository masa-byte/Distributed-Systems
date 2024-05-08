import java.io.Serializable;
import java.rmi.*;

public class Vehicle implements Serializable {
    private int id;
    private String address;
    private boolean isFree;
    private int roundNum;

    public Vehicle(int id, String address, boolean isFree, int roundNum) {
        super();
        this.id = id;
        this.address = address;
        this.isFree = isFree;
        this.roundNum = roundNum;
    }

    public int getId() {
        return this.id;
    }

    public String getAddress() {
        return this.address;
    }

    public boolean getIsFree() {
        return this.isFree;
    }

    public int getRoundNum() {
        return this.roundNum;
    }

    public void setAdress(String address) {
        this.address = address;
    }

    public void setRoundNum(int roundNum) {
        this.roundNum = roundNum;
    }
}