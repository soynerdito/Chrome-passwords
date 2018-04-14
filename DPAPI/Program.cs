using System;
//using System.Reflection;

public class Chrome
{

    //static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    //{
    //    return EmbeddedAssembly.Get(args.Name);
    //}


    static void Main(string[] args)
    {
        //Load assemblies
        //string resource1 = "DPAPI.System.Data.SQLite.DLL";
        //EmbeddedAssembly.Load(resource1, "System.Data.SQLite.dll");

        //AppDomain currentDomain = AppDomain.CurrentDomain;
        //currentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

        ProgramCode.LetsDothis(args);
    }

}