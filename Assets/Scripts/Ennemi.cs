using UnityEngine;
using UnityEngine.AI;

/* 
    Class Ennemi:
        - Gestion des deplacements de l'ennemi grace au component NavMeshAgent + NavMesh;
        - Gestion des animations;
        - Gestion de mort;

    Par: Yanis Oulmane
    Derniere modification: 20/11/2024
*/

public class Ennemi : MonoBehaviour
{
    [SerializeField] Transform posJoueur; // Reference au Transform du joueur pour sa position;
    [SerializeField] int ptsVie; // int memorisant le nombre de points de vie de l'ennemi
    [SerializeField] AudioClip sonMort; // Reference a un AudioClip du son de mort de l'ennemi
    [SerializeField] AudioClip sonTouche; // Reference a un AudioClip du son de touche de l'ennemi
    [SerializeField] int valeurPoints; // int memorisant combient l'ennemi vaut en points
    private bool mort = false; // Bool memorisant si l'ennemi est mort

    [SerializeField] Gamemanager gamemanager; // Reference a la class Gamemanager;

    NavMeshAgent navAgent;
    Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(posJoueur.position);
        
        if (!DeplacementPersoScript.enVie)
        {
            navAgent.speed = 0;
            navAgent.SetDestination(transform.position);
        }


        animator.SetFloat("vitesse", navAgent.velocity.magnitude);
    }

    public void Touche()
    {
        // Decrement a chaque appel la variable ptsVie;
        // Joue le son approprie selon la valeur de la variable
        ptsVie--;
        audioSource.PlayOneShot(ptsVie == 0 ? sonMort : sonTouche);

        /*  
            - Si l'ennemi est a 0 pt vie et qu'il n'est pas encore mort;
            - Assigne la valeur true au bool et active le parametre trigger 'mort' de l'animator;
            - Assigne la valeur 0 aux proprietes speed et angularSpeed du NavMeshAgent pour immobiliser l'ennemi;
            - Change le tag de l'ennemi a 'Untagged' pour eviter la detection de colisions;
            - Appel de la methode de pointage du Gamemanager;
            - Ivoke la fonction Disparition() apres 2sec;
        */

        if (ptsVie == 0 && !mort)
        {
            mort = true;
            animator.SetTrigger("mort");

            navAgent.speed = 0;
            navAgent.angularSpeed = 0;

            gameObject.tag = "Untagged";

            gamemanager.SetPointage(valeurPoints);

            Invoke(nameof(Disparition), 2f);
        }
    }

    void Disparition()
    {
        // Activation du gameObject "DeathParticles"
        transform.Find("DeathParticles").gameObject.SetActive(true);

        // Fait jouer son effet de particule
        transform.Find("DeathParticles").gameObject.GetComponent<ParticleSystem>().Play();

        // Destruction de l'objet "DeathParticles" apres 2s;
        Destroy(transform.Find("DeathParticles").gameObject, 2f);
        
        // Deparentage
        transform.Find("DeathParticles").parent = null;

        // Destruction de l'ennemi
        Destroy(gameObject);
    }
}
