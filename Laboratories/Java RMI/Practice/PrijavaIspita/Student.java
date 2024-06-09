import java.rmi.Remote;
import java.rmi.RemoteException;

public interface Student extends Remote {
    Prijava vratiPrijavu() throws RemoteException;

    void prijaviIspit(String ispit) throws RemoteException;
}