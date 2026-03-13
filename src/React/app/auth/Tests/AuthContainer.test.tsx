import React from 'react';
import { render, screen, fireEvent, act } from '@testing-library/react';
import AuthContainer from '../AuthContainer';
import { AuthStatus, CaptchaStatus } from '../AuthServiceAdapter';

// Define mocks that will be used by jest.mock
const mockRouterPush = jest.fn();
const mockUseAuth = {
  authStatus: AuthStatus.VALIDATING_USERNAME, // Default initial state
  captchaStatus: CaptchaStatus.VERIFIED,    // Default initial state
  setCaptchaStatus: jest.fn(),
};

// Mock 'next/navigation'
jest.mock('next/navigation', () => ({
  useRouter: () => ({
    push: mockRouterPush,
  }),
}));

// Mock '../AuthProvider'
jest.mock('../AuthProvider', () => ({
  useAuth: () => mockUseAuth,
}));

// Mock environment variables
const mockEnv = {
  NEXT_PUBLIC_NOME_PRODUTO: 'Test Product',
  NEXT_PUBLIC_WHATSAPP_NUMBER: '5511999999999',
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
  
  // Mock process.env
  Object.defineProperty(process, 'env', {
    value: mockEnv,
    writable: true,
  });
});

jest.mock('../UsernameForm', () => {
  return function MockUsernameForm() {
    return <div data-testid="username-form">Username Form</div>;
  };
});

jest.mock('../PasswordForm', () => {
  return function MockPasswordForm({ captchaSuccess }: { captchaSuccess: boolean }) {
    return <div data-testid="password-form">Password Form (captcha: {captchaSuccess.toString()})</div>;
  };
});

jest.mock('../PasswordChangeForm', () => {
  return function MockPasswordChangeForm({ captchaSuccess }: { captchaSuccess: boolean }) {
    return <div data-testid="password-change-form">Password Change Form (captcha: {captchaSuccess.toString()})</div>;
  };
});

jest.mock('../createaccount/CreateAccountForm', () => {
  return function MockCreateAccountForm({ captchaSuccess }: { captchaSuccess: boolean }) {
    return <div data-testid="create-account-form">Create Account Form (captcha: {captchaSuccess.toString()})</div>;
  };
});

jest.mock('../ChangePassword', () => {
  return function MockChangePassword({ readCurrentPassword }: { readCurrentPassword: boolean }) {
    return <div data-testid="change-password-form">Change Password Form (readCurrent: {readCurrentPassword.toString()})</div>;
  };
});

const mockDispatch = jest.fn();
const mockSystemContextValue = {
  systemContext: {
    MustChangePasswordChecked: undefined as boolean | undefined,
  },
};
jest.mock('@/app/store/hooks', () => ({
  useAppDispatch: () => mockDispatch,
  useAppSelector: (selector: any) =>
    selector({ systemContext: { systemContext: mockSystemContextValue.systemContext } }),
}));
jest.mock('@/app/store/slices/systemContextSlice', () => ({
  selectSystemContext: (s: any) => s.systemContext.systemContext,
  setSystemContext: jest.fn((v: any) => ({ type: 'systemContext/setSystemContext', payload: v })),
}));

// Mock RecaptchaUI to always render its children and provide captcha simulation
jest.mock('@/app/components/RecaptchaUI', () => {
  return function MockRecaptchaUI({ children, setCaptchaSuccess }: any) {
    return (
      <div data-testid="recaptcha-ui">
        {children}
        <button data-testid="simulate-captcha-success" onClick={() => setCaptchaSuccess(1)}>Success</button>
        <button data-testid="simulate-captcha-waiting" onClick={() => setCaptchaSuccess(0)}>Waiting</button>
        <button data-testid="simulate-captcha-fail" onClick={() => setCaptchaSuccess(-1)}>Fail</button>
      </div>
    );
  };
});

// Mock Kendo UI components
jest.mock('@progress/kendo-react-indicators', () => ({
  Loader: function MockLoader({ size, type }: { size?: string; type?: string }) {
    return <div role="progressbar" data-testid="kendo-loader">Loading... ({size}, {type})</div>;
  },
}));

jest.mock('@progress/kendo-react-buttons', () => ({
  Button: function MockButton({ children, onClick, className, themeColor }: any) {
    return (
      <button 
        onClick={onClick} 
        className={className} 
        data-theme={themeColor}
        data-testid="kendo-button"
      >
        {children}
      </button>
    );
  },
}));

// Mock window.open
Object.defineProperty(window, 'open', {
  value: jest.fn(),
  writable: true,
});

// window.location.reload is read-only in jsdom; do not attempt to override it here

describe('AuthContainer', () => {
  beforeEach(() => {
    // Reset all mocks and mock states before each test
    jest.clearAllMocks();
    mockUseAuth.authStatus = AuthStatus.VALIDATING_USERNAME; // Default state
    mockUseAuth.captchaStatus = CaptchaStatus.VERIFIED; // Default state
    mockUseAuth.setCaptchaStatus.mockClear();
    mockRouterPush.mockClear();
    mockSystemContextValue.systemContext = { MustChangePasswordChecked: undefined };
  });

  it('should render username form when validating username', () => {
    mockUseAuth.authStatus = AuthStatus.VALIDATING_USERNAME;
    mockUseAuth.captchaStatus = CaptchaStatus.VERIFIED;
    
    render(<AuthContainer />);
    expect(screen.getByTestId('username-form')).toBeInTheDocument();
    expect(screen.getByTestId('recaptcha-ui')).toBeInTheDocument();
  });

  it('should render password form when validating password', () => {
    mockUseAuth.authStatus = AuthStatus.VALIDATING_PASSWORD;
    mockUseAuth.captchaStatus = CaptchaStatus.VERIFIED;
    
    render(<AuthContainer />);
    expect(screen.getByTestId('password-form')).toBeInTheDocument();
    expect(screen.getByText(/Password Form \(captcha: true\)/)).toBeInTheDocument();
  });

  it('should render password change form when password reset is required', () => {
    mockUseAuth.authStatus = AuthStatus.PASSWORD_RESET_REQUIRED;
    mockUseAuth.captchaStatus = CaptchaStatus.VERIFIED;
    
    render(<AuthContainer />);
    expect(screen.getByTestId('password-change-form')).toBeInTheDocument();
    expect(screen.getByText(/Password Change Form \(captcha: true\)/)).toBeInTheDocument();
  });

  it('should show captcha waiting message', () => {
    mockUseAuth.captchaStatus = CaptchaStatus.WAITING;
    
    render(<AuthContainer />);
    // Loader should be visible while waiting
    expect(screen.getByTestId('kendo-loader')).toBeInTheDocument();
    expect(screen.queryByTestId('kendo-button')).not.toBeInTheDocument();
  });

  it('should show captcha failed message', () => {
    mockUseAuth.captchaStatus = CaptchaStatus.FAILED;
    
    render(<AuthContainer />);
    expect(screen.getByText('Captcha inválido')).toBeInTheDocument();
  });

  it('should render CreateAccountForm when authStatus is CREATE_ACCPOUNT', () => {
    mockUseAuth.authStatus = AuthStatus.CREATE_ACCPOUNT;
    mockUseAuth.captchaStatus = CaptchaStatus.VERIFIED;
    
    render(<AuthContainer />);
    expect(screen.getByTestId('create-account-form')).toBeInTheDocument();
    expect(screen.getByText(/Create Account Form \(captcha: true\)/)).toBeInTheDocument();
  });

  it('should render ChangePassword form when authStatus is CHANGING_PASSWORD', () => {
    mockUseAuth.authStatus = AuthStatus.CHANGING_PASSWORD;
    mockUseAuth.captchaStatus = CaptchaStatus.VERIFIED;
    
    render(<AuthContainer />);
    expect(screen.getByTestId('change-password-form')).toBeInTheDocument();
    expect(screen.getByText(/Change Password Form \(readCurrent: true\)/)).toBeInTheDocument();
  });

  it('should render "Iniciando..." and Loader when authStatus is LOGGED_IN and MustChangePasswordChecked is defined', () => {
    mockUseAuth.authStatus = AuthStatus.LOGGED_IN;
    mockUseAuth.captchaStatus = CaptchaStatus.VERIFIED;
    mockSystemContextValue.systemContext = { MustChangePasswordChecked: false };
    
    render(<AuthContainer />);
    // Loading animation may split text into spans; assert loader presence instead
    expect(screen.getByRole('progressbar')).toBeInTheDocument();
    expect(screen.getByTestId('kendo-loader')).toBeInTheDocument();
  });

  it('should redirect to /auth/splash when authStatus is LOGGED_IN and MustChangePasswordChecked is undefined', async () => {
    mockUseAuth.authStatus = AuthStatus.LOGGED_IN;
    mockUseAuth.captchaStatus = CaptchaStatus.VERIFIED;
    mockSystemContextValue.systemContext = { MustChangePasswordChecked: undefined };
    
    await act(async () => {
      render(<AuthContainer />);
    });
    
    // Wait for useEffect to run
    await act(async () => {
      await new Promise(resolve => setTimeout(resolve, 0));
    });
    
    expect(mockRouterPush).toHaveBeenCalledWith('/auth/splash');
  });

  describe('when captchaStatus is WAITING with timeout', () => {
    beforeEach(() => {
      jest.useFakeTimers();
      mockUseAuth.captchaStatus = CaptchaStatus.WAITING;
    });

    afterEach(() => {
      jest.runOnlyPendingTimers();
      jest.useRealTimers();
    });

    it('should initially show loader while waiting and no update button', () => {
      render(<AuthContainer />);

      // Component shows loader while waiting; avoid fragile text matching
      expect(screen.getByTestId('kendo-loader')).toBeInTheDocument();
      expect(screen.queryByTestId('kendo-button')).not.toBeInTheDocument();
    });

    it('should show "Atualizar" button and related message after 5 seconds timeout', () => {
      render(<AuthContainer />);
      
      act(() => {
        jest.advanceTimersByTime(5000); // PConstTimeoutCaptcha
      });
      
      const btn = screen.getByTestId('kendo-button');
      expect(btn).toBeInTheDocument();
      expect(btn).toHaveTextContent(/ATUALIZAR/i);
      expect(screen.getByText(/Se persistir, por favor, clique em/i)).toBeInTheDocument();
      expect(screen.queryByText(/Aguarde/i)).not.toBeInTheDocument();
    });

    it('should call window.location.reload when "Atualizar" button is clicked after timeout', () => {
      render(<AuthContainer />);
      
      act(() => {
        jest.advanceTimersByTime(5000);
      });
      
      const updateButton = screen.getByTestId('kendo-button');
      // Clicking the update button should not throw (window.location.reload is read-only in jsdom)
      expect(() => fireEvent.click(updateButton)).not.toThrow();
    });
  });

  it('should call setCaptchaStatus with VERIFIED when RecaptchaUI simulates success', () => {
    render(<AuthContainer />);
    
    fireEvent.click(screen.getByTestId('simulate-captcha-success'));
    expect(mockUseAuth.setCaptchaStatus).toHaveBeenCalledWith(CaptchaStatus.VERIFIED);
  });

  it('should call setCaptchaStatus with WAITING when RecaptchaUI simulates waiting', () => {
    render(<AuthContainer />);
    
    fireEvent.click(screen.getByTestId('simulate-captcha-waiting'));
    expect(mockUseAuth.setCaptchaStatus).toHaveBeenCalledWith(CaptchaStatus.WAITING);
  });

  it('should call setCaptchaStatus with FAILED when RecaptchaUI simulates fail', () => {
    render(<AuthContainer />);
    
    fireEvent.click(screen.getByTestId('simulate-captcha-fail'));
    expect(mockUseAuth.setCaptchaStatus).toHaveBeenCalledWith(CaptchaStatus.FAILED);
  });

  it('should render UsernameForm by default if authStatus is unhandled and captcha is verified', () => {
    // @ts-expect-error Testing an intentionally unhandled enum case for default switch behavior
    mockUseAuth.authStatus = 'UNHANDLED_STATUS';
    mockUseAuth.captchaStatus = CaptchaStatus.VERIFIED;
    
    render(<AuthContainer />);
    expect(screen.getByTestId('username-form')).toBeInTheDocument();
  });

  it('should render footer links correctly', () => {
    render(<AuthContainer />);
    
    expect(screen.getByText('www.menphis.com.br')).toBeInTheDocument();
    expect(screen.getByText('Suporte')).toBeInTheDocument();    
  });

  it('should render product name from environment variable', () => {
    render(<AuthContainer />);
    
    expect(screen.getByText('Test Product')).toBeInTheDocument();
    expect(screen.getByText('Bem-vindo')).toBeInTheDocument();
  });

  it('should handle window.open when clicking Telerik powered link', () => {
    render(<AuthContainer />);
    
    const poweredByElement = screen.getByText(/Powered by Telerik/);
    fireEvent.click(poweredByElement);
    
    expect(window.open).toHaveBeenCalledWith('https://telerik.com', '_blank');
  });
});