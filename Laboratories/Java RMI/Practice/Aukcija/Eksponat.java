import java.rmi.*;
import java.util.ArrayList;

public interface Eksponat extends Remote {

    void prijaviLicitaciju(KlijentAukcije klijentAukcije, Callback callback) throws RemoteException;

    void odjaviLicitaciju(String klijentAukcijeId) throws RemoteException;

    ArrayList<KlijentAukcije> vratiKlijenteAukcije() throws RemoteException;

    String vratiNaziv() throws RemoteException;

    String vratiId() throws RemoteException;

    int vratiCenu() throws RemoteException;

    void povecajCenu(int iznos) throws RemoteException;
}
