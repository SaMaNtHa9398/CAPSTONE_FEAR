using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
public class ToolTipManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=y2N_J391ptg
    public static ToolTipManager _instance;

    public TextMeshProUGUI tooltipText;
    public TextMeshProUGUI itemTitle;
    public TextMeshProUGUI itemTip;
    public Image titleBorder;
    public Image DesciptionBoarder;
    public Image icon; 
    private void Awake()
    {
       if(_instance != null && _instance !=this)
        {
            Destroy(this.gameObject); 
        }    
       else
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Input.mousePosition; 
    }
    public void SetAndShowToolTip(string message, string itemtitle, string itemtip, Color titleBoarderColor, Color descriptionBoarderColor, Sprite itemIcon)
    {
        gameObject.SetActive(true);
        tooltipText.text = message;
        itemTitle.text = itemtitle;
        itemTip.text = itemtip;
        titleBorder.color = titleBoarderColor;
        DesciptionBoarder.color = descriptionBoarderColor;
        icon.sprite = itemIcon; 
      
    }
    public void HidToolTip()
    {
        gameObject.SetActive(false);
        tooltipText.text = string.Empty;
        itemTitle.text = string.Empty;
        itemTip.text = string.Empty;
        titleBorder.color = Color.white;
        DesciptionBoarder.color =Color.white;
        icon.sprite = null; 
    }
}
