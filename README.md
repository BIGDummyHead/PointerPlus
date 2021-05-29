# Pointer Plus

```csharp
using PointerPlus;
```

#### This was created to help with reading Memory Addresses on the fly and converting them to their managed type and taking managed types and turning them into Pointers and Memory addresses.

#### For example, when trying to turn any managed type into a pointer would be considered an error. There is a simple work around for this using [IntPtr](https://docs.microsoft.com/en-us/dotnet/api/system.intptr?view=net-5.0) and [GcHandle](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.gchandle?view=net-5.0)

#### Managed Type -> Ptr*(unmanaged struct) -> IntPtr -> Managed Type 
#### Managed Type -> IntPtr*(unmanaged struct) -> Managed Type 

#### This project was moved to .Net Core 3.1, this is because of ExactPtr<T> is only available in C# 8.0.

#### This helps recreate the feeling of C++ and using Memory addresses with simplicity. 

________________________________________________________

## Unsafe Pointer

#### In this main example it is shown how to use the [Ptr](https://github.com/BIGDummyHead/PointerHelper/blob/master/PointerHelper/Ptr.cs) structure is used.

![Main Example](https://github.com/BIGDummyHead/PointerPlus/blob/master/ExamplePictures/unsafe_Pointer.png)

## Memory

#### See this next example:

![Mem](https://github.com/BIGDummyHead/PointerPlus/blob/master/ExamplePictures/memExample.png)

## Ptr Structure

#### Please take a look at the Ptr structure.

![ptrex](https://github.com/BIGDummyHead/PointerPlus/blob/master/ExamplePictures/ptrExample.png)


## Ptr : [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-5.0)

![disposable pic](https://github.com/BIGDummyHead/PointerPlus/blob/master/ExamplePictures/idispose.png)

## ExactPtr<T> : [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-5.0)
  
#### I realized that you may easily forget what Type your Ptr may be. So this allows you to directly set the T.
#### This is different from Ptr because it may be only switched back to a T by using the 'Back' method seen below.
  
![exact_pic](https://github.com/BIGDummyHead/PointerPlus/blob/master/ExamplePictures/exact.png)

# Dependencies

#### The example pictures were made on [Carbon](https://carbon.now.sh/)

#### No other dependencies were used.

________________________________________________
