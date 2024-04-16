import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.HashMap;

public class EksponatImpl extends UnicastRemoteObject implements Eksponat {

    private String id;
    private String naziv;
    private int cena;
    private HashMap<String, KlijentAukcije> prijavljeniKlijenti;
    private HashMap<String, Callback> callbacks;

    protected EksponatImpl(String id, String naziv, int cena) throws RemoteException {
        super();
        this.id = id;
        this.naziv = naziv;
        this.cena = cena;
        this.prijavljeniKlijenti = new HashMap<String, KlijentAukcije>();
        this.callbacks = new HashMap<String, Callback>();
    }

    @Override
    public void prijaviLicitaciju(KlijentAukcije klijentAukcije, Callback callback) throws RemoteException {

        if (!prijavljeniKlijenti.containsKey(klijentAukcije.vratiKlijentAukcijeId())) {

            prijavljeniKlijenti.put(klijentAukcije.vratiKlijentAukcijeId(), klijentAukcije);
            callbacks.put(klijentAukcije.vratiKlijentAukcijeId(), callback);
        } else {
            System.out.println(
                    "Klijent sa ID-jem " + klijentAukcije.vratiKlijentAukcijeId() + " je vec prijavljen na aukciju.");
        }
    }

    @Override
    public void odjaviLicitaciju(String klijentAukcijeId) throws RemoteException {
        if (prijavljeniKlijenti.containsKey(klijentAukcijeId)) {

            prijavljeniKlijenti.remove(klijentAukcijeId);
            callbacks.remove(klijentAukcijeId);
        } else {
            System.out.println("Klijent sa ID-jem " + klijentAukcijeId + " nije prijavljen na aukciju.");
        }
    }

    @Override
    public ArrayList<KlijentAukcije> vratiKlijenteAukcije() throws RemoteException {
        return new ArrayList<KlijentAukcije>(prijavljeniKlijenti.values());
    }

    @Override
    public String vratiNaziv() throws RemoteException {
        return this.naziv;
    }

    @Override
    public String vratiId() throws RemoteException {
        return this.id;
    }

    @Override
    public int vratiCenu() throws RemoteException {
        return this.cena;
    }

    @Override
    public void povecajCenu(int iznos) throws RemoteException {
        if (iznos < 0) {
            System.out.println("Iznos mora biti pozitivan.");
            return;
        }
        if (iznos == 0) {
            System.out.println("Iznos mora biti veci od 0.");
            return;
        }

        this.cena += iznos;
        callCallbacks();
    }

    private void callCallbacks() {
        for (Callback cb : callbacks.values()) {
            try {
                cb.cenaEksponentaPromenjena(this.id, this.cena);
            } catch (RemoteException e) {
                e.printStackTrace();
            }
        }
    }
}
