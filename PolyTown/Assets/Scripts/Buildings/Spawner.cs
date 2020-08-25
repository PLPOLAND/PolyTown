using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * <summary>
 * Klasa odpowiadająca za budowanie budynków.
 * </summary>
 */
public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject dom = null;//Dom Poziom1
    [SerializeField]
    private GameObject jagody = null;//Zbieraczej jagód
    [SerializeField]
    private GameObject drwal = null;//Hata Drwala
    [SerializeField]
    private GameObject woda = null; //Studnia
    [SerializeField]
    private GameObject centurm = null; //Studnia
    [SerializeField]
    private GameObject magazyn = null; //Studnia
    [SerializeField]
    private GameObject szczegolyLink = null;

    private GameObject active = null; //Aktualnie wybrany obiekt do budowy
    private GameObject wizualizer = null; //Aktualnie wybrany obiekt do budowy
    public bool isSpawn = false; //wskaźnik czy aktualnie użytkownik ma zamiar budować.
    public bool isDel = false; // wskaźnik czy aktualnie użytkownik ma zamiar usuwać. TODO.
    protected Zasoby zasoby_gracza = null; //Odnośnik do obiektu przechowującego 
    protected Map map = null;
    protected Field activeField = null; 

    public Dictionary<string, Budynek.BudynekToSave> budynki = null;//przechowuje dane budynków potrzebne do zapisu

    private void Start()
    {
        zasoby_gracza = GameObject.Find("Player").GetComponent<Player>().zasoby;
        map = GameObject.Find("Map").GetComponent<Map>();
        budynki = new Dictionary<string,Budynek.BudynekToSave>();
    }
    private void Update()
    {
        if (Input.GetKeyDown("escape") || Input.GetMouseButtonDown(1))
        {
            isSpawn = false;
            isDel = false;
            szczegolyLink.SetActive(false);
            GameObject.Find("DolnyPanel").GetComponent<Select>().deselectAll();
        }
        if (isSpawn == false)
        {
            if (activeField != null)
                activeField.clearHighLight();
            activeField = null;
            active = null;
            MonoBehaviour.Destroy(wizualizer);
        }
        if (Input.GetKeyDown(","))
        {
            active.transform.RotateAround(active.transform.position, Vector3.up, 90f);
            wizualizer.transform.RotateAround(wizualizer.transform.position, Vector3.up, 90f);
        }
        if (Input.GetKeyDown("."))
        {
            active.transform.RotateAround(active.transform.position, Vector3.up, -90f);
            wizualizer.transform.RotateAround(wizualizer.transform.position, Vector3.up, -90f);
        }
    }
    public void onClick(Vector2Int pozycja)
    {
        Debug.Log(isDel);
        if(isSpawn){
            spawn(pozycja);
        }
        else if(isDel){
            Debug.Log("Delete");
            if (map.mapa[pozycja.x, pozycja.y].budynek != null)
            {
                Debug.Log(map.mapa[pozycja.x, pozycja.y].budynek.name + " " + budynki.Remove(map.mapa[pozycja.x, pozycja.y].budynek.name));
                MonoBehaviour.Destroy(map.mapa[pozycja.x, pozycja.y].budynek);
                map.mapa[pozycja.x, pozycja.y].budynek = null;
            }
        }
        else if(map.mapa[pozycja.x, pozycja.y].posiadaBudynek())
        {
            szczegolyLink.SetActive(true);
            szczegolyLink.GetComponent<SzczegolyBudynku>().onClick(map.mapa[pozycja.x, pozycja.y].budynek);
        }
    }
    public bool spawn(Vector2Int pozycja){
        var zasobyDoOdjęciaNaStart = (active.GetComponent("Budynek") as Budynek).zasobyPoczątkowe;
        if (zasoby_gracza.isOkToSub(zasobyDoOdjęciaNaStart) && (zasoby_gracza.getPieniadze() - zasobyDoOdjęciaNaStart.getPieniadze()) >= 0)
        {
            var okToBuild = map.mapa[pozycja.x, pozycja.y].canBuild;
            if (okToBuild)
            {
                if (active.GetComponent<Budynek>().finder.znajdź(pozycja))
                {
                    
                    var budynek = MonoBehaviour.Instantiate(active);
                    budynek.transform.position = map.getPositionOfPole(pozycja);
                    zasoby_gracza.subWithPieniadze(zasobyDoOdjęciaNaStart);
                    map.mapa[pozycja.x, pozycja.y].canBuild = false;
                    map.mapa[pozycja.x, pozycja.y].budynek = budynek;
                    budynek.GetComponent<Budynek>().pozycjaNaMapie = pozycja;
                    budynek.name = budynek.name + " " +pozycja.x +","+ pozycja.y;
                    Budynek.BudynekToSave bud = new Budynek.BudynekToSave(budynek.GetComponent<Budynek>());
                    Debug.Log(budynek.name+"addToList");
                    budynki.Add(budynek.name, bud);
                    return true;
                }
            }
        }
        return false;
    }

    public void setJagody(){
        if (wizualizer != null)
            MonoBehaviour.Destroy(wizualizer);//Zniszcz obecną instancje wizualizowanego obiekty
        isSpawn = true; 
        active = jagody; // przypisz nowy obiekt do spawnowania
        wizualizer = MonoBehaviour.Instantiate(jagody); // Stwórz nowy obiekt wizualicyjny
        setPositionOfWizualizer(); //ustaw odpowiednia pozycje obiektu wizualizacyjnego
        wizualizer.GetComponent<ZbieraczeJagod>().enabled = false; // dla obiektu wizualizacyjnego wyłącz działanie skryptu z zasobami
    }
    public void setDom(){
        if (wizualizer != null)
            MonoBehaviour.Destroy(wizualizer);//Zniszcz obecną instancje wizualizowanego obiekty
        isSpawn = true; 
        active = dom; // przypisz nowy obiekt do spawnowania
        wizualizer = MonoBehaviour.Instantiate(dom); // Stwórz nowy obiekt wizualicyjny
        setPositionOfWizualizer(); //ustaw odpowiednia pozycje obiektu wizualizacyjnego
        wizualizer.GetComponent<Dom>().enabled = false; // dla obiektu wizualizacyjnego wyłącz działanie skryptu z zasobami
    }
    public void setWoda(){
        if (wizualizer != null)
            MonoBehaviour.Destroy(wizualizer); //Zniszcz obecną instancje wizualizowanego obiekty
        isSpawn = true; 
        active = woda; // przypisz nowy obiekt do spawnowania
        wizualizer = MonoBehaviour.Instantiate(woda); // Stwórz nowy obiekt wizualicyjny
        setPositionOfWizualizer(); //ustaw odpowiednia pozycje obiektu wizualizacyjnego
        wizualizer.GetComponent<Studnia>().enabled = false; // dla obiektu wizualizacyjnego wyłącz działanie skryptu z zasobami
    }
    public void setDrwal(){
        if (wizualizer != null)
            MonoBehaviour.Destroy(wizualizer);//Zniszcz obecną instancje wizualizowanego obiekty
        isSpawn = true; 
        active = drwal; // przypisz nowy obiekt do spawnowania
        wizualizer = MonoBehaviour.Instantiate(drwal); // Stwórz nowy obiekt wizualicyjny
        setPositionOfWizualizer(); //ustaw odpowiednia pozycje obiektu wizualizacyjnego
        wizualizer.GetComponent<Drwal>().enabled = false; // dla obiektu wizualizacyjnego wyłącz działanie skryptu z zasobami
    }
    public void setMagazyn(){
        if (wizualizer != null)
            MonoBehaviour.Destroy(wizualizer);//Zniszcz obecną instancje wizualizowanego obiekty
        isSpawn = true; 
        active = magazyn; // przypisz nowy obiekt do spawnowania
        wizualizer = MonoBehaviour.Instantiate(magazyn); // Stwórz nowy obiekt wizualicyjny
        setPositionOfWizualizer(); //ustaw odpowiednia pozycje obiektu wizualizacyjnego
        wizualizer.GetComponent<Magazyn>().enabled = false; // dla obiektu wizualizacyjnego wyłącz działanie skryptu z zasobami
    }
    public void setCentrum(){
        if (wizualizer != null)
            MonoBehaviour.Destroy(wizualizer);//Zniszcz obecną instancje wizualizowanego obiekty
        isSpawn = true; 
        active = centurm; // przypisz nowy obiekt do spawnowania
        wizualizer = MonoBehaviour.Instantiate(centurm); // Stwórz nowy obiekt wizualicyjny
        setPositionOfWizualizer(); //ustaw odpowiednia pozycje obiektu wizualizacyjnego
        wizualizer.GetComponent<Centrum>().enabled = false; // dla obiektu wizualizacyjnego wyłącz działanie skryptu z zasobami
    }
    public void setDeleteMode(){
        isSpawn = false;
        isDel = true;
    }
    /**
     * <summary>
     * Ustawia nowe aktywne pole. Dba o podświetlanie i anulowanie podświetlenia
     * </summary>
     * <param name="field"></param>
     */
    public void setActiveField(Field field){
        if (activeField != field || activeField == null)
        {
            if(activeField != null)
                activeField.clearHighLight();//usuń podświetlenie poprzednie pola
            activeField = field; //ustaw nowe pole na które jest skierowana myszka
            activeField.highLight(); //podświetl pole
            setPositionOfWizualizer(); //przesuń model poglądowy na nowe miejsce;
        }
    }
    /**
     * <summary>
     * Ustawia pozycję obiektu wizualizowanego na pozycje pola. Pozycja jest pobierana z pola zawartego w Map.
     * </summary>
     * <param name="pozycja"></param>
     */
    public void setPositionOfWizualizer(Vector2Int pozycja){
        if (active != null)
        {
            wizualizer.transform.position = map.getPositionOfPole(pozycja);
        }
    }
    /**
     * <summary>
     * Ustawia pozycje obiektu wizualizacyjnego na pozycje aktywnego pola. Jeśli nie ma aktywnego pola ustawia pozycje (teoretycznie)po za widokiem 
     * </summary>
     */
    public void setPositionOfWizualizer(){
        if (active != null && activeField != null)
        {
            wizualizer.transform.position = map.getPositionOfPole(activeField.pos);
        }
        else if (active != null)
        {
            wizualizer.transform.position = new Vector3(1000000,1000000,1000000);
        }
    }


}
