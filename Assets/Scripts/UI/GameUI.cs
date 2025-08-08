using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameField;
    
    [SerializeField] private Button enterNameButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        enterNameButton.onClick.AddListener(InputNickname);
        
        hostButton.onClick.AddListener(NetworkManager.singleton.StartHost);

        clientButton.onClick.AddListener(NetworkManager.singleton.StartClient);

        quitButton.onClick.AddListener(Quit);
    }

    private void InputNickname()
    {
        if (string.IsNullOrWhiteSpace(nicknameField.text))
            SceneMediator.PlayerNickname = null;
        else
            SceneMediator.PlayerNickname = nicknameField.text;
    }
    
    private void Quit()
    {
        Application.Quit();
    }
}