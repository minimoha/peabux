import React, { useState } from 'react';
import { Button, Form } from 'semantic-ui-react';
import axios from 'axios';
import { useNavigate, Link } from 'react-router-dom';


export default function Create() {
    const navigate = useNavigate();
    const [nationalIDNumber, setNationalIDNumber] = useState('');
    const [title, setTitle] = useState('');
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [dateOfBirth, setDateOfBirth] = useState('');
    const [teacherNumber, setTeacherNumber] = useState('');
    const [salary, setSalary] = useState('0');

    const validateDate = () =>{
        var date = document.getElementById('dob').value
        let checkDate = new Date().getFullYear() - new Date(date).getFullYear()
        if (checkDate < 21) {
            setDateOfBirth('')
            alert("Age cannot be less than 21")
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
            console.log("National ID Number cannot be empty")

            return false
        }
        if (!title) {
            alert("Title cannot be empty")
            console.log("Title cannot be empty")

            return false
        }
        if (!name) {
            alert("Name cannot be empty")
            console.log("Name cannot be empty")

            return false
        }
        if (!surname) {
            alert("Surname cannot be empty")
            console.log("Surname cannot be empty")

            return false
        }
        if (!teacherNumber) {
            alert("Teacher Number cannot be empty")
            console.log("Teacher Number cannot be empty")

            return false
        }
        if (!dateOfBirth) {
            alert("Date Of Birth cannot be empty")
            console.log("Teacher Number cannot be empty")

            return false
        }
        if (salary < 0) {
            alert("Salary cannot be less than 0")
            console.log("Salary cannot be less than 0")
            return false
        }
        return true
    }

    const postData = () => {
        let validate = validateFields()
        if(!validate){
            return
        }

        axios.post(`https://localhost:7051/api/Teacher/Create`, {
            nationalIDNumber,
            title,
            name,
            surname,
            dateOfBirth,
            teacherNumber,
            salary
        }).then(() => {
            navigate('/teacher/read')
        }).catch((err) =>{
console.log(err)
        })
    }

    const options = [
        { key: '0', text: 'Select', value: '' },
        { key: '1', text: 'Mr', value: 'Mr' },
        { key: '2', text: 'Mrs', value: 'Mrs' },
        { key: '3', text: 'Miss', value: 'Miss' },
        { key: '4', text: 'Dr', value: 'Dr' },
        { key: '5', text: 'Prof', value: 'Prof' },
      ]
    return (
        <div className='form-field'>
            <Form className="create-form">
                <Form.Field>
                    <label>National ID Number</label>
                    <input placeholder='National ID Number' onChange={(e) => setNationalIDNumber(e.target.value)} required/>
                </Form.Field>
                <Form.Select
                    fluid
                    label='Title'
                    onChange={(e, {value}) => setTitle(value)}
                    options={options}
                    placeholder='Title'
                    required
                />
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
                    <label>Teacher Number</label>
                    <input placeholder='Teacher Number' type='number' onChange={(e) => setTeacherNumber(e.target.value)} required/>
                </Form.Field>
                <Form.Field>
                    <label>Salary</label>
                    <input placeholder='Salary' type='number' onChange={(e) => setSalary(e.target.value)} />
                </Form.Field>
                <Button onClick={postData} type='submit'>Submit</Button>
            </Form>
            <br/>
            <Link to='/'> Home </Link>
            <Link to='/teacher/read'> Back to List </Link>

        </div>
    )
}