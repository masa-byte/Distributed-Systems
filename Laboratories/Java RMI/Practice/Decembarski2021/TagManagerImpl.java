import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.HashMap;
import java.rmi.RemoteException;

public class TagManagerImpl extends UnicastRemoteObject implements TagManager {
    private ArrayList<String> tags;
    private HashMap<UserImpl, ArrayList<String>> userFollowingTags;
    private HashMap<UserImpl, TagMessageCallback> userCallbacks;

    protected TagManagerImpl() throws RemoteException {
        super();
        tags = new ArrayList<String>();
    }

    @Override
    public void SendMessage(TagMessageImpl msg) throws RemoteException {
        ArrayList<String> tags = msg.GetTags();

        for (String tag : tags) {
            if (!this.tags.contains(tag)) {
                this.tags.add(tag);
            }

            for (UserImpl user : userFollowingTags.keySet()) {
                if (userFollowingTags.get(user).contains(tag)) {
                    TagMessageCallback cb = userCallbacks.get(user);
                    cb.OnTagMessage(msg, tag);
                }
            }
        }
    }

    @Override
    public void FollowUser(UserImpl user, ArrayList<String> tags, TagMessageCallback cb) throws RemoteException {
        userCallbacks.put(user, cb);
        userFollowingTags.put(user, tags);
    }

    @Override
    public ArrayList<String> GetAllTags() throws RemoteException {
        return this.tags;
    }

}
