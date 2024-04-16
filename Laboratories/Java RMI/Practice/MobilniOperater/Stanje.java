import java.rmi.*;

public interface Stanje extends Remote {
    int vratiMinute() throws RemoteException;

    int vratiPoruke() throws RemoteException;

    int vratiInternet() throws RemoteException;

    float vratiRacun() throws RemoteException;

    String vratiBroj() throws RemoteException;
}
