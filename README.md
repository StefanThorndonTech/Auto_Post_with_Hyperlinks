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

