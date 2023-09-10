export const FetchData = () => {
    return fetch(`${process.env.REACT_APP_API_URL}/api/Teacher/GetAll`)
        .then((response) => {
            return response.json()
        }).then((data) => {
            return data.data;
          })
}

export const DeleteData = (id) => {
    return fetch(`${process.env.REACT_APP_API_URL}/api/Teacher/${id}`, {
        method: 'DELETE',
      })
}

export const FetchStudentData = () => {
    return fetch(`${process.env.REACT_APP_API_URL}/api/Student/GetAll`)
        .then((response) => {
            return response.json()
        }).then((data) => {
            return data.data;
          })
}


export const DeleteStudentData = (id) => {
    return fetch(`${process.env.REACT_APP_API_URL}/api/Student/${id}`, {
        method: 'DELETE',
      })
}