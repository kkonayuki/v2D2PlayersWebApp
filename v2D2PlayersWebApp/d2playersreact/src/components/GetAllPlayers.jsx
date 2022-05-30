useEffect(()=>{
    axios.get(`${url}/api/Player/GetPlayers`)
    .then((json) => {
      console.log(json.data);
    })
  }, [])