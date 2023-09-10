import React from 'react';
import { render, screen } from '@testing-library/react';
import App from '../App';

describe('App Component', () => {
  it('renders the main title', () => {
    render(<App />);
    const titleElement = screen.getByText(/Peabux Assessment/i);
    expect(titleElement).toBeInTheDocument();
  });

});
