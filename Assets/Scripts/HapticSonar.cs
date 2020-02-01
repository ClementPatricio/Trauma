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
        if (timer > 1/sonarFrenquency)
        {
            
            sonarIntensity = getPostionRelativeToPlayer();
            sonarIntensity = sonarIntensity.normalized;
            Vector2 tmp = sonarIntensity;
            
            sonarIntensity.x = ((-2.0f / 3.0f) * tmp.x) + (1.0f / 3.0f);
            sonarIntensity.y = ((2.0f / 3.0f) * tmp.x) + (1.0f / 3.0f);
            Debug.Log(sonarIntensity.ToString());
            playerMovement.Vibrate(sonarIntensity.x, sonarIntensity.y, 0.1f);
            timer = 0;
        }
    }

    public void setObjectToFind(GameObject objectToFind)
    {
        this.objectToFind = objectToFind;
    }

    public void setSonarFrenquency(float frenquency)
    {
        this.sonarFrenquency = frenquency;
    }

    public Vector2 getPostionRelativeToPlayer()
    {
        Vector2 newPos = new Vector2();
        Vector3 newPos3D = this.transform.InverseTransformDirection(objectToFind.transform.position - this.transform.position);
        newPos.x = newPos3D.x;
        newPos.y = newPos3D.y;
        
        return newPos;
    }


}
