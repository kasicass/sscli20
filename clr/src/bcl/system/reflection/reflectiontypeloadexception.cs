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
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
//
// ReflectionTypeLoadException is thrown when multiple TypeLoadExceptions may occur.  
//  Specifically, when you call Module.GetTypes() this causes multiple class loads to occur.
//  If there are failures, we continue to load classes and build an array of the successfully
//  loaded classes.  We also build an array of the errors that occur.  Then we throw this exception
//  which exposes both the array of classes and the array of TypeLoadExceptions. 
//
// 
// 
//
namespace System.Reflection {
    
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    [Serializable()] 
[System.Runtime.InteropServices.ComVisible(true)]
    public sealed class ReflectionTypeLoadException : SystemException, ISerializable {
        private Type[] _classes;
        private Exception[] _exceptions;

        // private constructor.  This is not called.
        private ReflectionTypeLoadException()
            : base(Environment.GetResourceString("ReflectionTypeLoad_LoadFailed")) {
            SetErrorCode(__HResults.COR_E_REFLECTIONTYPELOAD);
        }

        // private constructor.  This is called from inside the runtime.
        private ReflectionTypeLoadException(String message) : base(message) {
            SetErrorCode(__HResults.COR_E_REFLECTIONTYPELOAD);
        }

        public ReflectionTypeLoadException(Type[] classes, Exception[] exceptions) : base(null)
        {
            _classes = classes;
            _exceptions = exceptions;
            SetErrorCode(__HResults.COR_E_REFLECTIONTYPELOAD);
        }

        public ReflectionTypeLoadException(Type[] classes, Exception[] exceptions, String message) : base(message)
        {
            _classes = classes;
            _exceptions = exceptions;
            SetErrorCode(__HResults.COR_E_REFLECTIONTYPELOAD);
        }

        internal ReflectionTypeLoadException(SerializationInfo info, StreamingContext context) : base (info, context) {
            _classes = (Type[])(info.GetValue("Types", typeof(Type[])));
            _exceptions = (Exception[])(info.GetValue("Exceptions", typeof(Exception[])));
        }
    
        public Type[] Types {
            get {return _classes;}
        }
        
        public Exception[] LoaderExceptions {
            get {return _exceptions;}
        }    

	[SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)] 		
        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            if (info==null) {
                throw new ArgumentNullException("info");
            }
            base.GetObjectData(info, context);
            info.AddValue("Types", _classes, typeof(Type[]));
            info.AddValue("Exceptions", _exceptions, typeof(Exception[]));
        }

    }
}
