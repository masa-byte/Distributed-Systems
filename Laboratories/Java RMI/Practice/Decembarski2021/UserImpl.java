import java.io.Serializable;

public class UserImpl implements Serializable {

    private int id;
    private String userName;

    public UserImpl(int id, String userName) {
        this.id = id;
        this.userName = userName;
    }
}