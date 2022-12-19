using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameControllerHelper : MonoBehaviour
{
    public List<ICharacter> GetHeroes()
    {
        List<ICharacter> heroes = new();
        List<GameObject> heroGameObjects = GameObject.FindGameObjectsWithTag("Player").ToList();
        foreach (GameObject hero in heroGameObjects)
        {
            heroes.Add(hero.GetComponent<Player>());
        }
        return heroes;
    }

    public List<ICharacter> GetEnemies()
    {
        List<ICharacter> enemies = new();
        List<GameObject> enemyGameObjects = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        foreach (GameObject enemy in enemyGameObjects)
        {
            enemies.Add(enemy.GetComponent<Enemy>());
        }
        return enemies;
    }
}
