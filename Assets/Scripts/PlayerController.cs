using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Alapértelmezett sebesség
    public float slowDownFactor = 0.5f;  // Lassítási tényezõ
    public float slowDuration = 3f;  // Lassítás idõtartama (másodpercben)

    private float hInput;
    private float vInput;
    private bool isSlowed = false;  // Annak jelzése, hogy az ûrhajó lassított állapotban van-e
    public Vector3 startPosition;

    void Start()
    {
        // Ha nem lett beállítva, akkor alapértelmezett kezdõ pozíció
        if (startPosition == Vector3.zero)
            startPosition = transform.position;
    }

    public void ResetPlayer()
    {
        // Visszaállítja a játékos pozícióját és aktiválja
        transform.position = startPosition;
        // Ha van más állapot, amit vissza kell állítani, akkor itt tedd meg
    }
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        // Az aktuális sebességet használva mozgatjuk az ûrhajót
        transform.Translate(new Vector2(hInput, vInput) * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ha a freezing spottal érintkezik, és még nincs lassítva
        if (collision.CompareTag("FreezingSpot") && !isSlowed)
        {
            isSlowed = true;
            moveSpeed *= slowDownFactor;  // Lassítjuk a sebességet
            StartCoroutine(RestoreSpeedAfterDelay());  // Elindítjuk a visszaállítást 3 másodperc múlva
        }
    }

    private IEnumerator RestoreSpeedAfterDelay()
    {
        yield return new WaitForSeconds(slowDuration);  // 3 másodperc várakozás (vagy amennyi a slowDuration értéke)
        moveSpeed /= slowDownFactor;  // Visszaállítjuk az eredeti sebességet
        isSlowed = false;
    }
}
