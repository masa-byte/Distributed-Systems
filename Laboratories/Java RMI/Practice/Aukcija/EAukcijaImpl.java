import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.HashMap;

public class EAukcijaImpl extends UnicastRemoteObject implements EAukcija {

    private HashMap<String, Eksponat> eksponati;

    protected EAukcijaImpl() throws RemoteException {
        super();
        eksponati = new HashMap<String, Eksponat>();
    }

    @Override
    public Eksponat vratiEksponat(String id) throws RemoteException {
        return eksponati.get(id);
    }

    @Override
    public void dodajEksponat(Eksponat eksponat) throws RemoteException {
        eksponati.put(eksponat.vratiId(), eksponat);
    }
}
