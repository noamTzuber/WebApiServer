# About this project
In this project we implement a server withe **ASP.NET** for chat client that implement before. 
Now all customer communication is done with the server and not with static lists.
We have created an api server that accepts requests and responds in Json format to the customer.
The requests are as required in the assigment, in addition we have added user's field as follows:

http://localhost:1234/api/contacts/{Alice} will return all the contacts of Alice.

The server use **signalR** to tell to the contacts about new changes without the users need to pull update from the server.


![image](https://user-images.githubusercontent.com/71848366/170560165-59b937f3-cc0f-4b7e-9911-3013687b54bc.png)


# Build with
 mvc asp.net
 
 # Libraries we used
 @microsoft/signalr
 
 Microsoft.AspNetCore.Mvc
 
 using Microsoft.AspNetCore.SignalR;


