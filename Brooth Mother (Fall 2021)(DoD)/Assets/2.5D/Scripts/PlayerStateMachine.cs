using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float groundOffset = 1.0f;

    [Header("References")]
    [SerializeField] private Transform ground;

    private Vector3 movement;
    private Rigidbody rigid;
    private PlayerStates playerState;
    private SpriteRenderer spriteRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerState(PlayerStates.NORMAL);
        rigid = GetComponent<Rigidbody>();
        rigid.constraints = RigidbodyConstraints.FreezePositionY;

        ground = GameObject.Find("Ground").transform;
        if (ground != null) movement.y = ground.position.y + groundOffset;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + movement * moveSpeed * Time.deltaTime);
    }


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //gives us the x value 
        movement.z = Input.GetAxisRaw("Vertical");  // gives us the y value
    }

    public PlayerStates CurrentPlayerState()
    {
        return playerState;
    }

    public void SetPlayerState(PlayerStates ps)
    {
        playerState = ps;
    }
}
