using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Manager
{
    Canvas canvas;
    Image im;
    Render render;

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

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        im = GameObject.Find("Screen").GetComponent<Image>();
        render = GameObject.Find("Camera").GetComponent<Render>();
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
        //Shader a gérer ici ou juste Canvas
        
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
                canvas.enabled = true;
                break;
            case GameState.play:
                canvas.enabled = false;
                switch (GameManager.getInstance().getStage())
                {
                    case GameStage.chat:
                        render.changeShader("NoVision");
                        //im = Resources.Load<Image>("");
                        break;
                    case GameStage.cheminee:
                        //im = Resources.Load<Image>("");
                        break;
                    case GameStage.dessin:
                        render.changeShader("VisionGrey");
                        //im = Resources.Load<Image>("");
                        break;
                    case GameStage.boite_a_musique:
                        //im = Resources.Load<Image>("");
                        break;
                    case GameStage.fleurs:
                        //couper shader
                        //activer post processing
                        //render.changeShader("VisionCorrect");
                        //im = Resources.Load<Image>("");
                        break;
                    case GameStage.photo:
                        //im = Resources.Load<Image>("");
                        break;
                }
                break;
            case GameState.transition:
                canvas.enabled = false;
                break;
            case GameState.souvenir:
                switch (GameManager.getInstance().getStage())
                {
                    case GameStage.chat:
                        //im = Resources.Load<Image>("");
                        break;
                    case GameStage.cheminee:
                        //im = Resources.Load<Image>("");
                        break;
                    case GameStage.dessin:
                        //im = Resources.Load<Image>("");
                        break;
                    case GameStage.boite_a_musique:
                        //im = Resources.Load<Image>("");
                        break;
                    case GameStage.fleurs:
                        //im = Resources.Load<Image>("");
                        break;
                    case GameStage.photo:
                        //im = Resources.Load<Image>("");
                        break;
                }
                canvas.enabled = true;
                break;

            case GameState.end:
                ;
                break;
        }
    }
}
