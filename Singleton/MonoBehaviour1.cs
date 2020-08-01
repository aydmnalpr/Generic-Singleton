using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
// The instance. This property only has a getter, which means // that other parts of the code won't be able to modify it.
    public static T instance {
    get {
// If we don't have an instance ready, get one by // either finding it in the scene, or creating one
    if (_instance == null) {
        _instance = FindOrCreateInstance(); }
    return _instance; }
}
// This variable stores the actual instance. It's private, and // can only be accessed through the 'instance' property above.
private static T _instance;
// Attempts to find an instance of this singleton. If one can't // be found, a new one is created.
private static T FindOrCreateInstance() {
// Attempt to locate an instance.
var instance = GameObject.FindObjectOfType<T>();
    if (instance != null) {
// We found one. Return it; it will be used // as the shared instance.
    return instance;
}
// Script components can only exist when they're // attached to a game object, so to create this // instance, we'll create a new game object, and // attach the new component.
// Figure out what to name the singleton
var name = typeof(T).Name + " Singleton";
// Create the container game object with that name
var containerGameObject = new GameObject(name);
// Create and attach a new instance of whatever 'T' is; // we'll return this new instance
var singletonComponent =
    containerGameObject.AddComponent<T>(); return singletonComponent;
} }

//Test
public class MoverManager : Singleton<MoverManager> {
    public void ManageMovers() { Debug.Log("Doing some useful work!");
    } }