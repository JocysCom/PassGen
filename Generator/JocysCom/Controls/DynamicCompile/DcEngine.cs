// This program is for DynamicCompileAndRun
// "CreateAssembly()" and "CallEntry()" are from jconwell, see http://www.codeproject.com/dotnet/DotNetScript.asp
// dstang2000@263.net    2004.3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System.CodeDom;
using System.IO;

namespace JocysCom.ClassLibrary.Controls.DynamicCompile
{
	public partial class DcEngine
	{
		public DcEngine(string code)
		{
			SourceCode = code;
		}

		public DcEngine(string code, LanguageType language, string entry)
		{
			SourceCode = code;
			Language = language;
			EntryPoint = entry;
		}

		private BindingFlags flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;

		public string[] GetEntryPoints(bool includePrivate = false)
		{
			List<string> list = new List<string>();
			Assembly assembly = GetAssembly();
			if (assembly == null) return list.ToArray();
			Module[] mods = assembly.GetModules(false);
			if (mods.Length == 0) return list.ToArray();
			Type[] types = includePrivate
				? mods[0].GetTypes().Where(x => x.IsClass).ToArray()
				: mods[0].GetTypes().Where(x => x.IsClass && x.IsPublic).ToArray();
			if (Language == LanguageType.JScript)
			{
				types = types.Where(x => x.Name != "JScript 0").ToArray();
			}
			foreach (Type type in types)
			{
				MethodInfo[] methods = type.GetMethods(flags);
				foreach (var method in methods)
				{
					list.Add(string.Format("{0}.{1}", type.Name, method.Name));
				}
			}
			return list.ToArray();
		}

		public Assembly CurrentAssembly;

		public object Run(params object[] parameters)
		{
			ClearErrMsgs();
			string strRealSourceCode = PrepareRealSourceCode();
			if (CurrentAssembly == null) CurrentAssembly = CreateAssembly(strRealSourceCode);
			object results = CallEntry(CurrentAssembly, EntryPoint, parameters);
			//DisplayErrorMsg();
			return results;
		}

		public Assembly GetAssembly()
		{
			string strRealSourceCode = PrepareRealSourceCode();
			Assembly assembly = CreateAssembly(strRealSourceCode);
			return assembly;
		}

		//Holds the main source code that will be dynamically compiled and executed
		internal string SourceCode = string.Empty;

		//Holds the method name that will act as the assembly entry point
		internal string EntryPoint = "Main";

		//A list of all assemblies that are referenced by the created assembly
		internal ArrayList References = new ArrayList();

		//A flag the determines if console window should remain open until user clicks enter
		internal bool WaitForUserAction = true;

		//Flag that determines which language to use
		internal LanguageType Language = LanguageType.CSharp;


		// prepare the source code
		private string PrepareRealSourceCode()
		{

			string strRealSourceCode = "";

			// add some using(Imports) statements
			string strUsingStatement = "";

			if (Language == LanguageType.VB)
			{
				string[] basicImportsStatement = {
							"Imports Microsoft.VisualBasic",
							"Imports System",
							"Imports System.Windows.Forms",
							"Imports System.Drawing",
							"Imports System.Data",
							"Imports System.Threading",
							"Imports System.Xml",
							"Imports System.Collections",
							"Imports System.Diagnostics",
				};
				foreach (string si in basicImportsStatement)
				{
					if (SourceCode.IndexOf(si) < 0)
						strUsingStatement += si + "\r\n";
				}
			}

			strRealSourceCode = strUsingStatement + SourceCode;

			// for VB Prog, Add Main(), So We Can Run It
			if (Language == LanguageType.VB && EntryPoint == "Main" &&
				strRealSourceCode.IndexOf("Sub Main(") < 0)
			{
				try
				{
					int posClass = strRealSourceCode.IndexOf("Public Class ") + "Public Class ".Length;
					int posClassEnd = strRealSourceCode.IndexOf("\r\n", posClass);
					string className = strRealSourceCode.Substring(posClass, posClassEnd - posClass);
					int pos = strRealSourceCode.LastIndexOf("End Class");
					if (pos > 0)
						strRealSourceCode = strRealSourceCode.Substring(0, pos) + @"
										Private Shared Sub Main()
											" + "Dim frm As New " + className + "()" + @"
													If TypeOf frm Is Form Then frm.ShowDialog()
										End Sub
									" + strRealSourceCode.Substring(pos);
				}
				catch { }
			}

			return strRealSourceCode;

		}

		// compile the source, and create assembly in memory
		// this method code is mainly from jconwell, 
		// see http://www.codeproject.com/dotnet/DotNetScript.asp
		private Assembly CreateAssembly(string sourceCode)
		{
			if (sourceCode.Length == 0)
			{
				LogErrMsgs("Error:  There was no CS script code to compile");
				return null;
			}

			//Create an instance whichever code provider that is needed
			CodeDomProvider codeProvider = null;
			switch (Language)
			{
				case LanguageType.CSharp:
					codeProvider = new CSharpCodeProvider(); // new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } }
					break;
				case LanguageType.VB:
					codeProvider = new VBCodeProvider();
					break;
				case LanguageType.JScript:
					codeProvider = new Microsoft.JScript.JScriptCodeProvider();
					//             provider = (CodeDomProvider)Activator.CreateInstance(
					//"Microsoft.JScript",
					//"Microsoft.JScript.JScriptCodeProvider").Unwrap();
					break;
				default:
					break;
			}

			CompilerResults ResultsLog;

			//create the language specific code compiler
			//ICodeCompiler compiler = codeProvider.CreateCompiler();

			//add compiler parameters
			CompilerParameters compilerParams = new CompilerParameters();
			if (Language == LanguageType.CSharp || Language == LanguageType.VB)
			{
				compilerParams.CompilerOptions = "/target:library"; // you can add /optimize
																	//compilerParams.CompilerOptions += @" /lib:""C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5\""";
				compilerParams.CompilerOptions += " /errorreport:prompt";
				// Load assemblies (DLL files).
				AssemblyName[] refs = Assembly.GetEntryAssembly().GetReferencedAssemblies();
				for (int a = 0; a < refs.Length; a++)
				{
					if (refs[a].Name == "mscorlib") continue;
					Assembly refAssembly = Assembly.Load(refs[a].FullName);
					compilerParams.CompilerOptions += string.Format(@" /reference:""{0}""", refAssembly.Location);
				}
				compilerParams.CompilerOptions += " /debug+";
				compilerParams.CompilerOptions += " /debug:full";
				compilerParams.CompilerOptions += " /filealign:512";
				compilerParams.CompilerOptions += " /optimize-";
			}
			if (Language == LanguageType.VB)
			{
				compilerParams.CompilerOptions += " /define:DEBUG";
			}
			if (Language == LanguageType.CSharp)
			{
				compilerParams.CompilerOptions += " /define:DEBUG;TRACE";
				compilerParams.CompilerOptions += " /warn:4";
				//compilerParams.CompilerOptions += " /noconfig";
				compilerParams.CompilerOptions += " /nowarn:1701,1702";
			}

			compilerParams.GenerateExecutable = false;
			compilerParams.GenerateInMemory = true;
			compilerParams.IncludeDebugInformation = true;

			if (Language == LanguageType.VB)
			{
				compilerParams.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll");
			}
			// http://www.codeproject.com/KB/dotnet/nscript.aspx
			if (Language == LanguageType.JScript)
			{
				compilerParams.ReferencedAssemblies.Add("Microsoft.JScript.dll");
			}
			// Add any additional references needed.
			foreach (string refAssembly in References)
			{
				try
				{
					compilerParams.ReferencedAssemblies.Add(refAssembly);
				}
				catch { }
			}
			// Compile the code.
			ResultsLog = codeProvider.CompileAssemblyFromSource(compilerParams, sourceCode);
			// If compiling resulted in errors then...
			if (ResultsLog.Errors.Count > 0)
			{
				foreach (CompilerError error in ResultsLog.Errors)
				{
					LogErrMsgs("Compile Error:  " + error.ToString());
				}
				return null;
			}
			// Get a hold of the actual assembly that was generated.
			Assembly generatedAssembly = ResultsLog.CompiledAssembly;
			return generatedAssembly;
		}

		// invoke the entry method
		// this method code is mainly from jconwell, 
		// see http://www.codeproject.com/dotnet/DotNetScript.asp
		private object CallEntry(Assembly assembly, string entryPoint, object[] parameters)
		{
			string[] entry = entryPoint.Split('.');
			if (entry.Length != 2) return null;
			string className = entry[0];
			string methodName = entry[1];
			object results = null;
			try
			{
				//Use reflection to call the static Main function
				Module[] mods = assembly.GetModules(false);
				Type[] types = mods[0].GetTypes().Where(x => x.Name == className).ToArray();
				foreach (Type type in types)
				{
					MethodInfo mi = type.GetMethod(methodName, flags);
					if (mi != null)
					{
						//if (mi.GetParameters().Length == 1)
						//{
						//	if (mi.GetParameters()[0].ParameterType.IsArray)
						//	{
						//		parameters = new string[1]; // if Main has string [] arguments
						//	}
						//}
						object instance = Activator.CreateInstance(type);
						if (mi.GetParameters().Count() > 0)
						{
							results = mi.Invoke(instance, parameters);
						}
						else
						{
							results = mi.Invoke(instance, null);
						}
						//Type jsType = engine.GetAssembly().GetType("JSSample");
						//results = type.InvokeMember(entryPoint, flags, null, instance, null);
						//results = type.InvokeMember(entryPoint, flags, null, instance, null);
						return results;
					}
				}
				LogErrMsgs("Engine could not find the public static " + entryPoint);
			}
			catch (Exception ex)
			{
				LogErrMsgs("Error:  An exception occurred", ex);
			}
			return results;
		}

		public StringBuilder ErrorsLog = new StringBuilder();
		internal void LogErrMsgs(string customMsg)
		{
			LogErrMsgs(customMsg, null);
		}

		internal void LogErrMsgs(string customMsg, Exception ex)
		{
			//put the error message into builder
			ErrorsLog.Append("\r\n").Append(customMsg).Append("\r\n");
			//get all the exceptions and add their error messages
			while (ex != null)
			{
				ErrorsLog.Append("\t").Append(ex.ToString()).Append("\r\n");
				ex = ex.InnerException;
			}
		}

		internal void ClearErrMsgs()
		{
			ErrorsLog.Remove(0, ErrorsLog.Length);
		}

	}
}
