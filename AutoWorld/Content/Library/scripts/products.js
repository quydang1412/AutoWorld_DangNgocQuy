filterOption("all")
function filterOption() {
  var a = document.getElementById("myselect1").value; 
  var y, i;
  y = document.getElementsByClassName("filterOp");
  if (a == "all") a = "";
  // Add the "show" class (display:block) to the filtered elements, and remove the "show" class from the elements that are not selected
  for (i = 0; i < y.length; i++) {
    w3RemoveClass(y[i], "show");
    if (y[i].className.indexOf(a) > -1) w3AddClass(y[i], "show");
  }
}



filterSelection("all")
function filterSelection(c) {
  var m = document.getElementById("myselect1").value;
  var n = document.getElementById("myselect2").value;
  var p = document.getElementById("myselect3").value;
  var q = document.getElementById("myselect4").value;
  var x, i;
  x = document.getElementsByClassName("filterDiv");
  if (c == "all") c = "";
  // Add the "show" class (display:block) to the filtered elements, and remove the "show" class from the elements that are not selected
  for (i = 0; i < x.length; i++) {
    w3RemoveClass(x[i], "show");
    if ((x[i].className.indexOf(m) > -1) && (x[i].className.indexOf(n) > -1) && (x[i].className.indexOf(p) > -1) && (x[i].className.indexOf(q) > -1)) 
    w3AddClass(x[i], "show");
  }
}

// Show filtered elements
function w3AddClass(element, name) {
  var i, arr1, arr2;
  arr1 = element.className.split(" ");
  arr2 = name.split(" ");
  for (i = 0; i < arr2.length; i++) {
    if (arr1.indexOf(arr2[i]) == -1) {
      element.className += " " + arr2[i];
    }
  }
}

// Hide elements that are not selected
function w3RemoveClass(element, name) {
  var i, arr1, arr2;
  arr1 = element.className.split(" ");
  arr2 = name.split(" ");
  for (i = 0; i < arr2.length; i++) {
    while (arr1.indexOf(arr2[i]) > -1) {
      arr1.splice(arr1.indexOf(arr2[i]), 1);
    }
  }
  element.className = arr1.join(" ");
}
