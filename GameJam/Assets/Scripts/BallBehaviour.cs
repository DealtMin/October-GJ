using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    float speed;
    private float _currentSpeed = 0;
    Vector3 direction;
    private float delay;

    public void SetParams(Vector3 _direction, float _speed, float _delay)
    {
        direction = _direction;
        speed = _speed;
        delay = _delay;
        Invoke("SetSpeed", delay);
        Invoke("Stop", 10f);
    }
    

    void SetSpeed()
    {
        _currentSpeed = speed;
    }

    void Update()
    {
        transform.position += direction * _currentSpeed * Time.deltaTime;
    }

    void Stop()
    {
        Destroy(gameObject);
    }
    

}
