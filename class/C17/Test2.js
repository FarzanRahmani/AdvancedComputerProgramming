function test() {
    console.log("Salam");
}

function test2(str) {
    console.log(str);
}

// setTimeout(test(), 3000); // pas az ye modat miad sedash mizane 3sanie

// setTimeout(function() {
//     test2("Salam1234")
// }, 3000);

setInterval(function() {
    test2("Salam1234");
}, 500);

for(var i = 0; i<1000; i++)
    for(var j = 0; j<10; j++)
        if (i * j % 20000 == 0)
            console.log("waiting " + i + " " + j);