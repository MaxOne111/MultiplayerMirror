using Mirror;
using UnityEngine;

public class ServerListener : NetworkManager
{
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        base.OnServerConnect(conn);
        
        Debug.Log($"Client with ID {conn.connectionId} has connected");
    }


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        
        Debug.Log("New player on server");
    }
}