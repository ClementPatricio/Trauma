using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//phase de controle du systeme
public enum GameState { intro, play, transition, souvenir , end };
//phase de jeu
public enum GameStage {accident,chat,cheminee,boite_a_musique,dessin,fleurs,photo }


public class GameManager : MonoBehaviour
{
    GameState state;
    GameStage stage;

    [SerializeField]
    public GameObject [] objects;
    [SerializeField]
    GameObject player;
    HapticSonar sonar;

    //contient les différents manager
    private UIManager ui_manager;
    private SoundManager sound_manager;
    private static GameManager instance;


    public static GameManager getInstance()
    {
        return instance;
    }

    void Awake()
    {
        ui_manager = GameObject.Find("UIManager").GetComponent<UIManager>();
        sound_manager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        /*setStage(GameStage.accident);
        setState(GameState.intro);*/
        sonar = player.GetComponent<HapticSonar>();
        sonar.setObjectToFind(objects[0]);
        sonar.setObjectToFind(objects[4]);
        setStage(GameStage.boite_a_musique);
        setState(GameState.souvenir);
    }

    public void Stop()
    {
        #if UNITY_EDITOR
                // Application.Quit() does not work in the editor so
                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                                        Application.Quit();
        #endif
    }

    public HapticSonar getHaptic()
    {
        return this.sonar;
    }

    public void setStage(GameStage stage)
    {
        this.stage = stage;
    }

    public void setState(GameState state)
    {
        this.state = state;
        ui_manager.actualiseState(state);
        sound_manager.actualiseState(state);
        if(state == GameState.transition)
        {
            Debug.Log("Début transition");
            switch (GameManager.getInstance().getStage())
            {
                case GameStage.accident:
                    setStage(GameStage.chat);
                    //sonar.setObjectToFind(objects[0]);
                    setState(GameState.play);
                    break;
                case GameStage.chat:
                    setStage(GameStage.cheminee);
                    sonar.setObjectToFind(objects[1]);
                    setState(GameState.play);
                    break;
                case GameStage.cheminee:
                    setStage(GameStage.dessin);
                    sonar.setObjectToFind(objects[2]);
                    setState(GameState.play);
                    break;
                case GameStage.dessin:
                    setStage(GameStage.boite_a_musique);
                    sonar.setObjectToFind(objects[3]);
                    setState(GameState.play);
                    break;
                case GameStage.boite_a_musique:
                    setStage(GameStage.fleurs);
                    sonar.setObjectToFind(objects[4]);
                    setState(GameState.play);
                    break;
                case GameStage.fleurs:
                    setStage(GameStage.photo);
                    setState(GameState.souvenir);
                    break;
                case GameStage.photo:
                    setState(GameState.end);
                    break;
            }
        }
    }

    public GameState getState()
    {
        return this.state;
    }
    public GameStage getStage()
    {
        return this.stage;
    }
}
