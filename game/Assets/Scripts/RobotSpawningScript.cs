using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawningScript : MonoBehaviour
{

    public List<GameObject> Robots;
   
    public List<int> RobotSpawnRate;
    public Camera Camera;
    private float CamHeight;
    private float CamWidth;
    public float SpawnRange;
    void Start()
    {
         CamHeight = 2f * Camera.orthographicSize;
         CamWidth = CamHeight * Camera.aspect;
       
    }
    void FixedUpdate()
    {
        int SP = Random.Range(0, 50);
        if (SP == 40)
        {
            SpawnEnemy();
        }
    }
    public void SpawnEnemy()
    {
        float x = 0;
        float y = 0;
        int RobotNum = Random.Range(0, 100);
        for (int i = 0;i<Robots.Count;i++)
        {
            if (RobotNum<= RobotSpawnRate[i])
            {
                RobotNum = i;
                break;
            }
        }
        GameObject Robot = Robots[RobotNum];
        int RX = Random.Range(0, 2);
        if ( RX== 0) {  x = Camera.transform.position.x + Random.Range(CamWidth / 2 +3f, CamWidth / 2 + 3f+SpawnRange); }
        else { x = Camera.transform.position.x +Random.Range(-CamWidth / 2 - 3f - SpawnRange, -CamWidth / 2 - 3f); }
        
        int RY = Random.Range(0, 2);
        if (RY == 0) {  y = Camera.transform.position.y + Random.Range(CamHeight / 2 + 3f, CamHeight / 2 + 3f+SpawnRange); }
        else {  y = Camera.transform.position.y + Random.Range(-CamHeight / 2 - 3f - SpawnRange, -CamHeight / 2 - 3f); };

        GameObject NewRobo = Instantiate(Robot);
        NewRobo.transform.position = new Vector3(x,y,0);


    }
}
