{
    "PresetName": "Script: Words",
    "PasswordLength": 6,
    "UseUppercase": true,
    "RatioUppercase": 1,
	"UseLowercase": true,
	"RatioLowercase": 1,
	"UseNumbers": false,
	"RatioNumbers": 1,
	"UseSymbols": false,
	"RatioSymbols": 1,
	"FilterRemember": false,
    "ScriptEnabled": true,
    "ScriptLanguage": "CSharp",
    "ScriptEntry": "Class1.Main",
    "ScriptCode": "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing JocysCom.Password.Generator;\r\nusing JocysCom.ClassLibrary.Security.Password;\r\n\r\nnamespace Scripts\r\n{\r\n    public partial class Class1\r\n    {\r\n        public string Main(Generator generator, Word password)\r\n        {\r\n            var adjective = PassGenHelper.GetRandom(PassGenHelper.Adjectives, generator);\r\n            var noun = PassGenHelper.GetRandom(PassGenHelper.Nouns, generator);\r\n            var verb = PassGenHelper.GetRandom(PassGenHelper.Verbs, generator);\r\n            var adverb = PassGenHelper.GetRandom(PassGenHelper.Adverbs, generator);\r\n            var words = string.Format(\"{0}{1}{2}{3}\", adjective, noun, verb, adverb);\r\n            if (generator.Preset.UseSymbols)\r\n                words = PassGenHelper.Replace(words, generator.Preset.RatioSymbols, \"[S]\", \"$\");\r\n            if (generator.Preset.UseNumbers)\r\n                words = PassGenHelper.Replace(words, generator.Preset.RatioNumbers, \"[O|o]\",\"0\");\r\n            return words;\r\n        }\r\n    }\r\n}"
}
