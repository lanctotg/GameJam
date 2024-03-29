using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GenerateurPasse : MonoBehaviour
{
    public GameObject[] plats;

    public GameObject RefSons;
    public int intervalleSpawnBouffe;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Commande());
    }

    IEnumerator Commande()
    {
        while (true)
        {
            // Faire respirer la coroutine à chaque 10 secondes
            yield return new WaitForSeconds(intervalleSpawnBouffe);
            
            //Génération d'un ennemi au hasard
            int platHasard = Random.Range(0, plats.Length);
            GameObject insanceAutrePlat = Instantiate(plats[platHasard], plats[platHasard].transform.position, plats[platHasard].transform.rotation);
            insanceAutrePlat.SetActive(true);
            RefSons.GetComponent<GestionSonoreAmbiance>().JouerSons("Cloche");
            StopCoroutine(Commande());
            
            //GetComponent<Animator>().SetBool("qqch", true);
        }
    }
}
