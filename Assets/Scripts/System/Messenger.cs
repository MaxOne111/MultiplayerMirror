using UnityEngine;
using Mirror;

public class Messenger : NetworkBehaviour
{
    
    [Command(requiresAuthority = false)]
    public void CmdSendMessage(string nickname)
    {
        RpcReceiveMessage(nickname);
    }

    
    [ClientRpc]
    private void RpcReceiveMessage(string nickname)
    {
        Debug.Log($"Hello from {nickname}");
    }
}