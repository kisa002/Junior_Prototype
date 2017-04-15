using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {

    private int i = 1;

    public int hp = 5;

    public Transform[] target = new Transform[2];

    NavMeshAgent nav;

    bool isAttack = false;

    bool isDistance = false;

    private void Start()
    {
        nav = this.transform.GetComponent<NavMeshAgent>();

        nav.destination = target[0].position;
    }



    void Update () {

        if (!isDistance)
        {
            if(Vector3.Distance(nav.destination, this.transform.position) < 10)
            {
                nav.destination = target[i].position;

                if (i == 0)
                    i = 1;
                else if (i == 1)
                    i = 0;
            }
        }
        
		if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
