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
        ui_manager.actualiseState(state);
        sound_manager.actualiseState(state);
        if(state == GameState.transition)
        {
            switch (GameManager.getInstance().getStage())
            {
                case GameStage.accident:
                    GameManager.getInstance().setStage(GameStage.chat);
                    break;
                case GameStage.chat:
                    GameManager.getInstance().setStage(GameStage.cheminee);
                    break;
                case GameStage.cheminee:
                    GameManager.getInstance().setStage(GameStage.dessin);
                    break;
                case GameStage.dessin:
                    GameManager.getInstance().setStage(GameStage.boite_a_musique);
                    break;
                case GameStage.boite_a_musique:
                    GameManager.getInstance().setStage(GameStage.fleurs);
                    break;
                case GameStage.fleurs:
                    GameManager.getInstance().setState(GameState.end);
                    break;
            }
            setState(GameState.play);
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
