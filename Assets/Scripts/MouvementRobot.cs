using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MouvementRobot : MonoBehaviour
{
    public GameObject[] patrouilleurs;
    public GameObject[] chasseurs;
    public GameObject[] destinations;
    public GameObject ferdinand;

    private NavMeshAgent agentIA;
    private Animator _animator;

    public int point;
    
    // Start is called before the first frame update
    void Start()
    {
        patrouilleurs = GameObject.FindGameObjectsWithTag("Patrouilleur");
        chasseurs = GameObject.FindGameObjectsWithTag("Chasseur");
        destinations = GameObject.FindGameObjectsWithTag("Destination");
        
        agentIA = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        // Determiner destination aleatoire pour chaque patrouilleur au debut du jeu
        if (gameObject.tag == "Patrouilleur")
        {
            for (int i = 0; i < patrouilleurs.Length; i++)
            {
                point = Random.Range(0, destinations.Length);
            }
        }
    }
    public void DemarrerChasse()
    {
        // Tous les robots marchent vers Ferdinand
        _animator.SetBool("Marcher", true);
        agentIA.enabled = true;
        agentIA.SetDestination(ferdinand.transform.position);
        
    }
    public void ArreterChasse()
    {
        // Deplacer les patrouilleurs vers leur destination de patrouille
        if (gameObject.tag == "Patrouilleur")
        {
            agentIA.SetDestination(destinations[point].transform.position);
            _animator.SetBool("Marcher", true);

            // Passer à la prochaine destination une fois arrivé
            for (int i = 0; i < patrouilleurs.Length; i++)
            {
                if (Vector3.Distance(transform.position, destinations[point].transform.position) < 0.1f)
                {
                    if (point < destinations.Length - 1)
                    {
                        point++;
                    }
                    else
                    {
                        point = 0;
                    }
                }
            }
        }

        // Immobiliser les chasseurs
        if (gameObject.tag == "Chasseur")
        {
            _animator.SetBool("Marcher", false);
            agentIA.enabled = false;
        }
    }
}

