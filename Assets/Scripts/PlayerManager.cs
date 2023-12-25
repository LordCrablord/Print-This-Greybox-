using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : Singleton<PlayerManager>
{
    public float speed;
    private Vector2 move;
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform hands;

    public GameObject objectInHands;
    
    public void SetObjectToHands(GameObject obj)
    {
        objectInHands = obj;
        if(objectInHands != null)
        {
            objectInHands.transform.SetParent(hands);
            objectInHands.transform.localPosition = Vector3.zero;
        }
    }

    public bool HasObjectInHands() => objectInHands == null ? false : true;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ManageInput();
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0, move.y);

        characterController.Move(movement * speed * Time.deltaTime);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.5f);
        }
        Gravity();
    }

    void ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.SetMenu();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            GameManager.Instance.SetUIHelp();
        }
    }

    void Gravity()
    {
        Vector3 movement = new Vector3(0, -5, 0);
        characterController.Move(movement * Time.deltaTime);
    }
}
