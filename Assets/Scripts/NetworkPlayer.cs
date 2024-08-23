using FishNet;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private float movementSpeed;
    
    public static NetworkPlayer Local { get; private set; }

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public override void OnOwnershipClient(NetworkConnection prevOwner)
    {
        if (IsOwner)
        {
            Local = this;
        }
    }

    private void Update()
    {
        if (!IsOwner) 
            return;

        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontal, 0f, vertical);
        var speed = movementSpeed * (float)InstanceFinder.TimeManager.TickDelta;

        _characterController.Move(direction * speed);
    }
}
