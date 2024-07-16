using UnityEngine;
using System;
using System.Collections.Generic;

public static class JsonPlayerPrefs
{
    // Save a serializable object as JSON string
    public static void SetObject<T>(string key, T value)
    {
        string json = JsonUtility.ToJson(value);
        PlayerPrefs.SetString(key, json);
    }

    // Load a JSON string and deserialize it to an object
    public static T GetObject<T>(string key, T defaultValue = default(T))
    {
        if (PlayerPrefs.HasKey(key))
        {
            string json = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(json);
        }
        return defaultValue;
    }

    // Save a list of serializable objects as JSON string
    public static void SetList<T>(string key, List<T> list)
    {
        string json = JsonHelper.ToJson(list.ToArray());
        PlayerPrefs.SetString(key, json);
    }

    // Load a JSON string and deserialize it to a list of objects
    public static List<T> GetList<T>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string json = PlayerPrefs.GetString(key);
            T[] array = JsonHelper.FromJson<T>(json);
            return new List<T>(array);
        }
        return new List<T>();
    }

    // Check if a key exists
    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    // Remove a key
    public static void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    // Clear all keys
    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    // Save all changes to disk
    public static void Save()
    {
        PlayerPrefs.Save();
    }
}

public static class JsonHelper
{
    // Wrapper class to hold the array
    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }

    // Convert an array to JSON string
    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T> { Items = array };
        return JsonUtility.ToJson(wrapper);
    }

    // Convert JSON string to an array
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }
}
