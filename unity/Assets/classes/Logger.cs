using UnityEngine;
using System.Collections;



 public class Logger
    {
     int _logLevel;
     string name;

     public Logger()
     {
         _logLevel = 9;
         name = "";
         
     }
     public Logger(int level, string name)
     {
         this._logLevel = level;
         this.name = name;
     }

     public void Log(int lvl, string message)
     {
         if (lvl <= _logLevel)
             Debug.Log(Time.time+ "\t" +name+ ":\t"+ message);
     }

     public void LogWarning(string message)
     {
         Debug.LogWarning(Time.time+"\t"+name+":\t"+message);
     }
     public void LogError(string message)
     {
         Debug.LogError(Time.time+"\t"+name+":\t"+message);
     }

     public int logLevel
     {
         get { return _logLevel; }
         set { _logLevel = value; }
     }
    }

