using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using System.Text;
using anysdk;

public class Init
{
	private static Init _instance;
	private string appKey = "D22AB625-CD4C-2167-D35C-C5A03E5896F5";
	private string appSecret = "8959c650440b6b051d6af588d7f965f3";
	private string privateKey = "BA26F2670407E0B8664DDA544026FA54";
	
	private string oauthLoginServer = "http://oauth.anysdk.com/api/OauthLoginDemo/Login.php";
	
	public static Init getInstance() {
		if( null == _instance ) {
			_instance = new Init();
		}
		return _instance;
	}
	
	Init()
	{
		AnySDK.getInstance ().init (appKey, appSecret, privateKey, oauthLoginServer);


	}
	
	
}
