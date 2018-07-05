{
    "PresetName": "Script: Words",
    "PasswordLength": 6,
    "UseUppercase": true,
    "RatioUppercase": 1,
    "FilterRemember": true,
    "ScriptEnabled": true,
    "ScriptLanguage": "CSharp",
    "ScriptEntry": "Class1.Main",
    "ScriptCode": "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing JocysCom.Password.Generator;\r\nusing JocysCom.ClassLibrary.Security.Password;\r\n\r\nnamespace Scripts\r\n{\r\n    public partial class Class1\r\n    {\r\n        public string Main(Generator generator, Word password)\r\n        {\r\n            var adjective = PassGenHelper.GetRandom(PassGenHelper.Adjectives);\r\n        var noun = PassGenHelper.GetRandom(PassGenHelper.Nouns);\r\n        var verb = PassGenHelper.GetRandom(PassGenHelper.Verbs);\r\n        var adverb = PassGenHelper.GetRandom(PassGenHelper.Adverbs);\r\n        var words = string.Format(\"{0}{1}{2}{3}\", adjective, noun, verb, adverb);\r\n            return words;\r\n        }\r\n    }\r\n}\r\n"
}
