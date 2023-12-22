using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{
    LibPdInstance pd;
    public PlantType type;
    
    // Start is called before the first frame update
    void Start()
    {
        pd = transform.GetComponent<LibPdInstance>();
        switch (type)
        {
            case PlantType.Plant2:
                pd.SendBang("bell");
                break;
            case PlantType.Plant3:
                pd.SendBang("drum");
                break;
            default:
                break;
        }
    }

    public void PlayMidi(int midi) {
        Debug.Log(pd);
        pd.SendFloat("midi", midi);
    }

    public void SetVolume(float volume) {
        pd.SendFloat("volume", volume);
    }

    public void SetDrum() {
        pd.SendBang("drum");
    }

    public void SetBell() {
        Debug.Log("AAA");
        Debug.Log(pd);
        SetInstrument("bell");
    }

    IEnumerator SetInstrument(string instrument)
    {   
        bool set = false;
        while (!set) {
            if (pd != null) {
                Debug.Log("Setting");
                pd.SendBang(instrument);
                set = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
