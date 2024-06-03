# Auto Post With HyperLinks
This project can be used to create a link that can be used within the text value of a post object. 

## Setup 
An Action needs to be defined within the Power Platform, the action should have the following parameters. All paramterse defined should be set to required and are all string parameters.
>[!IMPORTANT]
>The Action should be unbound.

| Parameter Name | Direction | Description |
|--|--|--|
|LinkText | In | The text that will be displayed to the user in the link |
|TableName| In | The logical name of the table that the link will be used to access | 
|RowId | In | The Id of the Dataverse Row that the link will navigate to | 
|PostLink| Out | The return value, containing the link, that will be used in Post Row |

e.g.
<img width="1437" alt="Screenshot 2024-06-03 at 12 46 27 PM" src="https://github.com/StefanThorndonTech/Auto_Post_with_Hyperlinks/assets/91337126/376697f3-826a-4f96-91ea-4c501a1011d0">
The name of the action will not matter much as you will be calling it from Power Automate.

You will also need to import the plugin package into D365. Once Registered, you will need to register a plugin step on the action. 
>[!IMPORTANT]
>The Plugin Step Image must be registered on the Post Operation plugin pipeline. Otherwise the output value will not be set and the PostLink Output Argument will always be set to null.
>By setting the plugin step Image to Post Opertation, this allows the argument to be set.

Package Registered:
![image](https://github.com/StefanThorndonTech/Auto_Post_with_Hyperlinks/assets/91337126/ca20ecb1-b1b7-4f3d-a9f0-7d95da2adb0d)

Plugin Step Image Registration:
![image](https://github.com/StefanThorndonTech/Auto_Post_with_Hyperlinks/assets/91337126/b19a32d1-1a20-4354-a67f-9f005908602a)

It is then possible to call the action within a Power Automate to create the link and to use it within a create record action
![image](https://github.com/StefanThorndonTech/Auto_Post_with_Hyperlinks/assets/91337126/8bbe4cf0-8477-40dc-b5f4-74f2930c5a13)

This will produce the following output in the D365 Organisation
![image](https://github.com/StefanThorndonTech/Auto_Post_with_Hyperlinks/assets/91337126/827af8b3-8f48-4ec9-b4d7-ec2402415190)
