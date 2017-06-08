**CRM Web API Specification Doc**** **

08.06.2016

**─**

BetConstruct Coding Bootcamp team Bet-C

Tigran Vardanyan, Lusine Hovsepyan, Siranush Aslanyan, Sargis Chilingaryan, Hovannes Nalbandyan

Microsoft Innovation Center Armenia 

State Engineering University of Armenia, Building #10, 6th Floor

Yerevan

# **Index**

**Registration Authentication**

* **[Registration(Adds admin**)](#bookmark=kix.7m7xmrnpfia7)

* **[Login (Authenticates the user with the system and gives token**)](#bookmark=kix.y8i3au6fkpwb)

**Contacts**** **

* **[Get (returns all contacts from database**)](#bookmark=kix.88gl7uv8nli4)

* **[Get By GuId  (returns specific contact and mailing lists of that contact**)](#bookmark=kix.no5hxfwx2ncc)

* **[Put  (updates specific contact by GuId**)](#bookmark=kix.87symi1pt30s)

* **[Post (creates new contact**)](#bookmark=kix.uk0zmppuc007)

* **[Delete (deletes contact by GuId**)](#bookmark=kix.5o73r2ikxxbm)

* **[Delete (deletes contact by GuId list**)](#bookmark=kix.bmil1mrda9te)

* **[Post (uploads contacts from Excel or CSV file to database**)](#bookmark=kix.262tylozxcap)

* **Post (returns contacts by paiges filtered and ordered by specific fields)**

**Email Lists**** **

* **[Get (returns all email lists from database**)](#bookmark=kix.r5ci25iwn2rs)

* **[Get By Id  (returns specific email list and contacts of that list**)](#bookmark=kix.smq51v4rbm8l)

* **[Put  (updates specific email list contacts**)](#bookmark=kix.ex7n35k1157i)

* **[Put  (updates specific email list**)](#bookmark=kix.r9iddduloj27)

* **[Post (creates new email list**)](#bookmark=kix.vu1nyb4xm30q)

* **[Delete (deletes email list by Id**)](#bookmark=kix.j2vs7yn0mpmx)

**Send Email**

* **[Post (sends emails to contacts by contacts guid list, and template id**)](#bookmark=kix.h0g1lcm7nsa)

* **[Post (sends emails to contacts by email list id and template id**)](#bookmark=kix.urpjjqugmy8r)

**Email Templates**

* **[Get(returns all templates from database**)](#bookmark=kix.a42gazhygdq9)


## **1 Registration/Authentication**

**1.1 Post (Registration)**

Adds new admin

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Post</td>
    <td>http://crmbetc.azurewebsites.net/api/Account/Register</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>Post_Body_Param</td>
    <td>{
  "Email": "tigran_vardanuan@yahoo.com",
  "UserName": "tigran",
  "Password": "123456789pass",
  "ConfirmPassword": "123456789pass"
}</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status Code</td>
    <td>Response Body</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td>Admin created successfully</td>
  </tr>
  <tr>
    <td>400 Bad Request </td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td></td>
  </tr>
</table>


**1.2 Post(Authentication)**

Authenticates the user with the system and gives token

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Post</td>
    <td>http://crmbetc.azurewebsitesnet/token</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Param name</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>Body_urlencoded</td>
    <td>grant_type</td>
    <td>password</td>
  </tr>
  <tr>
    <td>Body_urlencoded</td>
    <td>username</td>
    <td>tigran</td>
  </tr>
  <tr>
    <td>Body_urlencoded</td>
    <td>password</td>
    <td>123456789pass</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status Code</td>
    <td>Response Body</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td> {
  "access_token": "EBEnYF1oI_EmdlRPRGNIbRy3VvkRIUU9JHbiK9V0IUV6wu1m9eeySAx5tKhZSw3ZzYtTXUtDWW4oU3to9sC2KiFd9j8WgRFg9nsGSH6zY1xRfZE--7HkKqtjZiy7-Lr6hu4SH-q7vbGNppOnVPNGvchkUIpC-b6_LiJAoxlVJdxcEWnGFFTwLkZvVQp6AlY-wisIG0M6t1wh8qkRNMZL6xPmd-dtdAUm0ZrVLuHh8P8",
  "token_type": "bearer",
  "expires_in": 86399
}</td>
  </tr>
  <tr>
    <td>400 Bad Request </td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>500  Internal Server Error</td>
    <td></td>
  </tr>
</table>


**Attention!!!**

Required header for all bellow Requests

<table>
  <tr>
    <td>Header Name</td>
    <td>Value -  Bearer token_key</td>
  </tr>
  <tr>
    <td>Authorization</td>
    <td>Bearer QH3izQ8iEPgDjrDSZFnHduwzOQJdHI4ejjUqEdW6h2Nx18uzfvI6Jf_3RE2zoxshh4egfLw6lt2_EjPZEu4aF89y7ztOsk9pETS-SUTBr39YhiMsPntXw6_QQ1mhWcCuizGEZuqW2SVMCw-epBS84VT3MAxLaa9ow4QsO4q7pQflKqzgwts1UVFg1HQEGJUkL5F4lRHV709xeXaZhzanosHeP86XKq804ImJ0P3Xc4w</td>
  </tr>
</table>


## **2 Contacts**

**2.1 Get**

Gets all contacts from database without email lists

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Get</td>
    <td>http://crmbetc.azurewebsitesnet/api/contacts</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status Code</td>
    <td>Response Body</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td>  {
    "Full Name": "Aghasi Lorsabyan",
    "Company Name": "TUMO",
    "Position": "Mentor",
    "Country": "Armenia",
    "Email": "lorsabyan@gmail.com",
    "GuID": "1d8cecd5-2d4c-43c1-bcd1-085664eb6bdc"
  },
  {
    "Full Name": "Siranush Aslanyan",
    "Company Name": "Mic Armenia",
    "Position": "Developer",
    "Country": "Armenia",
    "Email": "siranushik94@gmail.com",
    "GuID": "7d4866ed-4cc1-40c1-a552-ee28f4cacee6"
  }
]</td>
  </tr>
  <tr>
    <td>400 Bad Request </td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td></td>
  </tr>
</table>


**2.2 Get (by guid)**

Gets specific contact by GuId

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Get</td>
    <td>http://crmbetc.azurewebsites.net/api/contacts?guid=1d8cecd5-2d4c-43c1-bcd1-085664eb6bdc</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Param name</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>URL_PARAM </td>
    <td>guid</td>
    <td>dab7e4fb-171f-4e65-8a5a-7640fb113fe5</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td>{
  "Full Name": "Aghasi Lorsabyan",
  "Company Name": "TUMO",
  "Position": "Mentor",
  "Country": "Armenia",
  "Email": "lorsabyan@gmail.com",
  "GuID": "1d8cecd5-2d4c-43c1-bcd1-085664eb6bdc",
  "EmailLists": [
    {
      "EmailListID": 1,
      "EmailListName": "All"
    },
    {
      "EmailListID": 5,
      "EmailListName": "New Year"
    }
  ]
}</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>If in database Contact with such guid is not found </td>
  </tr>
</table>


**2.3 Put (updates contact)**

Updates specific  contact 

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Put</td>
    <td>http://crmbetc.azurewebsites.net/api/contacts</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>Post_Body_Param</td>
    <td>{
  "FullName": "Tatevik Vardanyan",
  "CompanyName": "Mic Armenia",
  "Position": "Developer",
  "Country": "Armenia",
  "Email": "tatevik@gmail.com",
  "GuID": "943d9186-6350-4ecb-a826-048a0306228a",
  "EmailLists": [1, 2]
}
The   "EmailLists":  field is optional and can be ignored in request  (in this case the email lists of contact will not be changed)</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td>{
  "Full Name": "Tatevik Vardanyan",
  "Company Name": "Mic Armenia",
  "Position": "Developer",
  "Country": "Armenia",
  "Email": "tatevik@gmail.com",
  "GuID": "943d9186-6350-4ecb-a826-048a0306228a",
  "EmailLists": {
    "1": "All",
    "2": "VIP Partners"
  }
}</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>If in database Contact with such guid is not found </td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
</table>


**2.4 Post (creates contact)**

Creates new  contact 

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Post</td>
    <td>http://crmbetc.azurewebsites.net/api/contacts</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>Post_Body_Param</td>
    <td>{
  "FullName": "Tatevik Vardanyan",
  "CompanyName": "Mic Armenia",
  "Position": "Developer",
  "Country": "Armenia",
  "Email": "tatevik@gmail.com",
  "EmailLists": [1, 2]
}

The   "EmailLists":  field is optional and can be ignored in request  (in this case the created contact will not be in any email lists)</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td>{
  "Full Name": "Tatevik Vardanyan",
  "Company Name": "Mic Armenia",
  "Position": "Developer",
  "Country": "Armenia",
  "Email": "tatevik@gmail.com",
  "GuID": "edf 30214-9c92-4533-864f-db6baf8a1fe0",
  "EmailLists": {
    "1": "AllSir",
    "2": "VIP Partners"
  }
}</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
</table>


**2.5 Delete (by guid)**

Deletes the specific  contact by GuId

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>DELETE</td>
    <td>http://crmbetc.azurewebsites.net/api/contacts?guid=a1e1ce1c-2c04-494b-add1-340bad88b6e8</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Param name</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>URL_PARAM </td>
    <td>guid</td>
    <td>dab7e4fb-171f-4e65-8a5a-7640fb113fe5</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td></td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>If in database Contact with such guid is not found </td>
  </tr>
</table>


**2.6 Delete (by guid list)**

Deletes the specific  contact by GuId

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>DELETE</td>
    <td>http://crmbetc.azurewebsites.net/api/contacts</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>Delete_Body_Param</td>
    <td>[
"b3e48661-7979-440d-bf33-c8da8ed2cb62,
"dab7e4fb-171f-4e65-8a5a-7640fb113fe5", "e621e4c4-5d33-48de-8b36-2596066e4617",
"B3b91410-6c3b-42e3-b90b-c0ef9298be58"
]</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td></td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>If in database Contact with such guid is not found </td>
  </tr>
</table>


**2.5 Post (file uploading)**

Uploads Excel or CSV file of  contacts into database

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>POST</td>
    <td>http://crmbetc.azurewebsites.net/api/contacts/upload</td>
  </tr>
</table>


<table>
  <tr>
    <td>Example of html to upload file</td>
  </tr>
  <tr>
    <td><form name="form1" method="post" enctype="multipart/form-data" action="http://crmbetc.azurewebsites.net/api/contacts/upload">
    <div>
        <label for="datafile">Data File</label>
        <input name="datafile" type="file" />
    </div>
    <div>
        <input type="submit" value="Submit" />
    </div>
</form></td>
  </tr>
</table>


<table>
  <tr>
    <td>Use the following formats to upload contacts into csv and excel </td>
  </tr>
  <tr>
    <td>Excel file</td>
  </tr>
  <tr>
    <td></td>
  </tr>
  <tr>
    <td>CSV file</td>
  </tr>
  <tr>
    <td>FullName,CompanyName,Position,Country,Email
Name1,Company1,Position 1,Country1,samplemail25@gmail.com
Name2,Company2,Position 2,Country2,samplemail26@gmail.com
Name3,Company3,Position 3,Country3,samplemail27@gmail.com
Name4,Company4,Position 4,Country4,samplemail28@gmail.com
Name5,Company5,Position 5,Country5,samplemail29@gmail.com
Name6,Company6,Position,Country6,samplemail30@gmail.com
Name7,Company7,Position,Country7,samplemail31@gmail.com
Name8,Company8,Position 8,Country8,samplemail32@gmail.com
Name9,Company9,Position,Country9,samplemail33@gmail.com</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td>Number of successfully uploaded and failed contacts</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
</table>


## **3 Email lists**

**3.1 Get**

Gets all email lists from database without contacts

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Get</td>
    <td>http://crmbetc.azurewebsites.net/api/emaillists</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status Code</td>
    <td>Response Body</td>
  </tr>
  <tr>
    <td>200</td>
    <td>[
  {
    "EmailListID": 1,
    "EmailListName": "All"
  },
  {
    "EmailListID": 2,
    "EmailListName": "VIP Partners"
  }
]</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td></td>
  </tr>
</table>


**3.2 Get (by id)**

Gets specific  email list by Id

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Get</td>
    <td>http://crmbetc.azurewebsites.net/api/emaillists?id=1</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Param name</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>URL_PARAM </td>
    <td>id</td>
    <td>integer</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td>{
  "EmailListID": 1,
  "EmailListName": "All",
  "Contacts": [
    {
      "Full Name": "Aghasi Lorsabyan",
      "Company Name": "TUMO",
      "Position": "Mentor",
      "Country": "Armenia",
      "Email": "lorsabyan@gmail.com",
      "GuID": "1d8cecd5-2d4c-43c1-bcd1-085664eb6bdc"
    }
  ]
}</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>If Email List  with such id is not found in database</td>
  </tr>
</table>


**3.3 Put (updates email list contacts)**

Updates specific  email list contacts: if flag is true, adds contacts from request body to email list , if flag = false, deletes those contacts from email list.

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Put</td>
    <td>http://crmbetc.azurewebsites.net/api/emaillists/update?id=12&flag=true</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Param name</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>URL_PARAM </td>
    <td>id</td>
    <td>Integer (the id of email list to update)</td>
  </tr>
  <tr>
    <td>URL_PARAM </td>
    <td>flag</td>
    <td>Bool ( true- add contacts to list, false delete  )</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>Post_Body_Param</td>
    <td>[
"80e4b849-d711-4335-936f-598780906704",
"33b304fa-664d-4224-b9f4-bd4e3eeba876"
]</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td>{
  "EmailListID": 12,
  "EmailListName": "All3",
  "Contacts": [
    {
      "Full Name": "Aghasi Lorsabyan",
      "Company Name": "TUMO",
      "Position": "Mentor",
      "Country": "Armenia",
      "Email": "lorsabyan@gmail.com",
      "GuID": "33b304fa-664d-4224-b9f4-bd4e3eeba876"
    },
    {
      "Full Name": "Tatevik Vardanyan",
      "Company Name": "Mic Armenia",
      "Position": "Developer",
      "Country": "Armenia",
      "Email": "tatevik@gmail.com",
      "GuID": "80e4b849-d711-4335-936f-598780906704"
    }
  ]
}</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>If email list with such id is not found in database</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td></td>
  </tr>
</table>


**3.4 Put (updates email list)**

Updates specific  email list

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Put</td>
    <td>http://crmbetc.azurewebsites.net/api/emaillists</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>Post_Body_Param</td>
    <td>{
  "EmailListID": 1,
  "EmailListName": "All",
  "Contacts": [
       "1d8cecd5-2d4c-43c1-bcd1-085664eb6bdc",
       "943d9186-6350-4ecb-a826-048a0306228a"
  ]
}
The    "Contacts":  field is optional and can be ignored in request  (in this case the contacts of email list will not be changed)</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td>{
  "EmailListID": 1,
  "EmailListName": "All",
  "Contacts": [
    {
      "Full Name": "Aghasi Lorsabyan",
      "Company Name": "TUMO",
      "Position": "Mentor",
      "Country": "Armenia",
      "Email": "lorsabyan@gmail.com",
      "GuID": "1d8cecd5-2d4c-43c1-bcd1-085664eb6bdc"
    },
    {
      "Full Name": "Tatevik Vardanyan",
      "Company Name": "Mic Armenia",
      "Position": "Developer",
      "Country": "Armenia",
      "Email": "tatevik@gmail.com",
      "GuID": "943d9186-6350-4ecb-a826-048a0306228a"
    }
  ]
}</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>If email list with such id is not found in database</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td></td>
  </tr>
</table>


**3.5 Post (creates email list)**

Creates new  email list

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Post</td>
    <td>http://crmbetc.azurewebsites.net/api/emaillists</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>Post_Body_Param</td>
    <td>{
    "EmailListName": "All 2",
    "Contacts": [
       "1d8cecd5-2d4c-43c1-bcd1-085664eb6bdc",
       "943d9186-6350-4ecb-a826-048a0306228a"
  ]
}

The   "Contacts":  field is optional and can be ignored in request  (in this case the created email list will  be empty)</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td>{
  "EmailListID": 22,
  "EmailListName": "All 2",
  "Contacts": [
    {
      "Full Name": "Aghasi Lorsabyan",
      "Company Name": "TUMO",
      "Position": "Mentor",
      "Country": "Armenia",
      "Email": "lorsabyan@gmail.com",
      "GuID": "1d8cecd5-2d4c-43c1-bcd1-085664eb6bdc"
    },
    {
      "Full Name": "Tatevik Vardanyan",
      "Company Name": "Mic Armenia",
      "Position": "Developer",
      "Country": "Armenia",
      "Email": "tatevik@gmail.com",
      "GuID": "943d9186-6350-4ecb-a826-048a0306228a"
    }
  ]
}</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td></td>
  </tr>
</table>


**3.6 Delete (by id)**

Deletes the specific  email list by Id

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>DELETE</td>
    <td>http://crmbetc.azurewebsites.net/api/emaillists?id=1</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Param name</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>URL_PARAM </td>
    <td>id</td>
    <td>number</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td></td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td>If email list with such guid is not found in database</td>
  </tr>
</table>


## **4 Send Email**

**4.1 Post**

Sends emails to contacts by guid

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Post</td>
    <td>http://crmbetc.azurewebsites.net/api/sendemails?template=1</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Param name</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>URL_PARAM </td>
    <td>template</td>
    <td>number</td>
  </tr>
  <tr>
    <td>Post_Body_Param</td>
    <td>Array of Guids</td>
    <td>[
"b3e48661-7979-440d-bf33-c8da8ed2cb62,
"Dab7e4fb-171f-4e65-8a5a-7640fb113fe5"
]</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200 OK</td>
    <td></td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td></td>
  </tr>
  <tr>
    <td>500 Internal Server error</td>
    <td></td>
  </tr>
</table>


**4.2 Post**

Sends emails to contacts by email list id

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Post</td>
    <td>http://crmbetc.azurewebsites.net/api/sendemails?template=3&emaillistId=1</td>
  </tr>
</table>


<table>
  <tr>
    <td>Type</td>
    <td>Param name</td>
    <td>Values</td>
  </tr>
  <tr>
    <td>URL_PARAM </td>
    <td>template</td>
    <td>number</td>
  </tr>
  <tr>
    <td>URL_PARAM</td>
    <td>emaillistId</td>
    <td>number</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status</td>
    <td>Response</td>
  </tr>
  <tr>
    <td>200</td>
    <td></td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td></td>
  </tr>
  <tr>
    <td>500 Internal Server error</td>
    <td></td>
  </tr>
</table>


## **5 Email Templates**

**5.1 Get**

Gets all templates 

**Request**

<table>
  <tr>
    <td>Method</td>
    <td>URL</td>
  </tr>
  <tr>
    <td>Get</td>
    <td>http://crmbetc.azurewebsites.net/api/templates</td>
  </tr>
</table>


**Response**

<table>
  <tr>
    <td>Status Code</td>
    <td>Response Body</td>
  </tr>
  <tr>
    <td>200</td>
    <td>An array of templates 
[
  {
    "TemplateId": 1,
    "TemplateName": "NewYear.html"
  },
  {
    "TemplateId": 2,
    "TemplateName": "BirthdayWish.html"
  },
  {
    "TemplateId": 3,
    "TemplateName": "LabourDay.html"
  }
]</td>
  </tr>
  <tr>
    <td>400 Bad Request</td>
    <td>Exception and InnerException Message</td>
  </tr>
  <tr>
    <td>404 Not Found</td>
    <td></td>
  </tr>
  <tr>
    <td>500 Internal Server Error</td>
    <td></td>
  </tr>
</table>


