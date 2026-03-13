
// __tests__/PasswordForm.test.tsx
import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import PasswordForm from '../PasswordForm';

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});


const mockUseAuth: {
  email: string;
  uri: string;
  login: jest.Mock;
  requestPasswordReset: jest.Mock;
  errorMessage: string | null;
  setUri: jest.Mock;
  setEmail: jest.Mock;
} = {
  email: 'test@email.com',
  uri: 'test-uri',
  login: jest.fn(),
  requestPasswordReset: jest.fn(),
  errorMessage: null,
  setUri: jest.fn(),
  setEmail: jest.fn(),
};

jest.mock('../AuthProvider', () => ({
  useAuth: () => mockUseAuth,
}));

jest.mock('next/navigation', () => ({
  useRouter: () => ({
    push: jest.fn(),
    refresh: jest.fn(),
  }),
}));

const mockDispatch = jest.fn();
jest.mock('@/app/store/hooks', () => ({
  useAppDispatch: () => mockDispatch,
  useAppSelector: (selector: any) =>
    selector({ systemContext: { systemContext: null } }),
}));
jest.mock('@/app/store/slices/systemContextSlice', () => ({
  selectSystemContext: (s: any) => s.systemContext.systemContext,
  setSystemContext: jest.fn((v: any) => ({ type: 'systemContext/setSystemContext', payload: v })),
}));

describe('PasswordForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
    localStorage.clear();
  });

  it('should render password form correctly', () => {
    render(<PasswordForm captchaSuccess={true} />);
    
    expect(screen.getByDisplayValue('test@email.com')).toBeInTheDocument();
    expect(screen.getByLabelText(/senha/i)).toBeInTheDocument();
    expect(screen.getByRole('button', { name: /entrar/i })).toBeInTheDocument();
  });

  it('should disable submit when captcha fails', () => {
    render(<PasswordForm captchaSuccess={false} />);
    
    const submitButton = screen.getByRole('button', { name: /entrar/i });
    expect(submitButton).toBeDisabled();
  });

  it('should submit login form', async () => {
    mockUseAuth.login.mockResolvedValue(true);

    render(<PasswordForm captchaSuccess={true} />);
    
    const passwordInput = screen.getByLabelText(/senha/i);
    const submitButton = screen.getByRole('button', { name: /entrar/i });
    
    fireEvent.change(passwordInput, { target: { value: 'password123' } });
    fireEvent.click(submitButton);

    await waitFor(() => {
      expect(mockUseAuth.login).toHaveBeenCalledWith('test-uri', 'password123');
    });
  });

  it('should show reset password button on error', async () => {
    mockUseAuth.errorMessage = 'Senha incorreta';

    render(<PasswordForm captchaSuccess={true} />);
    
    const matches = screen.getAllByText(/resetar senha/i);
    expect(matches.length).toBeGreaterThan(0);
  });

  it('should handle password reset', async () => {
    mockUseAuth.errorMessage = 'Senha incorreta';

    render(<PasswordForm captchaSuccess={true} />);
    
    const resetButton = screen.getAllByText(/resetar senha/i)[0];
    fireEvent.click(resetButton);

    const requestButton = screen.getByRole('button', { name: /solicitar nova senha/i });
    fireEvent.click(requestButton);

    await waitFor(() => {
      expect(mockUseAuth.requestPasswordReset).toHaveBeenCalledWith('test-uri');
    });
  });
});
