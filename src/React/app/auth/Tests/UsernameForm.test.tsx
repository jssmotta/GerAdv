
// __tests__/UsernameForm.test.tsx
import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import UsernameForm from '../UsernameForm';
import { AuthProvider } from '../AuthProvider';

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});


// Mock do useAuth
const mockUseAuth = {
  validateUsername: jest.fn(),
  errorMessage: null,
  setErrorMessage: jest.fn(),
};

jest.mock('../AuthProvider', () => ({
  ...jest.requireActual('../AuthProvider'),
  useAuth: () => mockUseAuth,
}));

// Mock do Next.js router
jest.mock('next/navigation', () => ({
  useRouter: () => ({
    push: jest.fn(),
    refresh: jest.fn(),
  }),
}));

describe('UsernameForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  it('should render form fields correctly', () => {
    render(<UsernameForm />);
    
    expect(screen.getByLabelText(/domínio/i)).toBeInTheDocument();
    expect(screen.getByLabelText(/e-mail/i)).toBeInTheDocument();
    expect(screen.getByRole('button', { name: /continuar/i })).toBeInTheDocument();
  });

  it('should validate email format', async () => {
    render(<UsernameForm />);
    
    const emailInput = screen.getByLabelText(/e-mail/i);
    const submitButton = screen.getByRole('button', { name: /continuar/i });
    
    fireEvent.change(emailInput, { target: { value: 'invalid-email' } });
    
    // O botão deve estar desabilitado com email inválido
    expect(submitButton).toBeDisabled();
  });

  it('should submit form with valid data', async () => {
    mockUseAuth.validateUsername.mockResolvedValue(true);

    render(<UsernameForm />);
    
    const domainInput = screen.getByLabelText(/domínio/i);
    const emailInput = screen.getByLabelText(/e-mail/i);
    const submitButton = screen.getByRole('button', { name: /continuar/i });
    
    fireEvent.change(domainInput, { target: { value: 'TEST-DOMAIN' } });
    fireEvent.change(emailInput, { target: { value: 'test@email.com' } });
    
    fireEvent.click(submitButton);

    await waitFor(() => {
      expect(mockUseAuth.validateUsername).toHaveBeenCalledWith('TEST-DOMAIN', 'test@email.com');
    });
  });

  it('should convert domain to uppercase', () => {
    render(<UsernameForm />);
    
    const domainInput = screen.getByLabelText(/domínio/i);
    
    fireEvent.change(domainInput, { target: { value: 'test-domain' } });
    
    expect(domainInput).toHaveValue('TEST-DOMAIN');
  });

  it('should convert email to lowercase', () => {
    render(<UsernameForm />);
    
    const emailInput = screen.getByLabelText(/e-mail/i);
    
    fireEvent.change(emailInput, { target: { value: 'TEST@EMAIL.COM' } });
    
    expect(emailInput).toHaveValue('test@email.com');
  });
});
