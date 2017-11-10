using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryVisuals : MonoBehaviour
{

    private int charge;
    private int flashingLimit = 4;
    private Material[] materials;
    private Renderer rend;
    private Color green = new Color(0.0274f, 0.949f, 0.0156f, 1.0f);
    private Color yellow = new Color(0.8f, 0.749f, 0.0f, 1.0f);
    private Color gray = new Color(0.662f, 0.662f, 0.662f, 1.0f);
    private Color black = new Color(0.0274f, 0.0274f, 0.0274f, 1.0f);
    private Color red = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    private Color white = new Color(1.0f, 1.0f, 1.0f, 1.0f);


    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        setCharge(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            setCharge(charge - 5);
        }
    }

    public int getCharge()
    {
        return charge;
    }


    private void setMaterialColor(string materialName, Color setColor)
    {
        foreach (Material m in rend.materials)
        {
            if (m.name == materialName)
            {
                m.color = setColor;
            }
        }
    }

    public void setCharge(int chargeValue)
    {
        charge = chargeValue;
        if (charge >= 70)
        {
            //Debug.Log("3 Full bars");
            setMaterialColor("Battery Green (Instance)", green);
            setMaterialColor("Battery Green 2 (Instance)", green);
            setMaterialColor("Battery Green 3 (Instance)", green);
        }
        else if (charge < 70 && charge >= 40)
        {
            //Debug.Log("2 full bars");
            setMaterialColor("Battery Green (Instance)", green);
            setMaterialColor("Battery Green 2 (Instance)", green);
            setMaterialColor("Battery Green 3 (Instance)", white);
        }
        else if (charge < 40 && charge >= 10)
        {
            //Debug.Log("1 full bar");
            setMaterialColor("Battery Green (Instance)", green);
            setMaterialColor("Battery Green 2 (Instance)", white);
            setMaterialColor("Battery Green 3 (Instance)", white);
        }
        else if (charge < 10 && charge >= 1)
        {
            for (int i = 0; i <= flashingLimit; i ++)
            {
                //Debug.Log("Flashing");
                setMaterialColor("Battery Green (Instance)", white);
                setMaterialColor("Battery Green 2 (Instance)", white);
                setMaterialColor("Battery Green 3 (Instance)", white);

                Wait(1.0f);

                //Debug.Log("Flashing");
                setMaterialColor("Battery Green (Instance)", red);
                setMaterialColor("Battery Green 2 (Instance)", red);
                setMaterialColor("Battery Green 3 (Instance)", red);

                Wait(1.0f);
            }
        }
        else
        {
            //Debug.Log("Battery Off");
            setMaterialColor("Battery Green (Instance)", white);
            setMaterialColor("Battery Green 2 (Instance)", white);
            setMaterialColor("Battery Green 3 (Instance)", white);
        }
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}
