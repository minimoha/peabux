import React, { useState } from 'react';
import { Button, Form } from 'semantic-ui-react';
import { useNavigate, Link } from 'react-router-dom';


export default function CreateStudent() {
    const navigate = useNavigate();
    const [nationalIDNumber, setNationalIDNumber] = useState('');
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [dateOfBirth, setDateOfBirth] = useState('');
    const [studentNumber, setStudentNumber] = useState('');

    const validateDate = () =>{
        var date = document.getElementById('dob').value
        let checkDate = new Date().getFullYear() - new Date(date).getFullYear()
        if (checkDate > 22) {
            setDateOfBirth('')
            alert("Age cannot be more than 22")
            document.getElementById('dob').value = ''
            return false
        }else{
            setDateOfBirth(date)
            return true
        }
    }

    const validateFields = () =>{
        let validateAge = validateDate()
        if(!validateAge){
            return
        }
        if (!nationalIDNumber) {
            alert("National ID Number cannot be empty")
            return false
        }
        if (!name) {
            alert("Name cannot be empty")
            return false
        }
        if (!surname) {
            alert("Surname cannot be empty")
            return false
        }
        if (!studentNumber) {
            alert("Student Number cannot be empty")
            return false
        }
        if (!dateOfBirth) {
            alert("Date Of Birth cannot be empty")
            return false
        }
        return true
    }

    const postData = () => {
        let validate = validateFields()
        if(!validate){
            return
        }

        fetch(`https://localhost:7051/api/Student/Create`,{
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            }, body: JSON.stringify({
            nationalIDNumber,
            name,
            surname,
            dateOfBirth,
            studentNumber,
        })}).then(() => {
            navigate('/student/read')
        }).catch((err) =>{

        })
    }

    return (
        <div className='form-field'>
            <Form className="create-form">
                <Form.Field>
                    <label>National ID Number</label>
                    <input placeholder='National ID Number' onChange={(e) => setNationalIDNumber(e.target.value)} required/>
                </Form.Field>
                <Form.Field>
                    <label htmlFor='name'>Name</label>
                    <input placeholder='Name' id='name' onChange={(e) => setName(e.target.value)} required/>
                </Form.Field>
                <Form.Field>
                    <label>Surname</label>
                    <input placeholder='Surname' onChange={(e) => setSurname(e.target.value)} required/>
                </Form.Field>
                <Form.Field>
                    <label>dateOfBirth</label>
                    <input placeholder='Date Of Birth' type='date' id='dob' onBlur={validateDate} required/>
                </Form.Field>
                <Form.Field>
                    <label>Student Number</label>
                    <input placeholder='Student Number' type='number' onChange={(e) => setStudentNumber(e.target.value)} required/>
                </Form.Field>
                <Button onClick={postData} type='submit'>Submit</Button>
            </Form>
            <br/>
            <Link to='/'> Home </Link>
            &nbsp; &nbsp;
            <Link to='/student/read'> <button> Back to List </button> </Link>

        </div>
    )
}