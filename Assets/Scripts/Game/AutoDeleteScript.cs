using UnityEngine;
using System.Collections;
using System;

public class AutoDeleteScript : MonoBehaviour {

    // Use this for initialization

    IEnumerator Start() {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);

    }
}
