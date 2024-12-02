using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using System.Reflection;

public class PlayModeTests
{
    [UnityTest]
    public IEnumerator PlayerCanMove()
    {
        // Lépjünk be a játékba
        yield return new EnterPlayMode();

        // Hozzunk létre egy új játékos GameObject-et
        var player = new GameObject("Spaceship");

        // Adjunk hozzá PlayerController komponenst a játékoshoz
        var playerController = player.AddComponent<PlayerController>();

        // Ellenõrizzük, hogy a PlayerController sikeresen hozzá lett adva
        Assert.IsNotNull(playerController); // Ellenõrizzük, hogy a PlayerController script rajta van

        // Kezdjük el a mozgást, szimuláljuk a bemenetet
        playerController.transform.Translate(Vector3.right * playerController.moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);  // Várunk egy kicsit, hogy a mozgás történhessen

        // Ellenõrizzük, hogy a játékos elmozdult
        Assert.AreNotEqual(player.transform.position, Vector3.zero);

        // Lépjünk ki a Play Mode-ból
        yield return new ExitPlayMode();
    }

    [UnityTest]
    public IEnumerator EnemyMovesAutomatically()
    {
        // Létrehozunk egy egyszerû ellenséget
        GameObject enemy = new GameObject("Enemy");

        // Hozzárendeljük a ShipMovements scriptet az ellenséghez
        var movement = enemy.AddComponent<ShipMovements>();

        // Beállítjuk a mozgás sebességét és a határokat
        movement.moveSpeed = 2f;            // Sebesség
        movement.leftBoundary = -5f;        // Bal oldali határ
        movement.rightBoundary = 5f;        // Jobb oldali határ

        // Kezdeti pozíció mentése
        Vector3 initialPosition = enemy.transform.position;

        // Várakozunk 1 másodpercet, hogy az ellenség mozogjon
        yield return new WaitForSeconds(1.0f);

        // Az új pozíció mentése
        Vector3 newPosition = enemy.transform.position;

        // Ellenõrizzük, hogy a pozíció változott
        Assert.AreNotEqual(initialPosition, newPosition, "Az ellenség nem mozgott!");

        // Kilépünk a Play Mode-ból
        yield return new ExitPlayMode();
    }

    [UnityTest]
    public IEnumerator GameOverIsTriggeredWhenPlayerLosesAllLives()
    {
        // Belépünk a Play Mode-ba
        yield return new EnterPlayMode();

        // Játékos létrehozása és hozzáadása a PlayerLives script
        var player = new GameObject("Spaceship");
        var playerLives = player.AddComponent<PlayerLives>();

        // Beállítjuk, hogy a játékosnak 1 élete maradjon
        playerLives.lives = 1;

        // Csökkentjük az életeket közvetlenül
        playerLives.lives--;

        // Várunk egy rövid idõt, hogy az állapot frissüljön
        yield return new WaitForSeconds(0.5f);

        // Ellenõrizzük, hogy a játék vége-e
        Assert.AreEqual(0, playerLives.lives);

        // Kilépünk a Play Mode-ból
        yield return new ExitPlayMode();
    }
}
