using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerPersonnage : MonoBehaviour
{
    public float vitesseX;      //vitesse en gauche et droite
    public float vitesseY;      //vitesse en haut et bas
    public float Vitesse;
    public bool ControlesInversees = false;

    /* Détection des touches et modification de la vitesse de déplacement;
       "a" et "d" pour aller a gauche et a droite, "w" et "s" pour en haut et en bas */
    
    private Animator animator;
 
    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }
 
    // Update is called once per frame
    void Update()
    {
        /* Détection des touches et modification de la vitesse de déplacement;
       "a" et "d" pour avancer et reculer, "w" pour sauter */

        Vector2 directionMouvement = Vector2.zero;
        var VitesseY = Mathf.Round(Input.GetAxis("Vertical")) * Vitesse;
        var VitesseX = Mathf.Round(Input.GetAxis("Horizontal")) * Vitesse;

        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);

        if (VitesseX == 0)
        {
            directionMouvement.x = 0;
            directionMouvement.y = 0;
            animator.SetInteger("Direction", -1);
        }

        if (VitesseX > 0)
        {
            directionMouvement.x = 1;
            if (VitesseY < 0)
            {
                directionMouvement.x = 1;
                directionMouvement.y = -1;
            }

            else if (VitesseY > 0)
            {
                directionMouvement.x = 1;
                directionMouvement.y = 1;
            }

            if (ControlesInversees == true)
            {
                animator.SetInteger("Direction", 0);
            }

            else
            {
                animator.SetInteger("Direction", 2);
            }
        }
        else if (VitesseX < 0)
        {
            directionMouvement.x = -1;
            if (VitesseY < 0)
            {
                directionMouvement.x = -1;
                directionMouvement.y = -1;
            }

            else if (VitesseY > 0)
            {
                directionMouvement.x = -1;
                directionMouvement.y = 1;
            }

            if (ControlesInversees == true)
            {
                animator.SetInteger("Direction", 2);
            }

            else
            {
                animator.SetInteger("Direction", 0);
            }
        }
        else if (VitesseY > 0)
        {
            directionMouvement.y = 1;
            if (VitesseX < 0)
            {
                directionMouvement.x = -1;
                directionMouvement.y = 1;
            }

            else if (VitesseX > 0)
            {
                directionMouvement.x = 1;
                directionMouvement.y = 1;
            }

            if (ControlesInversees == true)
            {
                animator.SetInteger("Direction", 3);
            }

            else
            {
                animator.SetInteger("Direction", 1);
            }
        }
        else if (VitesseY < 0)
        {
            directionMouvement.y = -1;
            if (VitesseX < 0)
            {
                directionMouvement.x = -1;
                directionMouvement.y = -1;
            }

            else if (VitesseX > 0)
            {
                directionMouvement.x = 1;
                directionMouvement.y = -1;
            }
           
            if (ControlesInversees == true)
            {
                animator.SetInteger("Direction", 1);
            }

            else
            {
                animator.SetInteger("Direction", 3);
            }
        }
        if (ControlesInversees == false)
        {
            transform.Translate(directionMouvement * Vitesse * Time.deltaTime, Space.World);
        }

        if (ControlesInversees == true)
        {
            transform.Translate(-directionMouvement * Vitesse * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le personnage entre en contact avec la mouche
        if (collision.gameObject.tag == "Mouche")
        {
        // Insérer ici tout ce qui est nécessaire après le contact de la mouche
        }

        if (collision.gameObject.tag == "Flaque")
        {
            ControlesInversees = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flaque")
        {
            Invoke("RemettreLesCommandes", 5f);
        }
    }

    void RemettreLesCommandes()
    {
        ControlesInversees = false;
    }
   
}