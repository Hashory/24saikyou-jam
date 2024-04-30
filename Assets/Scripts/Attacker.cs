using UnityEngine;

public class Attacker : MonoBehaviour
{
    public GameObject[] Weapon;
    public float cycleTime = 10.0f;
    public float radius = 15.0f;
    public float SpawnHeight = 10;
    public Vector3 initialVelocity;
    public KeyCode KeyCode = KeyCode.K;
    public int disnum; 
    public int PlayerNumber;
    public Potion_manager PotionManager;

    
    private float keyDownTime = 0f;
    private GameObject spawnKnife = null;
    private bool mode = false;

   
    void Update()
    {
        HandleKeyPress();
    }

    private void HandleKeyPress()
    {
        if (InputManager.GetKeyDown(disnum) && !mode)
        {
            keyDownTime = Time.time;
            // Weapon配列からプレハブを取得し、そのプレハブのrotationを使用してインスタンス化
            GameObject weaponPrefab = Weapon[PotionManager.player_Lv[PlayerNumber]];
            spawnKnife = Instantiate(weaponPrefab, new Vector3(radius, SpawnHeight, 0), weaponPrefab.transform.rotation);
            InitializeKnife();
        }
        if (InputManager.GetKey(disnum) && !mode)
        {
            UpdateKnifePos();
        }

        if (InputManager.GetKeyUp(disnum))
        {
            ToggleMode();
        }

    }

    private void InitializeKnife()
    {
        knife knifeScript = spawnKnife.GetComponent<knife>();
        if (knifeScript != null)
        {
            knifeScript.setnumber(PlayerNumber);
        }

    }

    private void ToggleMode()
    {
        if (!mode)
        {
            mode = true;
        }
        else if (spawnKnife != null)
        {
            ApplyGravity();
        }
    }

    private void ApplyGravity()
    {
        Rigidbody rb = spawnKnife.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            if (PotionManager.player_Lv[PlayerNumber] == 1)
            {
                Vector3 modifiedVelocity = new Vector3(initialVelocity.x, initialVelocity.y*2,initialVelocity.z);
                rb.velocity = modifiedVelocity;
            }
            else if (PotionManager.player_Lv[PlayerNumber] == 4)
            {
                SpawnHeight += 30;
                Vector3 modifiedVelocity = new Vector3(initialVelocity.x, initialVelocity.y*4, initialVelocity.z);
                rb.velocity = modifiedVelocity;
            }
            else
            {
                // それ以外の場合は、初期のvelocityを使用
                rb.velocity = initialVelocity;
            }
            if (PotionManager.player_Lv[PlayerNumber] == 4)
            {
                PotionManager.lastresort--;
            }

        }
        
        mode = false;
        spawnKnife = null;
    }

    private void UpdateKnifePos()
    {
        float duration = Time.time - keyDownTime;
        float angle = Mathf.PI * 2 * (duration / cycleTime) * Mathf.Pow(-1,PlayerNumber);
        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);
        spawnKnife.transform.position = new Vector3(x, SpawnHeight, y);
    }
}