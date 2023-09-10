import React from 'react';
import { render, screen } from '@testing-library/react';
import Home from '../Home'
import { BrowserRouter } from 'react-router-dom';

describe('Home Component', () => {
  it('renders text on screen', () => {
    render(<BrowserRouter><Home /></BrowserRouter>
    );
    const titleElement = screen.getByText(/View Teachers/i);
    expect(titleElement).toBeInTheDocument();
  });
});