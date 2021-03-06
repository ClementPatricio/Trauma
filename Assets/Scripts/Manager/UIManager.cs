using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class UIManager : Manager
{
    Canvas canvas;
    Image im, im2, background, titre2,ground;
    Render render;
    PostProcessVolume ppv;
    GameObject cam;
    int compteur;
    public float tmp_intro;
    public float tmp_titre;
    public float tmp_end;
    public Text titre,sous_titre;
    float time,time2;
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
        im2 = GameObject.Find("Screen2").GetComponent<Image>();
        background = GameObject.Find("Background").GetComponent<Image>();
        background.enabled = false;
        ground = GameObject.Find("Ground").GetComponent<Image>();
        ground.enabled = false;
        im2.enabled = false;
        cam = GameObject.Find("Main Camera");
        titre = GameObject.Find("Titre").GetComponent<Text>();
        titre.enabled = false;
        sous_titre = GameObject.Find("Sous-Titre").GetComponent<Text>();
        sous_titre.enabled = false;
        titre2 = GameObject.Find("Titre_Image").GetComponent<Image>();
        titre2.color = new Color(titre2.color.r, titre2.color.g, titre2.color.b, 0.0f);
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
            if(tmp >= 7.0f && titre2.color.a == 0.0f)
            {
                titre2.color = new Color(titre.color.r, titre.color.g, titre.color.b, 1.0f);
            }
        }
        else
        {
            
            titre2.enabled = false;
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
            if(GameManager.getInstance().getStage() == GameStage.photo)
            {
                Debug.Log("fondu");
                im2.color = new Color(im2.color.r, im2.color.g, im2.color.b,1.0f - alpha);
            }
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
        if (tmp < 56.0f)
        {
            Color color = im.color;
            if (up)
            {
                im.color = new Color(im.color.r, im.color.g, im.color.b, im.color.a +0.01f);
                im2.color = new Color(im2.color.r, im2.color.g, im2.color.b, im2.color.a - 0.01f);
                if(im2.color.a <= 0.0f)
                {
                    im2.sprite = Resources.Load<Sprite>("Images/hopital");
                    up = false;
                }
            }
            else
            {
                if (im2.color.a < 1.0f)
                {
                    im.color = new Color(im.color.r, im.color.g, im.color.b, im.color.a - 0.004f);
                    im2.color = new Color(im2.color.r, im2.color.g, im2.color.b, im2.color.a + 0.004f);
                }
            }
            /*if(color.a>= 1.0f)
            {
                if (im.rectTransform.localScale.x > 1.0f)
                    im.rectTransform.localScale = new Vector3(im.rectTransform.localScale.x - 0.08f, im.rectTransform.localScale.y - 0.08f,1.0f);
                else if(im.rectTransform.localScale.x < 1.0f)
                {
                    im.rectTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
                float x = 0.0f;
                float y = 0.0f;
                if (im.rectTransform.localPosition.x > 0.0f)
                {
                    x = -8.0f * 4.0f;
                }
                else if(im.rectTransform.localPosition.x < 0.0f)
                {
                    im.rectTransform.localPosition = new Vector3(0.0f, im.rectTransform.localPosition.y, 0.0f);
                }
                if(im.rectTransform.localPosition.y < 0.0f)
                {
                    y = 2.0f*4.0f;
                }
                else if(im.rectTransform.localPosition.y > 0.0f)
                {
                    im.rectTransform.localPosition = new Vector3(im.rectTransform.localPosition.x, 0.0f, 0.0f);
                }
                im.rectTransform.localPosition = new Vector3(im.rectTransform.localScale.x + x, im.rectTransform.localScale.y + y , 1.0f);
            }*/
            if (tmp >= 17.0f)
            {
                if (!titre.enabled)
                {
                    background.enabled = true;
                    time2 = Time.realtimeSinceStartup;
                    compteur = 0;
                    titre.enabled = true;
                    sous_titre.enabled = true;
                    titre.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    sous_titre.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
                switch (compteur)
                {
                    case 0:
                        //titre.text = "Jad BERRADA\nProject Management - 3D Assets";
                        titre.text = "Jad BERRADA\n";
                        sous_titre.text = "\nProject Management - 3D Assets";
                        break;
                    case 1:
                        //titre.text = "Pierre-Henri HEURTE\nGame/Level Design - 3D Assets";
                        titre.text = "Pierre-Henri HEURTE\n";
                        sous_titre.text = "\nGame/Level Design - 3D Assets";
                        break;
                    case 2:
                        //titre.text = "Elise MALBEC\nIllustrations";
                        titre.text = "Elise MALBEC\n";
                        sous_titre.text = "\nIllustrations";
                        break;
                    case 3:
                        //titre.text = "Clément PATRICIO\nProgramming";
                        titre.text = "Clément PATRICIO\n";
                        sous_titre.text = "\nProgramming";
                        break;
                    case 4:
                        //titre.text = "Terry PEREZ-GERVAIS\nMusic & Sound Design";
                        titre.text = "Terry PEREZ-GERVAIS\n";
                        sous_titre.text = "\nMusic & Sound Design";
                        break;
                    case 5:
                        //titre.text = "Théa TREVIGNON\nProject Management - 3D Assets";
                        titre.text = "Théa TREVIGNON\n";
                        sous_titre.text = "\nProject Management - 3D Assets";
                        break;
                    case 6:
                        //titre.text = "Julien VANDERHAEGEN\nProgramming";
                        titre.text = "Julien VANDERHAEGEN\n";
                        sous_titre.text = "\nProgramming";
                        break;
                    default:
                        titre.text = "";
                        sous_titre.text = "";
                        break;
                }
                if(Time.realtimeSinceStartup - time2 > 6.0f)
                {
                    time2 = Time.realtimeSinceStartup;
                    compteur++;
                }
            }
        }
        else
        {
            GameManager.getInstance().Stop();
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
                //titre.color = new Color(titre.color.r, titre.color.g, titre.color.b, 0.0f);
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
                        im2.sprite = Resources.Load<Sprite>("Images/photo_complete");
                        im2.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        im2.enabled = true;
                        ground.enabled = true;
                        //background.enabled = true;
                        break;
                }
                canvas.enabled = true;
                break;

            case GameState.end:
                im.sprite  = Resources.Load<Sprite>("Images/hopital");
                //2975.3    -874
                //5.8       5.8
                im.color = new Color(im.color.r, im.color.g, im.color.b, 0.0f);
                im.rectTransform.localPosition = new Vector3(2975.3f, -874.0f, 0.0f);
                //im.rectTransform.position = new Vector3(2975.3f,-874.0f,0.0f);
                im.rectTransform.localScale = new Vector3(5.8f, 5.8f, 0.0f);
                //im2.sprite = Resources.Load<Sprite>("Images/hopital");
                up = true;

                //im.sprite = Resources.Load<Sprite>("Images/hopital");
                titre.text = "";
                sous_titre.text = "";
                //titre.enabled = true;
                titre.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                canvas.enabled = true;
                time = Time.realtimeSinceStartup;
                break;
        }
    }
}
