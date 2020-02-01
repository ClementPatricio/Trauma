using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlerManager : Manager{





    void Awake()
    {
    }
    // Use this for initialization
    void Start () {
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


    // Update is called once per frame
    void Update () {
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
        /*switch (GameManager.getInstance().getStage())
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
        }*/
    }


    override
    public void TraitementIntro()
    {
        //rien
        ;
    }

    override
    public void TraitementTransition()
    {
        //rien
        ;
    }

    override
    public void TraitementSouvenir()
    {
        //rien
        ;
    }

    override
    //traitement de l'UI ici aussi ou directement dans UI ?
    public void TraitementPlay()
    {
        //depend surement du stage
    }
    override
    public void TraitementEnd()
    {
        //rien
        ;
    }
}
