using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace anysdk {
	public enum PayResultCode
	{
		kPaySuccess = 0,/**< enum value is callback of succeeding in paying . */
		kPayFail,/**< enum value is callback of failing to pay . */
		kPayCancel,/**< enum value is callback of canceling to pay . */
		kPayNetworkError,/**< enum value is callback of network error . */
		kPayProductionInforIncomplete,/**< enum value is callback of incompleting info . */
		kPayInitSuccess,/**< enum value is callback of succeeding in initing sdk . */
		kPayInitFail,/**< enum value is callback of failing to init sdk . */
		kPayNowPaying,/**< enum value is callback of paying now . */
		kPayRechargeSuccess,/**< enum value is callback of  succeeding in recharging. */
		kPayExtension = 30000 /**< enum value is  extension code . */
	} ;
	/** @brief RequestResultCode enum, with inline docs */
	public enum RequestResultCode
	{
		kRequestSuccess = 31000,/**< enum value is callback of succeeding in paying . */
		kRequestFail/**< enum value is callback of failing to pay . */
	} ;
	public class AnySDKIAP
	{
		private static AnySDKIAP _instance;
		
		public static AnySDKIAP getInstance() {
			if( null == _instance ) {
				_instance = new AnySDKIAP();
			}
			return _instance;
		}

		/**
   	 	@brief pay for product
   		 @param info The info of product, must contains key:
   		 @warning  Look at the manual of plugins.

    	*/

		public  void payForProduct(Dictionary<string,string> info,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string value = AnySDKUtil.dictionaryToString (info);
			AnySDKIAP_nativePayForProduct(value,pluginId);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		/**
    	 @brief get order id
    	 @return the order id
    	 */

		public  string getOrderId(string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder value = new StringBuilder ();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKIAP_nativeGetOrderId (value,pluginId);
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
     	@brief Check function the plugin support or not
     	*/
		
		public  bool  isFunctionSupported (string functionName, string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return AnySDKIAP_nativeIsFunctionSupported (functionName,pluginId);
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
			AnySDKIAP_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		/**
    	 @brief set pListener The callback object for IAP result
    	 @param the MonoBehaviour object
    	 @param the callback of function
    	 */

		public  void setListener(MonoBehaviour gameObject,string functionName)
		{
#if !UNITY_EDITOR && UNITY_ANDROID  
			AnySDKUtil.registerActionCallback (AnySDKType.IAP, gameObject, functionName);
#elif !UNITY_EDITOR && UNITY_IOS
			string gameObjectName = gameObject.gameObject.name;
			AnySDKIAP_nativeSetListener(gameObjectName,functionName);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief get plugin ids
     	@return List<string> the plugin ids
     	*/

		public List<string> getPluginId()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder value = new StringBuilder ();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKIAP_nativeGetPluginId (value);
			List<string> list = AnySDKUtil.StringToList (value.ToString());
			return list;
#else
			Debug.Log("This platform does not support!");
			return null;
#endif
		}

		/**
   		 @brief change the state of paying
    	 @param the state
		*/

		public void resetPayState()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			AnySDKIAP_nativeResetPayState ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
		 * Get Plugin version
		 * @param  pluginid
		 * @return string
	 	*/

		public  string getPluginVersion(string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			StringBuilder version = new StringBuilder();
			version.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKIAP_nativeGetPluginVersion (version,pluginId);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		/**
		 * Get SDK version
		 *@param  pluginid 
		 * @return string
	 	*/

		public  string getSDKVersion(string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKIAP_nativeGetSDKVersion (version,pluginId);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		
		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  AnySDKParam param 
   		 *@param  pluginid
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, AnySDKParam param,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			AnySDKIAP_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count,pluginId);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  List<AnySDKParam> param 
   		 *@param  pluginid
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, List<AnySDKParam> param = null,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			if (param == null) 
			{
				AnySDKIAP_nativeCallFuncWithParam (functionName, null, 0,pluginId);
				
			} else {
				AnySDKIAP_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count,pluginId);
			}
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  AnySDKParam param 
   		 *@param  pluginid
    	 *@return int
    	 */
		public  int callIntFuncWithParam(string functionName, AnySDKParam param,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKIAP_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count,pluginId);
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  List<AnySDKParam> param 
   		 *@param  pluginid
    	 *@return int
    	 */
		public  int  callIntFuncWithParam(string functionName, List<AnySDKParam> param = null,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return AnySDKIAP_nativeCallIntFuncWithParam (functionName, null, 0,pluginId);
				
			} else {
				return AnySDKIAP_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count,pluginId);
			}
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  AnySDKParam param 
   		 *@param  pluginid
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, AnySDKParam param,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS)  
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKIAP_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count,pluginId);
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  List<AnySDKParam> param 
   		 *@param  pluginid
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, List<AnySDKParam> param = null,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return AnySDKIAP_nativeCallFloatFuncWithParam (functionName, null, 0,pluginId);
				
			} else {
				return AnySDKIAP_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count,pluginId);
			}
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  AnySDKParam param 
   		 *@param  pluginid
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, AnySDKParam param,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKIAP_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count,pluginId);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  List<AnySDKParam> param
   		 *@param  pluginid
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, List<AnySDKParam> param = null,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return AnySDKIAP_nativeCallBoolFuncWithParam (functionName, null, 0,pluginId);
				
			} else {
				return AnySDKIAP_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count,pluginId);
			}
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  AnySDKParam param 
   		 *@param  pluginid 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, AnySDKParam param,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			StringBuilder value = new StringBuilder();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKIAP_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value,pluginId);
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param  List<AnySDKParam> param 
   		 *@param  pluginid 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, List<AnySDKParam> param = null,string pluginId = "")
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder value = new StringBuilder();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			if (param == null)
			{
				AnySDKIAP_nativeCallStringFuncWithParam (functionName, null, 0,value,pluginId);
				
			} else {
				AnySDKIAP_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value,pluginId);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM,CallingConvention=CallingConvention.Cdecl)]
		private static extern void AnySDKIAP_RegisterExternalCallDelegate(IntPtr functionPointer);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKIAP_nativeSetListener(string gameName, string functionName);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKIAP_nativePayForProduct(string info,string pluginId);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKIAP_nativeGetOrderId(StringBuilder orderId,string pluginId);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKIAP_nativeResetPayState();

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKIAP_nativeIsFunctionSupported(string functionName,string pluginId);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKIAP_nativeSetDebugMode(bool bDebug);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKIAP_nativeGetPluginId(StringBuilder pluginID);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKIAP_nativeGetPluginVersion(StringBuilder version,string pluginId);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKIAP_nativeGetSDKVersion(StringBuilder version,string pluginId);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKIAP_nativeCallFuncWithParam(string functionName, AnySDKParam[] param,int count,string pluginId);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern int AnySDKIAP_nativeCallIntFuncWithParam(string functionName, AnySDKParam[] param,int count,string pluginId);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern float AnySDKIAP_nativeCallFloatFuncWithParam(string functionName, AnySDKParam[] param,int count,string pluginId);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKIAP_nativeCallBoolFuncWithParam(string functionName, AnySDKParam[] param,int count,string pluginId);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKIAP_nativeCallStringFuncWithParam(string functionName, AnySDKParam[] param,int count,StringBuilder value,string pluginId);
	}
	
}


