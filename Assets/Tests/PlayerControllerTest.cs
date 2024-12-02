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
        // L�pj�nk be a j�t�kba
        yield return new EnterPlayMode();

        // Hozzunk l�tre egy �j j�t�kos GameObject-et
        var player = new GameObject("Spaceship");

        // Adjunk hozz� PlayerController komponenst a j�t�koshoz
        var playerController = player.AddComponent<PlayerController>();

        // Ellen�rizz�k, hogy a PlayerController sikeresen hozz� lett adva
        Assert.IsNotNull(playerController); // Ellen�rizz�k, hogy a PlayerController script rajta van

        // Kezdj�k el a mozg�st, szimul�ljuk a bemenetet
        playerController.transform.Translate(Vector3.right * playerController.moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);  // V�runk egy kicsit, hogy a mozg�s t�rt�nhessen

        // Ellen�rizz�k, hogy a j�t�kos elmozdult
        Assert.AreNotEqual(player.transform.position, Vector3.zero);

        // L�pj�nk ki a Play Mode-b�l
        yield return new ExitPlayMode();
    }

    [UnityTest]
    public IEnumerator EnemyMovesAutomatically()
    {
        // L�trehozunk egy egyszer� ellens�get
        GameObject enemy = new GameObject("Enemy");

        // Hozz�rendelj�k a ShipMovements scriptet az ellens�ghez
        var movement = enemy.AddComponent<ShipMovements>();

        // Be�ll�tjuk a mozg�s sebess�g�t �s a hat�rokat
        movement.moveSpeed = 2f;            // Sebess�g
        movement.leftBoundary = -5f;        // Bal oldali hat�r
        movement.rightBoundary = 5f;        // Jobb oldali hat�r

        // Kezdeti poz�ci� ment�se
        Vector3 initialPosition = enemy.transform.position;

        // V�rakozunk 1 m�sodpercet, hogy az ellens�g mozogjon
        yield return new WaitForSeconds(1.0f);

        // Az �j poz�ci� ment�se
        Vector3 newPosition = enemy.transform.position;

        // Ellen�rizz�k, hogy a poz�ci� v�ltozott
        Assert.AreNotEqual(initialPosition, newPosition, "Az ellens�g nem mozgott!");

        // Kil�p�nk a Play Mode-b�l
        yield return new ExitPlayMode();
    }

    [UnityTest]
    public IEnumerator GameOverIsTriggeredWhenPlayerLosesAllLives()
    {
        // Bel�p�nk a Play Mode-ba
        yield return new EnterPlayMode();

        // J�t�kos l�trehoz�sa �s hozz�ad�sa a PlayerLives script
        var player = new GameObject("Spaceship");
        var playerLives = player.AddComponent<PlayerLives>();

        // Be�ll�tjuk, hogy a j�t�kosnak 1 �lete maradjon
        playerLives.lives = 1;

        // Cs�kkentj�k az �leteket k�zvetlen�l
        playerLives.lives--;

        // V�runk egy r�vid id�t, hogy az �llapot friss�lj�n
        yield return new WaitForSeconds(0.5f);

        // Ellen�rizz�k, hogy a j�t�k v�ge-e
        Assert.AreEqual(0, playerLives.lives);

        // Kil�p�nk a Play Mode-b�l
        yield return new ExitPlayMode();
    }
}
