using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour
{
    // Start is called before the first frame update

    public float latitud;
    public float longitud;
    public Text gpsText;
    void Start()
    {
        if(Input.location.isEnabledByUser)
        StartCoroutine(GetLocation());
    }

    private IEnumerator GetLocation()
    {
        Input.location.Start();
        while(Input.location.status == LocationServiceStatus.Initializing)
        {
            yield return new WaitForSeconds(0.5f);
        }

        latitud = Input.location.lastData.latitude;
        longitud = Input.location.lastData.longitude;
        yield break;

    }

    // Update is called once per frame
    void Update()
    {
        longitud = Input.location.lastData.longitude;
        latitud = Input.location.lastData.latitude;
        gpsText.text = "Latitud:"+latitud + " Longitud "+ longitud;

    }
}
