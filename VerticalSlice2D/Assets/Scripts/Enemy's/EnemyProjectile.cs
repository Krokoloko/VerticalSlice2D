using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
 
    public List<Sprite> bulletSprites;
    public List<Material> materialPrefabs;
    public List<string> types;
    public CircleCollider2D Collider;
    public Animator animator;
    public string identity;
    private Material _material;
    private SpriteRenderer _spriteRenderer;
    private Projectiles _type;

    void Start()
    {
        identity = gameObject.GetComponentInParent<GameObject>().tag;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _material = gameObject.GetComponent<Material>();
        for (int i = 0; i < types.Count; i++)
        {
            if (identity == types[i])
            {
                _material.CopyPropertiesFromMaterial(materialPrefabs[i]);
                _spriteRenderer.sprite = bulletSprites[i];
            }
        }
    }

    void Update () {
        switch (identity)
        {
            case "Mushroom":
                Projectiles.Spore type1 = new Projectiles.Spore();
                transform.Translate(type1.Travel());
                break;
            case "Tullip":
                Projectiles.Spore type2 = new Projectiles.Spore();
                transform.Translate(type2.Travel());
                break;
            default:
                Debug.Log("Identity is not recognised.");
                break;
        }
	}
}
