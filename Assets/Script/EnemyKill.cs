using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    [SerializeField] public GameObject itemFeedback;
    [SerializeField] public GameObject dieSpot;
    private LevelController levelController;
    public void Start()
    {
        levelController = LevelController.Instance;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GameObject.Instantiate(itemFeedback, this.transform.position, this.transform.rotation);

            //Increase player item pickup counter
            levelController.BeatedEnemy();
            dieSpot.SetActive(false);
            Destroy(this.gameObject);

        }
    }
}
