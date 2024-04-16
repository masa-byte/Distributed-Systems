import java.io.Serializable;

public class KlijentAukcije implements Serializable {

    private String klijentAukcijeId;
    private String ime;
    private String prezime;

    public KlijentAukcije(String klijentAukcijeId, String ime, String prezime) {
        this.klijentAukcijeId = klijentAukcijeId;
        this.ime = ime;
        this.prezime = prezime;
    }

    public String vratiKlijentAukcijeId() {
        return this.klijentAukcijeId;
    }

    public String vratiIme() {
        return this.ime;
    }

    public String vratiPrezime() {
        return this.prezime;
    }
}