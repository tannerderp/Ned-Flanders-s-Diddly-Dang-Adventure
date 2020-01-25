using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject); //despawn bible when its off screen
    }
}
