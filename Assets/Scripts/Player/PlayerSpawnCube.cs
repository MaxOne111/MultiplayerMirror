using Mirror;
using UnityEngine;

public class PlayerSpawnCube : NetworkBehaviour
{
    [SerializeField] private GameObject cubePrefab;

    [SerializeField] private Transform body;
    
    [SerializeField] private KeyCode spawnKey = KeyCode.F;
    
    [SerializeField] private Vector3 spawnOffset;

    
    [Command]
    private void CmdSpawnCube(Vector3 spawnPosition)
    {
        GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
        
        NetworkServer.Spawn(cube);
        
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(spawnKey))
            LocalSpawnCube();
    }

    private void LocalSpawnCube()
    {
        if (isLocalPlayer)
        {
            Vector3 spawnPosition = body.position + body.forward * 
            spawnOffset.z + body.right * 
            spawnOffset.x + body.up * 
            spawnOffset.y;
            
            CmdSpawnCube(spawnPosition);
        }

    }
}
