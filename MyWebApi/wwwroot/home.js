


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
    sessionStorage.setItem('CurrentUser', JSON.stringify(res));
}
async function getResposeLogin() {
    const LogData = {
        password: document.querySelector(".password").value,
        email: document.querySelector(".email").value
    }
    const responseLogin = await fetch('API/User/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(LogData)
    });
    if (!responseLogin.ok) 
        alert("This user is undifine!!")
    else
        alert("The user exist in the system")
    
    const res = await responseLogin.json();
    sessionStorage.setItem('CurrentUser', res.id);
    alert(JSON.stringify(res));
}
async function getResponse() {
    const postData =
    {
        userName: document.querySelector(".userName").value,
        password: document.querySelector(".password").value,
        firstName: document.querySelector(".firstName").value,
        lastName: document.querySelector(".lastName").value,
        id: sessionStorage.getItem('currentUser')
    };
    const userJson = sessionStorage.getItem('currentUser');
    const updateUser = await fetch('api/users', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application / json'
        },
        body: JSON.stringify(postData)
    });
    if (!updateUser.ok)
        throw new Error(`error!! status: ${updateUser.status}`);
    else
        alert("updates!")
}
}

const CheckPasswordStrong = async () =>
{
    
    const checkpassword= document.querySelector(".checkpassword").value
    
    //const result = zxcvbn(password);
    //const score = result.score;
    const strength = await fetch('API/User/check', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(checkpassword)
    });
    if (strength < 2) {
        alert("Iam the best!!")
    }


}