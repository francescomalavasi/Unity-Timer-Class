using UnityEngine;

public class Timer
{
    public float lastTimeCalled = new();
    public float interruptTime; 
    public bool isGoing = false;
    public bool hasInterrupted;
    public float duration;
    public float expirationTime;
    public float ExpirationTime                                     //set the expiration time the HasExpired proprety refers to
    {
        set
        {
            expirationTime = Time.time+value;
        }
        get
        {
            return expirationTime-Time.time;
        }
    }
    public float Elapsed                                            //the time elapsed between the time the method has been called and the start method  
    {
        get
        {
            return Time.time - lastTimeCalled;
        }
    }
    public bool HasExpired                                          //returns true if the time elapsed is larger than the expiration one
    {
        get
        {
            if(isGoing)
            {
                return (Elapsed+lastTimeCalled)>expirationTime;     //not directly Time.time because there's the option to speed the timer up
            }
            return false;
        }
    }
    /*public float Completion
    {
        get
        {
            return (expirationTime-Time.time)/(expirationTime-lastTimeCalled);
        }
    }*/
    public void Start()                 //Start the timers, the timer does not start on his own upon declaring!!!
    {
        expirationTime = Time.time + duration;
        lastTimeCalled = Time.time;
        isGoing = true;
    }
    public float Stop()                 //Stop timer, the timer will reset on Start()
    {
        if (isGoing)
        {
            isGoing = false;
            return Time.time - lastTimeCalled;
        }
        else
        {
            //Debug.Log("Timer's not going!");
            return 0;
        }
    }
    public bool HasPassed(float num)       //returns true if the time elapsed is larger than the one specified as an argument
    {
        return lastTimeCalled+num<Time.time;
    }
    public float Interrupt()            //temporarly interrupt the timer, the timer will continue on Start()  
    {
        if (!isGoing)
        {
            //Debug.Log("Timer's not going!");
            return 0;
        }
        else
        {
            hasInterrupted = true;
            interruptTime = Time.time - lastTimeCalled;
            return interruptTime;
        }
    }
    public void AddValue(float val)     //speed the timer up
    {
        lastTimeCalled -= val;
    }

    public Timer(float time)
    {
        duration = time;
    }

    public Timer(){}
}

