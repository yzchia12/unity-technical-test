using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbilityController : MonoBehaviour
{
    List<GameObject> spawnObjects;
    // Start is called before the first frame update
    void Start()
    {
        spawnObjects = new List<GameObject>();

        Hand.OnCardExecute += OnCardExecute;
    }

    void OnDestroy()
    {
        Hand.OnCardExecute -= OnCardExecute;
    }

    private void OnCardExecute(CardAbility ability)
    {
        switch (ability)
        {
            case CardAbility.SpawnCube:
            case CardAbility.SpawnCapsule:
            case CardAbility.SpawnSphere:
                Spawn(ability);
                break;
            case CardAbility.Jump:
                SpawnObjectsJump();
                break;
            case CardAbility.Enlarge:
            case CardAbility.Shrink:
                SpawnObjectScaling(ability);
                break;
        }
    }

    private void Spawn(CardAbility ability)
    {
        GameObject go;

        switch (ability)
        {
            case CardAbility.SpawnCube:
                go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
            case CardAbility.SpawnCapsule:
                go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                break;
            case CardAbility.SpawnSphere:
                go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            default:
                go = null;
                break;
        }

        go.transform.position += new Vector3(0, 2, 0);
        go.AddComponent<Rigidbody>();

        spawnObjects.Add(go);
    }

    private void SpawnObjectsJump()
    {
        Rigidbody rigidbody;

        foreach (GameObject spawn in spawnObjects)
        {
            rigidbody = spawn.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);    
            }            
        }        
    }

    private void SpawnObjectScaling(CardAbility ability)
    {
        Vector3 objectScale;
        float scaleValue;                

        if (ability == CardAbility.Enlarge)
        {
            scaleValue = 0.25f;
        }
        else
        {
            scaleValue = -0.25f;
        }

        foreach (GameObject spawn in spawnObjects)
        {
            objectScale = spawn.transform.localScale;
            objectScale = new Vector3(objectScale.x + scaleValue, objectScale.y + scaleValue, objectScale.z + scaleValue);

            spawn.transform.localScale = objectScale;
        } 
    }
}
