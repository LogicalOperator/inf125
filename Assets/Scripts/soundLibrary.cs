using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class soundLibrary : MonoBehaviour {

    public soundGroup[] soundGroups;

    Dictionary<string, AudioClip[]> groupDictionary = new Dictionary<string, AudioClip[]>(); //dictionary of all sounds


    void Awake()
    {
        foreach(soundGroup aGroup in soundGroups)
        {
            groupDictionary.Add(aGroup.groupID, aGroup.group);
        }

    }
    public AudioClip getClipFromName(string name) //return name of audioclip depending on sound, could be a grp of sounds
    {
        if (groupDictionary.ContainsKey(name))
        {
            AudioClip[] sounds = groupDictionary[name];
            return sounds[Random.Range(0, sounds.Length)];
        }
        return null;
    }

    [System.Serializable]
    public class soundGroup
    {
        public string groupID;
        public AudioClip[] group;
    }
}
