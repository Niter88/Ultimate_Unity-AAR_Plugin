package br.com.manp.libaartest;

public abstract class JavaToCSInterface {

    //instance will keep an reference to the JavaToCSReceiver.java, this way you can send stuff to unity
    public static JavaToCSInterface instance; //don't remove this

    public static int testNumber = 5; //just for testing

    //constructor
    public JavaToCSInterface(){
        instance = this;
    }

    //sends a message to Unity. The String data will be intercepted on the method method inside object GameObject.
    //object is the GameObject's name, also the Class name. method is the method you'll call. data is the data you'll send
    public abstract void UnitySendMessage(String object, String method, String data);
}
