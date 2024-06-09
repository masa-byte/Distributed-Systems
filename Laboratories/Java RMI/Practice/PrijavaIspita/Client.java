import java.rmi.Naming;
import java.util.Scanner;

public class Client {

    public Client() {
        Scanner sc = new Scanner(System.in);
        try {
            EStudSluzba sluzba = (EStudSluzba) Naming.lookup("rmi://localhost:1099/sluzba");

            while (true) {
                System.out.println("Izaberi opcije:");
                System.out.println("1. Prijavi ispit");
                System.out.println("2. Prikazi ispite");
                System.out.println("3. Kraj");

                int opcija = sc.nextInt();

                if (opcija == 1) {

                    System.out.println("Unesi broj indeksa:");
                    String brIndeksa = sc.next();

                    Student s = sluzba.vratiStudenta(brIndeksa);

                    System.out.println("Unesi ispit:");

                    String ispit = sc.next();
                    s.prijaviIspit(ispit);
                } else if (opcija == 2) {

                    System.out.println("Unesi broj indeksa:");
                    String brIndeksa = sc.next();

                    Student s = sluzba.vratiStudenta(brIndeksa);
                    System.out.println(s.vratiPrijavu().vratiIspite());

                } else if (opcija == 3) {
                    break;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void main(String[] args) {
        new Client();
    }
}
