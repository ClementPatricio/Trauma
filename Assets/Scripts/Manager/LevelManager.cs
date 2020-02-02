using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelManager : Manager {

    
    private static LevelManager instance;
    public static LevelManager getInstance()
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
    public void TraitementTransition()
    {
        //chargement en fonction du stage
        //tp etc
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
        //rien
    }

    override
    public void TraitementSouvenir()
    {
        //rien
    }

    override
    //traitement de l'UI ici aussi ou directement dans UI ?
    public void TraitementPlay()
    {
        //soit verif objet en cours
        //soit directement sur objet
        //ou Object classe avec objet héritant tous de cette classe
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
    public void TraitementEnd()
    {
        //rien
    }


    override
    public void actualiseState(GameState state)
    {
        switch (state)
        {
            case GameState.intro:
                //rien ici
                ;
                break;
            case GameState.play:
                //Generation nouvel éléments suivant GameStage
                break;
            case GameState.transition:
                //transition chargement
                //Ici chargement objet
                ;
                break;
            case GameState.souvenir:
                //Generation nouvel éléments suivant GameStage
                /*
                 */

                break;
            
            case GameState.end:
                ;
                break;
        }
    }
}
