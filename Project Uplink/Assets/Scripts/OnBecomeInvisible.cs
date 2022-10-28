using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBecomeInvisible : MonoBehaviour
{
    void OnBecameInvisible() {
        Destroy(gameObject);
     }
}
