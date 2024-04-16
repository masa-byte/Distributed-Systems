import java.rmi.*;

public interface Operater extends Remote {
    void dodajKorisnika(String broj, int minuti, int poruke, int internet, int minutiTarifa, int porukeTarifa,
            int internetTarifa) throws RemoteException;

    Korisnik vratKorisnika(String broj) throws RemoteException;
}
