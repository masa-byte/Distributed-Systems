import java.rmi.*;
import java.util.ArrayList;

public interface TagManager extends Remote {
    void SendMessage(TagMessageImpl msg) throws RemoteException;

    void FollowUser(UserImpl user, ArrayList<String> tags, TagMessageCallback cb) throws RemoteException;

    ArrayList<String> GetAllTags() throws RemoteException;
}
