function display_fn(msg)
{
    console.log(msg)
}

function mySecond(n1, n2, fn) {
    let sum = n1 + n2
    fn(sum)
}

var XMLHttpRequest = require('xhr2').XMLHttpRequest;
let req = new XMLHttpRequest();
req.open('GET', "http://www.irna.ir");
req.onload = function() {
  if (req.status == 200) {
      console.log(req.responseText.length);
  }
  else {
      console.log("Not Found");
  }
};
req.send();

setInterval(function(resolve, reject) { console.log("waiting")}, 500)

// async function getFile() {
//     let myPromise = new Promise(function(myResolve, myReject) {
//       let req = new XMLHttpRequest();
//       req.open('GET', "http://www.irna.ir");
//       req.onload = function() {
//         if (req.status == 200) {
//             myResolve(req.response);
//         }
//         else {
//             myResolve("File not Found");
//         }
//       };
//       req.send();
//     });
//     document.getElementById("demo").innerHTML = await myPromise;
//   }
  
//   getFile();


// setInterval(function() {mySecond(5, 4, display_fn);}, 3000);
// for(let i=0; i<10; i++)
//     console.log("Waiting " + i);