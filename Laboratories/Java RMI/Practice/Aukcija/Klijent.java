import java.rmi.*;
import java.rmi.server.UnicastRemoteObject;
import java.util.Scanner;

public class Klijent {

    private EAukcija aukcija;
    private Callback callback;

    public Klijent(String objectName) {

        Scanner scanner = new Scanner(System.in);

        try {
            callback = new CallbackImpl();

            aukcija = (EAukcija) Naming.lookup("rmi://localhost:1099/" + objectName);
            System.out.println("Uspesno povezan sa serverom.");

            String ime;
            String prezime;
            String id;
            String eksponatId;

            System.out.println("Dobrodosli na elektronsku aukciju. Za nastavak unesite vase licne podatke:");
            System.out.println("Unesite ime:");
            ime = scanner.nextLine();
            System.out.println("Unesite prezime:");
            prezime = scanner.nextLine();
            System.out.println("Unesite ID:");
            id = scanner.nextLine();

            KlijentAukcije klijentAukcije = new KlijentAukcije(id, ime, prezime);

            while (true) {
                System.out.println("Unesite ID eksponata od interesa:");
                eksponatId = scanner.nextLine();

                Eksponat eksponat = aukcija.vratiEksponat(eksponatId);

                if (eksponat == null) {
                    System.out.println("Eksponat sa ID-jem " + eksponatId + " ne postoji.");
                    continue;
                }

                System.out.println("Eksponat: " + eksponat.vratiNaziv() + " Cena: " + eksponat.vratiCenu());

                System.out
                        .println("Izaberite opciju: \n a) Licitacija (i povecanje cene) \n b) Odustajanje \n c) Kraj");
                String opcija = scanner.nextLine();

                switch (opcija) {
                    case "a":
                        eksponat.prijaviLicitaciju(klijentAukcije, callback);
                        System.out.println("Unesite iznos za povecanje cene:");
                        int iznos = scanner.nextInt();
                        eksponat.povecajCenu(iznos);

                        break;
                    case "b":
                        eksponat.odjaviLicitaciju(klijentAukcije.vratiKlijentAukcijeId());
                        break;
                    case "c":
                        break;
                    default:
                        System.out.println("Nepostojeca opcija.");
                }
            }
        } catch (Exception e) {
            System.out.println("Greska: " + e);
        } finally {
            if (scanner != null)
                scanner.close();
        }
    }

    private void showMessage(String message) {
        System.out.println(message);
    }

    public static void main(String args[]) {
        String objectName = args[0];
        new Klijent(objectName);
    }

    public class CallbackImpl extends UnicastRemoteObject implements Callback {

        public CallbackImpl() throws RemoteException {
            super();
        }

        @Override
        public void cenaEksponentaPromenjena(String eksponatId, int novaCena) throws RemoteException {
            showMessage("Nova cena eksponata " + eksponatId + " je " + novaCena);
        }
    }
}
