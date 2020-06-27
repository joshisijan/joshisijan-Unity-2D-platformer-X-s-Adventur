using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour
{
    public PlayerStats playerStats;
    public Slider energySlider;
    public FireButton fireButton;
    public Transform hitPoint;
    public GameObject bulletPrefab;
    public Transform bulletParent;
    public Image energyFillArea;

    AudioManager audioManager;
    Color energyFillColor;
    bool fired = false;
    float energyIncreaser;
    float firePower;

    private void Awake()
    {
        energyIncreaser = playerStats.energyIncreaser;
        firePower = playerStats.firePower;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        EnergyValue(1);
        energyFillColor = energyFillArea.color;
    }

    private void Update()
    {
        //for bottom slider
        if (!fireButton.firePressed)
        {
            fired = false;
        }

        if (energySlider.value < firePower)
        {
            energyFillArea.color = Color.red;
        }
        else
        {
            energyFillArea.color = energyFillColor;
        }

        if (Time.timeScale == 0)
            return;

        if (fireButton.firePressed && !fired && energySlider.value >= firePower)
        {
            DecreaseEnergyValue();

            FireEnergyBeam();

            fired = true;
        }
        IncreaseEnergyValue();
    }


    void FireEnergyBeam()
    {
        audioManager.Play("PlayerFire");
        Instantiate(bulletPrefab, hitPoint.position, hitPoint.rotation, bulletParent);
    }


    void EnergyValue(float x)
    {
        energySlider.value = x;
    }

    void DecreaseEnergyValue()
    {
        if(energySlider.value > 0)
        {
            energySlider.value -= this.firePower;
        }

        if (energySlider.value < 0)
        {
            energySlider.value = 0;
        }
    }
    
    void IncreaseEnergyValue()
    {
        if(energySlider.value < 1)
        {
            energySlider.value += energyIncreaser;
        }
        if(energySlider.value > 1)
        {
            energySlider.value = 1;
        }
    }

}
