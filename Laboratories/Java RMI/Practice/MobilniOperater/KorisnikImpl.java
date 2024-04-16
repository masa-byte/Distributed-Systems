import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class KorisnikImpl extends UnicastRemoteObject implements Korisnik {

    private int minutiTarifa;
    private int porukeTarifa;
    private int internetTarifa;
    private Stanje stanje;

    protected KorisnikImpl(String broj, int minuti, int poruke, int internet, int minutiTarifa, int porukeTarifa,
            int internetTarifa) throws RemoteException {
        super();
        int racun = minuti * minutiTarifa + poruke * porukeTarifa + internet * internetTarifa;
        this.stanje = new StanjeImpl(broj, minuti, poruke, internet, racun);
        this.minutiTarifa = minutiTarifa;
        this.porukeTarifa = porukeTarifa;
        this.internetTarifa = internetTarifa;
    }

    @Override
    public void uplatiMinute(int minuti) throws RemoteException {
        int noviMinuti = stanje.vratiMinute() + minuti;
        stanje = new StanjeImpl(stanje.vratiBroj(), noviMinuti, stanje.vratiPoruke(), stanje.vratiInternet(),
                stanje.vratiRacun() + minuti * minutiTarifa);
    }

    @Override
    public void uplatiPoruke(int poruke) throws RemoteException {
        int novePoruke = stanje.vratiPoruke() + poruke;
        stanje = new StanjeImpl(stanje.vratiBroj(), stanje.vratiMinute(), novePoruke, stanje.vratiInternet(),
                stanje.vratiRacun() + poruke * porukeTarifa);
    }

    @Override
    public void uplatiInternet(int internet) throws RemoteException {
        int noviInternet = stanje.vratiInternet() + internet;
        stanje = new StanjeImpl(stanje.vratiBroj(), stanje.vratiMinute(), stanje.vratiPoruke(), noviInternet,
                stanje.vratiRacun() + internet * internetTarifa);
    }

    @Override
    public Stanje vratiStanje() throws RemoteException {
        return stanje;
    }

}
