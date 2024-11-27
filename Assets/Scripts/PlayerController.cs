using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Alap�rtelmezett sebess�g
    public float slowDownFactor = 0.5f;  // Lass�t�si t�nyez�
    public float slowDuration = 3f;  // Lass�t�s id�tartama (m�sodpercben)

    private float hInput;
    private float vInput;
    private bool isSlowed = false;  // Annak jelz�se, hogy az �rhaj� lass�tott �llapotban van-e
    public Vector3 startPosition;

    void Start()
    {
        // Ha nem lett be�ll�tva, akkor alap�rtelmezett kezd� poz�ci�
        if (startPosition == Vector3.zero)
            startPosition = transform.position;
    }

    public void ResetPlayer()
    {
        // Vissza�ll�tja a j�t�kos poz�ci�j�t �s aktiv�lja
        transform.position = startPosition;
        // Ha van m�s �llapot, amit vissza kell �ll�tani, akkor itt tedd meg
    }
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        // Az aktu�lis sebess�get haszn�lva mozgatjuk az �rhaj�t
        transform.Translate(new Vector2(hInput, vInput) * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ha a freezing spottal �rintkezik, �s m�g nincs lass�tva
        if (collision.CompareTag("FreezingSpot") && !isSlowed)
        {
            isSlowed = true;
            moveSpeed *= slowDownFactor;  // Lass�tjuk a sebess�get
            StartCoroutine(RestoreSpeedAfterDelay());  // Elind�tjuk a vissza�ll�t�st 3 m�sodperc m�lva
        }
    }

    private IEnumerator RestoreSpeedAfterDelay()
    {
        yield return new WaitForSeconds(slowDuration);  // 3 m�sodperc v�rakoz�s (vagy amennyi a slowDuration �rt�ke)
        moveSpeed /= slowDownFactor;  // Vissza�ll�tjuk az eredeti sebess�get
        isSlowed = false;
    }
}
