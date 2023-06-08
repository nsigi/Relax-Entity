document.addEventListener("DOMContentLoaded", () => { });
  
var pass = document.getElementById('btnUpdatePass');
pass.onclick = generateStr;
var newPas = document.getElementById('btnNewPass');
newPas.onclick = generateStr;
var log = document.getElementById('btnUpdateLog');
log.onclick = generateStr; 
var newlog = document.getElementById('btnNewLog');
newlog.onclick = generateStr; 

function generateStr(e) {
	var string = "";
	var strong = 10;
	var dic = "abcdefghijklmnopqrstuvwxyz1234567890";
 
	for (var i = 0; i < strong; ++i) 
	{
		string += dic.charAt(Math.floor(Math.random() * dic.length));
	}
	
	btn = e.currentTarget;
	parent = btn.parentNode;
	d = parent.previousElementSibling;
	elem = d.firstElementChild;
	
	elem.value = string;
};
