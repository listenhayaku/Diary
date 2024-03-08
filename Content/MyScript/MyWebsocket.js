//連線到wss://localhost:44349/WebSocket1.ashx 目前沒有真正使用
console.log("(debug)[MyWebsocket]start");
var url = "ws://localhost:3000";
var mySocket = new WebSocket("wss://localhost:44349/WebSocket1.ashx");

mySocket.onopen = () => { console.log("open connection"); };
mySocket.onclose = () => { console.log("close connection"); };
mySocket.onmessage = event => { console.log("receive message: " + event); };
