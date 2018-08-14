using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour {

    public GameObject Logo;
    public GameObject Obj2;
    public GameObject Obj3;


    public Animator Anim_Obj2;

    public GameObject OpenSphere;

    public GameObject[] Models;
    bool isZoomIn;
    bool isZoomOut;

	bool isMoveUp;
	bool isMoveDown;

	public GameObject portraitButton;
	public GameObject landscapeButton;

    public AudioSource klik1;
    public AudioSource klik2;

    GameObject EffectObject;

    //public GameObject[] sphere;

    // Use this for initialization
    void Start () {
		
	}

	void OnApplicationFocus(bool hasFocus)
	{
		Application.LoadLevel (0);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit klik;
            Ray posisiketuk = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(posisiketuk, out klik/*, 9000*/))
            {
                if (klik.collider.tag == "Logo")
                {
                    Obj2.SetActive(true);
                    Obj3.SetActive(true);
                }

				if (klik.collider.tag == "open1") {
					Anim_Obj2.SetBool ("open1", true);
					OpenSphere.SetActive (false);
                    klik1.Play();
				} else if (klik.collider.tag == "open2") {
					Anim_Obj2.SetBool ("open2", true);
					OpenSphere.SetActive (false);
                    klik1.Play();
                } else if (klik.collider.tag == "open3") {
					Anim_Obj2.SetBool ("open3", true);
					OpenSphere.SetActive (false);
                    klik1.Play();
                } else if (klik.collider.tag == "open4") {
					Anim_Obj2.SetBool ("open4", true);
					OpenSphere.SetActive (false);
                    klik1.Play();
                } else if (klik.collider.tag == "open5") {
					Anim_Obj2.SetBool ("open5", true);
					OpenSphere.SetActive (false);
                    klik1.Play();
                } else if (klik.collider.tag == "open6") {
					Anim_Obj2.SetBool ("open6", true);
					OpenSphere.SetActive (false);
                    klik1.Play();
                } else {
					OpenUrlChild (klik.collider.tag);
                    klik2.Play();
                }
					
            }
            else// if (klik.collider.tag == "")
            {
                Anim_Obj2.SetBool("open1", false);
                Anim_Obj2.SetBool("open2", false);
                Anim_Obj2.SetBool("open3", false);
                Anim_Obj2.SetBool("open4", false);
                Anim_Obj2.SetBool("open5", false);
                Anim_Obj2.SetBool("open6", false);
                OpenSphere.SetActive(true);
            }
        }


        //Zoom
        for (int i = 0; i < Models.Length; i++)
        {
            if (isZoomIn)
            {
                Models[i].transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }
            else if (isZoomOut)
            {
                Models[i].transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            }

			if (isMoveUp)
			{
				Models [i].transform.Translate (Vector3.up * Time.deltaTime *10);
			}
			else if (isMoveDown)
			{
				Models[i].transform.Translate (Vector3.down * Time.deltaTime *10);
			}
        }

    }

	public void SwitchLandscape()
	{
		for (int i = 0; i < Models.Length; i++) 
		{
			//Models [i].transform.rotation.x = 90;
			Models [i].transform.Rotate(90f, 0f, 0f);
		}
		portraitButton.SetActive (false);
		landscapeButton.SetActive (true);
	}

	public void SwitchPortrait()
	{
		for (int i = 0; i < Models.Length; i++) 
		{
			//Models [i].transform.rotation.x = 90;
			Models [i].transform.Rotate(-90f, 0f, 0f);
		}
		portraitButton.SetActive (true);
		landscapeButton.SetActive (false);
	}

    //Zoom
    public void ZoomINPressed()
    {
        isZoomIn = true;
    }
    public void ZoomINReleased()
    {
        isZoomIn = false;
    }

    public void ZoomOUTPressed()
    {
        isZoomOut = true;
    }
    public void ZoomOUTReleased()
    {
        isZoomOut = false;
    }

	//Move
	public void MoveUpPressed()
	{
		isMoveUp = true;
	}
	public void MoveUpReleased()
	{
		isMoveUp = false;
	}

	public void MoveDownPressed()
	{
		isMoveDown = true;
	}
	public void MoveDownReleased()
	{
		isMoveDown = false;
	}

    IEnumerator ActivateEffect(string tag)
    {
        //GameObject.Find("Quad").SetActive
        //EffectObject = GameObject.FindGameObjectWithTag(tag);
        //GameObject asd = find

        //if (true)
        //{

        //}
        //EffectObject.
        yield return new WaitForSeconds(2);
        //EffectObject.SetActive(false);
    }

	public void OpenUrlChild(string tag)
	{
        //ActivateEffect(tag);
		switch (tag) {
		    case "1.1_SimPersampahan":
			    Application.OpenURL ("http://ciptakarya.pu.go.id/plp/simpersampahan/baseline/");
			    break;
            case "1.2_AplikasiKlinikSanitasi":
                Application.OpenURL("http://ciptakarya.pu.go.id/plp/klinik/");
                break;
            case "1.3_SIM.PLPBM":
                Application.OpenURL("http://ciptakarya.pu.go.id/plp/");
                break;
            case "1.4_AppKampanyePLP":
                Application.OpenURL("http://ciptakarya.pu.go.id/plp/dutasanitasi/");
                break;
            case "1.5_SIM.GIS-Drainase":
                Application.OpenURL("http://sim.ciptakarya.pu.go.id/drainase/");
                break;
            //////////////////////////////////////////////////////////////
            case "2.1_SIMAsetTanah":
                Application.OpenURL("http://ciptakarya.pu.go.id/setditjen/aset_tanah/");
                break;
            case "2.2_AppE-LHP-BMN":
                Application.OpenURL("http://ciptakarya.pu.go.id/pbmn/temuan/");
                break;
            case "2.3_SIM.Hibah.Aset.BMN":
                Application.OpenURL("http://ciptakarya.pu.go.id/pbmn/bmn/");
                break;
            case "2.4_SIM.Aset.TDB":
                Application.OpenURL("http://ciptakarya.pu.go.id/tanggapdarurat/");
                break;
            case "2.5_E-LHP.Keuangan":
                Application.OpenURL("http://ciptakarya.pu.go.id/lk-lhp/");
                break;
            case "2.6_SIMHukum":
                Application.OpenURL("http://ciptakarya.pu.go.id/simhukum/");
                break;
            case "2.7_AppKKNTematik":
                Application.OpenURL("http://ciptakarya.pu.go.id/setditjen/kkntematik/id/");
                break;
            case "2.8_AppSatgasTDB":
                Application.OpenURL("http://ciptakarya.pu.go.id/pbmn/tdb/");
                break;
            case "2.9_AppSiKadir":
                Application.OpenURL("http://ciptakarya.pu.go.id/absensi/masuk");
                break;
            case "2.10_SIM.KA":
                Application.OpenURL("http://ciptakarya.pu.go.id/simka/");
                break;
            case "2.11_AppInfoPublik":
                Application.OpenURL("http://ciptakarya.pu.go.id/infopublik/");
                break;
            //////////////////////////////////////////////////////////////
            case "3.1_SimPersampahan":
				Application.OpenURL("http://ciptakarya.pu.go.id/plp/simpersampahan/");
                break;
            case "3.2_AppGIS.AsetSPAM":
				Application.OpenURL("http://sigamas.ciptakarya.pu.go.id/");
                break;
			case "3.3_AppKlinikSanitasi":
				Application.OpenURL("http://ciptakarya.pu.go.id/plp/klinik/"); //!!!
				break;
			case "3.4_AppHibahSPAM":
				Application.OpenURL("http://ciptakarya.pu.go.id/pspam/hibahspam/login.php");
				break;
			case "3.5_SIM.PAMSIMAS":
				Application.OpenURL("http://pamsimas.pu.go.id/"); //!!!
				break;
			case "3.6_AppInvestasiSPAM":
				Application.OpenURL("http://ciptakarya.pu.go.id/pspam/investasi_spam");
				break;
			case "3.7_AppHematAir":
				Application.OpenURL("http://ciptakarya.pu.go.id/pspam/hematair");
				break;
			case "3.8_AppInfoAirMinum":
				Application.OpenURL("http://infoairminum.pu.go.id/");
				break;
			case "3.9_AppKampanyePLP":
				Application.OpenURL("http://ciptakarya.pu.go.id/plp/dutasanitasi/");  //!!!
				break;
			case "3.10_AppCOEHebat":
				Application.OpenURL("http://ciptakarya.pu.go.id/pspam/coehebat");
				break;
			/////////////////////////////////////
			case "4.1_AppProhamsam":
				Application.OpenURL("http://ciptakarya.pu.go.id/prohamsan/");
				break;
			case "4.2_AppMonitoringSIM":
				Application.OpenURL("http://ciptakarya.pu.go.id/monitoring/");
				break;
			case "4.4_AppSIMEKA":
				Application.OpenURL("http://ciptakarya.pu.go.id/simeka/v2/");
				break;
			case "4.5_KnowledgeMgmDJCK":
				Application.OpenURL("http://ciptakarya.pu.go.id/knowledge/");
				break;
			case "4.6_SIM.PHLN.CK":
				Application.OpenURL("http://ciptakarya.pu.go.id/phlnck/");
				break;
			case "4.7_SIM.RevAnggaran":
				Application.OpenURL("http://ciptakarya.pu.go.id/simrevisidipa");
				break;
			case "4.8_AppSIPPA":
				Application.OpenURL("http://ciptakarya.pu.go.id/sippa/v25/");
				break;
			//////////////////////////////////////
			case "5.1_SIM.KotaBaru":
				Application.OpenURL("http://sim.ciptakarya.pu.go.id/kotabaru/");
				break;
			case "5.2_SIM.NUSP-2":
				Application.OpenURL("http://ciptakarya.pu.go.id/bangkim/nusp-2/");  //!!!
				break;
			case "5.3_perdaKumuh":
				Application.OpenURL("http://ciptakarya.pu.go.id/bangkim/perdakumuh/");
				break;
			case "5.4_AppR2KPKP":
				Application.OpenURL("http://ciptakarya.pu.go.id/bangkim/rp2kpkp/");
				break;
			case "5.5_SIM.KOTAKU":
				Application.OpenURL("http://kotaku.pu.go.id/"); //!!!
				break;
			case "5.6_SIM.PISEW":
				Application.OpenURL("http://ciptakarya.pu.go.id/bangkim/simpp/");   //!!!
				break;
			case "5.7_SIM.Perbatasan":
				Application.OpenURL("http://ciptakarya.pu.go.id/bangkim/simperbatasan/");
				break;
			//////////////////////////////////
			case "6.1_AppP2KH":
				Application.OpenURL("http://sim.ciptakarya.pu.go.id/p2kh/");
				break;
			case "6.2_AppRNG.III":
				Application.OpenURL("http://rng3.pu.go.id/sirn/");
				break;
			case "6.3_AppHSBGN":
				Application.OpenURL("http://ciptakarya.pu.go.id/hsbgn");
				break;
			case "6.4_SIM.BG":
				Application.OpenURL("http://rng3.pu.go.id/dev/simbg/");
				break;
			case "6.5_AppKotaPusaka":
				Application.OpenURL("http://sim.ciptakarya.pu.go.id/kotapusaka/");
				break;   
            default:
			break;
		}
	}

    //private void SetSphere(bool status)
    //{
    //    for (int i = 0; i < sphere.Length; i++)
    //    {
    //        sphere[i].SetActive(status);
    //    }
    //} 
}
