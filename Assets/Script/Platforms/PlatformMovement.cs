using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private float platformVelocity;
    private int _nextWayPoint;
    
        
    // Start is called before the first frame update
    void Start()
    {
        platformVelocity = 1;
        _nextWayPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (Vector2.Distance(transform.position, wayPoints[_nextWayPoint].transform.position) < 0.1f)
        {
            _nextWayPoint++;

            if (_nextWayPoint >= wayPoints.Length)
            {
                _nextWayPoint = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[_nextWayPoint].transform.position,
            platformVelocity * Time.deltaTime);
    }
    
}
