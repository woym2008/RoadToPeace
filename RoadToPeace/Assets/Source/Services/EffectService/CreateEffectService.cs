using UnityEngine;
using System.Collections;

public class CreateEffectService : Service
{
    public CreateEffectService(Contexts contexts)
        : base(contexts)
    {
        ;
    }

    public void CreateEffect(string name, Vector2 pos, int sortid)
    {
        var e = _contexts.game.CreateEntity();

        e.AddAsset(name, sortid);
        e.AddPosition(pos);
    }
}
