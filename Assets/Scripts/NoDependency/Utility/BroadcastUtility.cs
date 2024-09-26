using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BroadcastUtility
{
	public static void BroadcastCommandTokens(string commands, string tokenStart, string tokenEnd)
	{
		KeyValuePair<System.Type, object> pair = new KeyValuePair<System.Type, object>(typeof(BroadcastUtility), null);
		int tokenStartIndex = commands.IndexOf(tokenStart);
		int tokenEndIndex = commands.IndexOf(tokenEnd);
		if (tokenEndIndex > tokenStartIndex) {
			string token = commands.Substring(tokenStartIndex + 1, tokenEndIndex - tokenStartIndex - 1);
			Base.Call(token, typeof(Base), pair);

			BroadcastCommandTokens(commands.Substring(tokenEndIndex + 1), tokenStart, tokenEnd);
		}
	}

	public static void BroadcastCommandTokens(string commands, string tokenStart = "[", string tokenEnd = "]", string parameterSeparator = "|")
	{
		KeyValuePair<System.Type, object> pair = new KeyValuePair<System.Type, object>(typeof(BroadcastUtility), null);
		int tokenStartIndex = commands.IndexOf(tokenStart);
		int tokenEndIndex = commands.IndexOf(tokenEnd);
		if (tokenEndIndex > tokenStartIndex) {
			string token = commands.Substring(tokenStartIndex + 1, tokenEndIndex - tokenStartIndex - 1);
			int parameterSeparatorIndex = token.IndexOf(parameterSeparator);
			if (parameterSeparatorIndex != -1) {
				string cmd = token.Substring(0, parameterSeparatorIndex);
				string parameter = token.Substring(parameterSeparatorIndex + 1);
				Base.Call(cmd, typeof(Base), pair, parameter);
			} else {
				Base.Call(token, typeof(Base), pair);
			}

			BroadcastCommandTokens(commands.Substring(tokenEndIndex + 1), tokenStart, tokenEnd, parameterSeparator);
		}
	}

	public static List<string> FindCommandTokens(string text, string tokenStart = "[", string tokenEnd = "]", string parameterSeparator = "|")
	{
		List<string> tokens = new List<string>();
		string commands = text;
		int tokenStartIndex = commands.IndexOf(tokenStart);
		if(tokenStartIndex < 0) {
			return tokens;
		}
		int tokenEndIndex = commands.IndexOf(tokenEnd);
		if (tokenEndIndex > tokenStartIndex) {
			string token = commands.Substring(tokenStartIndex, tokenEndIndex - tokenStartIndex +1);
			tokens.Add(token);

			text = text.Remove(tokenStartIndex, token.Length);
			tokens.AddRange(FindCommandTokens(text, tokenStart, tokenEnd, parameterSeparator));
		}

		return tokens;
	}

	public static string BroadcastAndRemoveCommandTokens(string displayedDescription)
	{
		string removedDescription = displayedDescription;
		List<string> tokens = FindCommandTokens(displayedDescription);
		foreach(string token in tokens) {
			BroadcastCommandTokens(token);
			removedDescription = removedDescription.Replace(token, "");
		}

		return removedDescription;
	}
}
