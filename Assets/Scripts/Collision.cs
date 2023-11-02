using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePS;
    private MeshFilter playerMeshFilter;

    private void Start()
    {
        playerMeshFilter = GetComponent<MeshFilter>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CubeObst Instance") || other.CompareTag("PrismObst Instance") || other.CompareTag("SphereObst Instance"))
        {
            if (other.CompareTag(playerMeshFilter.mesh.name))
            {
                GameObject tempPS = Instantiate(obstaclePS, transform.position, Quaternion.identity);
                tempPS.GetComponent<ParticleSystemRenderer>().mesh = other.GetComponent<MeshFilter>().mesh;
                Destroy(tempPS, 3f);
            }
            else
            {
             // Game Manager Game Over
             // 
             FindObjectOfType<GameManager>().EndGameActivation();

            }
        }

    }
}
