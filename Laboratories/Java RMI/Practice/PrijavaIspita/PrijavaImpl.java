import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;

public class PrijavaImpl extends UnicastRemoteObject implements Prijava {
    private ArrayList<String> ispiti;

    public PrijavaImpl() throws RemoteException {
        super();
        ispiti = new ArrayList<String>();
    }

    @Override
    public String vratiIspite() throws RemoteException {
        String result = "";
        for (String s : ispiti) {
            result += s + "\n";
        }
        return result;
    }

    public void dodajIspit(String ispit) {
        ispiti.add(ispit);
    }
}
