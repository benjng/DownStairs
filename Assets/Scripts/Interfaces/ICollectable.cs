using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    void OnTriggerEnter2D(Collider2D collision);
}
