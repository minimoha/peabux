import React from 'react';
import { render, screen, waitFor } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import Create from '../components/teacher/create';
import * as services from '../utils/services'
import Read from '../components/teacher/read';

const mockData = [
    {
        dateOfBirth : "2000-01-01T00:00:00",
        id: 44,
        name: "Jane",
        nationalIDNumber: "8787978809",
        salary: 54151515,
        surname: "Lane",
        teacherNumber: "154841515",
        title: "Mrs"
    }
]


describe('Create Teacher', () => {
    it('renders submit button', () => {
      render(<BrowserRouter><Create /></BrowserRouter>);
      const titleElement = screen.getByRole('button', { name: /submit/i });
      expect(titleElement).toBeInTheDocument();
    });

    it('renders create national id', () => {
        render(<BrowserRouter><Create /></BrowserRouter>
        );
        const titleElement = screen.getByPlaceholderText(/National ID Number/i);
        expect(titleElement).toBeInTheDocument();
      });

      it('renders label correctly', () => {
        render(<BrowserRouter><Create /></BrowserRouter>
        );
        const titleElement = screen.getAllByLabelText(/Salary/i);
        expect(titleElement[0]).toBeInTheDocument();
      });

      it("Fetch Data API called", async () => {
        const mockFetchData = jest.spyOn(services, 'FetchData')
            .mockImplementation(async () => {
                return mockData;
            })
        
        render(<BrowserRouter><Read /></BrowserRouter>)
        expect(mockFetchData).toHaveBeenCalled();
        await waitFor(() => {
            expect(screen.getByText(/Jane/i)).toBeInTheDocument();
        })     
    })
  });