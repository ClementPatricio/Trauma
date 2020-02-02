using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager
{
    GameObject HUD;

    private static UIManager instance;
    public static UIManager getInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); ;
        }
    }

    override
    public void TraitementTransition()
    {
        //ici chargement shader ou dans LevelManager peut etre
        switch (GameManager.getInstance().getStage())
        {
            case GameStage.accident:
                break;
            case GameStage.chat:
                break;
            case GameStage.cheminee:
                break;
            case GameStage.dessin:
                break;
            case GameStage.boite_a_musique:
                break;
            case GameStage.fleurs:
                break;
            case GameStage.photo:
                break;
        }
    }

    override
    public void TraitementIntro()
    {
        //ici gestion de l'intro
        
    }

    override
    public void TraitementSouvenir()
    {
        //gestion du fragment du souvenir avec Canvas
        switch (GameManager.getInstance().getStage())
        {
            case GameStage.accident:
                break;
            case GameStage.chat:
                break;
            case GameStage.cheminee:
                break;
            case GameStage.dessin:
                break;
            case GameStage.boite_a_musique:
                break;
            case GameStage.fleurs:
                break;
            case GameStage.photo:
                break;
        }
    }

    override
    //traitement de l'UI ici aussi ou directement dans UI ?
    public void TraitementPlay()
    {
        //rien
    }
    override
    public void TraitementEnd()
    {
        //gestion cinématique de fin
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.getInstance().getState())
        {
            case GameState.intro:
                TraitementIntro();
                break;
            case GameState.play:
                TraitementPlay();
                break;
            case GameState.transition:
                TraitementTransition();
                break;
            case GameState.souvenir:
                TraitementSouvenir();
                break;

            case GameState.end:
                TraitementEnd();
                break;
        }
    }


    override
    public void actualiseState(GameState state)
    {
        switch (state)
        {
            case GameState.intro:
                ;
                break;
            case GameState.play:
                ;
                break;
            case GameState.transition:
                ;
                break;
            case GameState.souvenir:
                ;
                break;

            case GameState.end:
                ;
                break;
        }
    }
}
