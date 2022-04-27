using UnityEngine;

public class ShaderSB3 : MonoBehaviour
{
    Renderer rend; // -----------> ShaderManager

    // Estos 6 que estan a continuacion son como una especie de banderas que se ejecutan en una proporcion
    // del llenado del shader
    public float manosLim;//0.147   -----------> ShaderController
    public float mirrorLimt;//0.223 -----------> ShaderController
    public float luzLimt;//0.301    -----------> ShaderController

    //public float guiaStandup;//0.401  // NO SE USA 
    //public float guiaAvatar;//0.555   // NO SE USA 
    //public float bellyLimt;//0.633    // NO SE USA 


    //public bool instruccionIni;  // --------------> Descartado (NO SE USA)
    public bool InStandup;         // ----------------> Descartado
    public bool InLuzamb;          // ----------------> Descartado

    public bool alCollider;      // ----------------> SE USA EN ManoRTocaGuia (Todavia no movido)
    public bool InMirror;        // ----------------> Implementado como enumeracion en ShaderManager
    public bool InHands;         // ----------------> Implementado como enumeracion en ShaderManager
    public bool InGuia;          // ----------------> Implementado como enumeracion en ShaderManager


    public PointerEvents gaze;   // ---------> CONTIENE LA INSTRUCCION 4 (todavia no movido)

    public LuzAmb luzAmb;    // -----------> ShaderManager
    public LuzGuia luzguia;  // -----------> ShaderManager

    public CinturaCollider espejo; // -----------> GameManager.
    //public ChangeMat avatar; // NO SE USA

    public PDSensorSHARED pd;   // ---------> Reemplazado por el estatico
    public ManoRtocaGUIA touch; // ---------> CONTIENE LA INSTRUCCION 5 (todavia no movido)

    public activarColliderGuia colliderOnG;   // -----------> ShaderManager
    public activarColliderManoR colliderOnR;  // -----------> ShaderManager
    public activarColliderManoL colliderOnL;  // -----------> ShaderManager

    public int steps = 10; // ----> Numero de instrucciones? Reemplazado por otra logica en ShadeInstructions
    public float targetValueDownIncreaseStep; // -----------> Reemplazado por otra logica en ShaderController
    public float targetValueUp; // -----------> Reemplazado por otra logica en ShaderController
    public float targetValueDown; // -----------> Reemplazado por otra logica en ShaderController

    public float MaxContribution; //  // -----------> Reemplazado por otra logica en ShaderController
    public float MinContributionNew;//start in black  // --> Reemplazado por otra logica en ShaderController
    public int MinContributionCount; // -----------> Reemplazado por otra logica en ShaderController
    public float VelContribution; // -----------> Reemplazado por otra logica en ShaderController
    public float currentValue;  // -------------> ShaderController (shaderCurrentValue)
    [Range(0.210f, 1)] public float lerpedValue;

    public float lerpSpeedUp; // -----------> Reemplazado por otra logica en ShaderController
    public float lerpSpeedDown; // -----------> Reemplazado por otra logica en ShaderController
    private float lerpSpeedUpNew; // -----------> Reemplazado por otra logica en ShaderController
    private float lerpSpeedUpCount; // -----------> Reemplazado por otra logica en ShaderController
    public float lerpSpeedUpVel; // -----------> Reemplazado por otra logica en ShaderController

    public AudioSource instrIni; // ---------> Reemplazado en ShaderInstructions
    public float delay = 2;    // ---------> Reemplazado en ShaderInstructions
    public float volume = 0.5f; // ---------> Reemplazado en ShaderInstructions


    public FlowCal flowcal;  // -------------> Reemplazado por el estatico

    //public MyMessageListenerSHARED contador;


    void Start()
    {      
        instrIni.PlayDelayed(delay); // ---------> Reemplazado en el awake de ShaderInstructions

        InStandup = true;
        InMirror = true;

        InHands = true;
        InLuzamb = true;
        InGuia = true;
    
        targetValueDownIncreaseStep = (targetValueUp - targetValueDown) / steps;
        rend = GetComponent<Renderer>();
        currentValue = rend.material.GetFloat("_ZeroValue");

        MaxContribution = 1;
        targetValueUp = 1;
        targetValueDown = 0;
        MinContributionNew = 0.181f;//0.210f; //=1 resp
        lerpSpeedUpCount = 0;
        MinContributionCount = 0;

    }

    void Update()
    {
        if (Input.GetKeyDown("1")) // (Input.GetKeyDown("1"))//
        {
            MinContributionNew = 0.454f;
            Debug.Log("ver");
        }

        if (Time.timeSinceLevelLoad <= delay || instrIni.isPlaying)//?
            return; // ¿Una condicion para terminar una funcion update?


        // Si el estado es notstarted la inicializamos a chest ¿Esto deberia checkearse siempre?
        if (flowcal.CurrentState1 == GameState1.NotStarted1)  // -------> Reemplazado en el awake de ShaderManager
            flowcal.SetState(GameState1.Chest1);
        
    }

    // esta es la funcion que va cambiando progresivamente el shader
    public void LuzUp()
    {
        lerpedValue = Mathf.Lerp(currentValue, targetValueUp, Time.deltaTime * lerpSpeedUpNew);
        currentValue = Mathf.Clamp(lerpedValue, MinContributionNew, MaxContribution);
        rend.material.SetFloat("_ZeroValue", currentValue);

        lerpSpeedUpCount = lerpSpeedUpCount + 1; // So you add to the count everytime you go into this function, if it executes once when you have a new breath
        lerpSpeedUpNew = lerpSpeedUpCount * lerpSpeedUpVel; // So this increases by 0.2f everytime this function is called

        MinContributionCount = MinContributionCount + 1;
        MinContributionNew = MinContributionCount * VelContribution;

            if (MinContributionNew >= manosLim && InHands && !SoundManagerGuia.instance.IsPlaying)
            {//////////////////////0.147                   
                 Debug.Log("manosAIR"); //Se prende luz manos x input porque en esta en MyMessageListenerSHARED
            SoundManagerGuia.instance.PlayInstruccion01();//where AIR?
            InHands = false;
            }


            if (MinContributionNew > mirrorLimt && InMirror && !SoundManagerGuia.instance.IsPlaying)
            {//////////////////////////0.223
                espejo.planeMirror.SetActive(true);
                Debug.Log("espejoReal");
            SoundManagerGuia.instance.PlayInstruccion02();//Air enter... air out
            InMirror = false;
            }

            if (MinContributionNew >= luzLimt && InGuia && !SoundManagerGuia.instance.IsPlaying)
            {///////////////////////////////0.301
                    luzguia.luzUpGuia();
                    luzAmb.luzUp();
                    Debug.Log("luzAmb1 + luzGuia");              
            SoundManagerGuia.instance.PlayInstruccion03();//Its me! To guide you ||-NO TOCO, SOLO SALUDO!!-
            InGuia = false;                        
                       colliderOnG.agrandarCollider();////agrando collider GUIA
                       alCollider = true;///////aviso al collider que se puede activar recien aca
            }
        //no mas input CHEST!(va a seguir afectando el shader pero sin trigeriar nada)
        //usuario mira GUIA Y play INSTRUCCION04 take my hand>>>>PointerEvents

        if (gaze == true )//&& InStandup )//&& !SoundManagerGuia.instance.IsPlaying)
        {
            luzAmb.luzUp();
            Debug.Log("standUp");/// por que se pone en false con el 1er input??
            InStandup = false;         
                    colliderOnL.agrandarCollidermanoL();////agrando collider MANOS para que toqen guia+mano
                    colliderOnR.agrandarCollidermanoR();// y luego manos+capsula
        }

        ////////YO TOCO GUIA CON MANO, COLISIONO VOY AL CODIGO >>>colliderManos
        //// Y PlayInstruccion05();//put hands waits [IF alCollider = true]


        var potentialNextValue = Mathf.Clamp(targetValueDown + targetValueDownIncreaseStep, 0, targetValueUp);
        if (currentValue >= potentialNextValue)
        {
            targetValueDown = potentialNextValue;
        }

    }


    public void LuzDown()
    {

        lerpedValue = Mathf.Lerp(currentValue, targetValueDown, Time.deltaTime * lerpSpeedDown);

        rend.material.SetFloat("_ZeroValue", Mathf.Clamp(lerpedValue, MinContributionNew, MaxContribution));

        currentValue = rend.material.GetFloat("_ZeroValue");
    }

}
