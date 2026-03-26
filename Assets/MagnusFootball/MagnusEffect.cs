using UnityEngine;
using UnityEngine.InputSystem;

public class MagnusEffect : MonoBehaviour
{
    public Vector3 kickPower; // ความแรงของการเตะ กำหนดทิศทาง x, y, z
    public float spinAmount = 1.0f; // กำหนดการหมุนของบอล
    public float magnusStrength = 0.5f; // ตัวคูณ effect
    private Rigidbody _rb;
    private bool _isShoot = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !_isShoot)
        {
            _rb.AddRelativeForce(kickPower, ForceMode.Impulse);
            _rb.AddTorque(Vector3.up * spinAmount);
            _isShoot = true;
        }
    }
    void FixedUpdate()
    {
        if (!_isShoot) return;
        Vector3 velocity = _rb.linearVelocity;
        Vector3 spin = _rb.angularVelocity;
        // Cross Product หาทิศทางใหม่ที่บอลต้องเคลื่อนที่ไป
        Vector3 magnusForce = Vector3.Cross(spin, velocity);
        magnusForce *= magnusStrength;
        _rb.AddForce(magnusForce);
    }
}
