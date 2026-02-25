using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace _Source.Clicker
{
    public class AddPoitnForClick : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI poitnText;
        
        private int _poitnAmount;
        public void Click()
        {
           _poitnAmount++;
           poitnText.text = _poitnAmount.ToString();
        }
    }
}
