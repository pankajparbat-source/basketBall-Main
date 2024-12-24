using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playGame : MonoBehaviour
{
    public static playGame Instance;
    [Header("Player Next Position")]
    [SerializeField] private List<Transform> endPoint = new List<Transform>(); // Ending position
    private float height = 5.0f; // Height of the parabola
    private float duration = 2.0f; // Duration of the movement
    private int index = 0;
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
    private void Start()
    {
      
    }

   

    public void MovePlayer()
    {
        if (index < endPoint.Count)
        {
            StartCoroutine(MoveInParabola(movePlayerUP.Instance.transform.position, endPoint[index].position, height, duration));
            index++;
        }
        else
        {
            Debug.LogError("No more end points available.");
        }
    }

    private IEnumerator MoveInParabola(Vector3 start, Vector3 end, float height, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            Vector3 currentPos = Parabola(start, end, height, t);
            movePlayerUP.Instance.transform.position = currentPos;

            yield return null;
        }

        movePlayerUP.Instance.transform.position = end;
    }

    private Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Vector3 lerp = Vector3.Lerp(start, end, t);
        float parabolicT = t * 2 - 1;
        Vector3 heightOffset = Vector3.up * (1 - parabolicT * parabolicT) * height;

        return lerp + heightOffset;
    }
}
