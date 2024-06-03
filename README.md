# Auto Post With HyperLinks
This project can be used to create a link that can be used within the text value of a post object. 

## Setup 
An Action needs to be defined within the Power Platform, the action should have the following parameters. All paramterse defined should be set to required and are all string parameters
| Parameter Name | Direction | Description |
|--|--|--|
|LinkText | In | The text that will be displayed to the user in the link |
|TableName| In | The logical name of the table that the link will be used to access | 
|RowId | In | The Id of the Dataverse Row that the link will navigate to | 
|PostLink| Out | The return value, containing the link, that will be used in Post Row |
