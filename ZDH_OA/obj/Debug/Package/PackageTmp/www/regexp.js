
 function ifIndex (_index) {
     if (!/^[1-9]\d*$/.test(_index.value)) {
        alert("请输入正确序号");
        _index.value = "";
        return false;
    }
 };
 


function reg(arr) {
    var arr2 = [];
    var z = /^[0-9]+.?[0-9]*$| (^\s*)|(\s*$) /;
    let s;
    for (let i = 0; i < arr.length; i++) {
        //console.log(arr[i].value + ":" + typeof (arr[i].value));
        if (arr[i].value != "") {
            s = z.test(arr[i].value);
        } else {
            s = true;
        }
        arr2.push(s);
    }
    //console.log(arr2 + ":" + arr2.length);
    for (let i = 0; i < arr2.length; i++) {
        console.log(arr2[i]);
        if (arr2[i] == false || arr2[i] == "false") {
            arr[i].value = "";
            alert("请输入有效数字");
            return false;
        }
    }
}

