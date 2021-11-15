using System.Collections.Generic;
using UnityEngine;


public class Settings : MonoBehaviour
{
    //private IControlleble controlleble;
    private GameObject generalGear;
    [Header("Settings")]
    public float torque;
    public bool inercionFirstGear;
    public BehaviorEngine behaviorEngine;

    [ExecuteInEditMode]
    public List<Gear> gears = new List<Gear>();
    protected List<Gear> reverseGears = new List<Gear>();

    private float generalSpeed;
    //The variable depends on the radius of the gear
    private float variableSpeed;

    private void Awake()
    {
        //Inicialization GeneralGear
        generalGear = GameObject.FindGameObjectWithTag("GeneralGear");
        GeneralGear general = generalGear.GetComponent<GeneralGear>();

        reverseGears.AddRange(gears);
        reverseGears.Reverse();

        general.SetTorque(torque);
        generalSpeed = general.speed;
        variableSpeed = generalSpeed;
    }

    private void Start()
    {
        Inicialization();
    }

    public void RunGears(BehaviorEngine behaviorEngine)
    {
        this.behaviorEngine = behaviorEngine;
        Inicialization();
    }

    public void Inicialization()
    {
        switch (behaviorEngine)
        {
            case BehaviorEngine.ForceForwad:
                foreach (Gear gear in gears)
                {
                    Gear gear1 = gear.GetComponent<Gear>();
                    float angularVelocity = gear.AngularVelocity(variableSpeed);

                    if (inercionFirstGear)
                    {
                        gear1.SetActiveGear(true);
                        gear1.SetTorque(torque);
                        inercionFirstGear = false;
                    }
                    else
                    {
                        gear1.SetActiveGear(true);
                        gear1.SetTorque(-angularVelocity);
                    }

                    variableSpeed = gear1.speed;
                }
                break;
            case BehaviorEngine.ForceBack:
                foreach (Gear gear in reverseGears)
                {
                    Gear gear1 = gear.GetComponent<Gear>();
                    float angularVelocity = gear.AngularVelocity(variableSpeed);

                    if (inercionFirstGear)
                    {
                        gear1.SetActiveGear(true);
                        gear1.SetTorque(torque);
                        inercionFirstGear = false;
                    }
                    else
                    {
                        gear1.SetActiveGear(true);
                        gear1.SetTorque(-angularVelocity);
                    }

                    variableSpeed = gear1.speed;
                }
                break;
            case BehaviorEngine.Stop:
                foreach (Gear gear in gears)
                {
                    Gear gear1 = gear.GetComponent<Gear>();
                    gear1.SetTorque(0);
                    gear1.SetActiveGear(false);
                }
                break;
        }
    }
}
