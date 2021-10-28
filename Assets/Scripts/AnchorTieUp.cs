using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnchorTieUp : MonoBehaviour
{
    private void OnEnable()
    {
        AnchorDataTransfer.OnAnchorChange.AddListener(SetupNewTransform);
        SetupNewTransform();
    }

    public void SetupNewTransform()
    {
        transform.position = AnchorDataTransfer.anchor.position;
        transform.rotation = AnchorDataTransfer.anchor.rotation;
    }
}
