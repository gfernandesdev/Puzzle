using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePuzzleGame : MonoBehaviour
{
    float timer;
    bool partesEmbaralhadas = false;
    public Image parte;
    public Image localMarcado;
    float lmLargura, lmAltura;
    
    void criarLocaisMarcados()
    {
    	lmLargura = 100; lmAltura = 100;
    	float numLinhas = 5; float numColunas = 5;
    	float linha, coluna;
    	for (int i = 0; i < 25; i++) {
    		Vector3 posicaoCentro = new Vector3();
    		posicaoCentro = GameObject.Find("ladoDireito").transform.position;
    		linha = i % 5;
    		coluna = i / 5;
    		Vector3 lmPosicao = new Vector3(posicaoCentro.x + lmLargura * (linha - numLinhas / 2),
    			posicaoCentro.y - lmAltura * (coluna - numColunas / 2),
    			posicaoCentro.z);
    		Image lm = (Image)(Instantiate(localMarcado, lmPosicao, Quaternion.identity));
    		lm.tag = "" + (i+1);
    		lm.name = "LM" + (i+1);
    		lm.transform.SetParent(GameObject.Find("Canvas").transform);
    	}
    }
    
    public void criarPartes()
    {
    	lmLargura = 100;
    	lmAltura = 100;
    	float numLinhas, numColunas;
    	numLinhas = numColunas = 5;
    	float linha, coluna;
    	for (int i = 0; i<25; i++)
    	{
    	    Vector3 posicaoCentro = new Vector3();
    	    posicaoCentro = GameObject.Find("ladoEsquerdo").transform.position;
    	    linha = i % 5;
    	    coluna = i / 5;
    	    Vector3 lmPosicao = new Vector3(posicaoCentro.x + lmLargura * (linha - numLinhas / 2),
    	    	posicaoCentro.y - lmAltura * (coluna - numColunas / 2),
    	    	posicaoCentro.z);
    	    Image lm = (Image)(Instantiate(parte, lmPosicao, Quaternion.identity));
    	    lm.tag = ""+ (i+1);
    	    lm.name = "Parte" + (i+1);
    	    lm.transform.SetParent(GameObject.Find("Canvas").transform);
    	    Sprite[] todasSprites = Resources.LoadAll<Sprite>("corinthians");
    	    Sprite s1 = todasSprites[i];
    	    lm.GetComponent<Image>().sprite = s1;
    	}
    }
    
    void embaralhaPartes() {
    	int[] novoArray = new int[25];
    	for (int i = 0; i < 25; i++)
    	    novoArray[i] = i;
    	int tmp;
        for (int t =0; t<25; t++) {
            tmp = novoArray[t];
            int r = Random.Range(t, 10);
            novoArray[t] = novoArray[r];
            novoArray[r] = tmp;
        }
        float linha, coluna, numLinhas, numColunas;
        numLinhas = numColunas = 5;
        for (int i = 0; i < 25; i++) {
            linha = (novoArray[i]) % 5;
            coluna = (novoArray[i]) / 5;
            Vector3 posicaoCentro = new Vector3();
            posicaoCentro = GameObject.Find("ladoEsquerdo").transform.position;
            var g = GameObject.Find("Parte" + (i+1));
            Vector3 novaPosicao = new Vector3(posicaoCentro.x + lmLargura * (linha - numLinhas /2),
                posicaoCentro.y - lmAltura * (coluna - numColunas / 2),
                posicaoCentro.z);
            g.transform.position = novaPosicao;
            g.GetComponent<DragAndDrop>().posicaoInicialPartes();
        }
    }
    
    void falaInicial() {
    	GameObject.Find("totemInicio").GetComponent<tocadorInicio>().playInicio();
    }
    
    void falaPlay() {
    	GameObject.Find("totemPlay").GetComponent<tocadorPlay>().playPlay();
    }
    
    void Start()
    {
    	criarLocaisMarcados();
    	criarPartes();
    	falaInicial();
    	// embaralhaPartes();
    }
    
    void Update() {
    	timer += Time.deltaTime;
    	if (timer >= 4 && !partesEmbaralhadas) {
    	    embaralhaPartes();
    	    falaPlay();
    	    partesEmbaralhadas = true;
    	}
    }
}
