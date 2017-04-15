using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private int fullMagzine = 150;
    private int remainingMagazine = 30;

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {

            if(remainingMagazine > 0)
            {
                Attack();
            }
            else if(fullMagzine <= 0)
            {
                Debug.Log("탄창부족");
            }
            else
            {
                Debug.Log("장전필요");
            }

        }

        if (Input.GetKeyDown(KeyCode.R) && fullMagzine > 0)
        {
            Reload();
        }
        
    }

    void Reload()
    {
        fullMagzine -= 30;
        remainingMagazine = 30;
    }

    void Attack()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        EnemyScript ES = null;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.transform.tag == "Enemy")
            {
                GameObject hitObject = hit.transform.gameObject;

                Debug.DrawRay(Camera.main.transform.position, Input.mousePosition, Color.red);

                ES = hitObject.GetComponent<EnemyScript>();

                ES.hp--;

                Debug.Log("남은 적 체력 : " + ES.hp);
            }
        }

        remainingMagazine--;

        Debug.Log("잔여 탄창수 : " + remainingMagazine + " 전체 탄창수 : " + fullMagzine);
    }
}
