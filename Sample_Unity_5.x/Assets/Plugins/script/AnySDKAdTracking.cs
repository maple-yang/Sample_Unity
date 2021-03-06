using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace anysdk {
	public class AnySDKAdTracking
	{
		private static AnySDKAdTracking _instance;
		
		public static AnySDKAdTracking getInstance() {
			if( null == _instance ) {
				_instance = new AnySDKAdTracking();
			}
			return _instance;
		}

		/**
     	* 
    	* @Title: onRegister 
    	* @Description: Call this method if you want to track register events as happening during a section.
    	* @param userId    user identifier
    	* @return void     
     	*/

		public  void onRegister(string userId)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			AnySDKAdTracking_nativeOnRegister (userId);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
	 	*
		* @Title: onLogin
		* @Description:Call this method if you want to track login events as happening during a section.
		* @param userInfo  The details of this parameters are already covered by document.
		* @return void
	 	*/

		public  void onLogin(Dictionary<string,string> userInfo)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string info = AnySDKUtil.dictionaryToString (userInfo);
			Debug.Log("onLogin   " + info);
			AnySDKAdTracking_nativeOnLogin (info);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	*
    	* @Title: onPay
    	* @Description: Call this method if you want to track pay events as happening during a section.
    	* @param  productInfo  The details of this parameters are already covered by document.
    	* @return void
     	*/
		
		public  void onPay(Dictionary<string,string> userInfo)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string info = AnySDKUtil.dictionaryToString (userInfo);
			Debug.Log("onPay   " + info);
			AnySDKAdTracking_nativeOnPay (info);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
	 	*
		* @Title: trackEvent
		* @Description: Call this method if you want to track custom events with parameters as happening during a section.
		* @param eventId The custom event name.
		* @param  paramMap The details of this parameters are already covered by document.
	 	*/
		public  void  trackEvent (string eventId,Dictionary<string,string> paramMap = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string value;
			if (paramMap == null) value = null; 
			else value = AnySDKUtil.dictionaryToString (paramMap);
			AnySDKAdTracking_nativeTrackEvent (eventId,value);
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
			return AnySDKAdTracking_nativeIsFunctionSupported (functionName);
#else
			Debug.Log("This platform does not support!");
			return false;
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
			AnySDKAdTracking_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
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
			AnySDKAdTracking_nativeGetPluginVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
		 * Get SDK version
		 * 
		 * @return string
	 	*/

		public  string getSDKVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKAdTracking_nativeGetSDKVersion (version);
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
			AnySDKAdTracking_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
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
				AnySDKAdTracking_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				AnySDKAdTracking_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return AnySDKAdTracking_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return AnySDKAdTracking_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKAdTracking_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
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
			return AnySDKAdTracking_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
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
				return AnySDKAdTracking_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKAdTracking_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
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
    	 *@return string
    	 */
		public  bool callBoolFuncWithParam(string functionName, AnySDKParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKAdTracking_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return string
    	 */
		public  bool callBoolFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return AnySDKAdTracking_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKAdTracking_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, AnySDKParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			StringBuilder value = new StringBuilder();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKAdTracking_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
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
				AnySDKAdTracking_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				AnySDKAdTracking_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAdTracking_nativeOnRegister(string userId);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAdTracking_nativeOnLogin(string info);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAdTracking_nativeOnPay(string info);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAdTracking_nativeTrackEvent(string eventId, string message);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKAdTracking_nativeIsFunctionSupported(string functionName);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAdTracking_nativeSetDebugMode(bool bDebug);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAdTracking_nativeGetPluginVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAdTracking_nativeGetSDKVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAdTracking_nativeCallFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern int AnySDKAdTracking_nativeCallIntFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern float AnySDKAdTracking_nativeCallFloatFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKAdTracking_nativeCallBoolFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKAdTracking_nativeCallStringFuncWithParam(string functionName, AnySDKParam[] param,int count,StringBuilder value);
	}
	
}


