import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class StudentImpl extends UnicastRemoteObject implements Student {
    private Prijava prijava;
    private String brIndeksa;

    protected StudentImpl(String brIndeksa) throws RemoteException {
        super();
        this.brIndeksa = brIndeksa;
        this.prijava = new PrijavaImpl();
    }

    @Override
    public Prijava vratiPrijavu() throws RemoteException {
        return prijava;
    }

    @Override
    public void prijaviIspit(String ispit) throws RemoteException {
        System.out.println("Student " + this.brIndeksa + " prijavljuje ispit " + ispit);
        ((PrijavaImpl) this.prijava).dodajIspit(ispit);
    }

}
