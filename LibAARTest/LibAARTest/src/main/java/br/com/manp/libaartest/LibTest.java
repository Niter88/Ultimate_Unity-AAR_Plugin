package br.com.manp.libaartest;



public class LibTest {

    //instances and references
    public static LibTest instance;
    public static JavaToCSInterface javaToCSSender;

    //static variables
    public static String testString = "";
    public static int counter = 0;
    public static int testNum = 0;

    //object variables (not static)
    public String textObj = "object string non static";

    //Unity call this in order to keep a reference of the JavaToCSReceiver
    //you can use it to inicialize anything
    public static void setInstance(JavaToCSInterface javaToCSReceiver){
        instance = new LibTest();
        javaToCSSender = javaToCSReceiver;
    }

    public static void sendAStringToJava(String data){
        counter++;
        testString = counter + data;
    }

    public static String getStringMessage(){
        return testString;
    }

    public String getTextObj(){
        return textObj;
    }

    //when called sends messages to Unity
    public static void sendMessagesToUnity(){
        //check the UnitySendMessage methods comments
        javaToCSSender.UnitySendMessage("Integration", "ReceiveMessageFromAndroid", "This is a message sent from Android");
        javaToCSSender.UnitySendMessage("Integration", "ReceiveMessageFromAndroid", "This message was also sent from Android");
        javaToCSSender.UnitySendMessage("Integration", "ReceiveMessageFromAndroid", "Also this one, you got it");
    }
}
