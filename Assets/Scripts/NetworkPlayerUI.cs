using TMPro;
using UnityEngine;

public class NetworkPlayerUI : MonoBehaviour
{
    private NetworkPlayer _networkPlayer;
    private TextMeshProUGUI _nicknameText;
    private void Awake()
    {
        _networkPlayer = GetComponentInParent<NetworkPlayer>();
        _nicknameText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!_networkPlayer.IsSpawned) 
            return;

        DisplayPlayerName();
    }

    private void DisplayPlayerName()
    {
        _nicknameText.color = _networkPlayer.IsOwner ? Color.red : Color.black;
        _nicknameText.text = $"PLAYER_{_networkPlayer.OwnerId}";
    }
}
