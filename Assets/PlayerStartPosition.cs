using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    public Vector2 startPosition = new Vector2(-1, -120); // Az �j kezd� poz�ci�

    void Start()
    {
        // Az �rhaj� poz�ci�j�nak be�ll�t�sa minden szintn�l
        transform.position = startPosition;
    }
}
