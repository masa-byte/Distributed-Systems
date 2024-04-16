import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class StanjeImpl extends UnicastRemoteObject implements Stanje {

    private String broj;
    private int minuti;
    private int poruke;
    private int internet;
    private float racun;

    protected StanjeImpl(String broj, int minuti, int poruke, int internet, float racun) throws RemoteException {
        super();
        this.broj = broj;
        this.minuti = minuti;
        this.poruke = poruke;
        this.internet = internet;
        this.racun = racun;
    }

    @Override
    public int vratiMinute() throws RemoteException {
        return minuti;
    }

    @Override
    public int vratiPoruke() throws RemoteException {
        return poruke;
    }

    @Override
    public int vratiInternet() throws RemoteException {
        return internet;
    }

    @Override
    public float vratiRacun() throws RemoteException {
        return racun;
    }

    @Override
    public String vratiBroj() throws RemoteException {
        return broj;
    }
}
