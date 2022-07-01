using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
/* using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json; */
public class NearWalletHandler : MonoBehaviour
{
	public Button connectButton;
	public static NearWalletHandler Instance;
	[DllImport("__Internal")]
	private static extern void ConnectWallet();
	[DllImport("__Internal")]
	private static extern void VoteAction(int vote);
	[DllImport("__Internal")]
	private static extern void BuyAction();
	public string walletAddress;
	private void Awake()
	{
		Instance = this;
		DontDestroyOnLoad(gameObject);
		/* Dictionary<string, string> data = new Dictionary<string, string>();
		data.Add("account_id", "ewtd.testnet");
		string args = JsonConvert.SerializeObject(data);
		string json = Utils.CallFunctionJson(
			"cafe.elcafecartel.testnet",
		 	"ft_balance_of",
			args
			);

		StartCoroutine(Utils.NearRPC(json)); */
	}
	public void ConnectWalletTrigger()
	{
#if UNITY_WEBGL == true && UNITY_EDITOR == false
    ConnectWallet();
#else
		Debug.Log("Editor set wallet");
		setWalletAddress("ewtd.testnet" + UnityEngine.Random.Range(0, 100));
#endif
	}
	public void setWalletAddress(string address)
	{
		Debug.Log("setWalletAddress:" + address);
		this.walletAddress = address;
		connectButton.GetComponentInChildren<TMPro.TMP_Text>().SetText(address);
	}
	public void BuyTrigger()
	{
#if UNITY_WEBGL == true && UNITY_EDITOR == false
		BuyAction();
#else
		Debug.Log("BUY");

#endif
	}

	public void VoteTrigger(int vote)
	{
#if UNITY_WEBGL == true && UNITY_EDITOR == false
		VoteAction(vote);
#else
		Debug.Log("VOTE:" + vote);
#endif
	}
}
