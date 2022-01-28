///////////////////////////////////////////////////////////
//  NetNegativeState.cs
//  Implementation of the Class NetNegativeState
//  Generated by Enterprise Architect
//  Created on:      18-Jan-2022 11:15:08 PM
//  Original author: Administrator
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using Common.Patterns;
namespace Common.Patterns {
	/// <summary>
	/// This subclass implements a behaviour associated with a state of the Context.
	/// </summary>
	public class NetNegativeState : State {

		public NetNegativeState(){

		}

		~NetNegativeState(){

		}

		/// 
		/// <param name="context"></param>
		public override void Handle(InvokerSubjectContext context){
			context.State = new NetPositiveState();
			context.Notify();
		}

	}//end NetNegativeState

}//end namespace Patterns