﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(FoV2DEyesMod))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class FoV2DConeMod : MonoBehaviour
{
    public enum Status
    {
        Idle,
        Suspicious,
        Alert
    }
    public Status status;
    public List<Material> materials;

    Vector3[] newVertices;
    Vector2[] newUV;
    int[] newTriangles;
    Mesh mesh;
    MeshRenderer meshRenderer;
    FoV2DEyesMod eyes;
    List<RaycastHit2D> hits;
    int i;
    int v;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshRenderer = GetComponent<MeshRenderer>();
        eyes = gameObject.GetComponent<FoV2DEyesMod>();

        meshRenderer.material = materials[0];
    }

    void LateUpdate()
    {
        UpdateMesh();

        UpdateMeshMaterial();
    }

    //Updates the mesh of the field of view
    void UpdateMesh()
    {
        hits = eyes.hits;

        if (hits == null || hits.Count == 0)
            return;

        if (mesh.vertices.Length != hits.Count + 1)
        {
            mesh.Clear();
            newVertices = new Vector3[hits.Count + 1];
            newTriangles = new int[(hits.Count - 1) * 3];

            i = 0;
            v = 1;
            while (i < newTriangles.Length)
            {
                if ((i % 3) == 0)
                {
                    newTriangles[i] = 0;
                    newTriangles[i + 1] = v;
                    newTriangles[i + 2] = v + 1;
                    v++;
                }
                i++;
            }
        }

        //Triangluar calculation to create the mesh.
        newVertices[0] = Vector3.zero;
        for (i = 1; i <= hits.Count; i++)
        {
            newVertices[i] = transform.InverseTransformPoint(hits[i - 1].point);
        }

        newUV = new Vector2[newVertices.Length];
        i = 0;
        while (i < newUV.Length)
        {
            newUV[i] = new Vector2(newVertices[i].x, newVertices[i].y);
            i++;
        }

        mesh.vertices = newVertices;
        mesh.triangles = newTriangles;
        mesh.uv = newUV;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    //Update the mesh material if status changes.
    void UpdateMeshMaterial()
    {
        for (i = 0; i < materials.Count; i++)
        {
            if (i == (int)status && meshRenderer.material != materials[i])
            {
                meshRenderer.material = materials[i];
            }
        }
    }
}


