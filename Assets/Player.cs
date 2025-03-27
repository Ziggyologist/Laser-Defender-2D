using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 9f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
