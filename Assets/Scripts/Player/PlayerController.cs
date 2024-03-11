using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _gravity = 9.8f;
    [SerializeField] float _jumpForce;
    [SerializeField] float _moveSpeed;
    CharacterController _charController;
    Vector3 _moveVector;
    float _fallVelocity = 0;
    
    void Start()
    {   // Получаем контроллер
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetKeysUpdate();
        JumpUpdate();
    }
    void FixedUpdate()
    {
        MoveGravityFixedUpdate();
    }

    void GetKeysUpdate()
    {
        _moveVector = Vector3.zero;

        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.z = Input.GetAxis("Vertical");
        _moveVector = transform.rotation * _moveVector;
    }
    void JumpUpdate()
    {
        // Прыжки
        if (Input.GetKeyDown(KeyCode.Space) && _charController.isGrounded)
        {
            _fallVelocity = -_jumpForce;
        }
    }
    void MoveGravityFixedUpdate() // Движение и гравитация
    {
        // Движение
        _charController.Move(_moveVector * _moveSpeed * Time.fixedDeltaTime);
        
        // Падение вниз
        if(_charController.isGrounded) _fallVelocity = 0f;
        
        _fallVelocity += _gravity * Time.fixedDeltaTime;
        _charController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
    }
}
