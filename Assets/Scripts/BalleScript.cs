using UnityEngine;

public class BalleScript : MonoBehaviour
{
    //Script à associer à la balle

    /*#################################################
    -- variables publiques à définir dans l'inspecteur
    #################################################*/
    public GameObject impactTir; // Référence au Prefab à instancier lorsque le tir frappe un objet. (Prefab ParticulesHit)
    public GameObject personnage; // Référence au personnage

    /*
     * Fonction OnCollisionEnter. Gère ce qui se passe lorsqu'une balle touche un objet.
     */
    private void OnCollisionEnter(Collision infoCollisions)
    {
        /* --> Partie à compléter
         * 1. Création d'une copie de l'objet de particules particulesContact
         * 2. On place l'objet copié au point de contact de la collison
         * 3. On active l'objet copié
         * 4. On oriente l'objet copié vers le personnage (LookAt)
         * 5. On applique une légère correction de position pour éviter que les particules se retouvent derrère l'objet
         * 5. On détruit l'objet copié (particules de fumée) après un délai d'une seconde.
         * 6. On détruit la balle (immédiatement)
         */
        
        GameObject particuleCopie = Instantiate(impactTir);

        particuleCopie.transform.position = infoCollisions.contacts[0].point;
        particuleCopie.SetActive(true);

        particuleCopie.transform.LookAt(personnage.transform);

        particuleCopie.transform.Translate(0f, 0f, 0.5f);

        Destroy(particuleCopie, 1f);

        if (infoCollisions.gameObject.tag == "Ennemi" && !infoCollisions.gameObject.GetComponent<Animator>().GetBool("mort"))
        {
            infoCollisions.gameObject.GetComponent<Ennemi>().Touche();
        }

        Destroy(gameObject);
    }


}
