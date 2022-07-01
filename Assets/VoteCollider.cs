using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VoteCollider : MonoBehaviour
{
	public Transform votePanel;
	public Button voteButton;
	public int vote;

	void Start()
	{
		voteButton.onClick.AddListener(() =>
		{
			GameObject.FindObjectOfType<NearWalletHandler>().VoteTrigger(vote);
		});
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Pawn>().IsOwner)
		{

			votePanel.gameObject.SetActive(true);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Pawn>().IsOwner)
		{

			votePanel.gameObject.SetActive(false);
		}
	}
}
