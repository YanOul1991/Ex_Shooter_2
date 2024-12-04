using UnityEngine;

public class TirScript_RayCast : MonoBehaviour
{
    public GameObject particuleBalle; // Référence au gameObject à activer lorsque le personnage tir
    public GameObject boutDuFusil; // Référence au gameObject qui représente le bout du fusil du personnage. Utile pour le tir.
    public GameObject impactTir; // Référence au Prefab à instancier lorsque le tir frappe un objet. (Prefab ParticulesHit)

    [SerializeField] AudioClip sonTir;

    /*#################################################
   -- variables privées
   #################################################*/
    private bool peutTirer; // Est-ce que le personnage peut tirer

    //----------------------------------------------------------------------------------------------
    void Start()
    {
        peutTirer = true; // Au départ, on veut que le personnage puisse tirer
    }
    //----------------------------------------------------------------------------------------------
    /*
    
     
     * Fonction Update. On appele la fonction Tir() lorsque la touche espace est enfoncée et que 
    * le personnage peut tirer
    */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) Tir();
        // --> partie à compléter ****

        /* Optionnel avec défi du lineRenderer : pour que la ligne de tir reste collée sur le bout du fusil lorsque le
         * personnage se déplace, on peut ajouter ici la ligne suivante. Le point de départ de la ligne sera ajustée
         * à chaque frame pour qu'elle parte du bout du fusil du personnage.
         * 
         * if (boutDuFusil.GetComponent<LineRenderer>().enabled) boutDuFusil.GetComponent<LineRenderer>().SetPosition(0, boutDuFusil.transform.position);
        */

        // Ray ray = new(boutDuFusil.transform.position, boutDuFusil.transform.forward);
        // // Debug.DrawRay(ray.origin, ray.direction * 500, Color.red);

        // if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        // {
        //     // GetComponent<LineRenderer>().SetPosition(0, boutDuFusil.transform.position);
        //     // GetComponent<LineRenderer>().SetPosition(1, hitInfo.point);

        //     Vector3[] test = new Vector3[2];

        //     test[0] = boutDuFusil.transform.position;
        //     test[1] = hitInfo.point;
            
        //     GetComponent<LineRenderer>().SetPositions(test);
        // }

    }
    //----------------------------------------------------------------------------------------------


    /*
     * Fonction Tir. Gère le tir d'une nouvelle balle.
     */
    void Tir()
    {
        /* On désactive la capacité de tirer et on appelle la fonction ActiveTir() après
         un délai de 0.1 seconde */
        peutTirer = false;
        Invoke("ActiveTir", 0.1f);

        /* --> partie à compléter...
         * 
         * 1. activation de la particuleBalle
         * 2. activation du son "Player GunShot". Que devez-vous ajouter au personnage pour qu'il puisse jouer un son?
         * 3. déclaration d'une variable de type RayCastHit pour utiliser avec le RayCast
         * 4. Création du rayon invisible RayCast. Les paramères sont :
         *      - Position de départ du rayon : le bout du fusil
         *      - Direction du rayon : vers le devant du bout du fusil (... transform.forward)
         *      - Variable qui récupère l'information (out NomDeVotreVariable de type RayCastHit)
         *      - Longueur du rayon : 50f
         * 5. S'il le rayon touche un objet, le RayCast renvoie true. Il faut alors instancier une particule au point de contact
         *      - Instanciation de l'objet impacTir (particule de fumée) au point de contact
         *      - Ajustement de sa rotation (localEulerAngles) à 0f, 0f, 0f
         *      - Destruction de l'impact de tir instancié après un délai d'environ 3 secondes
         *      
         * 6. Défi optionnel de la ligne jaune
         *      - Il faut d'abort ajouter un component "lineRenderer" sur le bout du fusil (gameObject GunBarrelEnd). Voir
         *      les consignes pour plus de détails.
         *      - activation du component "lineRenderer"
         *      - La position 0 de la ligne tracée par le lineRenderer = la position du bout du fusil
         *      - La position 1 de la ligne tracée par le lineRenderer = le point de contact du RayCast
         * */

        particuleBalle.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(sonTir);

        Ray ray = new(boutDuFusil.transform.position, boutDuFusil.transform.forward);
        Debug.DrawRay(boutDuFusil.transform.position, boutDuFusil.transform.forward * 1000, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 50f))
        {
            // Debug.Log(hitInfo.transform.name);

            // Particules effets tir/impact
            GameObject instanceImpactTir = Instantiate(impactTir);
            Destroy(instanceImpactTir, 3f);
            instanceImpactTir.transform.position = hitInfo.point;

            // Linerenderer
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetPosition(0, boutDuFusil.transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hitInfo.point);
        }
    }
    //----------------------------------------------------------------------------------------------


    /*
     * Fonction ActiveTir(). Réactive la capacité de tirer.
     */
    void ActiveTir()
    {
        /* --> partie à compléter...
         * 1. On réactive la capacité de tirer... variable peutTirer...
         * 2. On désactive la particule particuleBalle
         * 
         * 3. Défi optionnel de la ligne jaune : on désactive le component lineRenderer
         *  boutDuFusil.GetComponent<LineRenderer>().enabled = false;
         * 
         * */

        peutTirer = true;
        particuleBalle.SetActive(false);
        GetComponent<LineRenderer>().enabled = false;
    }
}
