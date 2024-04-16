import java.rmi.*;
import java.util.Scanner;

public class Klijent {
    private Operater operater;

    public Klijent(String objectName) {

        Scanner scanner = new Scanner(System.in);

        try {
            operater = (Operater) Naming.lookup("rmi://localhost:1099/" + objectName);
            System.out.println("Klijent je povezan na server.");

            while (true) {
                System.out
                        .println("Dobrodosli u korisnicki servis mobilnog operatera. Za nastavak izaberite opciju:\n" +
                                "a) Uplata Minuta \n" +
                                "b) Uplata Poruka \n" +
                                "c) Uplata Interneta \n" +
                                "d) Provera stanja \n" +
                                "e) Kraj ");

                String opcija = scanner.nextLine();

                switch (opcija) {
                    case "a":
                        System.out.println("Unesite broj telefona: ");
                        String broj = scanner.nextLine();
                        Korisnik korisnik = operater.vratKorisnika(broj);
                        if (korisnik == null) {
                            System.out.println("Korisnik sa unetim brojem ne postoji.");
                            break;
                        }
                        System.out.println("Unesite broj minuta: ");
                        int minuti = scanner.nextInt();
                        korisnik.uplatiMinute(minuti);
                        break;

                    case "b":
                        System.out.println("Unesite broj telefona: ");
                        broj = scanner.nextLine();
                        korisnik = operater.vratKorisnika(broj);
                        if (korisnik == null) {
                            System.out.println("Korisnik sa unetim brojem ne postoji.");
                            break;
                        }
                        System.out.println("Unesite broj poruka: ");
                        int poruke = scanner.nextInt();
                        korisnik.uplatiPoruke(poruke);
                        break;

                    case "c":
                        System.out.println("Unesite broj telefona: ");
                        broj = scanner.nextLine();
                        korisnik = operater.vratKorisnika(broj);
                        if (korisnik == null) {
                            System.out.println("Korisnik sa unetim brojem ne postoji.");
                            break;
                        }
                        System.out.println("Unesite broj megabajta: ");
                        int internet = scanner.nextInt();
                        korisnik.uplatiInternet(internet);
                        break;

                    case "d":
                        System.out.println("Unesite broj telefona: ");
                        broj = scanner.nextLine();
                        korisnik = operater.vratKorisnika(broj);
                        if (korisnik == null) {
                            System.out.println("Korisnik sa unetim brojem ne postoji.");
                            break;
                        }
                        Stanje stanje = korisnik.vratiStanje();
                        System.out.println("Broj: " + stanje.vratiBroj());
                        System.out.println("Minuti: " + stanje.vratiMinute());
                        System.out.println("Poruke: " + stanje.vratiPoruke());
                        System.out.println("Internet: " + stanje.vratiInternet());
                        System.out.println("Racun: " + stanje.vratiRacun());
                        break;

                    case "e":
                        System.out.println("Kraj rada.");
                        scanner.close();
                        System.exit(0);
                        break;

                    default:
                        System.out.println("Uneli ste nepostojecu opciju.");
                        break;
                }
            }

        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (scanner != null)
                scanner.close();
        }
    }

    public static void main(String args[]) {
        String objectName = args[0];
        new Klijent(objectName);
    }
}
