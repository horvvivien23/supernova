using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    public Vector2 startPosition = new Vector2(-1, -120); // Az új kezdõ pozíció

    void Start()
    {
        // Az ûrhajó pozíciójának beállítása minden szintnél
        transform.position = startPosition;
    }
}
