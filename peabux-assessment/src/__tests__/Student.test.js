import React from 'react';
import { render, screen, waitFor } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import CreateStudent from '../components/student/createStudent';
import ViewStudents from '../components/student/viewStudents';
import * as services from '../utils/services'

const mockData = [
    {
        dateOfBirth : "2000-01-01T00:00:00",
        id: 44,
        name: "Jane",
        nationalIDNumber: "8787978809",
        surname: "Lane",
        studentNumber: "154841515"
    }
]


describe('Create Student', () => {
    it('renders submit button', () => {
      render(<BrowserRouter><CreateStudent /></BrowserRouter>);
      const titleElement = screen.getByRole('button', { name: /submit/i });
      expect(titleElement).toBeInTheDocument();
    });

    it('renders create national id', () => {
        render(<BrowserRouter><CreateStudent /></BrowserRouter>
        );
        const titleElement = screen.getByPlaceholderText(/National ID Number/i);
        expect(titleElement).toBeInTheDocument();
      });

      it('renders label correctly', () => {
        render(<BrowserRouter><CreateStudent /></BrowserRouter>
        );
        const titleElement = screen.getAllByLabelText(/Name/i);
        expect(titleElement[0]).toBeInTheDocument();
      });

    it("Fetch Data API called", async () => {
        const mockFetchData = jest.spyOn(services, 'FetchStudentData')
            .mockImplementation(async () => {
                return mockData;
            })
        
        render(<BrowserRouter><ViewStudents /></BrowserRouter>)
        expect(mockFetchData).toHaveBeenCalled();
        await waitFor(() => {
            expect(screen.getByText(/Jane/i)).toBeInTheDocument();
        })     
    })

  });