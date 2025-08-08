using Mirror;
using UnityEngine;

public class PlayerSender : NetworkBehaviour
{
    [SerializeField] private KeyCode sendKey = KeyCode.Space;
    
    private PlayerGameData _playerGameData;
    private Messenger _messenger;
    
    public override void OnStartLocalPlayer()
    {
        _playerGameData = GetComponent<PlayerGameData>();
        _messenger = FindFirstObjectByType<Messenger>();
    }

    private void Update()
    {
        if(!isLocalPlayer)
            return;

        if(Input.GetKeyDown(sendKey))
            _messenger.CmdSendMessage(_playerGameData.Nickname);
    }
}