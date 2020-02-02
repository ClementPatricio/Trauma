using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Manager
{

    private static SoundManager instance;


    public GameObject SoundIntro;

    public GameObject SoundCat;
    public GameObject SoundFirePlace;
    public GameObject SoundDraw;
    public GameObject SoundMusicBox;
    public GameObject SoundFlower;
    public GameObject SoundPicture;

    public GameObject SoundEnd;

    public static SoundManager getInstance()
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


    //ICI SE FAIT UNE FOIS LORS DE CHANGEMENT D'ETAT DU JEU
    override
    public void actualiseState(GameState state)
    {
        switch (state)
        {
            case GameState.intro:
                AkSoundEngine.PostEvent("Game_Intro", SoundIntro);
                ;
                break;
            case GameState.play:
                ;
                break;
            case GameState.transition:
                //gestion du son pendant stage donc activation son obj ?
                switch (GameManager.getInstance().getStage())
                {
                    case GameStage.accident:
                        AkSoundEngine.PostEvent("SFX_Cat", SoundCat);
                        break;
                    case GameStage.chat:
                        AkSoundEngine.PostEvent("SFX_Fire", SoundFirePlace);
                        break;
                    case GameStage.cheminee:
                        AkSoundEngine.PostEvent("SFX_Draw", SoundDraw);
                        break;
                    case GameStage.dessin:
                        AkSoundEngine.PostEvent("Music_MusicBox", SoundMusicBox);
                        break;
                    case GameStage.boite_a_musique:
                        AkSoundEngine.PostEvent("Amb_Forest", SoundFlower);
                        break;
                    case GameStage.fleurs:
                        AkSoundEngine.PostEvent("SFX_Paper", SoundPicture);
                        break;
                    case GameStage.photo:
                        break;
                }
                break;
            case GameState.souvenir:
                ;
                AkSoundEngine.PostEvent("SFX_Paper", SoundFlower);
                break;

            case GameState.end:
                AkSoundEngine.PostEvent("Game_End", SoundEnd);
                ;
                break;
        }
    }

    override
    public void TraitementTransition()
    {
        //rien
    }

    override
    public void TraitementIntro()
    {
        //gestion du son de l'intro
    }

    override
    public void TraitementSouvenir()
    {
        //gestion du son pendant la transition en fonction du stage
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
        //gestion son de fin
    }
}
