using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class GameManager : MonoBehaviour
{
    public Transform pathParent;
    public PathCreator[] path;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject ant;
    public AntFollower newAntFollower;
    // Start is called before the first frame update
    void Start()
    {
        //drug all of the path automatic,didnt need to drug the path
        for (int i = 0; i < pathParent.transform.childCount; i++) {
            path[i] = pathParent.transform.GetChild(i).GetComponent<PathCreator>();
        }
        StartCoroutine(spawnAnt());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnAnt() {
        int randomPathIndex = Random.Range(0,3);

        for (int i = 0; i < 5; i++) {

            GameObject newAnt = Instantiate(ant, spawnPosition.position, Quaternion.identity) as GameObject;
            newAnt.name = "Ant";
            newAntFollower = newAnt.GetComponent<AntFollower>();
            newAntFollower.GetPath(path[randomPathIndex]);

            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine(spawnAnt());
    }
}
