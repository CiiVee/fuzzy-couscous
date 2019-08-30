using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeParent : MonoBehaviour {

    public void OnMouseUp()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}
