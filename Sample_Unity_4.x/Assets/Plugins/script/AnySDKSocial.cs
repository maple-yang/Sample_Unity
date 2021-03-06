using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace anysdk {
	public enum SocialRetCode
	{
		// code for leaderboard feature
		kScoreSubmitSucceed =1,/**< enum value is callback of succeeding in submiting. */
		kScoreSubmitfail,/**< enum value is callback of failing to submit . */
		
		// code for achievement feature
		kAchUnlockSucceed,/**< enum value is callback of succeeding in unlocking. */
		kAchUnlockFail,/**< enum value is callback of failing to  unlock. */
		
		kSocialSignInSucceed,/**< enum value is callback of succeeding to login. */
		kSocialSignInFail,/**< enum value is callback of failing to  login. */
		
		kSocialSignOutSucceed,/**< enum value is callback of succeeding to login. */
		kSocialSignOutFail,/**< enum value is callback of failing to  login. */
		kSocialGetGameFriends,/**< enum value is callback of getGameFriends. */
		kSocialExtensionCode = 20000 /**< enum value is  extension code . */
		
		
	} ;
	public class AnySDKSocial
	{
		private static AnySDKSocial _instance;
		
		public static AnySDKSocial getInstance() {
			if( null == _instance ) {
				_instance = new AnySDKSocial();
			}
			return _instance;
		}

		/**
     	@brief user signIn
    	 */

		public  void signIn()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			AnySDKSocial_nativeSignIn ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	@brief user signOut
    	 */

		public  void signOut()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			AnySDKSocial_nativeSignOut ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief submit the score
    	 @param leaderboardID
     	 @param the score
     	*/

		public  void submitScore(string leadboardID, long score)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			AnySDKSocial_nativeSubmitScore (leadboardID, score);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	 @brief show the id of Leaderboard page
     	 @param leaderboardID
     	 */

		public  void showLeaderboard(string leadboardID)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			AnySDKSocial_nativeShowLeaderboard (leadboardID);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		
		/**
    	 @brief methods of achievement feature
   		  @param the info of achievement
    	 */

		public  void unlockAchievement (Dictionary<string,string> achInfo)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string info = AnySDKUtil.dictionaryToString (achInfo);
			AnySDKSocial_nativeUnlockAchievement (info);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief show the page of achievements
     	*/

		public  void showAchievements ()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			AnySDKSocial_nativeShowAchievements ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
		 * set debugmode for plugin
		 * 
		 */
		[Obsolete("This interface is obsolete!",false)]
		public  void setDebugMode(bool bDebug)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			AnySDKSocial_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		/**
    	 @brief set pListener The callback object for social result
    	 @param the MonoBehaviour object
    	 @param the callback of function
    	 */

		public  void setListener(MonoBehaviour gameObject,string functionName)
		{
#if !UNITY_EDITOR && UNITY_ANDROID 
			AnySDKUtil.registerActionCallback (AnySDKType.Social, gameObject, functionName);
#elif !UNITY_EDITOR && UNITY_IOS
			string gameObjectName = gameObject.gameObject.name;
			AnySDKSocial_nativeSetListener(gameObjectName,functionName);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		/**
     	@brief Check function the plugin support or not
     	*/
		
		public  bool  isFunctionSupported (string functionName)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return AnySDKSocial_nativeIsFunctionSupported (functionName);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}
		/**
		 * Get Plugin version
		 * 
		 * @return string
	 	*/

		public  string getPluginVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKSocial_nativeGetPluginVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		/**
		 * Get Plugin version
		 * 
		 * @return string
	 	*/

		public  string getSDKVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKSocial_nativeGetSDKVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, AnySDKParam param)
		{
			#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			AnySDKSocial_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null) 
			{
				AnySDKSocial_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				AnySDKSocial_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return int
    	 */
		public  int callIntFuncWithParam(string functionName, AnySDKParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKSocial_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return int
    	 */
		public  int  callIntFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return AnySDKSocial_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKSocial_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, AnySDKParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKSocial_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return AnySDKSocial_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKSocial_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, AnySDKParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKSocial_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return AnySDKSocial_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKSocial_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, AnySDKParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			StringBuilder value = new StringBuilder();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKSocial_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder value = new StringBuilder();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			if (param == null)
			{
				AnySDKSocial_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				AnySDKSocial_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM,CallingConvention=CallingConvention.Cdecl)]
		private static extern void AnySDKSocial_RegisterExternalCallDelegate(IntPtr functionPointer);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeSetListener(string gameName, string functionName);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeSignIn();
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeSignOut();
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeShowLeaderboard(string leadboardID);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKSocial_nativeSubmitScore(string leadboardID, long score);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKSocial_nativeUnlockAchievement(string info);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKSocial_nativeShowAchievements();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKSocial_nativeIsFunctionSupported(string functionName);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeSetDebugMode(bool bDebug);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeGetPluginVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeGetSDKVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeCallFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern int AnySDKSocial_nativeCallIntFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern float AnySDKSocial_nativeCallFloatFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKSocial_nativeCallBoolFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKSocial_nativeCallStringFuncWithParam(string functionName, AnySDKParam[] param,int count,StringBuilder value);
	}
	
}


