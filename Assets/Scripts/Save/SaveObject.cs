using UnityEngine;
using System.Collections;

public class SaveObject  {
    public int id = 0;
    public bool headgear = false;
    public bool buff = false;
    public bool eyewear = false;
    public bool male = false;
    public int stagelocked = 1;
    public int levelonstage = 1;
    public string name = string.Empty;
    public float health = 1;
    public int level = 1;
    public float experience { get; set; }
}
