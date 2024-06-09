import java.util.ArrayList;
import java.io.Serializable;

public class TagMessageImpl implements Serializable {
    private UserImpl user;
    private String msg;
    private ArrayList<String> tags;

    public TagMessageImpl(UserImpl user, String msg, ArrayList<String> tags) {
        this.user = user;
        this.msg = msg;
        this.tags = tags;
    }

    public UserImpl GetUser() {
        return this.user;
    }

    public String GetMsg() {
        return this.msg;
    }

    public ArrayList<String> GetTags() {
        return this.tags;
    }
}