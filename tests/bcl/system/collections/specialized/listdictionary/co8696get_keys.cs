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
using System.IO;
using System.Text;  
using System;
using System.Collections;
using System.Collections.Specialized;
using GenStrings;
public class Co8696get_Keys
{
    public static String s_strActiveBugNums = "";
    public static String s_strDtTmVer       = "";
    public static String s_strClassMethod   = "ListDictionary.Keys";
    public static String s_strTFName        = "Co8696get_Keys.cs";
    public static String s_strTFAbbrev      = s_strTFName.Substring(0, 6);
    public static String s_strTFPath        = Environment.CurrentDirectory;
    public const int MAX_LEN = 50;          
    public virtual bool runTest()
    {
        Console.WriteLine(s_strTFPath + " " + s_strTFName + " , for " + s_strClassMethod + " , Source ver: " + s_strDtTmVer);
        int iCountErrors = 0;
        int iCountTestcases = 0;
        IntlStrings intl;
        String strLoc = "Loc_000oo";
        ListDictionary ld; 
        string [] values = 
        {
            "",
            " ",
            "a",
            "aa",
            "tExt",
            "     spAces",
            "1",
            "$%^#",
            "2222222222222222222222222",
            System.DateTime.Today.ToString(),
            Int32.MaxValue.ToString()
        };
        string [] keys = 
        {
            "zero",
            "one",
            " ",
            "",
            "aa",
            "1",
            System.DateTime.Today.ToString(),
            "$%^#",
            Int32.MaxValue.ToString(),
            "     spaces",
            "2222222222222222222222222"
        };
        Array arr;
        ICollection ks;         
        int ind;
        try
        {
            intl = new IntlStrings(); 
            Console.WriteLine("--- create dictionary ---");
            strLoc = "Loc_001oo"; 
            iCountTestcases++;
            ld = new ListDictionary();
            Console.WriteLine("1. get Keys for empty dictionary");
            iCountTestcases++;
            if (ld.Count > 0)
                ld.Clear();
            if (ld.Keys.Count != 0) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0001, returned Keys.Count = {0}", ld.Keys.Count);
            }
            Console.WriteLine("2. get Keys on filled dictionary");  
            strLoc = "Loc_002oo"; 
            int len = values.Length;
            iCountTestcases++;
            ld.Clear();
            for (int i = 0; i < len; i++) 
            {
                ld.Add(keys[i], values[i]);
            }
            if (ld.Count != len) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0002a, count is {0} instead of {1}", ld.Count, len);
            } 
            ks = ld.Keys;
            if (ks.Count != len) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0002a, returned Keys.Count = {0}", ks.Count);
            }
            arr = Array.CreateInstance(typeof(Object), len);
            ks.CopyTo(arr, 0);
            for (int i = 0; i < len; i++) 
            {
                iCountTestcases++;
                ind = Array.IndexOf(arr, keys[i]);
                if (ind < 0) 
                {
                    iCountErrors++;
                    Console.WriteLine("Err_0002b_{0}, Keys doesn't contain \"{1}\" key. Search result: {2}", i, keys[i], ind);
                } 
            }
            Console.WriteLine("3. get Keys on dictionary with different_in_casing_only values ");
            strLoc = "Loc_003oo"; 
            iCountTestcases++;
            ld.Clear();
            string intlStr = intl.GetString(MAX_LEN, true, true, true);
            ld.Add("keykey", intlStr);        
            for (int i = 0; i < len; i++) 
            {
                ld.Add(keys[i], values[i]);
            }
            ld.Add("keyKey", intlStr);        
            if (ld.Count != len+2) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0003a, count is {0} instead of {1}", ld.Count, len+2);
            } 
            iCountTestcases++;
            ks = ld.Keys;
            if (ks.Count != ld.Count) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0003b, returned Keys.Count = {0}", ks.Count);
            }
            arr = Array.CreateInstance(typeof(Object), len+2);
            ks.CopyTo(arr, 0);
            for (int i = 0; i < len; i++) 
            {
                iCountTestcases++;
                ind = Array.IndexOf(arr, keys[i]);
                if (ind < 0) 
                {
                    iCountErrors++;
                    Console.WriteLine("Err_0003c_{0}, Keys doesn't contain \"{1}\" key", i, keys[i]);
                } 
            }
            iCountTestcases++;
            ind = Array.IndexOf(arr, "keykey");
            if (ind < 0) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0003c, Keys doesn't contain {0} key", "keykey");
            } 
            iCountTestcases++;
            ind = Array.IndexOf(arr, "keyKey");
            if (ind < 0) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0003c, Keys doesn't contain \"{0}\" key", "keyKey");
            } 
            Console.WriteLine("4. get Keys for dictionary with intl strings");
            strLoc = "Loc_004oo"; 
            string [] intlValues = new string [len*2];
            for (int i = 0; i < len*2; i++) 
            {
                string val = intl.GetString(MAX_LEN, true, true, true);
                while (Array.IndexOf(intlValues, val) != -1 )
                    val = intl.GetString(MAX_LEN, true, true, true);
                intlValues[i] = val;
            } 
            ld.Clear();
            for (int i = 0; i < len; i++) 
            {
                ld.Add(intlValues[i+len], intlValues[i]);
            }
            if (ld.Count != len) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0004a, count is {0} instead of {1}", ld.Count, len);
            }
            ks = ld.Keys;
            if (ks.Count != len) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0004b, returned Keys.Count = {0}", ks.Count);
            }
            arr = Array.CreateInstance(typeof(Object), len);
            ks.CopyTo(arr, 0);
            for (int i = 0; i < arr.Length; i++) 
            {
                iCountTestcases++;
                ind = Array.IndexOf(arr, intlValues[i+len]);
                if (ind < 0) 
                {
                    iCountErrors++;
                    Console.WriteLine("Err_0004c_{0}, Keys doesn't contain \"{1}\" key", i, intlValues[i+len]);
                } 
            }
            Console.WriteLine("5. Change dictinary");
            strLoc = "Loc_005oo"; 
            iCountTestcases++;
            ld.Clear();
            for (int i = 0; i < len; i++) 
            {
                ld.Add(keys[i], values[i]);
            }
            if (ld.Count != len) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0005a, count is {0} instead of {1}", ld.Count, len);
            } 
            ks = ld.Keys;
            if (ks.Count != len) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0005a, returned Keys.Count = {0}", ks.Count);
            }
            Console.WriteLine("     - remove element from the dictionary");
            ld.Remove(keys[0]);
            if (ld.Count != len-1) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0005b, didn't remove element");
            } 
            if (ks.Count != len-1) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0005c, Keys were not updated after removal");
            }
            iCountTestcases++;
            arr = Array.CreateInstance(typeof(Object), ld.Count);
            ks.CopyTo(arr, 0);
            ind = Array.IndexOf(arr, keys[0]);
            if (ind >= 0) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0005d, Keys still contains removed key " + ind);
            } 
            Console.WriteLine("     - add element to the dictionary");
            ld.Add(keys[0], "new item");
            if (ld.Count != len) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0005e, didn't add element");
            } 
            if (ks.Count != len) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0005f, Keys were not updated after addition");
            }
            iCountTestcases++;
            arr = Array.CreateInstance(typeof(Object), ld.Count);
            ks.CopyTo(arr, 0);
            ind = Array.IndexOf(arr, keys[0]);
            if (ind < 0) 
            {
                iCountErrors++;
                Console.WriteLine("Err_0005g, Keys doesn't contain added key ");
            } 
        } 
        catch (Exception exc_general ) 
        {
            ++iCountErrors;
            Console.WriteLine (s_strTFAbbrev + " : Error Err_general!  strLoc=="+ strLoc +", exc_general==\n"+exc_general.ToString());
        }
        if ( iCountErrors == 0 )
        {
            Console.WriteLine( "Pass.   "+s_strTFPath +" "+s_strTFName+" ,iCountTestcases=="+iCountTestcases);
            return true;
        }
        else
        {
            Console.WriteLine("Fail!   "+s_strTFPath+" "+s_strTFName+" ,iCountErrors=="+iCountErrors+" , BugNums?: "+s_strActiveBugNums );
            return false;
        }
    }
    void printArr(Array ar) 
    {
        string temp = "";
        for (int i = 0; i < ar.Length; i++) 
        {
            temp += System.Environment.NewLine + ar.GetValue(i).ToString();
        }
        Console.WriteLine(temp);
    }
    public static void Main(String[] args)
    {
        bool bResult = false;
        Co8696get_Keys cbA = new Co8696get_Keys();
        try 
        {
            bResult = cbA.runTest();
        } 
        catch (Exception exc_main)
        {
            bResult = false;
            Console.WriteLine(s_strTFAbbrev + " : Fail! Error Err_main! Uncaught Exception in main(), exc_main=="+exc_main);
        }
        if (!bResult)
        {
            Console.WriteLine ("Path: "+s_strTFName + s_strTFPath);
            Console.WriteLine( " " );
            Console.WriteLine( "Fail!  "+ s_strTFAbbrev);
            Console.WriteLine( " " );
        }
        if (bResult) Environment.ExitCode=0; else Environment.ExitCode=1;
    }
}
