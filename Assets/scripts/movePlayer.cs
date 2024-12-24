using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    private movePlayer moveplayescrip;
    public static movePlayer Instance;
    public Transform startPoint;
    [SerializeField] private List<Transform> endPoint = new List<Transform>();// Ending position
    public float height = 5.0f; // Height of the parabola
    public float duration = 2.0f; // Duration of the movement
    public static int index;

    public delegate void MyDelegate();
    public static MyDelegate attack;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //else Instance = this;
    }

    private void Start()
    {
        index = 0;
    }
    public void move()
    {
        //  Debug.Log();
        startPoint = moveUp.Instance.transform;
        if (index < endPoint.Count)
        {
            StartCoroutine(MoveInParabola(startPoint.position, endPoint[index].position, height, duration));
            index++;

        }
        else
        {
            Debug.LogError("gama object destroy");
        }
    }
    private IEnumerator MoveInParabola(Vector3 start, Vector3 end, float height, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            // Calculate the current position using a parabolic formula
            Vector3 currentPos = Parabola(start, end, height, t);

            // Set the object's position to the calculated position
            transform.position = currentPos;

            yield return null;
        }

        // Ensure the object ends at the exact end position
        transform.position = end;
    }

    private Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        // Linear interpolation between start and end
        Vector3 lerp = Vector3.Lerp(start, end, t);

        // Adding the parabolic offset
        float parabolicT = t * 2 - 1;
        Vector3 heightOffset = Vector3.up * (1 - parabolicT * parabolicT) * height;

        return lerp + heightOffset;
    }
    public void removeEndPosion()
    {
        //endPoint.RemoveAt(0);
    }
    public void indexValueReset()
    {
        index = 0;
    }
    public void resetplayer()
    {
        moveCamera.Instance.player = gameObject;
    }

}
