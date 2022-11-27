"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (currentUser, message) {
  var li = document.createElement("li");
  document.getElementById("messagesList").appendChild(li);
  // We can assign user-supplied strings to an element's textContent because it
  // is not interpreted as markup. If you're assigning in any other way, you 
  // should be aware of possible script injection concerns.
  console.log(currentUser);
  console.log(currentUser.ImageUrl);
  let content = `<img src='/images/${currentUser.imageUrl}'  style='border-radius:50%;width:100px;height:100px'/>`;
  content += `${currentUser.userName} says ${message}`
  li.innerHTML = content;

});

connection.on("Connect", function (info) {

  var li = document.createElement("li");
  document.getElementById("messagesList").appendChild(li);
  li.innerHTML = `<span style='color:green;'>${info}</span>`;
});
connection.on("Disconnect", function (info) {

  var li = document.createElement("li");
  document.getElementById("messagesList").appendChild(li);
  li.innerHTML = `<span style='color:red;'>${info}</span>`;
});


connection.start().then(function () {
  document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
  return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
  var user = "";
  var message = document.getElementById("messageInput").value;
  connection.invoke("SendMessage", user, message).catch(function (err) {
    return console.error(err.toString());
  });
  event.preventDefault();
});