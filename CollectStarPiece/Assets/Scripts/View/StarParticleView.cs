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
        Observable.Interval(System.TimeSpan.FromSeconds(1))
                .Where(_ => !is_active && this.gameObject.activeSelf)
                .Subscribe(_ => {
                    var rnd = UnityEngine.Random.Range(0, 10);
                    if (rnd < 9) {
                        is_active = true;
                        PlayStarParticle();
                    }
                }).AddTo(this);
    }

    private void PlayStarParticle()
    {
        this.GetComponent<ParticleSystem>().Play();
        AudioManager.Instance.PlaySE("Star");
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
