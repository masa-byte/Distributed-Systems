import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.HashMap;

public class OperaterImpl extends UnicastRemoteObject implements Operater {

    private HashMap<String, Korisnik> korisnici;

    protected OperaterImpl() throws RemoteException {
        super();
        korisnici = new HashMap<>();
    }

    @Override
    public void dodajKorisnika(String broj, int minuti, int poruke, int internet, int minutiTarifa,
            int porukeTarifa,
            int internetTarifa) throws RemoteException {
        Korisnik korisnik = new KorisnikImpl(broj, minuti, poruke, internet, minutiTarifa, porukeTarifa,
                internetTarifa);
        korisnici.put(broj, korisnik);
    }

    @Override
    public Korisnik vratKorisnika(String broj) throws RemoteException {
        return korisnici.get(broj);
    }

}
