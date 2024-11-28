using System.Text;

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

    public static string Decompress(IEnumerable<byte> compressed)
    {
        var compressedList = compressed.ToList();
        var dictionary = new Dictionary<byte, string>();
        for (ushort i = 0; i < 256; i++)
        {
            dictionary.Add((byte)i, ((char)i).ToString());
        }

        string w = dictionary[compressedList[0]];
        compressedList.RemoveAt(0);
        StringBuilder decompressed = new(w);

        foreach (byte k in compressed)
        {
            string entry = null;
            if (dictionary.ContainsKey(k))
                entry = dictionary[k];
            else if (k == dictionary.Count)
                entry = w + w[0];

            decompressed.Append(entry);

            // new sequence; add it to the dictionary
            dictionary.Add((byte)dictionary.Count, w + entry[0]);

            w = entry;
        }

        return decompressed.ToString();
    }
}
