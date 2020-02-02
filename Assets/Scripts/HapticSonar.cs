using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class HapticSonar : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToFind;
    private PlayerMovement playerMovement;


    private float timer;
    [SerializeField]
    private float sonarFrenquency;
    private Vector2 sonarIntensity;
    

    void Awake()
    {
        this.playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        sonarFrenquency = (1.0f / getDistanceFromObject())*10;
        if (timer > 1/sonarFrenquency)
        {
            
            sonarIntensity = getPostionRelativeToPlayer();
            sonarIntensity = sonarIntensity.normalized;
            Vector2 tmp = sonarIntensity;
            
            sonarIntensity.x = ((-2.0f / 3.0f) * tmp.x) + (1.0f / 3.0f);
            sonarIntensity.y = ((2.0f / 3.0f) * tmp.x) + (1.0f / 3.0f);
            playerMovement.Vibrate(sonarIntensity.x, sonarIntensity.y, (1.0f/sonarFrenquency)/2.0f);
            timer = 0;
        }
    }

    public void setObjectToFind(GameObject objectToFind)
    {
        this.objectToFind = objectToFind;
    }


    public Vector2 getPostionRelativeToPlayer()
    {
        Vector2 newPos = new Vector2();
        Vector3 newPos3D = this.transform.InverseTransformDirection(objectToFind.transform.position - this.transform.position);
        newPos.x = newPos3D.x;
        newPos.y = newPos3D.z;
        return newPos;
    }

    public float getDistanceFromObject()
    {
        return Vector3.Distance(this.transform.position, objectToFind.transform.position);
    }


}
