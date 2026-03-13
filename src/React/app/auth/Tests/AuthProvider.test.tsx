// __tests__/AuthProvider.test.tsx
import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import { AuthProvider, useAuth, AuthStatus } from '../AuthProvider';
import * as authService from '../AuthServiceAdapter';

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => { });
  jest.spyOn(console, 'error').mockImplementation(() => { });
});

// Mock do AuthServiceAdapter
jest.mock('../AuthServiceAdapter', () => ({
  authServiceAdapter: {
    validateUsername: jest.fn(),
    login: jest.fn(),
    changePassword: jest.fn(),
    requestPasswordReset: jest.fn(),
  },
  AuthStatus: {
    LOGGED_OUT: 'LOGGED_OUT',
    VALIDATING_USERNAME: 'VALIDATING_USERNAME',
    VALIDATING_PASSWORD: 'VALIDATING_PASSWORD',
    PASSWORD_RESET_REQUIRED: 'PASSWORD_RESET_REQUIRED',
    LOGGED_IN: 'LOGGED_IN',
  },
  CaptchaStatus: {
    WAITING: 0,
    VERIFIED: 1,
    FAILED: 2,
  },
}));

// Mock MustChangePassword from api/authApi so tests can control its behavior
jest.mock('../api/authApi', () => ({
  MustChangePassword: jest.fn(),
}));

// Componente de teste para acessar o contexto
const TestComponent = () => {
  const auth = useAuth();
  return (
    <div>
      <div data-testid="auth-status">{auth.authStatus}</div>
      <div data-testid="email">{auth.email || 'no-email'}</div>
      <div data-testid="uri">{auth.uri || 'no-uri'}</div>
      <button
        data-testid="validate-username"
        onClick={() => auth.validateUsername('test-domain', 'test@email.com')}
      >
        Validate Username
      </button>
      <button
        data-testid="login"
        onClick={() => auth.login('test-uri', 'password123')}
      >
        Login
      </button>
      <button
        data-testid="logout"
        onClick={() => auth.logout()}
      >
        Logout
      </button>
    </div>
  );
};

const renderWithAuthProvider = () => {
  return render(
    <AuthProvider>
      <TestComponent />
    </AuthProvider>
  );
};

describe('AuthProvider', () => {

  describe('AuthProvider', () => {
    beforeEach(() => {
      jest.clearAllMocks();
        // Ensure global.localStorage has mock functions
        const originalLocalStorage = global.localStorage;
        Object.defineProperty(global, 'localStorage', {
          value: {
            getItem: jest.fn(),
            setItem: jest.fn(),
            clear: jest.fn(),
            removeItem: jest.fn(),
            key: jest.fn(),
            length: 0,
          },
          configurable: true,
        });
    });

    describe('Initial State', () => {
      it('should initialize with logged out state when no saved data', () => {
        renderWithAuthProvider();

        expect(screen.getByTestId('auth-status')).toHaveTextContent('VALIDATING_USERNAME');
        expect(screen.getByTestId('email')).toHaveTextContent('no-email');
        expect(screen.getByTestId('uri')).toHaveTextContent('no-uri');
      });

      it('should initialize with saved data from localStorage', async () => {
        const mockUser = { Id: 1, Username: 'test@email.com', Token: 'token123' };
        const mockEmail = 'test@email.com';
        const mockUri = 'test-uri';

        // Use the same key encoding as in AuthProvider
        const APP_ID = process.env.NEXT_PUBLIC_APP_GLOBAL ?? 'APP_ID';
        const systemContextKey = btoa(`${APP_ID}systemContext`);
        const loginUriKey = btoa(`${APP_ID}loginUri`);
        const loginEmailKey = btoa(`${APP_ID}loginEmail0`);

        const getItemMock = jest.fn((key: string) => {
          switch (key) {
            case systemContextKey:
              return JSON.stringify(mockUser);
            case loginUriKey:
              return JSON.stringify(mockUri);
            case loginEmailKey:
              return JSON.stringify(mockEmail);
            default:
              return null;
          }
        });
        const setItemMock = jest.fn();
        const clearMock = jest.fn();

        const originalLocalStorage = global.localStorage;
        Object.defineProperty(global, 'localStorage', {
          value: {
            getItem: getItemMock,
            setItem: setItemMock,
            clear: jest.fn(),
            removeItem: jest.fn(),
            key: jest.fn(),
            length: 0,
          },
          configurable: true,
        });

        renderWithAuthProvider();

        await waitFor(() => {
          expect(screen.getByTestId('auth-status')).toHaveTextContent('LOGGED_IN');
          expect(screen.getByTestId('email')).toHaveTextContent('test@email.com');
          expect(screen.getByTestId('uri')).toHaveTextContent('test-uri');
        });

        // Restore original localStorage after test
        Object.defineProperty(global, 'localStorage', {
          value: originalLocalStorage,
          configurable: true,
        });
      });
    });

    describe('validateUsername', () => {
      it('should validate username successfully', async () => {

        const mockValidateUsername = authService.authServiceAdapter.validateUsername as jest.Mock;
        mockValidateUsername.mockResolvedValue(true);

        renderWithAuthProvider();

        fireEvent.click(screen.getByTestId('validate-username'));

        await waitFor(() => {
          expect(mockValidateUsername).toHaveBeenCalledWith(
            'test@email.com',
            'test-domain',
            expect.any(Function)
          );
          expect(screen.getByTestId('auth-status')).toHaveTextContent('VALIDATING_PASSWORD');
          expect(screen.getByTestId('email')).toHaveTextContent('test@email.com');
        });
      });

      it('should handle username validation failure', async () => {
        const mockValidateUsername = authService.authServiceAdapter.validateUsername as jest.Mock;
        mockValidateUsername.mockResolvedValue(false);

        renderWithAuthProvider();

        fireEvent.click(screen.getByTestId('validate-username'));

        await waitFor(() => {
          expect(mockValidateUsername).toHaveBeenCalled();
          expect(screen.getByTestId('auth-status')).toHaveTextContent('VALIDATING_USERNAME');
        });
      });
    });

    describe('login', () => {
      it('should login successfully', async () => {
        const mockLogin = authService.authServiceAdapter.login as jest.Mock;
        const mockUser = { Id: 1, Username: 'test@email.com', Token: 'token123' };

        mockLogin.mockImplementation((credentials, uri, setUser) => {
          setUser(mockUser);
          return Promise.resolve(true);
        });

        renderWithAuthProvider();

        // Simulate username validation
        const mockValidateUsername = authService.authServiceAdapter.validateUsername as jest.Mock;
        mockValidateUsername.mockResolvedValue(true);

        fireEvent.click(screen.getByTestId('validate-username'));

        await waitFor(() => {
          expect(screen.getByTestId('auth-status')).toHaveTextContent('VALIDATING_PASSWORD');
        });

        fireEvent.click(screen.getByTestId('login'));

        await waitFor(() => {
          expect(mockLogin).toHaveBeenCalled();
          expect(screen.getByTestId('auth-status')).toHaveTextContent('LOGGED_IN');
        });
      });

      it('should handle login failure', async () => {
        const mockLogin = authService.authServiceAdapter.login as jest.Mock;
        mockLogin.mockResolvedValue(false);

        renderWithAuthProvider();

        fireEvent.click(screen.getByTestId('login'));

        await waitFor(() => {
          expect(screen.getByTestId('auth-status')).not.toHaveTextContent('LOGGED_IN');
        });
      });

      it('should set PASSWORD_RESET_REQUIRED if user.MustChangePasswordChecked is true', async () => {
          const mockLogin = authService.authServiceAdapter.login as jest.Mock;
          const mockUser = { Id: 1, Username: 'test@email.com', Token: 'token123', MustChangePasswordChecked: true };

          // Make MustChangePassword return true when called
          const api = require('../api/authApi');
          (api.MustChangePassword as jest.Mock).mockResolvedValue(true);

          mockLogin.mockImplementation((credentials, uri, setUser) => {
            setUser(mockUser);
            return Promise.resolve(true);
          });

          renderWithAuthProvider();

          const mockValidateUsername = authService.authServiceAdapter.validateUsername as jest.Mock;
          mockValidateUsername.mockResolvedValue(true);

          fireEvent.click(screen.getByTestId('validate-username'));

          await waitFor(() => {
            expect(screen.getByTestId('auth-status')).toHaveTextContent('VALIDATING_PASSWORD');
          });

          fireEvent.click(screen.getByTestId('login'));

          // wait for MustChangePassword promise chain to resolve and update state
          await waitFor(() => {
            expect(screen.getByTestId('auth-status')).toHaveTextContent('PASSWORD_RESET_REQUIRED');
          });
      });
    });

    describe('logout', () => {
      it('should logout and clear all data', async () => {
        const localStorageMock = global.localStorage as any;

        renderWithAuthProvider();

        fireEvent.click(screen.getByTestId('logout'));

        await waitFor(() => {
          expect(screen.getByTestId('auth-status')).toHaveTextContent('LOGGED_OUT');
          expect(screen.getByTestId('email')).toHaveTextContent('no-email');
          expect(screen.getByTestId('uri')).toHaveTextContent('no-uri');
          expect(localStorageMock.clear).toHaveBeenCalled();
        });
      });
    });

    describe('side effects and edge cases', () => {
      it('should update localStorage when user, email, or uri changes', async () => {
        const setItemMock = jest.fn();
        const removeItemMock = jest.fn();
        const originalLocalStorage = global.localStorage;
        Object.defineProperty(global, 'localStorage', {
          value: {
            getItem: jest.fn(),
            setItem: setItemMock,
            removeItem: removeItemMock,
            clear: jest.fn(),
            key: jest.fn(),
            length: 0,
          },
          configurable: true,
        });

        renderWithAuthProvider();

        // Validate username to set email and uri
        const mockValidateUsername = authService.authServiceAdapter.validateUsername as jest.Mock;
        mockValidateUsername.mockResolvedValue(true);

        fireEvent.click(screen.getByTestId('validate-username'));

        await waitFor(() => {
          expect(setItemMock).toHaveBeenCalled();
        });

        // Login to set user
        const mockLogin = authService.authServiceAdapter.login as jest.Mock;
        const mockUser = { Id: 1, Username: 'test@email.com', Token: 'token123' };
        mockLogin.mockImplementation((credentials, uri, setUser) => {
          setUser(mockUser);
          return Promise.resolve(true);
        });

        fireEvent.click(screen.getByTestId('login'));

        await waitFor(() => {
          expect(setItemMock).toHaveBeenCalled();
        });

        // Logout to remove items
        fireEvent.click(screen.getByTestId('logout'));

        await waitFor(() => {
          expect(removeItemMock).toHaveBeenCalled();
        });

        Object.defineProperty(global, 'localStorage', {
          value: originalLocalStorage,
          configurable: true,
        });
      });

      it('should not login if email is not set', async () => {
        const mockLogin = authService.authServiceAdapter.login as jest.Mock;
        mockLogin.mockResolvedValue(true);

        renderWithAuthProvider();

        fireEvent.click(screen.getByTestId('login'));

        await waitFor(() => {
          expect(mockLogin).not.toHaveBeenCalled();
          expect(screen.getByTestId('auth-status')).not.toHaveTextContent('LOGGED_IN');
        });
      });
    });
  });

  
});

it('should handle username validation failure', async () => {
  const mockValidateUsername = authService.authServiceAdapter.validateUsername as jest.Mock;
  mockValidateUsername.mockResolvedValue(false);

  renderWithAuthProvider();

  fireEvent.click(screen.getByTestId('validate-username'));

  await waitFor(() => {
    expect(mockValidateUsername).toHaveBeenCalled();
    expect(screen.getByTestId('auth-status')).toHaveTextContent('VALIDATING_USERNAME');
  });
});
  

describe('login', () => {
  it('should login successfully', async () => {
    const mockLogin = authService.authServiceAdapter.login as jest.Mock;
    const mockUser = { Id: 1, Username: 'test@email.com', Token: 'token123' };

    // Mock do login para simular sucesso
    mockLogin.mockImplementation((credentials, uri, setUser) => {
      setUser(mockUser);
      return Promise.resolve(true);
    });

    renderWithAuthProvider();

    // Simular que já passou pela validação de username
    const mockValidateUsername = authService.authServiceAdapter.validateUsername as jest.Mock;
    mockValidateUsername.mockResolvedValue(true);

    fireEvent.click(screen.getByTestId('validate-username'));

    await waitFor(() => {
      expect(screen.getByTestId('auth-status')).toHaveTextContent('VALIDATING_PASSWORD');
    });

    // Agora fazer login
    fireEvent.click(screen.getByTestId('login'));

    await waitFor(() => {
      expect(mockLogin).toHaveBeenCalled();
      expect(screen.getByTestId('auth-status')).toHaveTextContent('LOGGED_IN');
    });
  });

  it('should handle login failure', async () => {
    const mockLogin = authService.authServiceAdapter.login as jest.Mock;
    mockLogin.mockResolvedValue(false);

    renderWithAuthProvider();

    fireEvent.click(screen.getByTestId('login'));

    await waitFor(() => {
      expect(screen.getByTestId('auth-status')).not.toHaveTextContent('LOGGED_IN');
    });
  });
});

describe('logout', () => {
  it('should logout and clear all data', async () => {
    const localStorageMock = global.localStorage as jest.Mocked<Storage>;

    renderWithAuthProvider();

    fireEvent.click(screen.getByTestId('logout'));

    await waitFor(() => {
      expect(screen.getByTestId('auth-status')).toHaveTextContent('LOGGED_OUT');
      expect(screen.getByTestId('email')).toHaveTextContent('no-email');
      expect(screen.getByTestId('uri')).toHaveTextContent('no-uri');
      expect(localStorageMock.clear).toHaveBeenCalled();
    });
  });
});

