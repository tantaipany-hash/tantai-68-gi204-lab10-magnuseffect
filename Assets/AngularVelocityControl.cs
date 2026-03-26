using UnityEngine;
using UnityEngine.InputSystem;
public class AngularVelocityControl : MonoBehaviour
{
    public float angularSpeed = 1f; // ความเป็นการหมุน
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Keyboard.current.aKey.isPressed) // ทำงานเมื่อกดปุ่ม A ค้าง
        {
            _rb.angularVelocity = new Vector3(0, angularSpeed, 0); // เปลี่ยนความเร็วแกน Y ให้เท่าตัวแปร
        }
        else
        {
            _rb.angularVelocity = Vector3.zero;
        }
    }
}
