import React, { useEffect, useState } from 'react';
import { Table, Button } from 'semantic-ui-react';
import { Link } from 'react-router-dom';
import {  FetchData, DeleteData } from '../../utils/services'

export default function Read() {
    const [APIData, setAPIData] = useState([]);
    useEffect(() => {
        FetchData().then((data) => {
            //console.log(data)
            setAPIData(data);

          })
    }, []);

    const getData = () => {
        FetchData().then((data) => {
            //console.log(data)
            setAPIData(data);

          })
    }

    const onDelete = (id) => {
        DeleteData(id)
        .then(() => {
            getData();
        })
    }

    const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' }

    return (
        <div>
            <Link to='/teacher/create'>
                <Button color='green'>Create</Button>
            </Link>
                                <br/>
                                <br/>
            <Table singleLine>
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>NIN</Table.HeaderCell>
                        <Table.HeaderCell>Title</Table.HeaderCell>
                        <Table.HeaderCell>Full Name</Table.HeaderCell>
                        <Table.HeaderCell>Date Of Birth</Table.HeaderCell>
                        <Table.HeaderCell>Salary</Table.HeaderCell>
                        <Table.HeaderCell>Contact</Table.HeaderCell>
                        <Table.HeaderCell></Table.HeaderCell>
                    </Table.Row>
                </Table.Header>

                <Table.Body>
                    {APIData.map((data) => {
                        return (
                            <Table.Row key={data.id}>
                                <Table.Cell>{data.nationalIDNumber}</Table.Cell>
                                <Table.Cell>{data.title}</Table.Cell>
                                <Table.Cell>{data.name} {data.surname}</Table.Cell>
                                <Table.Cell>{new Date(data.dateOfBirth).toLocaleDateString("en-US", options)}</Table.Cell>
                                <Table.Cell>{data.salary}</Table.Cell>
                                <Table.Cell>{data.teacherNumber}</Table.Cell>
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