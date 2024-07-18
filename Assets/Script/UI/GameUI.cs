using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPR.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] GameObject donePanel;
        [SerializeField] OrderBar loadBarObject;


        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                SpawnLoad();
            }
        }

        public void SetActiveDonePanel(bool active)
        {
            donePanel.SetActive(active);
        }

        public void SpawnLoad()
        {
            OrderBar spawnedBar = Instantiate(loadBarObject, this.transform);

            spawnedBar.SetLoadingBar(100, PrintBisa, this.transform);
        }

        private void PrintBisa()
        {
            print("bisa");
        }
    }
}
