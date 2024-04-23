import java.rmi.Naming;
import java.util.Scanner;

public class UserClient {
    private VehicleManager vm;

    public UserClient() {
        Scanner scanner = new Scanner(System.in);
        try {
            vm = (VehicleManager) Naming.lookup("rmi://localhost:1099/vm");

            System.out.println("Client active");

            System.out.println("Address");

            String address = scanner.nextLine();
            if (vm.requestVehicle(address) == true) {
                System.out.println("Vehicle will be at the address in 5 minutes");
            } else {
                System.out.println("No free vehicles, forgive us!");
            }

        } catch (Exception e) {
            System.out.println(e.getMessage());
        } finally {
            scanner.close();
        }
    }

    public static void main(String args[]) {
        new UserClient();
    }
}
