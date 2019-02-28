using System.Collections.Generic;
using System;

namespace ConsoleClient.CommandHandlers.Utilites {
    public class CommandUtility {

        public static Dictionary<string, string> ParseArguments(string argumentString) {

            Dictionary<string, string> result = new Dictionary<string, string>();

            string[] arguments = argumentString.Split(' ');

            string key = "";
            string value = "";

            if (String.IsNullOrEmpty(arguments[0])) { return result; }

            for (int i = 0; i < arguments.Length; i++) {
                key = null;
                value = null;
                if (arguments[i].StartsWith("-") || i == 0) {
                    if (!arguments[i].StartsWith("-") && i == 0 && !result.ContainsKey("arg")) {
                        key = "arg";
                        i = i - 1;
                    } else {
                        key = arguments[i].Remove(0, 1);
                    }
                    
                    string parsedValue = "";
                    for (int j = i + 1; j < arguments.Length; j++) {
                        if (!arguments[j].StartsWith("-")) {
                            parsedValue += arguments[j] + " ";
                        } else {
                            i = j - 1;
                            break;
                        }
                    }
                    
                    if (parsedValue.Length > 0) {
                        value = parsedValue.Remove(parsedValue.Length - 1);
                    }

                    result.Add(key, value);
                }
            }

            return result;
        }

    }
}