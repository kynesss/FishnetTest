using FishNet;
using TMPro;
using UnityEngine;

public class ClientPingInfoUI : MonoBehaviour
{
    private TextMeshProUGUI _pingText;
    
    private void Awake()
    {
        _pingText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (InstanceFinder.ClientManager == null || !InstanceFinder.ClientManager.Connection.IsLocalClient) 
            return;

        DisplayPingInfo();
    }

    private void DisplayPingInfo()
    {
        var timeManager = InstanceFinder.TimeManager;
        _pingText.text = $"{timeManager.RoundTripTime} ms";
    }
}
