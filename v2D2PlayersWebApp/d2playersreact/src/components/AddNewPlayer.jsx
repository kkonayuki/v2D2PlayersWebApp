import React from 'react';
import {useState} from 'react';
import axios from 'axios';

const AddNewPlayer = () => {

  const url = 'https://localhost:7180';

  const[firstname, setFirstName] = useState('');
  const[lastname, setLastName] = useState('');
  const[nickname, setNickName] = useState('');
  const[countryId, setCountryId] = useState('');
  const[teamId, setTeamId] = useState('');
  const[age, setAge] = useState('');
  const[prizeMoney, setPrizeMoney] = useState('');

  

  const handleSubmit = (e) => {
    const data = {
      firstname: firstname,
      lastname: lastname,
      nickname: nickname,
      countryId: countryId,
      teamId: teamId,
      age: age,
      prizeMoney: prizeMoney
    }
    axios
    .post(`${url}/api/Player/AddPlayer`, data)
    .then((json) => {
      clear();
    })
    .catch((error)=>
    {
      console.log(error);
    })
  } 

  const clear = () => {
    setFirstName("")
    setLastName("")
    setNickName("")
    setCountryId("")
    setTeamId("")
    setAge("")
    setPrizeMoney("")
  }

    return (
        <div>
        <input type ="text" value={firstname} placeholder="Enter first name" onChange={(e) => setFirstName(e.target.value)}/>
        <br></br>
        <input type ="text" value={lastname} placeholder="Enter last name" onChange={(e) => setLastName(e.target.value)}/>
        <br></br>
        <input type ="text" value={nickname} placeholder="Enter nick name" onChange={(e) => setNickName(e.target.value)}/>
        <br></br>
        <input type ="text" value={countryId} placeholder="Enter country id" onChange={(e) => setCountryId(e.target.value)}/>
        <br></br>
        <input type ="text" value={teamId} placeholder="Enter team id" onChange={(e) => setTeamId(e.target.value)}/>
        <br></br>
        <input type ="text" value={age} placeholder="Enter age" onChange={(e) => setAge(e.target.value)}/>
        <br></br>
        <input type ="text" value={prizeMoney} placeholder="Enter prize money" onChange={(e) => setPrizeMoney(e.target.value)}/>
        <br></br>
        <button onClick={(e) => handleSubmit(e)}>Submit</button>
      </div>
    );
};

export default AddNewPlayer;