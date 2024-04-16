import java.rmi.*;

public interface Callback extends Remote {
    public void cenaEksponentaPromenjena(String id, int cena) throws RemoteException;
}
