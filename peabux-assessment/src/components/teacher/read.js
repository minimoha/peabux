import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Table, Button } from 'semantic-ui-react';
import { Link } from 'react-router-dom';

export default function Read() {
    const [APIData, setAPIData] = useState([]);
    useEffect(() => {
        axios.get(`https://localhost:7051/api/Teacher/GetAll`)
            .then((response) => {
                setAPIData(response.data.data);
            })
    }, []);

    const getData = () => {
        axios.get(`https://localhost:7051/api/Teacher/GetAll`)
            .then((getData) => {
                setAPIData(getData.data.data);
            })
    }

    const onDelete = (id) => {
        axios.delete(`https://localhost:7051/api/Teacher/${id}`)
        .then(() => {
            getData();
        }).catch((err) => {
            console.log(err)
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