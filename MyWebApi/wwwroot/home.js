


async function getResponse() {
    const postData = {
        firstname: document.querySelector(".firstname").value,
        lastname: document.querySelector(".lastname").value,
        password: document.querySelector(".password").value,
        email: document.querySelector(".email").value
    }
    const responsePost = await fetch('API/User', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    });
    if (!responsePost.ok)
    { throw new Error(`HTTP error! status:' ${responsePost.status()}`) }
    const res = await responsePost.json();
    //console.log('post data:', res);
    //console.log(typeof(res))
    sessionStorage.setItem('CurrentUser', res.id);
}
async function getResposeLogin() {
    const LogData = {
        password: document.querySelector(".login-password").value,
        email: document.querySelector(".login-email").value
    }
    const responseLogin = await fetch('api/User/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(LogData)
    });
    if (!responseLogin.ok)
        alert("This user is undifine!!")
    else
    {
    const res = await responseLogin.json();
    sessionStorage.setItem('CurrentUser', res.id);
    alert(JSON.stringify(res)); } 
}
async function put() {
    const postData =
        {
       
        firstname: document.querySelector(".firstname").value,
        lastname: document.querySelector(".lastname").value,
        password: document.querySelector(".password").value,
        email:document.querySelector(".email").value,
        id: sessionStorage.getItem('CurrentUser')
    };
    //const userJson = sessionStorage.getItem('currentUser');1
    const id = sessionStorage.getItem("CurrentUser");

    const updateUser = await fetch(`API/User/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(postData)
    });
    if (!updateUser.ok)
        //throw new Error(`error!! status: ${updateUser.status}`);
        alert("undefine!")
    else
        alert("updates!")
}


const CheckPasswordStrong = async () =>
{
    
    const checkpassword = document.querySelector(".password").value
    
    //const result = zxcvbn(password);
    //const score = result.score;
    const response = await fetch('API/User/check', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(checkpassword)
    });
    if (!response.ok) {
        throw new Error(`שגיאת שרת: ${response.status}`);
    }

    const strength = await response.json();

    if (strength < 2) {
        alert("הסיסמה חלשה");
    } else {
        alert("הסיסמה חזקה");
    }


}