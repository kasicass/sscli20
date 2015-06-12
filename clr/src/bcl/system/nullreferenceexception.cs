// ==++==
// 
//   
//    Copyright (c) 2006 Microsoft Corporation.  All rights reserved.
//   
//    The use and distribution terms for this software are contained in the file
//    named license.txt, which can be found in the root of this distribution.
//    By using this software in any fashion, you are agreeing to be bound by the
//    terms of this license.
//   
//    You must not remove this notice, or any other, from this software.
//   
// 
// ==--==
/*=============================================================================
**
** Class: NullReferenceException
**
**
** Purpose: Exception class for dereferencing a null reference.
**
**
=============================================================================*/

namespace System {   
    
	using System;
	using System.Runtime.Serialization;
[System.Runtime.InteropServices.ComVisible(true)]
    [Serializable()] public class NullReferenceException : SystemException {
        public NullReferenceException() 
            : base(Environment.GetResourceString("Arg_NullReferenceException")) {
    		SetErrorCode(__HResults.COR_E_NULLREFERENCE);
        }
    
        public NullReferenceException(String message) 
            : base(message) {
    		SetErrorCode(__HResults.COR_E_NULLREFERENCE);
        }
    	
        public NullReferenceException(String message, Exception innerException) 
            : base(message, innerException) {
    		SetErrorCode(__HResults.COR_E_NULLREFERENCE);
        }

        protected NullReferenceException(SerializationInfo info, StreamingContext context) : base(info, context) {}

    }

}
