using Mirror;
using TMPro;
using UnityEngine;

public class PlayerGameData : NetworkBehaviour
{
    [SerializeField] private TextMeshPro nicknameLabel;

    [SyncVar(hook = nameof(OnNicknameChanged))]
    private string _nickname;

    public string Nickname => _nickname;

    
    private void OnNicknameChanged(string oldNickname, string newNickname)
    {
        _nickname = newNickname;
    }
    
    public override void OnStartLocalPlayer()
    {
        LoadNickname();
        
        CmdSetNickname(_nickname);
        
        ShowNickname();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        
        if (!isLocalPlayer)
            ShowNickname();
    }


    [Command(requiresAuthority = false)]
    private void CmdSetNickname(string newNickname)
    {
        RpcUpdateNickname(newNickname);
    }
    
    
    [ClientRpc]
    private void RpcUpdateNickname(string newNickname)
    {
        nicknameLabel.text = newNickname;
    }

    private void ShowNickname()
    {
        nicknameLabel.text = _nickname;
    }

    private void LoadNickname()
    {
        if (SceneMediator.PlayerNickname != null)
            _nickname = SceneMediator.PlayerNickname;
        else
        {
            NetworkIdentity networkIdentity = GetComponent<NetworkIdentity>();
            uint playerId = networkIdentity.netId;

            _nickname = $"Player_{playerId}";
        }
    }


}