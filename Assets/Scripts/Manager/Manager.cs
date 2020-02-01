using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager : MonoBehaviour {
    public abstract void actualiseState(GameState state);

    //traitement dans Update des Manager
    public abstract void TraitementIntro();
    public abstract void TraitementPlay();
    public abstract void TraitementTransition();
    public abstract void TraitementSouvenir();
    public abstract void TraitementEnd();

}
