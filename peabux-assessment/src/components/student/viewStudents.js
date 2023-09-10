import React, { useEffect, useState } from 'react';
import { Table, Button } from 'semantic-ui-react';
import { Link } from 'react-router-dom';
import {  FetchStudentData, DeleteStudentData } from '../../utils/services'


export default function ViewStudents() {
    const [APIData, setAPIData] = useState([]);
    useEffect(() => {
        FetchStudentData().then((data) => {
                setAPIData(data);

              })
    }, []);

    const getData = () => {
        FetchStudentData().then((data) => {
            setAPIData(data);
          })
    }

    const onDelete = (id) => {
        DeleteStudentData(id)
        .then(() => {
            getData();
        })
    }

    const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' }

    return (
        <div>
            <Link to='/student/create'>
                <Button color='green'>Create</Button>
            </Link>
                                <br/>
                                <br/>
            <Table singleLine>
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>NIN</Table.HeaderCell>
                        <Table.HeaderCell>Full Name</Table.HeaderCell>
                        <Table.HeaderCell>Date Of Birth</Table.HeaderCell>
                        <Table.HeaderCell>Student Number</Table.HeaderCell>
                        <Table.HeaderCell></Table.HeaderCell>
                    </Table.Row>
                </Table.Header>

                <Table.Body>
                    {APIData.map((data) => {
                        return (
                            <Table.Row key={data.id}>
                                <Table.Cell>{data.nationalIDNumber}</Table.Cell>
                                <Table.Cell>{data.name} {data.surname}</Table.Cell>
                                <Table.Cell>{new Date(data.dateOfBirth).toLocaleDateString("en-US", options)}</Table.Cell>
                                <Table.Cell>{data.studentNumber}</Table.Cell>
                                <Table.Cell>
                                    <Button color='red' onClick={() => onDelete(data.id)}>Delete</Button>
                                </Table.Cell>
                            </Table.Row>
                        )
                    })}
                </Table.Body>
            </Table>
            <Link to='/'> Home </Link>

        </div>
    )
}