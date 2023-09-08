import React, { useState } from 'react';
import { Button, Form } from 'semantic-ui-react';
import axios from 'axios';
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

        axios.post(`https://localhost:7051/api/Student/Create`, {
            nationalIDNumber,
            name,
            surname,
            dateOfBirth,
            studentNumber,
        }).then(() => {
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
                    <label>Name</label>
                    <input placeholder='Name' onChange={(e) => setName(e.target.value)} required/>
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
            <Link to='/student/read'> Back to List </Link>

        </div>
    )
}