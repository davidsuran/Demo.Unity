using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    private readonly float _accelaration = 6.0f;
    private readonly float _ceilling = 50.0f;

    private static Transform _lookAt;
    private static bool _endOfTurn = false;
    private static readonly float _speed0 = 3.0f;
    private static float _currentSpeed = 0f;

    private void Start()
    {
    }

    private void Update()
    {
        if (_endOfTurn)
        {
            MoveCameraUp();
        }
    }

    public void MoveCameraUp()
    {
        if (transform.position.y <= _ceilling)
        {
            float deltaTime = Time.deltaTime;


            float distance = (_currentSpeed * deltaTime) + (_accelaration * deltaTime * deltaTime);

            _currentSpeed = _currentSpeed + _accelaration * deltaTime;

            transform.Translate(Vector3.up * distance);

            if (_lookAt != null)
            {
                //transform.LookAt(_lookAt);

                Vector3 relativePos = _lookAt.position - transform.position;
                Quaternion toRotation = Quaternion.LookRotation(relativePos);
                transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 1 * deltaTime);
            }
        }
    }

    public static void SetToEndOfTurn(Transform lookAt)
    {
        _currentSpeed = _speed0;
        _lookAt = lookAt;
        _endOfTurn = true;
    }

    public static void SetTurn()
    {
        _currentSpeed = 0f;
        _lookAt = null;
        _endOfTurn = false;
    }
}
