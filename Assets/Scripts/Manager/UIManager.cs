using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class UIManager : Manager
{
    Canvas canvas;
    Image im;
    Render render;
    PostProcessVolume ppv;
    GameObject cam;
    public float tmp_intro;
    public float tmp_titre;
    public float tmp_end;
    public Text titre;
    float time;
    bool up;
    float alpha = 0.0f;

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
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        im = GameObject.Find("Screen").GetComponent<Image>();
        cam = GameObject.Find("Main Camera");
        titre = GameObject.Find("Titre").GetComponent<Text>();
        ppv = cam.GetComponent<PostProcessVolume>();
        render = cam.GetComponent<Render>();
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
        float tmp = Time.realtimeSinceStartup - time;
        if (tmp < 10.0f)
        {
            Color color = im.color;
            im.color = new Color(im.color.r - 0.005f, im.color.g - 0.005f, im.color.b - 0.005f, 1.0f);
            if(tmp >= 7.0f && titre.color.a == 0.0f)
            {
                titre.color = new Color(titre.color.r, titre.color.g, titre.color.b, 1.0f);
            }
        }
        else
        {
            titre.enabled = false;
            im.color = new Color(1, 1, 1, 0);
            GameManager.getInstance().setState(GameState.transition);
        }
    }

    public void fondu()
    {
        if (up)
        {
            im.color = new Color(im.color.r, im.color.g, im.color.b, alpha);
            alpha+=0.01f;
            if(alpha >= 1.0f)
            {
                up = false;
            }
        }
        else
        {
            im.color = new Color(im.color.r, im.color.g, im.color.b, alpha);
            alpha -= 0.01f;
        }
    }

    override
    public void TraitementSouvenir()
    {
        fondu();
        if(!up && alpha <= 0.0f)
        {
            canvas.enabled = false;
            //Debug.Log("Fin phase souvenir");
            GameManager.getInstance().setState(GameState.transition);
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
        //ici gestion de l'intro
        //Shader a gérer ici ou juste Canvas
        float tmp = Time.realtimeSinceStartup - time;
        if (tmp < 10.0f)
        {
            Color color = im.color;
            if (color.r >= 0.0f)
            {
                im.color = new Color(im.color.r - 0.001f, im.color.g - 0.001f, im.color.b - 0.001f, 1.0f);
            }
            if (tmp >= 7.0f && titre.color.a == 0.0f)
            {
                titre.color = new Color(titre.color.r, titre.color.g, titre.color.b, 1.0f);
            }
        }
        else
        {
            GameManager.getInstance().setState(GameState.transition);
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
    public void actualiseState(GameState state)
    {
        switch (state)
        {
            case GameState.intro:
                up = true;
                time = Time.realtimeSinceStartup;
                titre.color = new Color(titre.color.r, titre.color.g, titre.color.b, 0.0f);
                canvas.enabled = true;
                render.shader_actif = false;
                ppv.enabled = true;
                break;
            case GameState.play:
                canvas.enabled = false;
                switch (GameManager.getInstance().getStage())
                {
                    case GameStage.chat:
                        ppv.enabled = false;
                        render.shader_actif = true;
                        render.changeShader("NoVision");
                        
                        break;
                    case GameStage.cheminee:
                        break;
                    case GameStage.dessin:
                        render.changeShader("VisionGrey");
                        break;
                    case GameStage.boite_a_musique:
                        break;
                    case GameStage.fleurs:
                        render.shader_actif = false;
                        ppv.enabled = true;
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
                up = true;
                alpha = 0.001f;
                
                switch (GameManager.getInstance().getStage())
                {
                    case GameStage.chat:
                        im.sprite = Resources.Load<Sprite>("Images/photo_chat");
                        //Debug.Log(im.ToString());
                        Debug.Log("Chat photo");
                        break;
                    case GameStage.cheminee:
                        im.sprite = Resources.Load<Sprite>("Images/photo_cheminee");
                        break;
                    case GameStage.dessin:
                        im.sprite = Resources.Load<Sprite>("Images/photo_dessin");
                        break;
                    case GameStage.boite_a_musique:
                        im.sprite = Resources.Load<Sprite>("Images/photo_boite");
                        break;
                    case GameStage.fleurs:
                        im.sprite = Resources.Load<Sprite>("Images/photo_fleurs");
                        break;
                    case GameStage.photo:
                        im.sprite = Resources.Load<Sprite>("Images/photo");
                        break;
                }
                canvas.enabled = true;
                break;

            case GameState.end:
                im = Resources.Load<Image>("end");
                canvas.enabled = true;
                break;
        }
    }
}
