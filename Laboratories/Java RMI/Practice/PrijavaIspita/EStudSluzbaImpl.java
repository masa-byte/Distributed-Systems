import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.HashMap;

public class EStudSluzbaImpl extends UnicastRemoteObject implements EStudSluzba {
    private HashMap<String, Student> studenti;

    protected EStudSluzbaImpl() throws RemoteException {
        super();

        this.studenti = new HashMap<String, Student>();
        this.studenti.put("123", new StudentImpl("123"));
        this.studenti.put("124", new StudentImpl("124"));
        this.studenti.put("125", new StudentImpl("125"));
        this.studenti.put("126", new StudentImpl("126"));
        this.studenti.put("127", new StudentImpl("127"));
        this.studenti.put("128", new StudentImpl("128"));
        this.studenti.put("129", new StudentImpl("129"));
        this.studenti.put("130", new StudentImpl("130"));
        this.studenti.put("131", new StudentImpl("131"));
        this.studenti.put("132", new StudentImpl("132"));
    }

    @Override
    public Student vratiStudenta(String brIndeksa) throws RemoteException {
        return this.studenti.get(brIndeksa);
    }

}
