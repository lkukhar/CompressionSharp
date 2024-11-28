namespace CompressionSharp.Core;

public static class LZW
{
    public static byte[] Compress(string text)
    {
        var dictionary = new Dictionary<string, byte>();
        for (ushort i = 0; i < 256; i++)
        {
            dictionary.Add(((char)i).ToString(), (byte)i);
        }

        var result = new List<byte>();
        var word = string.Empty;
        foreach (var character in text)
        {
            var tempWord = word + character;
            if (dictionary.ContainsKey(tempWord))
            {
                word = tempWord;
            }
            else
            {
                result.Add(dictionary[word]);
                dictionary.Add(tempWord, (byte)dictionary.Count);
                word = character.ToString();
            }
        }

        if (!string.IsNullOrEmpty(word))
        {
            result.Add(dictionary[word]);
        }

        return [.. result];
    }
}
