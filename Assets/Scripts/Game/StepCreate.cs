using UnityEngine;
using System.Collections;

public class StepCreate : MonoBehaviour
{

    public GameObject[] Prefab;
    int roop = -1;
    public GameObject SpeedUp;
    
    void Start() {
        SpeedUp = GetComponent<GameObject>();
        SpeedUp = GameObject.Find("Speed_Up");
        SpeedUp.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x >= roop)
        {
            if (GlobalVariableScript.BonusRedCoin >= 10)
            {
                int j = 10;
                Instantiate(Prefab[j], new Vector3(gameObject.transform.position.x + 18, 0, 0), Quaternion.identity);
                roop = roop + 17;
                GlobalVariableScript.BonusRedCoin = -1;
            }
            else {
            int j = Random.Range(0, 10);
            Instantiate(Prefab[j], new Vector3(gameObject.transform.position.x + 18, 0, 0), Quaternion.identity);
            GlobalVariableScript.CreateCount += 1;
                if(GlobalVariableScript.CreateCount == 5 || GlobalVariableScript.CreateCount == 10 ||
                    GlobalVariableScript.CreateCount == 15 || GlobalVariableScript.CreateCount == 20 || GlobalVariableScript.CreateCount == 25) {
                    SpeedUp.SetActive(true);
                    GlobalVariableScript.isSE_SpeedUp = true;
                } else {
                    SpeedUp.SetActive(false);
                    GlobalVariableScript.isSE_SpeedUp = false;
                }
            roop = roop + 17;
            }
        }
    }
}