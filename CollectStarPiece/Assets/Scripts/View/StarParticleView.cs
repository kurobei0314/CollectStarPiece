using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

[RequireComponent(typeof(ParticleSystem))]
public class StarParticleView : MonoBehaviour
{
    private bool is_active = false;
    public bool IsActive => is_active;

    // Start is called before the first frame update
    void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => !is_active)
            .Subscribe(_ => {
                var rnd = UnityEngine.Random.Range(0, 10);
                if (rnd < 6) {
                    is_active = true;
                    PlayStarParticle();
                }
            });
    }

    public void PlayStarParticle()
    {
        this.GetComponent<ParticleSystem>().Play();
        is_active = true;
    }

    void OnParticleSystemStopped ()
    {
        is_active = false;
    }

    public void SetActiveFalse()
    {
        is_active = false;
    }
}
