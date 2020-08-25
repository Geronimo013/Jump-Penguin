using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : MonoBehaviour {

    [SerializeField]
    private Transform[] spikes;

    [SerializeField]
    private GameObject coin;

    private bool fallDown;

    void Start() {

        ActivatePlatform();
    }


    void ActivateSpike() {

        int index = Random.Range(0, spikes.Length);

        spikes[index].gameObject.SetActive(true);

        spikes[index].DOLocalMoveY(0.6f, 1.1f).
        SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(3f, 5f));


    } // activate spike

   /* void AddCoin() {

        GameObject c = Instantiate(coin);
        c.transform.position = transform.position;
        c.transform.SetParent(transform);
        c.transform.DOLocalMoveY(1f, 0f);

    } // coin*/

    void ActivatePlatform() {

        int chance = Random.Range(0, 100);

        if(chance > 70) {

            int type = Random.Range(0, 8);
            
            switch (type)
            {
                case 0:                  
                    ActivateSpike();
                    break;
                case 1:
                    //AddCoin();
                    break;
                case 2:
                    fallDown=true;
                    break;
                case 3:
                    break;
                case 4:
                    //AddCoin();
                    break;
                case 5:
                    break;
                case 6:
                    fallDown=true;
                    break;
                case 7:
                    //AddCoin();
                    break;
                default:
                    break;
            }

        }

    } // activate platform

    void InvokeFalling() {
        gameObject.AddComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision target) {

        if(target.gameObject.tag == "Player") {

            if(fallDown) {
                fallDown = false;
                Invoke("InvokeFalling", 2f);
            }

        }

    }

    public Animator animator;



} // class




























