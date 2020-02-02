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


    //contient les différents manager
    private LevelManager level_manager;
    private UIManager ui_manager;
    private SoundManager sound_manager;
    private ControlerManager controler_manager;
    private static GameManager instance;


    public static GameManager getInstance()
    {
        //ou instantie si n'existe pas ?
        return instance;
    }

    void Awake()
    {
        level_manager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        ui_manager = GameObject.Find("UIManager").GetComponent<UIManager>();
        sound_manager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        controler_manager = GameObject.Find("ControlerManager").GetComponent<ControlerManager>();
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
        setStage(GameStage.accident);
        setState(GameState.intro);
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

    public void setStage(GameStage stage)
    {
        this.stage = stage;
    }

    public void setState(GameState state)
    {
        this.state = state;
        level_manager.actualiseState(state);
        ui_manager.actualiseState(state);
        sound_manager.actualiseState(state);
        controler_manager.actualiseState(state);

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
