# Thriday Back End Technical Challenge

## Introduction

Our Backend technical interview process involves candidates doing an at-home project to test your C#/Azure knowledge and problem solving abilities, while also giving you a chance to write code in a way that you find comfortable.
Using Google/StackOverflow/whatever for help is allowed, but ultimately you should write and be able to justify every piece of the code being submitted.
Your solution should be shared on a public Github or Bitbucket repo showing all commit history.

## Requirements

* Use Azure functions (v4, c#, net6)
* 
* 

## The Challenge

We have provided a JSON file containing a small sample from an API response; it contains a list of Transactions. This data is currently consumed by an existing client. We have lost the source code for this, in a data center fire! Oh no! Your challenge is to:

- Create an HTTP Triggered Azure function, matching the existing code patterns, which returns the data in the provided (SQLite/CosmosDB) database.
- Create a Timer based Azure function, which runs every <configurable> minutes, and randomly decides to do one of the following:
  - Generate a new transaction, and insert it into the database
    - TODO: Add transaction generator (for some fields) here
  - Update an existing transaction where the status is "PENDING", to a status of "POSTED". 



### Assets


### Acceptance Criteria

## Task Updates:
The Project has been updated with the requested Azure Function. 
 --Created an HTTP Triggered Azure function, matching the provided Sample JSON.When Deployed in Azure either in Windows or Linux container, this can be tested in Azure Portal.
 -- Created a Timer based Azure function, which runs every 30 minutes, and randomly decides to do one of the following:
  - Option 1 : Generate a new transaction, and insert it into the database
  - Option 2 : Update an existing transaction where the status is "PENDING", to a status of "POSTED". 
