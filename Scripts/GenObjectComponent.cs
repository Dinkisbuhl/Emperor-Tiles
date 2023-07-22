using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenObjectComponent : MonoBehaviour
{
    MeshFilter filter;
    Renderer rend;

    RaycastHit hit;
    [Range(0, 1)]
    public float align;
    public Vector2 widthVariation;
    public Vector2 heightVariation;

    public Season[] Seasons;

    public void Set(int season)
    {
        filter = gameObject.GetComponent<MeshFilter>();

        LayerMask mask = LayerMask.GetMask("Terrain");
        rend = gameObject.GetComponent<Renderer>();

        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, 2, mask))
            transform.rotation = Quaternion.FromToRotation(transform.up, Vector3.Lerp(Vector3.up, hit.normal, align)) * Quaternion.Euler(0, Random.Range(0, 360), 0);
        float width = Random.Range(widthVariation.x * 10f, widthVariation.y * 10f) / 10f;
        transform.localScale = Vector3.Scale(new Vector3(width, Random.Range(heightVariation.x * 10f, heightVariation.y * 10f) / 10f, width), transform.localScale);

        SetSeason(season);
    }

    public void SetSeason(int season)
    {
        filter.mesh = Seasons[season].mesh;

        for (int i = 0; i < Seasons[season].colorSets.Length; i++)
        {
            rend.materials[i].color = Seasons[season].colorSets[i].Evaluate(Random.Range(0, 10f) / 10f);
        }
    }

    [System.Serializable]
    public class Season
    {
        public Mesh mesh;
        public Gradient[] colorSets;
    }
}
