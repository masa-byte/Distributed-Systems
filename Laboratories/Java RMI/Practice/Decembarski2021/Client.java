
import java.rmi.Naming;
import java.util.ArrayList;

public class Client {
    private TagManager tagManager;

    public Client(String objname) {
        try {
            tagManager = (TagManager) Naming.lookup("rmi://localhost:1099/" + objname);
        } catch (Exception e) {
            e.printStackTrace();
        }

        TagMessageCallback cb = new TagMessageCallbackImpl();

        try {
            tagManager.FollowUser(new UserImpl(1, "user1"), new ArrayList<String>(), cb);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public class TagMessageCallbackImpl implements TagMessageCallback {

        @Override
        public void OnTagMessage(TagMessageImpl msg, String tag) {
            System.out.println("Received message with tag: " + tag);
        }

    }

    public static void main(String[] args) {
        new Client("tag");
    }
}
