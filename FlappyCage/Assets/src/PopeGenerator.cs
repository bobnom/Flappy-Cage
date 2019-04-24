using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopeGenerator : MonoBehaviour {

    public static PopeGenerator singleton;

    public GameObject pope;

    public Transform[] spawns = new Transform [5];

    public bool bIsStarted = false;

	// Use this for initialization
	void Start () {
        if (singleton != null)
            return;

        singleton = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator SpawnPopes()
    {
        while(bIsStarted)
        {
            print("Spawn");
            yield return new WaitForSeconds(1.8f);

            if (!bIsStarted)
                StopAllCoroutines();

            GameObject popeToSpawn = pope;

            int rand = Random.Range(0, 5);

            GameObject.Instantiate(popeToSpawn, spawns[rand]);
           
           
        }

        yield return null;
    }
}
