using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController _charController;
    Vector3 _moveVector;
    float _fallVelocity = 0;

    [Header("Main settings")]
    [SerializeField] float _gravity = 9.8f;
    [SerializeField] float _jumpForce;
    [SerializeField] float _moveSpeed;

    [Header("Ground collision settings (DISABLED!)")]
    [SerializeField] float m_MaxDistance;
    [SerializeField] Vector3 m_LocalScale;
    [SerializeField] bool m_BoolHitDetected;
    Quaternion m_Rotation;
    RaycastHit m_Hit;
    bool m_HitDetect;
    
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
/*    bool IsGroundedCheck()
    {
        m_BoolHitDetected = Physics.BoxCast(transform.position, m_LocalScale * 0.5f, Vector3.down, out m_Hit, m_Rotation, m_MaxDistance, 0);
        if (m_BoolHitDetected)
        {
            return true;
        } else {
            return false;
        }
    }
#if UNITY_EDITOR    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, (-transform.up) * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + (-transform.up) * m_Hit.distance, m_LocalScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, (-transform.up) * m_MaxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + (-transform.up) * m_MaxDistance, m_LocalScale);
        }
    }
#endif*/
}
