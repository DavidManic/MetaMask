using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WalletPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private TextMeshProUGUI account;
    [SerializeField]
    private TextMeshProUGUI balance;
    // set chain: ethereum, moonbeam, polygon etc
    string chain = "ethereum";
    // set network mainnet, testnet
    string network = "rinkeby";
    // smart contract method to call
    string method = "myTotal";
    // abi in json format
    string abi = "[ { \"inputs\": [ { \"internalType\": \"uint8\", \"name\": \"_myArg\", \"type\": \"uint8\" } ], \"name\": \"addTotal\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [], \"name\": \"myTotal\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\" } ], \"stateMutability\": \"view\", \"type\": \"function\" } ]";
    // address of contract
    string contract = "0x7286Cf0F6E80014ea75Dbc25F545A3be90F4904F";
    // array of arguments for contract
    string args = "[]";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void GetBlanace()
    {
        
        account.text = PlayerPrefs.GetString("Account");
        string balanc = await EVM.BalanceOf(chain,network,PlayerPrefs.GetString("Account"));
        balance.text = balanc.ToString();
    }

    public void OnSignOut()
    {
        // Clear Account
        PlayerPrefs.SetString("Account", "0x0000000000000000000000000000000000000001");
        // go to login scene
        SceneManager.LoadScene(0);
    }

    public void TogglePanel()
    {
        panel.SetActive(!panel.activeInHierarchy);
        if (panel.activeInHierarchy)
            GetBlanace();
    }
}
