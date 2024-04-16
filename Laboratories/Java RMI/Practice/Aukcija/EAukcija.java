import java.rmi.*;

public interface EAukcija extends Remote {

    Eksponat vratiEksponat(String id) throws RemoteException;

    void dodajEksponat(Eksponat eksponat) throws RemoteException;
}
