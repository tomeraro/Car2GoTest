# AspNetInterviewTest

פרוייקט דוגמא עבור ראיון עבודה

## תיאור הבעיה The Problem
The System Recevices an array of integars, each int represent a status code of an event. the events are numbered between 1 - 100 but the size of the array is about |10000|.
The Businness logic class has one function called Next
Next function has this requirements
1. get a postion in the array
2. return the next postion of the value of the item( the next  postion where the number at)
3.. the next postion is going "right" nextpostion > currentPostions


## Requeriemnts
1. return an answer as O(1) - not running on the the array.
2. check for Edge Cases ( Empty array, wrong postion)


## Location of code

1. EventsRepository has a function called Next, you need to implemnt it and return the next postion
2. EventsRepository has a list of int - Items this is the values you need to work on.
3. The function is called using the calc API
4. You can test the code using the Home controller and the next number
5. If the items are changed each call you can save it in memmory somehow.

## a simple check


var arr = [ 1,2,4,1,2,3,5,6,7,2,2,9,9,8,3,2,1,2,3];
// the number are from 1- 10


//example 
// getNewPostion(0) return 3
// getNewPostion(3) return 16
// getNewPostion(1) return 5
// getNewPostion(3) return ?

