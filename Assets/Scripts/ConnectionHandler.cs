using System;
using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Transporting;
using UnityEngine;

public class ConnectionHandler : MonoBehaviour
{
    [SerializeField] private ConnectionType connectionType;

#if UNITY_EDITOR
    private void OnEnable()
    {
        InstanceFinder.ClientManager.OnClientConnectionState += OnClientConnectionState;
    }

    private void OnDisable()
    {
        InstanceFinder.ClientManager.OnClientConnectionState -= OnClientConnectionState;
    }

    private void OnClientConnectionState(ClientConnectionStateArgs args)
    {
        if (args.ConnectionState == LocalConnectionState.Stopping)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
#endif
    private void Start()
    {
#if UNITY_EDITOR
        if (ParrelSync.ClonesManager.IsClone())
        {
            InstanceFinder.ClientManager.StartConnection();
        }
        else
        {
            if (connectionType == ConnectionType.Host)
                InstanceFinder.ServerManager.StartConnection();

            InstanceFinder.ClientManager.StartConnection();
        }
#endif

#if DEDICATED_SERVER
        InstanceFinder.ServerManager.StartConnection();
#endif
    }
}

public enum ConnectionType
{
    Host,
    Client
}